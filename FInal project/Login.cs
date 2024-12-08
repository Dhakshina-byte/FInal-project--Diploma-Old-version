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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Clear all textboxes in the form
            textBox1.Clear();
            textBox2.Clear();

            // Show message box if login is successful
            MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //connection
            string cs = "Data Source=THINKBOOK;Initial Catalog=Ford;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            string query = "select * from Login where username = '" + textBox1.Text + "' and password = '" + textBox2.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CEO_Dashbord cd = new CEO_Dashbord();
                cd.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login failed!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
