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
using System.Xml.Linq;
using System.Collections;

namespace POS
{
    public partial class AddItem : Form
    {
        public AddItem()
        {
            InitializeComponent();
            
        }
        //public String connectionString = "Data Source=APSARA;Initial Catalog=SuperMarket;Integrated Security=True;Encrypt=False";
        public String connectionString = "Data Source=GAWESH\\SQLEXPRESS;Initial Catalog=SuperMarket;Integrated Security=True;Encrypt=False";
       // public String connectionString = "Data Source=DESKTOP-EN95E81\\SQLEXPRESS;Initial Catalog=SuperMarket;Integrated Security=True;Encrypt=False";
        private void AddItem_Load(object sender, EventArgs e)
        {

        }

     

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            long bar_code;
            if (long.TryParse(textBox8.Text, out bar_code)) { };

            String product_category = comboBox2.Text;

            String product_name = textBox1.Text;

          

            int quantity;
           
            if (int.TryParse(textBox6.Text, out quantity)) { };

            DateTime expire_date = dateTimePicker1.Value;


            decimal p_cost;
            if (decimal.TryParse(textBox4.Text, out p_cost)) { };

            decimal p_price;
            if (decimal.TryParse(textBox5.Text, out p_price)) { };



            if (textBox8.Text.Length == 0)
            {
                MessageBox.Show("Scan the barcode");
                textBox8.Focus();
            }else if (comboBox2.SelectedIndex == 0) {
                MessageBox.Show("enter the Categerycode");
                comboBox2.Focus();
            }else if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("enter the product name");
                textBox1.Focus();
            }else if (textBox6.Text.Length == 0)
            {
                MessageBox.Show("enter the quantity");
                textBox6.Focus();
            }else if(dateTimePicker1.Value == DateTime.MinValue)
            {
                MessageBox.Show("enter expire date");
                dateTimePicker1.Focus();
            }else if(textBox4.Text.Length == 0)
            {
                MessageBox.Show("enter the product cost");
                textBox4.Focus();
            }else if(textBox5.Text.Length == 0)
            {
                MessageBox.Show("enter the product name");
                textBox5.Focus();
            }
            else
            {

                String query = "INSERT INTO Products (bar_code , p_category , p_name , quantity , expire_date , p_cost , p_price) VALUES (@bar_code , @p_category , @p_name , @quentity ,@expire_date , @p_cost , @p_price) ";

                using (SqlConnection conn = new SqlConnection(connectionString))

                {
                    try
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@bar_code", bar_code);
                            cmd.Parameters.AddWithValue("@p_category", product_category);
                            cmd.Parameters.AddWithValue("@p_name", product_name);
                            cmd.Parameters.AddWithValue("@quentity", quantity);
                            cmd.Parameters.AddWithValue("@expire_date", expire_date);
                            cmd.Parameters.AddWithValue("@p_cost", p_cost);
                            cmd.Parameters.AddWithValue("@p_price", p_price);

                            int result = cmd.ExecuteNonQuery();

                            if (result > 0)
                            {
                                MessageBox.Show("Succesfully Stock Added");
                                textBox8.Clear();
                                comboBox2.Items.Clear();
                                textBox1.Clear();
                                dateTimePicker1.Value = DateTime.Now;
                                textBox4.Clear();
                                textBox5.Clear();
                                textBox6.Clear();
                                textBox8.Focus();
                            }
                            else
                            {
                                MessageBox.Show("Faild");
                            }


                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An Error Occued" + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }

            }
        }



        // Update Part


