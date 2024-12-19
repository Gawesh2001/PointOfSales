using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Reflection.Emit;

namespace POS
{
    public partial class CreateAcc : Form
    {
        public CreateAcc()
        {
            InitializeComponent();
        }

        private void CreateAcc_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username = this.textBox1.Text.ToLower();
            String password = this.textBox2.Text;
            int level = 0;



            if (checkBox1.Checked)
            {
                level = 1;
            }
            else if (checkBox2.Checked)
            {
                level = 2;
            }




            if (textBox2.Text.Length < 6)
            {
                label6.Text = "Enter at leats 6 characters";
            }
            else if (textBox3.Text != textBox2.Text)
            {
                label7.Text = "Confirmation Password Doesn't Match";
                textBox3.Clear();
                textBox3.Focus();
            }
            else if (checkBox1.Checked && checkBox2.Checked)
            {
                label8.Text = "Pleas Select Only One Level";
                checkBox1.Checked = false;
                checkBox2.Checked = false;
            }
            
            else
            {




                String connectionString = "Data Source=GAWESH\\SQLEXPRESS;Initial Catalog=SuperMarket;Integrated Security=True;Encrypt=False";


                String query = "INSERT INTO Users (username, password, user_level) VALUES (@username, @password, @level )";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@username", username);
                            cmd.Parameters.AddWithValue("@password", password);
                            cmd.Parameters.AddWithValue("@level", level);

                            int result = cmd.ExecuteNonQuery();


                            if (result > 0)
                            {
                                MessageBox.Show("Registation Successfull !! ");
                                this.Close();
                                Form1 form1 = new Form1();
                                form1.Show();
                            }
                            else { MessageBox.Show("Registation Faild"); }

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
            }
            
        }
    }
}
