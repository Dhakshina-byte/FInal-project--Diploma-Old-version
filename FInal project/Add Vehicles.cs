using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FInal_project
{
    public partial class Add_Vehicles : Form
    {

        private SqlConnection con;
        private int id;
        private String vehicle_name, vehicle_no, type, model;

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                id = Convert.ToInt32(tbId.Text); // Assuming the ID is required for updating the record
                vehicle_name = tbName.Text;
                vehicle_no = tbNo.Text;
                type = tbType.Text;
                model = tbModel.Text;


                con = DatabaseConnection.Instance.GetConnection();
                con.Open();

                string query = "UPDATE vehicles SET Name = @vehicle_name, No = @vehicle_no, Type = @type, Model = @model WHERE VehicleID = @Id";

                SqlCommand cmd = new SqlCommand(query, con);

                // Use parameters to avoid SQL injection
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@vehicle_name", vehicle_name);
                cmd.Parameters.AddWithValue("@vehicle_no", vehicle_no);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@model", model);


                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Data updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to update data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
                clearTextBoxes();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                id = Convert.ToInt32(tbId.Text); // Only the ID is required for deletion

                con = DatabaseConnection.Instance.GetConnection();
                con.Open();

                string query = "DELETE FROM vehicles WHERE VehicleID = @ID";

                SqlCommand cmd = new SqlCommand(query, con);

                // Use parameters to avoid SQL injection
                cmd.Parameters.AddWithValue("@ID", id);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Data deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to delete data. Please check if the ID exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
                clearTextBoxes();
            }
        }

        private void clearTextBoxes()
        {
            tbId.Clear();
            tbName.Clear();
            tbNo.Clear();
            tbModel.Clear();
            tbType.Clear();
            
        }

        public Add_Vehicles()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(tbId.Text);
            vehicle_name = tbName.Text;
            vehicle_no = tbNo.Text;
            type = tbType.Text;
            model = tbModel.Text;

            con = DatabaseConnection.Instance.GetConnection();
            con.Open();
            string query = "INSERT INTO vehicles (Name, No, Model, Type) VALUES ('" + vehicle_name + "', '" + vehicle_no + "', '" + model + "', '" + type + "')";

            SqlCommand cmd = new SqlCommand(query, con);

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Data added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to add data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            con.Close();
            clearTextBoxes();

        }

    }
}
