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
    public partial class Add_Service_Head : Form
    {
        private SqlConnection con;
        private int id;
        private String name, city, email, address, mobile;
        private DateTime dob;

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                id = Convert.ToInt32(tbServiceId.Text); // Assuming the ID is required for updating the record
                name = tbName.Text;
                city = tbCity.Text;
                email = tbEmail.Text;
                address = tbAddress.Text;
                mobile = tbMobile.Text;
                dob = DateTime.Parse(tbDob.Text);

                con = DatabaseConnection.Instance.GetConnection();
                con.Open();

                string query = "UPDATE vehicleOwners SET Name = @Name, Email = @Email, Mobile = @Mobile, DateOfBirth = @DateOfBirth, City = @City, Address = @Address WHERE VehicleOwnerID = @ID";

                SqlCommand cmd = new SqlCommand(query, con);

                // Use parameters to avoid SQL injection
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Mobile", mobile);
                cmd.Parameters.AddWithValue("@DateOfBirth", dob);
                cmd.Parameters.AddWithValue("@City", city);
                cmd.Parameters.AddWithValue("@Address", address);

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
                id = Convert.ToInt32(tbServiceId.Text); // Only the ID is required for deletion

                con = DatabaseConnection.Instance.GetConnection();
                con.Open();

                string query = "DELETE FROM vehicleOwners WHERE VehicleOwnerID = @ID";

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

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void clearTextBoxes()
        {
            tbServiceId.Clear();
            tbName.Clear();
            tbEmail.Clear();
            tbCity.Clear();
            tbDob.Clear();
            tbAddress.Clear();
            tbMobile.Clear();
        }


        public Add_Service_Head()
        {
            InitializeComponent();
        }

        private void Add_Service_Head_Load(object sender, EventArgs e)
        {
            //hide form close button
            this.ControlBox = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(tbServiceId.Text);
            name = tbName.Text;
            city = tbCity.Text;
            email = tbEmail.Text;
            address = tbAddress.Text;
            mobile = tbMobile.Text;
            dob = DateTime.Parse(tbDob.Text);

            con = DatabaseConnection.Instance.GetConnection();
            con.Open();
            string query = "INSERT INTO vehicleOwners (Name, Email, Mobile, DateOfBirth, City, Address) VALUES ('" + name + "', '" + email + "', '" + mobile + "', '" + dob + "', '" + city + "', '" + address + "')";

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

        //private void textBox5_TextChanged(object sender, EventArgs e)
        //{

        //}
    }
}
