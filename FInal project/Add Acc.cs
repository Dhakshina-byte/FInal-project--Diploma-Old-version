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
            EID = Convert.ToInt32(tbId.Text);
            Fname = tbFirstName.Text;
            Lname = tbLastName.Text;
            Moblie = Convert.ToInt32(tbMobile.Text);
            NIC = tbNic.Text;
            Email = tbEmail.Text;
            gender = cbGender.Text;
            address = tbAddress.Text;
            DOB = dateTimePicker1.Text; 
            UN = tbUsername.Text;
            PW = tbPassword.Text;
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

           cmd = new SqlCommand("INSERT INTO Users(userID,username,passwords,jobId) VALUES (1,'Hemantha','Hemantha12',1);",con);
            cmd = new SqlCommand("INSERT INTO Employee(emp_id, emp_fname,emp_lname,NIC_ID, E_mail,DOB,mobile_number, gender,userID,department_ID, jobID,EAddress)VALUES (@EID,@Fname,@Lname,@NIC,@Email,@DOB,@Moblie,@gender,@address,1,2,2);", con);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
