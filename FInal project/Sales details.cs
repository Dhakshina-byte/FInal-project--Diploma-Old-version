using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FInal_project
{
    public partial class Sales_details : Form
    {


        public Sales_details()
        {
            InitializeComponent();
        }

        private void Sales_details_Load(object sender, EventArgs e)
        {
            this.Hide();
            CEO_Dashbord ceo = new CEO_Dashbord();
            Data();


            // Define connection string
            string connectionString = "Data Source =OM3GA;Initial Catalog= CarSales&ServiceMangementSystem;Integrated Security =True";

            // Define SQL query 
            string query = "SELECT VehicleID, VehicleModel, VehicleType, Price FROM Sales";

            // Create an instance of the typed DataSet
            SalesData ds = new SalesData();


            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    // Fill the DataTable in the DataSet
                    adapter.Fill(ds, "Sales");


                }

                ReportDocument reportDoc = new ReportDocument();
                reportDoc.Load("C:\\Users\\dhaks\\OneDrive\\Desktop\\FInal project\\FInal project\\SalesReport.rpt");
                reportDoc.SetDataSource(ds);

                // Assign to CrystalReportViewer
                crystalReportViewer1.ReportSource = reportDoc;
                crystalReportViewer1.Refresh();

                // Display data for testing
                foreach (DataRow row in ds.Sales.Rows)
                {
                    Console.WriteLine($"{row["VehicleID"]}, {row["VehicleType"]}, " +
                                       $"{row["VehicleModel"]}, {row["Price"]}");
                }
            }
            catch (ConstraintException ex)
            {
                Console.WriteLine("Constraint Error: " + ex.Message);

                // Display row errors if needed
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow row in table.GetErrors())
                    {
                        Console.WriteLine($"Row Error: {row.RowError}");
                    }
                }
            }
        }

        public void Data()
        {
            SqlConnection con = new SqlConnection("Data Source =OM3GA;Initial Catalog= CarSales&ServiceMangementSystem;Integrated Security =True");
            SqlCommand cmd = new SqlCommand("SELECT VehicleID, VehicleModel, VehicleType, Price FROM Sales ;", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            carTable.DataSource = dt;

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            // Get the selected row from the DataGridView
            if (carTable.SelectedRows.Count > 0)
            {
                // Get the selected car data
                DataRow selectedRow = ((DataRowView)carTable.SelectedRows[0].DataBoundItem).Row;
                int vehicleID = Convert.ToInt32(selectedRow["VehicleID"]);
                string vehicleModel = Convert.ToString(selectedRow["VehicleModel"]);
                string vehicleType = Convert.ToString(selectedRow["VehicleType"]);
                decimal price = Convert.ToDecimal(selectedRow["Price"]);

                // Create a DataSet to pass to the report
                DataSet invoiceData = new DataSet();
                DataTable invoiceTable = invoiceData.Tables.Add("Sales");

                // Add the data for the selected car
                invoiceTable.Columns.Add("VehicleID", typeof(int));
                invoiceTable.Columns.Add("VehicleModel", typeof(string));
                invoiceTable.Columns.Add("VehicleType", typeof(string));
                invoiceTable.Columns.Add("Price", typeof(decimal));

                invoiceTable.Rows.Add(vehicleID, vehicleModel, vehicleType, price);

                // Load the Crystal Report (assuming "InvoiceReport.rpt" is your invoice report)
                ReportDocument reportDoc = new ReportDocument();
                reportDoc.Load("C:\\Users\\dhaks\\OneDrive\\Desktop\\FInal project\\FInal project\\SalesInvoice.rpt");

                // Set the DataSource for the report
                reportDoc.SetDataSource(invoiceData);

                // Display the report in the CrystalReportViewer (assuming crystalReportViewer is your viewer)
                crystalReportViewer1.ReportSource = reportDoc;
                crystalReportViewer1.Refresh();
            }
            else
            {
                MessageBox.Show("Please select a car to view the invoice.");
            }
        }
    }
}
