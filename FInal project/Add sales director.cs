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
    public partial class Add_sales_director : Form
    {
        public Add_sales_director()
        {
            InitializeComponent();
        }
        public SqlConnection con;
        public SqlDataReader DR;
        public SqlCommand cmd;
        int EID;
        string Fname;
        string Lname;
        string NIC;
        string Email;
        int Moblie;
        string address;
        string UN;
        string PW;
        string gender;
        string DOB;
        int newUserID;

        public void Data()
        {
            SqlCommand cmd = new SqlCommand("SELECT Employee.emp_id , Employee.emp_fname ,Employee.emp_lname,Employee.NIC_ID,Employee.E_mail,Employee.DOB, Employee.mobile_number, Employee.gender,Employee.EAddress,jobTitle.jobname,Users. username,Users.passwords,Department.department_name,Department.location_name FROM Employee INNER JOIN jobTitle  ON  Employee.jobId = jobTitle.jobId INNER JOIN Users ON Employee.userID = Users.userID INNER JOIN Department ON Employee.department_ID = Department.department_id  WHERE jobTitle.jobname ='Sales Director' ;", con);
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
        public void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox7.Text = "";
            textBox10.Text = "";
            comboBox1.Text = "";
            textBox6.Text = "";
            dateTimePicker1.Text = "";
            textBox5.Text = "";
            textBox9.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Back Button Functioning       
            this.Hide();
            CEO_Dashbord cd = new CEO_Dashbord();
            cd.ShowDialog();
        }

        private void Add_sales_director_Load(object sender, EventArgs e)
        {
            //hide form close button
            this.ControlBox = false;
            con = new SqlConnection();
            con.ConnectionString = "Data Source =OM3GA;Initial Catalog= CarSales&ServiceMangementSystem;Integrated Security =True";
            Data();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox8.Text == "")
            {
                Data();
            }
            else
            {
                SqlCommand cmd = new SqlCommand("SELECT Employee.emp_id , Employee.emp_fname ,Employee.emp_lname,Employee.NIC_ID,Employee.E_mail,Employee.DOB, Employee.mobile_number, Employee.gender,Employee.EAddress,jobTitle.jobname,Users. username,Users.passwords,Department.department_name,Department.location_name FROM Employee INNER JOIN jobTitle  ON  Employee.jobId = jobTitle.jobId INNER JOIN Users ON Employee.userID = Users.userID INNER JOIN Department ON Employee.department_ID = Department.department_id  WHERE jobTitle.jobname ='Sales Director'AND Employee.emp_id = @EID", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                EID = Convert.ToInt32(textBox8.Text);
                cmd.Parameters.AddWithValue("EID", EID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();

                while (dr.Read())
                {
                    textBox1.Text = dr["emp_id"].ToString();
                    textBox2.Text = dr["emp_fname"].ToString();
                    textBox3.Text = dr["emp_lname"].ToString();
                    textBox4.Text = dr["mobile_number"].ToString();
                    textBox7.Text = dr["NIC_ID"].ToString();
                    textBox10.Text = dr["E_mail"].ToString();
                    comboBox1.Text = dr["gender"].ToString();
                    textBox6.Text = dr["EAddress"].ToString();
                    dateTimePicker1.Text = dr["DOB"].ToString();
                    textBox5.Text = dr["username"].ToString();
                    textBox9.Text = dr["passwords"].ToString();
                }
                con.Close();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Open();
            }
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
            cmd = new SqlCommand("INSERT INTO Employee(emp_id, emp_fname,emp_lname,NIC_ID, E_mail,DOB,mobile_number, gender,userID,department_ID,jobID,EAddress)VALUES (@EID,@Fname,@Lname,@NIC,@Email,@DOB,@Moblie,@gender,@usi,2,4,@address);", con);
            add();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Updated -  Done!!!");
            Data();
            clear();
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Close();

            varible();
            con.Open();
            cmd = new SqlCommand("SELECT userID FROM Employee WHERE Employee.emp_id = @EID;", con);
            add();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            int userID = Convert.ToInt32(dt.Rows[0][0]);
            newUserID = userID;
            cmd = new SqlCommand("Update Users set username=@UN,passwords=@PW,jobId =4 where userID = @usi", con);
            add();
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("Update Employee set emp_fname=@Fname,emp_lname=@Lname,NIC_ID=@NIC,E_mail=@Email,DOB=@DOB,mobile_number=@Moblie,gender=@gender,userID=@usi,jobId =4,department_ID=2,EAddress=@address where emp_id = @EID;", con);
            add();
            cmd.ExecuteNonQuery();
            Data();
            clear();
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            EID = Convert.ToInt32(textBox8.Text);
            cmd = new SqlCommand("SELECT userID FROM Employee WHERE Employee.emp_id = @EID;", con);
            cmd.Parameters.AddWithValue("@EID", EID); // Ensure parameter is added
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            int userID = Convert.ToInt32(dt.Rows[0][0]);
            newUserID = userID;

            cmd = new SqlCommand("DELETE FROM Employee WHERE Employee.emp_id = @EID;", con);
            cmd.Parameters.AddWithValue("@EID", EID);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Open();
            cmd = new SqlCommand("DELETE FROM Users WHERE userID = @usi", con);
            cmd.Parameters.AddWithValue("@usi", userID); // Ensure parameter is added
            cmd.ExecuteNonQuery();
            Data();
            MessageBox.Show("Record Deleted - Done!!!");
            clear();
            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void tbAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbDOB_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbMobile_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbSales_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnAddNewSales_Click(object sender, EventArgs e)
        {

        }

        private void btnView_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void tbCity_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
