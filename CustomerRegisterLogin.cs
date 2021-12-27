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
    public partial class CustomerRegisterLogin : Form
    {
        SqlConnection con = Splasher.connectionstring;

        public static string Firstname;
        public static string Lastname;
        public static string Middlename;
        public static string Gender;
        public static string Age;
        public static string Phone;
        public static string CustomerID;
        public static string Username;
        


        public CustomerRegisterLogin()
        {

            InitializeComponent();
           

        }

        private void btnexitform2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Username = textBox2.Text;
            con.Open();
            string CID = "select Customer_ID from Customer where Username='" + Username + "'";


            SqlCommand ctb = new SqlCommand(CID, con);
            using (SqlDataReader dr = ctb.ExecuteReader())
            {
                if (dr.Read())
                {
                    CustomerID = dr["Customer_ID"].ToString();
                }
                con.Close();
            }

            con.Close();
            con.Open();
            string Fn = "select First_name from Customer where Customer_ID ='" + CustomerID + "'";


            SqlCommand FNC = new SqlCommand(Fn, con);
            using (SqlDataReader dr = FNC.ExecuteReader())
            {
                if (dr.Read())
                {
                    Firstname = dr["First_name"].ToString();
                }
                con.Close();
            }

            con.Close();
            con.Open();
            string LN = "select Last_name from Customer where Customer_ID ='" + CustomerID + "'";


            SqlCommand LNN = new SqlCommand(LN, con);
            using (SqlDataReader dr = LNN.ExecuteReader())
            {
                if (dr.Read())
                {
                    Lastname = dr["Last_name"].ToString();
                }
                con.Close();
            }

            con.Close();
            con.Open();
            string MN = "select Middle_name from Customer where Customer_ID ='" + CustomerID + "'";


            SqlCommand MNN = new SqlCommand(MN, con);
            using (SqlDataReader dr = MNN.ExecuteReader())
            {
                if (dr.Read())
                {
                    Middlename = dr["Middle_name"].ToString();
                }
                con.Close();
            }

            con.Close();
            con.Open();
            string GN = "select Gender from Customer where Customer_ID='" + CustomerID + "'";


            SqlCommand GNN = new SqlCommand(GN, con);
            using (SqlDataReader dr = GNN.ExecuteReader())
            {
                if (dr.Read())
                {
                    Gender = dr["Gender"].ToString();
                }
                con.Close();
            }

            con.Close();
            con.Open();
            string AG = "select Age from Customer where Customer_ID='" + CustomerID + "'";


            SqlCommand AGG = new SqlCommand(AG, con);
            using (SqlDataReader dr = AGG.ExecuteReader())
            {
                if (dr.Read())
                {
                    Age = dr["Age"].ToString();
                }
                con.Close();
            }

            con.Close();
            con.Open();
            string PH = "select Phone from Customer where Customer_ID='" + CustomerID + "'";


            SqlCommand PHH = new SqlCommand(PH, con);
            using (SqlDataReader dr = PHH.ExecuteReader())
            {
                if (dr.Read())
                {
                    Phone = dr["Phone"].ToString();
                }
                con.Close();
            }

            con.Close();
/////////////////////////-----------------------------------------------------
            


            con.Open();
            SqlCommand check_User_Name = new SqlCommand("SELECT COUNT(*) FROM [Customer] WHERE ([Username] = @user)", con);
            check_User_Name.Parameters.AddWithValue("@user", Username);
            int UserExist = (int)check_User_Name.ExecuteScalar();

            check_User_Name.ExecuteNonQuery();


            con.Close();
            con.Open();
            SqlCommand check_User_Pass = new SqlCommand("SELECT COUNT(*) FROM [Customer] WHERE ([Password] = @pass)", con);
            check_User_Pass.Parameters.AddWithValue("@pass", textBox1.Text);
            int PassExist = (int)check_User_Pass.ExecuteScalar();

            check_User_Pass.ExecuteNonQuery();
            con.Close();

            if (UserExist == 1 && PassExist == 1)
            {

                MessageBox.Show("Correct credentials entered. Please Proceed Further", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                CustomerHandle CH = new CustomerHandle();
                CH.ShowDialog();
                this.Close();

            }


            else
            {
                MessageBox.Show("Wrong credentials entered. Please  try again!", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }

        }

        private void CustomerRegisterLogin_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            CustomerRegistration CR = new CustomerRegistration();
            CR.ShowDialog();
            this.Close();
        }
    }
}
