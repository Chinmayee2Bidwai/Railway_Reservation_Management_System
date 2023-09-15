using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RailwayReservationProject
{
    public partial class Trains_Master : Form
    {
        public Trains_Master()
        {
            InitializeComponent();
            populate();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=CHINMAYEE02;Initial Catalog=master;Integrated Security=True");
        private void populate()
        {

            Con.Open();
            string query = "select * from TrainTb1";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            var ds = new DataSet();
            sda.Fill(ds);
            TrainDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int key = 0;
                string querry = "Select * from TrainTb1 where TrainName = " + TrainName.Text;
                Con.Open();
                SqlCommand sqlCmd = new SqlCommand(querry, Con);
                SqlDataReader tid = sqlCmd.ExecuteReader();

                key = Int32.Parse(tid["TrainId"].ToString());
            }


            catch (Exception)
            {
                //MessageBox.Show("Unexpected Error");
            }
            finally
            {
                Con.Close();
            }

            string TrainSatus = "";

            if (TrainName.Text == "" || TrainCap.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                if (BusyRd.Checked == true)
                {
                    TrainSatus = "Busy";
                }
                else if (FreeRd.Checked == true)
                {
                    TrainSatus = "Available";
                }
                SqlConnection Con = new SqlConnection(@"Data Source=CHINMAYEE02;Initial Catalog=master;Integrated Security=True");

                try
                {
                    if (Con.State == ConnectionState.Closed)
                    {
                        Con.Open();
                    }
                    string Query = "UPDATE TrainTb1 set TrainName = '" + TrainName.Text + "', TrainCap = '" +TrainCap.Text+ "', TrainStatus = '" + TrainSatus + "' where TrainId = " + key + ";";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Train Updated Successfully");
                    Con.Close();
                    populate();
                    reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }
        int key = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TrainName.Text = TrainDGV.SelectedRows[0].Cells[1].Value.ToString();
            TrainCap.Text = TrainDGV.SelectedRows[0].Cells[2].Value.ToString();
            if (TrainName.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(TrainDGV.SelectedRows[0].Cells[0].Value.ToString());


            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string TrainStatus = "";
            if (TrainName.Text == "" || TrainCap.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                if (BusyRd.Checked == true)
                {
                    TrainStatus = "Busy";
                }
                else if (FreeRd.Checked == true)
                {
                    TrainStatus = "Available";
                }
                try
                {
                    if (Con.State == ConnectionState.Closed)
                    {
                        Con.Open();
                    }
                    //Con.Open();
                  
                    string Query = "insert into TrainTb1 values ('" + TrainName.Text + "', '" + TrainCap.Text + "', '" + TrainStatus + "')";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Train Added Successfully");
                    Con.Close();
                    populate();


                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void reset()
        {
            TrainName.Text = "";
            TrainCap.Text = "";
            BusyRd.Checked = false;
            FreeRd.Checked = false;
            key = 0;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            reset();
        }
        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
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
                    string Query = "Delete from TrainTb1 where TrainId=" + key + "";
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
                private void button5_Click(object sender, EventArgs e)
                {
                    MainForm Main = new MainForm();
                    Main.Show();
                    this.Hide();
                }

                private void textBox1_TextChanged_1(object sender, EventArgs e)
                {

                }

                private void textBox1_TextChanged_2(object sender, EventArgs e)
                {

                }
            }
        } 
    


