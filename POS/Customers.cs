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

namespace POS
{
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
        }
        public String connectionString = "Data Source=GAWESH\\SQLEXPRESS;Initial Catalog=SuperMarket;Integrated Security=True;Encrypt=False";
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Customers (cus_name,cus_no) VALUES (@cus_name,@cus_no)";
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                try
                {
                    string c_name = textBox1.Text;
                    long c_no = Convert.ToInt64(textBox2.Text);
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@cus_name", c_name);
                        cmd.Parameters.AddWithValue("@cus_no", c_no);


                        int result = cmd.ExecuteNonQuery();

                        if (result >0)
                        {

                            MessageBox.Show("Customer Registerd");
                            textBox1.Clear();
                            textBox2.Clear();
                            this.Close();
                            
                        }
                        else
                        {
                            MessageBox.Show("Customer Registation FAild");
                        }

                    }


                }
                catch (Exception ex) {
                    MessageBox.Show("An error occurred" + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                
            }
        }
    }
}
