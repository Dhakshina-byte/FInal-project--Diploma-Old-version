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
    public partial class Add_Service_Head : Form
    {
        public Add_Service_Head()
        {
            InitializeComponent();
        }

        private void Add_Service_Head_Load(object sender, EventArgs e)
        {
            //hide form close button
            this.ControlBox = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Back Button Functioning       
            this.Hide();
            CEO_Dashbord cd = new CEO_Dashbord();
            cd.ShowDialog();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
