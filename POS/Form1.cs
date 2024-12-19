using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace POS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            textBox1.Focus();

            String connectionString = "Data Source=GAWESH\\SQLEXPRESS;Initial Catalog=SuperMarket;Integrated Security=True;Encrypt=False";
            using (SqlConnection conn = new SqlConnection(connectionString))
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Users WHERE username = '" + textBox1.Text + "' AND password = '" + textBox2.Text + "'";

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query,conn);

                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        String username = this.textBox1.Text;
                        String password = this.textBox2.Text;

                        String Message = $"{textBox1.Text} Logged In";
                        MessageBox.Show(Message);

                        DashBoard dashBoard = new DashBoard();
                        dashBoard.Show();

                    }else
                    {
                        MessageBox.Show($"Invalid Loggind Details", "Enter Correct Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox1.Clear();
                        textBox2.Clear();

                        textBox1.Focus();
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            



           
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.BackColor = Color.FromArgb(169, 201, 242);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Transparent;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { 
               textBox2.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { 
            
            button1.Focus();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateAcc createAcc = new CreateAcc();
            createAcc.Show();
        }
    }
}
