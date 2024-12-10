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
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            CEO_Dashbord cEO_Dashbord = new CEO_Dashbord(); 
            cEO_Dashbord.Show();
        }
    }
}
