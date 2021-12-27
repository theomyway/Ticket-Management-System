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
    public partial class Airplane : Form
    {
        SqlConnection con = Splasher.connectionstring;
        public Airplane()
        {
            InitializeComponent();
        }
        string firstname = CustomerRegisterLogin.Firstname;
        string lastname = CustomerRegisterLogin.Lastname;
        string middlename = CustomerRegisterLogin.Middlename;
        string gender = CustomerRegisterLogin.Gender;
        string age = CustomerRegisterLogin.Age;
        string phone = CustomerRegisterLogin.Phone;
        public static DateTime departure, arrival;
        string CusID = CustomerRegisterLogin.CustomerID;
        public static double totalcost;



        private void btnexitform2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Airplane_Load(object sender, EventArgs e)
        {
            textBox2.Text = firstname;
            textBox1.Text = lastname;
            textBox8.Text = middlename;
            textBox3.Text = gender;
            textBox7.Text = phone;
            textBox4.Text = age;
            comboBox2.Items.Add("Karachi");
            comboBox2.Items.Add("Lahore");
            comboBox2.Items.Add("Islamabad");
            comboBox2.Items.Add("Peshawar");
            comboBox2.Items.Add("Sukkur");
            comboBox2.Items.Add("Faislabad");
            comboBox2.Items.Add("Gujranwala");
            comboBox2.Items.Add("Thatta");
            comboBox2.Items.Add("Chiniot");
            comboBox2.Items.Add("Bhawalpur");
            comboBox2.Items.Add("Rawalpindi");
            comboBox2.Items.Add("Quetta");
            //
            comboBox3.Items.Add("Karachi");
            comboBox3.Items.Add("Lahore");
            comboBox3.Items.Add("Islamabad");
            comboBox3.Items.Add("Peshawar");
            comboBox3.Items.Add("Sukkur");
            comboBox3.Items.Add("Faislabad");
            comboBox3.Items.Add("Gujranwala");
            comboBox3.Items.Add("Thatta");
            comboBox3.Items.Add("Chiniot");
            comboBox3.Items.Add("Bhawalpur");
            comboBox3.Items.Add("Rawalpindi");
            comboBox3.Items.Add("Quetta");
            //
            comboBox5.Items.Add("Pakistan International Airline (PIA)");
            comboBox5.Items.Add("Shaheen Airways");
            //
            
            for(int i=1;i<16 ;i++)
            {
                comboBox4.Items.Add(i);
            }

        }
        private bool IsValid()   //ENCAPSULATION

        {

            return true;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

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

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerHandle CH = new CustomerHandle();
            CH.ShowDialog();
            this.Close();
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            panel4.Height = button5.Height;
            panel4.Top = button5.Top;
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
               
                int Luggage = comboBox4.SelectedIndex;
                int Persons = Convert.ToInt32(textBox10.Text);
                string status = "Pending";
                int totaldays;
                string Cat = "Airplane";
               
                departure = dateTimePicker1.Value;
                arrival = dateTimePicker2.Value;
                totaldays = (departure - arrival).Days;
                double AirlineOneDayRateInterCity=0; 
               
                string Commute="";
                double WaysCommute=1;
                if (radioButton1.Checked == true)
                {
                    radioButton2.Checked = false;
                    Commute = "One Way";
                }
                else if(radioButton2.Checked == true)
                {
                    radioButton1.Checked = false;
                    Commute = "Round Trip";
                    WaysCommute++;
                }
                if (comboBox5.SelectedItem.ToString() == "Pakistan International Airline (PIA)")
                {
                    AirlineOneDayRateInterCity = 6000;
                }
                else if(comboBox5.SelectedItem.ToString() == "Shaheen Airways")
                {
                    AirlineOneDayRateInterCity = 4000;
                }

                totalcost = (totaldays * AirlineOneDayRateInterCity * (Persons * Luggage)) * WaysCommute;

                SqlCommand cmd = new SqlCommand("INSERT INTO Bookings values (@CusID,@Firstname,@Lastname,@Middlename,@Gender,@Age,@phone,@From,@To,@Departure,@Arrival,@Luggage,@Persons,@Commute,@Company,@Category,@Total,@Status)", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@CusID", CusID);
                cmd.Parameters.AddWithValue("@Firstname", firstname);
                cmd.Parameters.AddWithValue("@Lastname", lastname);
                cmd.Parameters.AddWithValue("@Age", age);
                
                cmd.Parameters.AddWithValue("@Middlename", middlename);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@Gender",gender);
                cmd.Parameters.AddWithValue("@Company", comboBox5.SelectedItem);
                cmd.Parameters.AddWithValue("@From", comboBox2.SelectedItem);
                cmd.Parameters.AddWithValue("@To", comboBox3.SelectedItem);
                cmd.Parameters.AddWithValue("@Luggage", comboBox4.SelectedItem);
                cmd.Parameters.AddWithValue("@Persons", textBox10.Text);
                cmd.Parameters.AddWithValue("@Departure", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@Arrival", dateTimePicker2.Value);
                cmd.Parameters.AddWithValue("@Total", totalcost);
                cmd.Parameters.AddWithValue("@Category", Cat);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@Commute",Commute );

                
                label16.Text = Convert.ToString("Rs:" + totalcost + "/-");

                

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Success", "You have requested a flight kindly wait for the approval!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
