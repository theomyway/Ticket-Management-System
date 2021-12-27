using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Ticket_Management_System
{
    public partial class Splasher : Form
    {
        public static SqlConnection connectionstring;
        SqlConnection con = new SqlConnection(@"Data Source=OMARSPC;Initial Catalog=TMSDB;Integrated Security=True");
        public Splasher()
        {
            InitializeComponent();
            connectionstring = con;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
             

        //Thread.Sleep(5000);
        //this.Hide();

        //YourIdentity y = new YourIdentity();
        //y.ShowDialog();
        //this.Close();
        //timer1.Start();


        timer1.Start();
            
           



        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Stop();    //Amazing
            this.Hide();
            YourIdentity y = new YourIdentity();
            y.ShowDialog();

            this.Close();

            
            
            
            
        }

        public void stop()
        {
            timer1.Stop();
        }
    }
}
