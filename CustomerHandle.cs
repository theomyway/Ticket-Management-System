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
    public partial class CustomerHandle : Form
    {
        public CustomerHandle()
        {
            InitializeComponent();
        }
        string CusID = CustomerRegisterLogin.CustomerID;
        float totall;
        float convertedfinal;
        SqlConnection con = Splasher.connectionstring;
        string status = "Approval Pending";
        string C = "Cancelled";
        float panalty;
        float updatedcost;
        int BookingID;
        string firstname = CustomerRegisterLogin.Firstname;
        string Lastname = CustomerRegisterLogin.Lastname;
        DateTime now = DateTime.Now;

        private void btnexitform2_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Airplane A = new Airplane();
            A.ShowDialog();
            this.Close();
        }
        private bool IsValid()   //ENCAPSULATION

        {

            return true;
        }
        public void gridviewstatusshow()
        {
            try
            {
                dataGridView1.Update();
                dataGridView1.Refresh();
                con.Open();
                string query = "select Booking_ID,Customer_ID,First_name,Company,Category,Total,Status from Bookings where Customer_ID = @CusID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CusID", CusID);
                cmd.Parameters.AddWithValue("@Stats", status);
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

        private void CustomerHandle_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 1000;
            label3.Text = firstname + Lastname;
            this.bookingsTableAdapter1.Fill(this.tmsdbDataSet1.Bookings);
            gridviewstatusshow();
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                SqlCommand cmd = new SqlCommand("UPDATE Bookings set Status = @Status where Customer_ID = @CusID and Booking_ID = @BookID", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@CusID", CusID);
                cmd.Parameters.AddWithValue("@BookID", BookingID);
                cmd.Parameters.AddWithValue("@Status", C);



                MessageBox.Show("You have cancelled this booking and panalty has been charged!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                con.Open();
                string PH = "select Total from Bookings where Booking_ID ='" + BookingID + "'";


                SqlCommand PHH = new SqlCommand(PH, con);
                using (SqlDataReader dr = PHH.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        totall = Convert.ToInt32(dr["Total"]);
                    }
                    con.Close();
                }

                con.Close();

                panalty = (float)(totall * 0.05);

                label16.Text = panalty.ToString();
                SqlCommand DCM = new SqlCommand("UPDATE Bookings set Total = @Total where Customer_ID = @CusID and Booking_ID = @BookID", con);
                DCM.CommandType = CommandType.Text;

                DCM.Parameters.AddWithValue("@CusID", CusID);
                DCM.Parameters.AddWithValue("@BookID", BookingID);
                DCM.Parameters.AddWithValue("@Total", panalty);



               

                con.Open();
                DCM.ExecuteNonQuery();
                con.Close();
                gridviewstatusshow();

            }





        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BookingID = Int32.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Train T = new Train();
            T.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bus B = new Bus();
            B.ShowDialog();
            this.Close();

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label5.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt");
           
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerRegisterLogin CR = new CustomerRegisterLogin();
            CR.ShowDialog();
            this.Close();
        }
    }
}
