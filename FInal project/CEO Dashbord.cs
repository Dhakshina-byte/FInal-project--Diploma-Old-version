using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FInal_project
{
    public partial class CEO_Dashbord : Form
    {
        public CEO_Dashbord()
        {
            InitializeComponent();
            UpdateDateTimeLabels();
        }

        private void UpdateDateTimeLabels()
        {//display date & time
            label9.Text = DateTime.Now.ToShortDateString();
            label10.Text = DateTime.Now.ToLongTimeString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
        //click accountant details button and go to accountant details form
        this.Hide();
         Add_Acc add_Acc = new Add_Acc();
         add_Acc.ShowDialog();

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //LogOut 
            this.Hide();
            Login loginForm = new Login();
            loginForm.Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CEO_Dashbord_Load(object sender, EventArgs e)
        { //hide form close button
            this.ControlBox = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //click sales director details button and go to sales director details form
            this.Hide();
            Add_sales_director add_sd = new Add_sales_director();
            add_sd.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //click service head details button and go to service head details form
            this.Hide();
            Add_Service_Head add_sh = new Add_Service_Head();
            add_sh.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //click inventory manager details button and go to inventory manager details form
            this.Hide();
            Add_Inventory_Manager add_im = new Add_Inventory_Manager();
            add_im.ShowDialog();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
