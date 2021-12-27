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
    public partial class AdminLogin : Form
    {

        public static SqlConnection connectionstring;
        SqlConnection con = Splasher.connectionstring;
        public AdminLogin()
        {
            InitializeComponent();
            connectionstring = con;
        }
        public static string Username;
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnexitform2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                string username = textBox2.Text;


                con.Open();
                SqlCommand check_User_Name = new SqlCommand("SELECT COUNT(*) FROM [Admin] WHERE ([Username] = @user)", con);
                check_User_Name.Parameters.AddWithValue("@user", textBox2.Text);
                int UserExist = (int)check_User_Name.ExecuteScalar();

                check_User_Name.ExecuteNonQuery();


                con.Close();
                con.Open();
                SqlCommand check_User_Pass = new SqlCommand("SELECT COUNT(*) FROM [Admin] WHERE ([Password] = @pass)", con);
                check_User_Pass.Parameters.AddWithValue("@pass", textBox1.Text);
                int PassExist = (int)check_User_Pass.ExecuteScalar();

                check_User_Pass.ExecuteNonQuery();
                con.Close();

            if (UserExist == 1 && PassExist == 1)
            {

                this.Hide();
                AdminHome A = new AdminHome();
                A.ShowDialog();
                this.Close();

            }


            else
            {
                MessageBox.Show("Wrong admin credentials entered . Try Again!");
                con.Close();
            }
            
        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {
            Username = textBox2.Text;
        }
    }
}
