using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace FInal_project
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        public SqlConnection con;
        public SqlCommand cmd;
        public SqlDataReader dr;
        public string UN;
        public string PW;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con = new SqlConnection();
            con.ConnectionString = "Data Source =OM3GA;Initial Catalog= CarSales&ServiceMangementSystem;Integrated Security =True";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Clear all textboxes in the form
            textBox1.Clear();
            textBox2.Clear();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("SELECT userID, username,passwords,jobTitle.jobname FROM Users INNER JOIN jobTitle ON Users.userID = jobTitle.jobId where username=@username and passwords=@password;", con);
            cmd.Parameters.AddWithValue("@username", textBox1.Text);
            cmd.Parameters.AddWithValue("@password", textBox2.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                string usertype = dt.Rows[0][3].ToString();

                if (usertype == "CEO")
                {
                    this.Hide();
                    CEO_Dashbord cd = new CEO_Dashbord();
                    cd.Show();
                }
                else if (usertype == "non")
                {
                    MessageBox.Show("wel non");
                }
                else
                {
                    MessageBox.Show("not found");
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }

            con.Close();
        }
    }
}