        private void button5_Click(object sender, EventArgs e)
        {
            string c_code = textBox2.Text;
            string c_name = textBox3.Text;


          
            String Query = "INSERT INTO category ( c_code,c_name) VALUES(@c_code,@c_name)";

            using (SqlConnection Conn = new SqlConnection(connectionString))
            {




                try
                {
                    Conn.Open();
                    using (SqlCommand cmdD = new SqlCommand(Query, Conn))
                    {

                        cmdD.Parameters.AddWithValue("@c_code", c_code);
                        cmdD.Parameters.AddWithValue("@c_name", c_name);

                        int result = cmdD.ExecuteNonQuery();

                        if (result > 0)
                        {
                            DialogResult dialogResult = MessageBox.Show("Updated");
                            
                        }
                        else
                        {
                            MessageBox.Show("Faild");
                        }

                    }

                } catch (Exception ex)
                {
                    MessageBox.Show("An Error Occued" + ex.Message);
                }
                finally
                {
                    Conn.Close();
                }
            }
        }


        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        //update stock
        private void button3_Click(object sender, EventArgs e)
        {
            // Validate and parse inputs
            if (string.IsNullOrWhiteSpace(textBox8.Text))
            {
                MessageBox.Show("Please scan the barcode.");
                textBox8.Focus();
                return;
            }

            if (!long.TryParse(textBox8.Text, out long bar_code))
            {
                MessageBox.Show("Invalid barcode. Please enter a valid number.");
                textBox8.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(comboBox2.Text))
            {
                MessageBox.Show("Please select or enter the product category.");
                comboBox2.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter the product name.");
                textBox1.Focus();
                return;
            }

            if (!int.TryParse(textBox6.Text, out int quantity))
            {
                MessageBox.Show("Invalid quantity. Please enter a valid number.");
                textBox6.Focus();
                return;
            }

            if (!int.TryParse(textBox4.Text, out int p_cost))
            {
                MessageBox.Show("Invalid product cost. Please enter a valid number.");
                textBox4.Focus();
                return;
            }

            if (!int.TryParse(textBox5.Text, out int p_price))
            {
                MessageBox.Show("Invalid product price. Please enter a valid number.");
                textBox5.Focus();
                return;
            }

            string product_category = comboBox2.Text;
            string product_name = textBox1.Text;
            DateTime expire_date = dateTimePicker1.Value;

            
            string query = "UPDATE Products SET p_category = @p_category, p_name = @p_name, quantity = @quantity, " +
                           "expire_date = @expire_date, p_cost = @p_cost, p_price = @p_price WHERE bar_code = @bar_code";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    int quentity1 = 0;
                    if (int.TryParse(textBox9.Text, out quentity1)) { };
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Add parameters explicitly
                        cmd.Parameters.Add(new SqlParameter("@bar_code", SqlDbType.BigInt) { Value = bar_code });
                        cmd.Parameters.Add(new SqlParameter("@p_category", SqlDbType.NVarChar) { Value = product_category });
                        cmd.Parameters.Add(new SqlParameter("@p_name", SqlDbType.NVarChar) { Value = product_name });
                        cmd.Parameters.Add(new SqlParameter("@quantity", SqlDbType.Int) { Value = (quantity + quentity1) });
                        cmd.Parameters.Add(new SqlParameter("@expire_date", SqlDbType.DateTime) { Value = expire_date });
                        cmd.Parameters.Add(new SqlParameter("@p_cost", SqlDbType.Int) { Value = p_cost });
                        cmd.Parameters.Add(new SqlParameter("@p_price", SqlDbType.Int) { Value = p_price });

                        
                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Stock successfully updated.");

                            // Clear input fields
                            textBox8.Clear();
                            comboBox2.Text = "";
                            textBox1.Clear();
                            textBox6.Clear();
                            textBox4.Clear();
                            textBox5.Clear();
                            dateTimePicker1.Value = DateTime.Now;
                            textBox8.Focus();
                            textBox9.Clear();
                        }
                        else
                        {
                            MessageBox.Show("No stock found with the provided barcode.");
                        }
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

        //removestock

        private void button2_Click(object sender, EventArgs e)
        {
            long code;
            if (!long.TryParse(textBox8.Text, out code))
            { }

            if (textBox8.Text.Length == 0)
            {
                MessageBox.Show("Please enter a valid Bar Code to remove stock.");
                return;
            }

            String quary = "DELETE FROM Products WHERE bar_code = @bar_code";

            using (SqlConnection connec = new SqlConnection(connectionString))
            {
                try
                {
                    connec.Open();

                    using (SqlCommand cmdd = new SqlCommand(quary, connec))
                    {
                        cmdd.Parameters.AddWithValue("@bar_code", code);
                       
                        int result = cmdd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Stock successfully removed.");
                            textBox8.Clear();
                            comboBox2.Items.Clear();
                            textBox1.Clear();
                            dateTimePicker1.Value = DateTime.Now;
                            textBox4.Clear();
                            textBox5.Clear();
                            textBox6.Clear();
                            textBox8.Focus();
                        }
                        else
                        {
                            MessageBox.Show("No stock found with the provided Bar Code.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
                finally
                {
                    connec.Close();
                }
            }





        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
          
            if (e.KeyCode == Keys.Enter)
            {
                long bar_code;
                if (!long.TryParse(textBox8.Text, out bar_code))
                {
                    MessageBox.Show("Please enter a valid Bar Code.");
                    return;
                }
                else
                {
                    textBox6.ReadOnly = true;
                    //MessageBox.Show("Bar Code is valid. Editing of TextBox6 is now disabled.");
                }

                String queryy = "SELECT p_category, p_name, quantity, expire_date, p_cost, p_price FROM Products WHERE bar_code = @bar_code";

                using (SqlConnection connn = new SqlConnection(connectionString))
                {
                    try
                    {
                        connn.Open();

                        using (SqlCommand cmd = new SqlCommand(queryy, connn))
                        {
                            cmd.Parameters.AddWithValue("@bar_code", bar_code);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    // Populate the fields with the fetched data
                                    comboBox2.Text = reader["p_category"].ToString();
                                    textBox1.Text = reader["p_name"].ToString();
                                    textBox6.Text = reader["quantity"].ToString();
                                    dateTimePicker1.Value = Convert.ToDateTime(reader["expire_date"]);
                                    textBox4.Text = reader["p_cost"].ToString();
                                    textBox5.Text = reader["p_price"].ToString();

                                    
                                }
                                else
                                {
                                    MessageBox.Show("No product found with the provided Bar Code.");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                    finally
                    {
                        connn.Close();
                    }
                }

                // Prevents the 'ding' sound when pressing Enter
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}

