using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Ticket_Management_System
{
    public partial class YourIdentity : Form
    {
        public YourIdentity()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnexitform2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnexitform2_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Red;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Transparent;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.Red;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.Transparent;
        }

        private void btnexitform2_MouseEnter(object sender, EventArgs e)
        {
            btnexitform2.BackColor = Color.Red;
        }

        private void btnexitform2_MouseLeave(object sender, EventArgs e)
        {
            btnexitform2.BackColor = Color.Transparent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminLogin AL = new AdminLogin();
            AL.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //Splasher S = new Splasher();
            //S.ShowDialog();
            //Thread.Sleep(5000);
            //this.Close();
            this.Hide();
            CustomerRegisterLogin CRL = new CustomerRegisterLogin();
            CRL.ShowDialog();
            this.Close();

        }

        private void YourIdentity_Load(object sender, EventArgs e)
        {

            

        }
    }
}
