using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RailwayReservationProject
{
    public partial class Cancellation : Form
    {
        public Cancellation()
        {
            InitializeComponent();
            populate();
            FillTicketId();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=CHINMAYEE02;Initial Catalog=master;Integrated Security=True");
        private void populate()
        {
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            string query = "select * from CancellationTb1";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            var ds = new DataSet();
            sda.Fill(ds);
            CancelDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void FillTicketId()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select  TicketId from ReservationTb1 ", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("TicketId", typeof(int));
            dt.Load(rdr);
            TidCb.ValueMember = "TicketId";
            TidCb.DataSource = dt;
            Con.Close();
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TickIdCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (TidCb.SelectedIndex == -1)
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
                        string Query = "insert into CancellationTb1 values (" + TidCb.SelectedValue.ToString() + ", '" + DateTime.Today.Date + "')";
                        SqlCommand cmd = new SqlCommand(Query, Con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Ticket Cancelled");
                        Con.Close();
                        populate();
                        remove();
                        FillTicketId();
                        TidCb.SelectedIndex = -1;
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        
        private void remove()
        {
               try
                {
                    Con.Open();
                    string Query = "Delete from ReservationTb1 where TicketId=" + TidCb.SelectedValue.ToString() + "";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                   
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        private void button4_Click(object sender, EventArgs e)
        {
            MainForm Main = new MainForm();
            Main.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    }

