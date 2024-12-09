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
    public partial class Add_Acc : Form
    {
        public Add_Acc()
        {
            InitializeComponent();
        }
        public SqlConnection con;
        public SqlDataReader DR;
        public SqlCommand cmd;
        int EID;
        string Fname;
        string Lname;
        string  NIC;
        string Email;
        int    Moblie;
        string address;
        string UN;
        string PW;
        string gender;
        string DOB;
        int newUserID;

        public void Data()
        {
            SqlCommand cmd = new SqlCommand("SELECT Employee.emp_id , Employee.emp_fname ,Employee.emp_lname,Employee.NIC_ID,Employee.E_mail,Employee.DOB, Employee.mobile_number, Employee.gender,Employee.EAddress,jobTitle.jobname,Users. username,Users.passwords,Department.department_name,Department.location_name FROM Employee INNER JOIN jobTitle  ON  Employee.jobId = jobTitle.jobId INNER JOIN Users ON Employee.userID = Users.userID INNER JOIN Department ON Employee.department_ID = Department.department_id  WHERE jobTitle.jobname ='Accountant' ;", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        public void varible()
        {
            EID = Convert.ToInt32(textBox1.Text);
            Fname = textBox2.Text;
            Lname = textBox3.Text;
            Moblie = Convert.ToInt32(textBox4.Text);
            NIC = textBox7.Text;
            Email = textBox10.Text;
            gender = comboBox1.Text;
            address = textBox6.Text;
            DOB = dateTimePicker1.Text; 
            UN = textBox5.Text;
            PW = textBox9.Text;
        }
        public void add() 
        {
            cmd.Parameters.AddWithValue("EID", EID);
            cmd.Parameters.AddWithValue("Fname", Fname);
            cmd.Parameters.AddWithValue("Lname", Lname);
            cmd.Parameters.AddWithValue("Moblie", Moblie);
            cmd.Parameters.AddWithValue("NIC", NIC);
            cmd.Parameters.AddWithValue("Email", Email);
            cmd.Parameters.AddWithValue("gender", gender);
            cmd.Parameters.AddWithValue("address", address);
            cmd.Parameters.AddWithValue("DOB", DOB);
            cmd.Parameters.AddWithValue("UN", UN);
            cmd.Parameters.AddWithValue("PW", PW);
            cmd.Parameters.AddWithValue("usi", newUserID);
;
        }

        private void Add_Acc_Load(object sender, EventArgs e)
        {
            //hide form close button
            this.ControlBox = false;
            con = DatabaseConnection.Instance.GetConnection();
            con.Open();
            Data();
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Data();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {    
            //Back Button Functioning       
            this.Hide();
            CEO_Dashbord cd = new CEO_Dashbord();
            cd.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            varible();
            con.Open();
            cmd = new SqlCommand("SELECT MAX(userID)FROM Users;", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            int userID = Convert.ToInt32(dt.Rows[0][0]);
            newUserID = ++userID;

            cmd = new SqlCommand("INSERT INTO Users(userID,username,passwords,jobId) VALUES (@usi,@UN,@PW,1);", con);
            add();
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("INSERT INTO Employee(emp_id, emp_fname,emp_lname,NIC_ID, E_mail,DOB,mobile_number, gender,userID,department_ID,jobID,EAddress)VALUES (@EID,@Fname,@Lname,@NIC,@Email,@DOB,@Moblie,@gender,@usi,1,2,@address);", con);
            add();
            
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Updated -  Done!!!");
            Data();
            con.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
