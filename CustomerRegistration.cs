using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Ticket_Management_System
{
    public partial class CustomerRegistration : Form
    {
        // SqlConnection con = AdminLogin.connectionstring;
        SqlConnection con = Splasher.connectionstring;

        public CustomerRegistration()
        {
            InitializeComponent();
            combobox1.Items.Add("Male");
            combobox1.Items.Add("Female");
            combobox1.Items.Add("Other");
            

        }
        private bool IsValid()   //ENCAPSULATION

        {

            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Customer values (@Firstname,@Lastname,@Middlename,@Gender,@Age,@phone,@Username,@Password)", con);
                cmd.CommandType = CommandType.Text;
                

                cmd.Parameters.AddWithValue("@Firstname", textBox2.Text);
                cmd.Parameters.AddWithValue("@Lastname", textBox1.Text);
                cmd.Parameters.AddWithValue("@Age", textBox4.Text);
                cmd.Parameters.AddWithValue("@Username", textBox3.Text);
                cmd.Parameters.AddWithValue("@Password", textBox5.Text);
                cmd.Parameters.AddWithValue("@Middlename", textBox8.Text);
                cmd.Parameters.AddWithValue("@phone", textBox7.Text);
                cmd.Parameters.AddWithValue("@Gender", combobox1.SelectedItem);       





                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Registered", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnexitform2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CustomerRegistration_Load(object sender, EventArgs e)
        {

        }
    }
}
