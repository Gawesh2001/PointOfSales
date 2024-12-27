using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace POS
{
    public partial class Workspace : Form
    {
        public Workspace()
        {
            InitializeComponent();

            this.ActiveControl = textBox3;

            //double subtotal = 0;
            double total = 0;

            //// Adding rows to the DataGridView and calculating subtotal and total
            //for (int i = 1; i <= 10; i++)
            //{
            //    double quantity = 12;
            //    double unitPrice = 30.00;
            //    subtotal = quantity * unitPrice;

            //    // Add row to the DataGridView
            //    billGridView.Rows.Add(i, "CS001", "Tikiri Marie", quantity, unitPrice.ToString("F2"), subtotal.ToString("F2"));

            //    // Update item count label
            //    lblItemCount.Text = i.ToString();

            //    // Calculate and display total
            //    total += subtotal; // Add to total dynamically
            //}

            // Set the total label
            lblTotal.Text = total.ToString("F2");

            // Initialize discount field
            txtDiscount.Text = 0.ToString("F2");
            txtDiscount.Tag = "0";  // Assign a default value to Tag if it is not set elsewhere
            if (txtDiscount.Text == "0.00")
            {
                txtDiscount.ForeColor = Color.Gray;
            }
            else
            {
                txtDiscount.ForeColor = Color.Black;
            }




        }


        

       public String connectionString = "Data Source=GAWESH\\SQLEXPRESS;Initial Catalog=SuperMarket;Integrated Security=True;Encrypt=False";
        SqlCommand cmd;
        private double CalculateTotal(double currentTotal, string discountType, double discountAmount)
        {
            double newTotal = currentTotal; // Use current total


            if (discountType == "Percentage")
            {
                newTotal -= currentTotal * (discountAmount / 100); // Calculate percentage discount
                double subAmount = currentTotal * (discountAmount / 100);
                txtDiscount.Text = subAmount.ToString("F2");
            }
            else if (discountType == "Fixed")
            {
                newTotal -= discountAmount; // Subtract fixed amount
                double subAmount = discountAmount;
                txtDiscount.Text = subAmount.ToString("F2");
            }

            return newTotal;
        }

        private void txtDiscount_Click(object sender, EventArgs e)
        {
            // Show the Password Form
            PasswordForm passwordForm = new PasswordForm();
            if (passwordForm.ShowDialog() == DialogResult.OK)
            {
                // If password is correct, show the DiscountForm
                DiscountForm discountForm = new DiscountForm();




                // Pass the current discount values to the DiscountForm
                discountForm.DiscountType = txtDiscount.Tag.ToString(); // Save the discount type to the Tag
                discountForm.DiscountAmount = double.Parse(txtDiscount.Text);

                if (discountForm.ShowDialog() == DialogResult.OK)
                {
                    // Get discount details
                    string discountType = discountForm.DiscountType;
                    double discountAmount = discountForm.DiscountAmount;

                    // Calculate the total with the discount
                    double currentTotal = double.Parse(lblTotal.Text); // Get current total from the label
                    double newTotal = CalculateTotal(currentTotal, discountType, discountAmount);
                    lblTotal.Text = newTotal.ToString("F2"); // Update the total label

                    // Update the discount display
                    txtDiscount.Text = discountAmount.ToString("F2");
                    txtDiscount.Tag = discountType;  // Store the discount type for future use
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void billGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Workspace_Load(object sender, EventArgs e)
        {

        }

        
        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                long bar_code;
                if (!long.TryParse(textBox3.Text, out bar_code))
                {
                    MessageBox.Show("Bar code is not filled or wrong");
                    textBox3.Focus();
                    return;
                }

                String query = "SELECT p_name, quantity, p_price FROM Products WHERE bar_code = @bar_code";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@bar_code", bar_code);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    
                                  
                                    textBox4.Text = reader["p_name"].ToString();
                                    textBox2.Text = reader["quantity"].ToString();
                                    textBox6.Text = reader["p_price"].ToString();
                                    textBox5.Focus();

                                }
                                else
                                {
                                    MessageBox.Show("No product found with the provided Bar Code.");
                                    textBox3.Clear();
                                    textBox3.Focus ();
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
                        conn.Close();
                    }
                }
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            float total = 0.2f;
            int quantity = 0;
            int u_price = 0;
            if (e.KeyCode == Keys.Enter) {
                if (int.TryParse(textBox6.Text, out u_price))
                    if (int.TryParse(textBox5.Text, out quantity))
                    total = quantity * u_price;
                textBox7.Text = total.ToString("F2");
            textBox7.Focus();
            }
        }
       public decimal newTotal = 0;
        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {

            decimal t_price = 0;
            
            if (e.KeyCode == Keys.Enter)
            {


                if (decimal.TryParse(textBox7.Text, out t_price))
                {
                   
                    decimal currentTotal = 0;
                    decimal.TryParse(lblTotal.Text, out currentTotal);

                   
                    newTotal = currentTotal + t_price;

                   
                    lblTotal.Text = newTotal.ToString("F2");
                }
                else
                {
                    MessageBox.Show("Please enter a valid number in the textbox.");
                }




                e.SuppressKeyPress = true; 

                
                if (!string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    listBox1.Items.Add(textBox3.Text);
                    textBox3.Clear(); 
                }
                if (!string.IsNullOrWhiteSpace(textBox4.Text))
                {
                    listBox2.Items.Add(textBox4.Text);
                    textBox4.Clear();
                }
                if (!string.IsNullOrWhiteSpace(textBox5.Text))
                {
                    listBox3.Items.Add(textBox5.Text);
                    textBox5.Clear();
                }
                if (!string.IsNullOrWhiteSpace(textBox6.Text))
                {
                    listBox4.Items.Add(textBox6.Text);
                    textBox6.Clear();
                }
                if (!string.IsNullOrWhiteSpace(textBox7.Text))
                {
                    listBox5.Items.Add(textBox7.Text);
                    textBox7.Clear();
                    textBox3.Focus();
                }
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Workspace workspace = new Workspace();
            workspace.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DashBoard dashBoard = new DashBoard();
            dashBoard.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1) 
            {
               
                int selectedIndex = listBox1.SelectedIndex;

           
            if (decimal.TryParse(listBox5.Items[selectedIndex].ToString(), out decimal valueToDeduct))
            {
                
                newTotal -= valueToDeduct;

                
                lblTotal.Text = newTotal.ToString("F2"); 
            }
            else
            {
                MessageBox.Show("Failed to parse the value from listBox5. Please check the data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            listBox1.Items.RemoveAt(selectedIndex);
            listBox2.Items.RemoveAt(selectedIndex);
            listBox3.Items.RemoveAt(selectedIndex);
            listBox4.Items.RemoveAt(selectedIndex);
            listBox5.Items.RemoveAt(selectedIndex);

            
            MessageBox.Show("Row deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    else
    {
        MessageBox.Show("Please select a barcode from the list to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}


        private void button11_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            String Pass = "1234";
            decimal dis = 0;
            decimal total = 0;
            if (e.KeyChar == (char)Keys.Enter)
            {

                
                decimal.TryParse(txtDiscount.Text, out dis);
                decimal.TryParse(lblTotal.Text, out total);

                if (textBox8.Text == Pass)
                {

                    decimal result = total + (total * dis) / 100;
                    lblTotal.Text = result.ToString("F2");
                }
                else
                {
                    MessageBox.Show("Admin Password is wrong");
                }
            }
        }

        
        
        private void LoadNextDonorID()
{
    try
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT ISNULL(MAX(bill_id), 999999) + 1 FROM Billings", conn))
            {
                object result = cmd.ExecuteScalar();
                int nextID = (result != null && result != DBNull.Value) ? Convert.ToInt32(result) : 1000; // Default if null
                label4.Text = nextID.ToString();
            }
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Error loading next  ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}

        private void button5_Click(object sender, EventArgs e)
        {
            LoadNextDonorID();





            textBox9.Text = newTotal.ToString();
            textBox10.Text = txtDiscount.Text;
            textBox11.Text = lblTotal.Text;
            textBox12.Focus();

            

            

        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            decimal balance = 0;
            decimal r_amount = 0;
            decimal t_amount = 0;
            decimal.TryParse(textBox11.Text, out t_amount);
            decimal.TryParse(textBox12.Text, out r_amount);

            if (e.KeyChar == (char)Keys.Enter)
            {
                balance = r_amount - t_amount;
                textBox13.Text = balance.ToString("F2");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox12.Focus();
            checkBox1.Checked = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox12.Text = null;
            textBox13.Text = null;
            checkBox2.Checked = true;

            
        }

        private void button11_Click_1(object sender, EventArgs e)
        {

            long b_id = 0;
            long.TryParse(label4.Text, out b_id);
            String Cashier = comboBox5.Text;
            decimal b_amount = 0;
            decimal.TryParse(textBox9.Text, out b_amount);
            decimal discount = 0;
            decimal.TryParse(textBox10.Text, out discount);
            decimal recive = 0;
            decimal.TryParse(textBox12.Text, out recive);
            decimal bal = 0;
            decimal.TryParse(textBox13.Text, out bal);
            decimal cash = 0;
            decimal card = 0;
            if (checkBox1.Checked)
            {
                decimal.TryParse(textBox11.Text, out cash);
            } else if (checkBox2.Checked) {
                decimal.TryParse(textBox11.Text, out card);
            }

            String station = comboBox4.Text;
            





            String Query = "INSERT INTO Billings (bill_id,c_name,bill_amount,discount,r_amount,balance,cash,card,station) VALUES (@bill_id,@c_name,@bill_amount,@discount,@r_amount,@balance,@cash,@card,@station)";
            string itemBillingQuery = "INSERT INTO item_wise_billings (bil_id, p_code, p_name, quentity, unit_price, total) VALUES (@bill_id, @p_code, @p_name, @quantity, @unit_price, @total)";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand(Query, con))
                    {
                        
                        com.Parameters.AddWithValue("@bill_id",b_id);
                        com.Parameters.AddWithValue("@c_name",Cashier);
                        com.Parameters.AddWithValue("@bill_amount",b_amount);
                        com.Parameters.AddWithValue("@discount",discount);
                        com.Parameters.AddWithValue("@r_amount",recive);
                        com.Parameters.AddWithValue("@balance",bal);
                        com.Parameters.AddWithValue("@cash",cash);
                        com.Parameters.AddWithValue("@card",card);
                        com.Parameters.AddWithValue("@station",station);


                        int result = com.ExecuteNonQuery();

                        if (result <= 0)
                        {
                           
                            MessageBox.Show("Failed to insert into Billings table.");
                            return;
                        }
                        


                    }
                    for (int i = 0; i < listBox1.Items.Count; i++)
                    {
                        using (SqlCommand cmdItemBilling = new SqlCommand(itemBillingQuery, con))
                        {
                            cmdItemBilling.Parameters.AddWithValue("@bill_id", b_id);
                            cmdItemBilling.Parameters.AddWithValue("@p_code", listBox1.Items[i].ToString());
                            cmdItemBilling.Parameters.AddWithValue("@p_name", listBox2.Items[i].ToString());
                            cmdItemBilling.Parameters.AddWithValue("@quantity", Convert.ToDecimal(listBox3.Items[i].ToString()));
                            cmdItemBilling.Parameters.AddWithValue("@unit_price", Convert.ToDecimal(listBox4.Items[i].ToString()));
                            cmdItemBilling.Parameters.AddWithValue("@total", Convert.ToDecimal(listBox5.Items[i].ToString()));

                            cmdItemBilling.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Billing and item-wise billing successful.");
                    this.Close();
                    Workspace workspace = new Workspace();
                    workspace.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            
            }


            
            
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }
}
