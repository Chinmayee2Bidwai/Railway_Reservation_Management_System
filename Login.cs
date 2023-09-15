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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Welcome_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {   
             
            if(UnameTb.Text == ""|| PassTb.Text=="")
            {
                MessageBox.Show("Enter Username and Password");
            }else if (UnameTb.Text == "Chinmayee" && PassTb.Text=="Password")
            {
                MainForm  Main = new MainForm();
                Main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Username OR Password");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
