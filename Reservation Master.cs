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
    public partial class Reservation_Master : Form
    {
        public Reservation_Master()
        {
            InitializeComponent();
            populate();
            FillPid();
            FillTravCode();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(@"Data Source=CHINMAYEE02;Initial Catalog=master;Integrated Security=True");
        private void populate()
        {
            Con.Open();
            string query = "select * from ReservationTb1";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            var ds = new DataSet();
            sda.Fill(ds);
            ReservationDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void FillPid()
        {
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            //Con.Open();
            SqlCommand cmd = new SqlCommand("Select  PId from PassengerTb1 ", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("PId", typeof(int));
            dt.Load(rdr);
            PidCb.ValueMember = "PId";
            PidCb.DataSource = dt;
            Con.Close();
        }
        private void FillTravCode()
        {
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            // Con.Open();
            SqlCommand cmd = new SqlCommand("Select  TravCode from TravelTb1 ", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("TravCode", typeof(int));
            dt.Load(rdr);
            TravelCodeCb.ValueMember = "TravCode";
            TravelCodeCb.DataSource = dt;
            Con.Close();
        }
        string pname;
        private void GetPName()
        {
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            //Con.Open();
            string mysql = "select * from PassengerTb1 where PId=" + PidCb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(mysql, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                pname = dr["PName"].ToString();
            }
            Con.Close();
            MessageBox.Show(pname);
        }
        string Date, Src, Dest;
        int Cost;
        private void GetTravel()
        {
            try
            {

                SqlConnection Con = new SqlConnection(@"Data Source=CHINMAYEE02;Initial Catalog=master;Integrated Security=True");
                Con.Open();
                string mysql = "select * from TravelTb1 where TravCode = " + TravelCodeCb.SelectedValue.ToString() + "";
                SqlCommand cmd = new SqlCommand(mysql, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {

                    Date = dr["TraveDate"].ToString();
                    Src = dr["Src"].ToString();
                    Dest = dr["Dest"].ToString();
                    Cost = Convert.ToInt32(dr["Cost"].ToString());
                }
                Con.Close();
                MessageBox.Show(Date + Src + Dest + Cost);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);

            }
        }

            private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void Reservation_Master_Load(object sender, EventArgs e)
        {

        }

        private void TravelCodeCb_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (TravelCodeCb.SelectedIndex == -1 || PidCb.SelectedIndex == -1)
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
                        string Query = "insert into ReservationTb1 values (" + PidCb.SelectedValue.ToString() + ", '" + pname + "', '" + TravelCodeCb.SelectedValue.ToString() + "', '" + Date + "', '" + Src + "' ,'" + Dest + "' ," + Cost + ")";
                        SqlCommand cmd = new SqlCommand(Query, Con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Reservation Accepted");
                        Con.Close();
                        populate();
                        //Reset();
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
            MainForm Main = new MainForm();
            Main.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TravelDGV_CellContentClick(object Sender, DataGridViewCellEventArgs E)
        {

        }

        private void TravelCodeCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetTravel();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void PidCb_SelectedIndexChanged(object Sender, EventArgs E)
        {

        }

        private void PidCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetPName();
        }
    }
}

