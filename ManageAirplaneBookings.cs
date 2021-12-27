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
    public partial class ManageAirplaneBookings : Form
    {
        public ManageAirplaneBookings()
        {
            InitializeComponent();
        }
        SqlConnection con = Splasher.connectionstring;
        string CusID = CustomerRegisterLogin.CustomerID;
        string status = "Pending";
        string Cat = "Airplane";
        string Comp1 = "Pakistan International Airline (PIA)";
        string Comp2 = "Shaheen Airways";
        string Approved = "Approved";
        string Rejected = "Rejected";
        int bookingID;

        private void ManageAirplaneBookings_Load(object sender, EventArgs e)
        {
            label3.Text = AdminLogin.Username;
            this.bookingsTableAdapter1.Fill(this.tmsdbDataSet1.Bookings);
            gridviewstatusshowtrainpendingbookings();
        }
        public void gridviewstatusshowtrainpendingbookings()
        {
            try
            {
                dataGridView2.Update();
                dataGridView2.Refresh();
                con.Open();
                string query = "select Booking_ID,Customer_ID,First_name,Company,Category,Total,Status from Bookings where Status = @Status and Company = @Comp and Category = @Cat ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Cat", Cat);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@Comp", Comp1);


                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt.Rows.Clear();

                da.Fill(dt);
                dataGridView2.DataSource = dt;

                con.Close();
                dataGridView2.Update();
                dataGridView2.Refresh();

            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                dataGridView1.Update();
                dataGridView1.Refresh();
                con.Open();
                string query = "select Booking_ID,Customer_ID,First_name,Company,Category,Total,Status from Bookings where Status = @Status and Company = @Comp and Category = @Cat ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Cat", Cat);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@Comp", Comp2);


                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt.Rows.Clear();

                da.Fill(dt);
                dataGridView1.DataSource = dt;

                con.Close();
                dataGridView1.Update();
                dataGridView1.Refresh();

            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void gridviewstatusshowtrainApprovedbookings()
        {
            try
            {
                dataGridView2.Update();
                dataGridView2.Refresh();
                con.Open();
                string query = "select Booking_ID,Customer_ID,First_name,Company,Category,Total,Status from Bookings where Status = @Status and Status= @ and Company = @Comp and Category = @Cat ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Cat", Cat);
                cmd.Parameters.AddWithValue("@Status", Approved);
                cmd.Parameters.AddWithValue("@Comp", Comp1);


                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt.Rows.Clear();

                da.Fill(dt);
                dataGridView2.DataSource = dt;

                con.Close();
                dataGridView2.Update();
                dataGridView2.Refresh();

            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                dataGridView1.Update();
                dataGridView1.Refresh();
                con.Open();
                string query = "select Booking_ID,Customer_ID,First_name,Company,Category,Total,Status from Bookings where Status = @Status and Company = @Comp and Category = @Cat ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Cat", Cat);
                cmd.Parameters.AddWithValue("@Status", Approved);
                cmd.Parameters.AddWithValue("@Comp", Comp2);


                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt.Rows.Clear();

                da.Fill(dt);
                dataGridView1.DataSource = dt;

                con.Close();
                dataGridView1.Update();
                dataGridView1.Refresh();

            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool IsValid()   //ENCAPSULATION

        {

            return true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                SqlCommand cmd = new SqlCommand("UPDATE Bookings set Status = @Status where Booking_ID = @BookID ", con);
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("@BookID", bookingID);
                cmd.Parameters.AddWithValue("@Status", Approved);



                MessageBox.Show("This booking has been accepted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                gridviewstatusshowtrainpendingbookings();


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                SqlCommand cmd = new SqlCommand("UPDATE Bookings set Status = @Status where Booking_ID = @BookID ", con);
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("@BookID", bookingID);
                cmd.Parameters.AddWithValue("@Status", Rejected);



                MessageBox.Show("This booking has been rejected", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                gridviewstatusshowtrainpendingbookings();

            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bookingID = Int32.Parse(dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bookingID = Int32.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminLogin AL = new AdminLogin();
            AL.ShowDialog();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageTrainBooking MTB = new ManageTrainBooking();
            MTB.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Hide();
            ManageBusBookings M = new ManageBusBookings();
            M.ShowDialog();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminHome A = new AdminHome();
            A.ShowDialog();
            this.Close();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            panel4.Height = button3.Height;
            panel4.Top = button3.Top;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            panel4.Height = button1.Height;
            panel4.Top = button1.Top;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            panel4.Height = button2.Height;
            panel4.Top = button2.Top;
        }
    }
}
