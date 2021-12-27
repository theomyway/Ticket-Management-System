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
    public partial class AdminHome : Form
    {
        public AdminHome()
        {
            InitializeComponent();
        }
        SqlConnection con = Splasher.connectionstring;
        DateTime now = DateTime.Now;
        string status = "Pending";

        private void btnexitform2_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            label5.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt");
        }

        private void AdminHome_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 1000;
            con.Open();
            SqlCommand check_status_count = new SqlCommand("SELECT COUNT(Status) FROM [Bookings]  where Status = @Status", con);
            check_status_count.Parameters.AddWithValue("@Status", status);
            int PendingRequestCount = (int)check_status_count.ExecuteScalar();

            check_status_count.ExecuteNonQuery();
            con.Close();
            label1.Text = PendingRequestCount.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageTrainBooking MTB = new ManageTrainBooking();
            MTB.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageAirplaneBookings M = new ManageAirplaneBookings();
            M.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageBusBookings M = new ManageBusBookings();
            M.ShowDialog();
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminLogin A = new AdminLogin();
            A.ShowDialog();
            this.Close();
        }
    }
}
