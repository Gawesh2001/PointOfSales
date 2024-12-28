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

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("            Cashier_Trix = 123\r\n            Cashier_Pheonix = 456\r\n            Cashire_Nick = 789\r\n            Cashire_Ted = 741\r\n            Cashire_Tim = 852\r\n            Cashire_Tize = 963\r\n            Admin = 123456\r\n           If Any of this password needs to be change pleas contact us;");
        }
    }
}
