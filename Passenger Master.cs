using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RailwayReservationProject
{
    public partial class Passenger_Master : Form
    {
        public Passenger_Master()
        {
            InitializeComponent();
            populate();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=CHINMAYEE02;Initial Catalog=master;Integrated Security=True");
        private void populate()
        {
            if (Con.State == ConnectionState.Closed) {
                Con.Open();
            }
            string query = "select * from PassengerTb1";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            var ds = new DataSet();
            sda.Fill(ds);
            PassengerDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string PGender = "";
            if (PNameTb.Text == "" || PphoneTb.Text == "" || PAddTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                if (MaleRd.Checked == true)
                {
                    PGender = "Male";
                }
                else if (FemaleRd.Checked == true)
                {
                    PGender = "Female";
                }
                try
                {
                    {
                        if (Con.State == ConnectionState.Closed)
                        {
                            Con.Open();
                        }
                        string Query = "insert into PassengerTb1 values ('" + PNameTb.Text + "', '" + PAddTb.Text + "', '" + PGender + "', '" + PNatCb.SelectedItem + "', '" + PphoneTb.Text + "')";
                        SqlCommand cmd = new SqlCommand(Query, Con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Passenger Added Successfully");
                        Con.Close();
                        populate();
                        Reset();
                    }
                     }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void Reset()
        {
            PNameTb.Text = "";
            PAddTb.Text = "";
            PphoneTb.Text = "";
            MaleRd.Checked = false;
            FemaleRd.Checked = false;
            PNatCb.SelectedIndex= -1;
            key = 0;
        }
        int key = 0;
        private void PassengerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PNameTb.Text = PassengerDGV.SelectedRows[0].Cells[1].Value.ToString();
            PAddTb.Text = PassengerDGV.SelectedRows[0].Cells[2].Value.ToString();
            PNatCb.SelectedItem = PassengerDGV.SelectedRows[0].Cells[4].Value.ToString();
            PphoneTb.Text = PassengerDGV.SelectedRows[0].Cells[5].Value.ToString();
            if (PNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(PassengerDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            string PGender = "";
            if (PNameTb.Text == "" || PphoneTb.Text == "" || PAddTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                if (MaleRd.Checked == true)
                {
                    PGender = "Male";
                }
                else if (FemaleRd.Checked == true)
                {
                    PGender = "Female";
                }
                try
                {
                    {
                        if (Con.State == ConnectionState.Closed)
                        {
                            Con.Open();
                        }
                        string Query = "update PassengerTb1 set PName= '" + PNameTb.Text + "',PAdd= '" + PAddTb.Text + "',PGender= '" + PGender + "' , PNat='" + PNatCb.SelectedItem.ToString() + "',Pphone='" + PphoneTb.Text + "' where PId= " + key+"";
                        SqlCommand cmd = new SqlCommand(Query, Con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Passenger Updated Successfully");
                        Con.Close();
                        populate();
                        Reset();
                        
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        
            private void button4_Click(object sender, EventArgs e)
            {
            Reset();
            }

        private void button3_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select The Passenger to be Deleted");
            }
            else
            {
                try
                {
                    if (Con.State == ConnectionState.Closed)
                    {
                        Con.Open();
                    }
                    //Con.Open();
                    string Query = "Delete from PassengerTb1 where PId=" + key + "";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Passenger Deleted Successfully");
                    Con.Close();
                    populate();
                    Reset();
                    

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
            }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Gender_Click(object sender, EventArgs e)
        {

        }

        private void MaleRd_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void FemaleRd_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            MainForm Main = new MainForm();
            Main.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
    

