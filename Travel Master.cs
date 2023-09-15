using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RailwayReservationProject
{
    public partial class Travel_Master : Form
    {
        public Travel_Master()
        {
            InitializeComponent();
            populate();
            FillTCode();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=CHINMAYEE02;Initial Catalog=master;Integrated Security=True");
        private void populate()
        {
            Con.Open();
            string query = "select * from TravelTb1";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            var ds = new DataSet();
            sda.Fill(ds);
            TravelDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void FillTCode()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select TrainId from TrainTb1 ", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("TrainId", typeof(int));
            dt.Load(rdr);
            TCode.ValueMember = "TrainId";
            TCode.DataSource = dt;
            Con.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void ChangeStatus()
        {
            string TrainStatus = "Busy";
            try
            {
                Con.Open();
                string Query = "update TrainTb1 TrainStatus= '" + TrainStatus + "' where TrainId= " + TCode.SelectedValue.ToString() + ";";
                SqlCommand cmd = new SqlCommand(Query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Train Updated Successfully");
                Con.Close();
                populate();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            if (TCostTb.Text == "" || TCode.SelectedIndex == -1 || SrcCb.SelectedIndex == -1 || DestCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    {
                        if (Con.State == ConnectionState.Closed)
                        {
                            Con.Open();
                        }
                        string Query = "insert into TravelTb1 values ('" + TraveDate.Value+ "', '" + TCode.SelectedValue.ToString() + "', '" + SrcCb.SelectedItem.ToString() + "', '" + DestCb.SelectedItem.ToString() + "', '" + TCostTb.Text + "')";
                        SqlCommand cmd = new SqlCommand(Query, Con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Travel Added Successfully");
                        Con.Close();
                        populate();
                        Reset();
                        //ChangeStatus();
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
            SrcCb.SelectedIndex = -1;
            DestCb.SelectedIndex = -1;
            // TCode.SelectedIndex = -1;
            TCostTb.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (SrcCb.SelectedIndex == -1 || DestCb.SelectedIndex == -1 || TCostTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    {
                        if (Con.State == ConnectionState.Closed)
                        {
                            Con.Open();
                        }
                      
                        string Query = "update TravelTb1 set TraveDate= '" + TraveDate.Value + "',Train= '" + TCode.SelectedValue.ToString() + "',Src= '" + SrcCb.SelectedItem.ToString() + "' , Dest='" + DestCb.SelectedItem.ToString() + "',Cost='" + TCostTb.Text + "'where TravCode= " + key;
                        SqlCommand cmd = new SqlCommand(Query, Con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Travel Updated Successfully");
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
        int key = 0;
        private void TravelDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                TraveDate.Text = TravelDGV.SelectedRows[0].Cells[1].Value.ToString();
                TCode.SelectedValue = TravelDGV.SelectedRows[0].Cells[2].Value.ToString();
                SrcCb.SelectedItem = TravelDGV.SelectedRows[0].Cells[3].Value.ToString();
                DestCb.SelectedItem = TravelDGV.SelectedRows[0].Cells[4].Value.ToString();
                TCostTb.Text = TravelDGV.SelectedRows[0].Cells[5].Value.ToString();
                if (TCode.SelectedIndex == -1)
                {
                    key = 0;
                   
                }
                else
                {
                    key = Convert.ToInt32(TravelDGV.SelectedRows[0].Cells[0].Value.ToString());
                }
            }
        }

        private void SrcCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            MainForm Main = new MainForm();
            Main.Show();
            this.Hide();
        }

        private void TCode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            {
                if (key == 0)
                {
                    MessageBox.Show("Select The Train to be Deleted");
                }
                else
                {
                    try
                    {
                        if (Con.State == ConnectionState.Closed)
                        {
                            Con.Open();
                        }
                        // Con.Open();
                        string Query = "Delete from TravelTb1 where TravCode=" + key + "";
                        SqlCommand cmd = new SqlCommand(Query, Con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Train Deleted Successfully");
                        Con.Close();
                        populate();

                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);
                    }
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TraveDate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
