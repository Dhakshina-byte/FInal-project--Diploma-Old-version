using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace FInal_project
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //click  inventory report button and go to inventory report form
            this.Hide();
            Inventory_report add_im = new Inventory_report();
            add_im.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //click net profit button and go to net profit form
            this.Hide();
            Net_profit add_im = new Net_profit();
            add_im.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //click sales report button and go to annual sales report form
            this.Hide();
            Anual_sales_report add_im = new Anual_sales_report();
            add_im.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //click service report button and go to annual service report form
            this.Hide();
            Anual_service_report add_im = new Anual_service_report();
            add_im.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //click sales report button and go to monthly sales report form
            this.Hide();
            Monthly_Sales_Report add_im = new Monthly_Sales_Report();
            add_im.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //click service report button and go to monthly service report form
            this.Hide();
            Monthly_service_report add_im = new Monthly_service_report();
            add_im.ShowDialog();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            CEO_Dashbord ceo = new CEO_Dashbord();
        }
    }
}
