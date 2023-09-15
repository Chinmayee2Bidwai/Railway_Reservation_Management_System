using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RailwayReservationProject
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Welcome_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Cancellation Cancel = new Cancellation();
            Cancel.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Cancellation Cancel = new Cancellation();
            Cancel.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Reservation_Master  Res = new Reservation_Master();
            Res.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Reservation_Master Res = new Reservation_Master();
            Res.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Passenger_Master Ps = new Passenger_Master();
            Ps.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Passenger_Master Ps = new Passenger_Master();
            Ps.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

           Travel_Master Tr = new Travel_Master();
            Tr.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Travel_Master Tr = new Travel_Master();
            Tr.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Trains_Master Tm = new Trains_Master();
            Tm.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }
    }
}