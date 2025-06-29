﻿using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
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
                discountForm.DiscountType = txtDiscount.Tag.ToString(); 
                discountForm.DiscountAmount = double.Parse(txtDiscount.Text);

                if (discountForm.ShowDialog() == DialogResult.OK)
                {
                    
                    string discountType = discountForm.DiscountType;
                    double discountAmount = discountForm.DiscountAmount;

             
                    double currentTotal = double.Parse(lblTotal.Text); 
                    double newTotal = CalculateTotal(currentTotal, discountType, discountAmount);
                    lblTotal.Text = newTotal.ToString("F2"); 

                   
                    txtDiscount.Text = discountAmount.ToString("F2");
                    txtDiscount.Tag = discountType;  
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

                if (comboBox5.Text.Length == 0)
                {
                    MessageBox.Show("Select a Cashier Name before proceeding.");
                    comboBox5.Focus();
                    return;
                }

                // Check if the cashier is signed in
                string checkQuery = "SELECT COUNT(*) FROM Sign_in WHERE c_name = @c_name AND sign_in = 'ON' AND sign_off IS NULL";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();

                        using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                        {
                            checkCmd.Parameters.AddWithValue("@c_name", comboBox5.Text);

                            int isSignedIn = (int)checkCmd.ExecuteScalar();

                            if (isSignedIn == 0)
                            {
                                MessageBox.Show("The selected cashier is not signed in. Please sign in before proceeding.");
                                textBox3.Clear();
                                comboBox5.Focus();
                                return;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while checking cashier sign-in: " + ex.Message);
                        return;
                    }
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

                    decimal result = total - (total * dis) / 100;
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
            if (comboBox5.Text.Length == 0)
            {
                MessageBox.Show("Select a Cashier Name before proceeding.");
                comboBox5.Focus();
                return;
            }

            // Check if the cashier is signed in
            string checkQuery = "SELECT COUNT(*) FROM Sign_in WHERE c_name = @c_name AND sign_in = 'ON' AND sign_off IS NULL";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@c_name", comboBox5.Text);

                        int isSignedIn = (int)checkCmd.ExecuteScalar();

                        if (isSignedIn == 0)
                        {
                            MessageBox.Show("The selected cashier is not signed in. Please sign in before proceeding.");
                            textBox3.Clear();
                            comboBox5.Focus();
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while checking cashier sign-in: " + ex.Message);
                    return;
                }
            }

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
            if (checkBox2.Checked)
            {
                checkBox2.Checked = false;
            }
            checkBox1.Checked = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox12.Text = null;
            textBox13.Text = null;
            if (checkBox1.Checked)
            {
               checkBox1.Checked = false;
            }
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
                        string p_code = listBox1.Items[i].ToString();
                        decimal quantity = Convert.ToDecimal(listBox3.Items[i].ToString());
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

                        string updateProductQuery = "UPDATE Products SET quantity = quantity - @quantity WHERE bar_code = @bar_code";

                        using (SqlCommand cmdUpdateProduct = new SqlCommand(updateProductQuery, con))
                        {
                            cmdUpdateProduct.Parameters.AddWithValue("@quantity", quantity);
                            cmdUpdateProduct.Parameters.AddWithValue("@bar_code", p_code);

                            int updateResult = cmdUpdateProduct.ExecuteNonQuery();

                            if (updateResult <= 0)
                            {
                                MessageBox.Show($"Failed to update quantity for product with bar_code: {p_code}");
                                return;
                            }
                        }
                    }

                    MessageBox.Show("Billing successful.");
                    GeneratePdfReceipt(label4.Text); // Assuming `b_id` is the bill ID

                    //this.Close();
                    //Workspace workspace = new Workspace();
                    //workspace.Show();


                    string updateLoyaltyPointsQuery = "UPDATE Customers SET loyality_points =  @loyality_points WHERE cus_no = @cus_no";
                    using (SqlCommand cmdUpdateLoyalty = new SqlCommand(updateLoyaltyPointsQuery, con))
                    {
                        decimal newLoyaltyPoints = Convert.ToDecimal(lblItemCount.Text) + 1;
                        cmdUpdateLoyalty.Parameters.AddWithValue("@loyality_points", newLoyaltyPoints);
                        cmdUpdateLoyalty.Parameters.AddWithValue("@cus_no", textBox1.Text);

                        int loyaltyUpdateResult = cmdUpdateLoyalty.ExecuteNonQuery();
                        if (loyaltyUpdateResult <= 0)
                        {
                          //  MessageBox.Show("Failed to update loyalty points for the customer.");
                        }
                    }


                    if (checkBox3.Checked)
                    {
                        string deductLoyaltyPointsQuery = "UPDATE Customers SET loyality_points = loyality_points - @loyality_points WHERE cus_no = @cus_no";

                        using (SqlCommand cmdDeductLoyalty = new SqlCommand(deductLoyaltyPointsQuery, con))
                        {
                            decimal loyaltyPointsToDeduct = Convert.ToDecimal(lblItemCount.Text); 
                            cmdDeductLoyalty.Parameters.AddWithValue("@loyality_points", loyaltyPointsToDeduct);
                            cmdDeductLoyalty.Parameters.AddWithValue("@cus_no", textBox1.Text);

                            int loyaltyUpdateResult = cmdDeductLoyalty.ExecuteNonQuery();
                            if (loyaltyUpdateResult <= 0)
                            {
                               // MessageBox.Show("Failed to update loyalty points for the customer.");
                            }
                        }
                    }




                    listBox1.Items.Clear();
                    listBox2.Items.Clear();
                    listBox3.Items.Clear();
                    listBox4.Items.Clear();
                    listBox5.Items.Clear();
                    label4.Text = string.Empty;
                    txtDiscount.Text = string.Empty;
                    textBox8.Text = string.Empty;
                    lblTotal.Text = string.Empty;
                    textBox2.Text = string.Empty;
                    textBox9.Text = string.Empty;
                    textBox10.Text = string.Empty;
                    textBox11.Text = string.Empty;
                    textBox12.Text = string.Empty;
                    textBox13.Text = string.Empty;
                    checkBox1.Checked = false;
                    checkBox2.Checked = false;
                    textBox1.Clear();
                    lblItemCount.Text = string.Empty;
                    textBox3.Focus();

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

        private void GeneratePdfReceipt(string billId)
        {
            try
            {
                // Set up a page size for POS printers (3 inches x 8.5 inches)
                Document document = new Document(new iTextSharp.text.Rectangle(216f, 792f), 5f, 5f, 5f, 5f); // 3" x 8.5"
                string filePath = "receipt_" + billId + ".pdf";
                PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
                document.Open();

                iTextSharp.text.Font font = FontFactory.GetFont(FontFactory.HELVETICA, 7);

             
                Paragraph marketName = new Paragraph("Pic And Go", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16))
                {
                    Alignment = Element.ALIGN_CENTER,
                    SpacingAfter = 5f
                };
                document.Add(marketName);

                // Optionally, add an image logo if you have one (uncomment and adjust the file path)
                // Image logo = Image.GetInstance("logo.png");
                // logo.ScaleToFit(80f, 80f); // Adjust logo size for the compact layout
                // logo.Alignment = Element.ALIGN_CENTER;
                // document.Add(logo);

                // Add Bill ID as a title
                Paragraph title = new Paragraph("Receipt for Bill ID: " + billId, font)
                {
                    Alignment = Element.ALIGN_CENTER,
                    SpacingAfter = 8f
                };
                document.Add(title);

                // Add Date
                Paragraph date = new Paragraph("Date: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), font)
                {
                    Alignment = Element.ALIGN_CENTER,
                    SpacingAfter = 8f
                };
                document.Add(date);





              
                PdfPTable table = new PdfPTable(3)
                {
                    WidthPercentage = 100 
                };

               
                table.SetWidths(new float[] { 0.6f, 0.2f, 0.2f });

                
                table.DefaultCell.Border = 0;

                
                table.AddCell(new Phrase("Description", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8)));  
                table.AddCell(new Phrase("Qty", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8)));
                table.AddCell(new Phrase("Price (RS:)", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8)));

                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    string itemName = listBox2.Items[i].ToString();
                    decimal quantity = Convert.ToDecimal(listBox3.Items[i].ToString());
                    decimal total = Convert.ToDecimal(listBox5.Items[i].ToString());

                    // Add the Item Name to the first column (left-aligned)
                    table.AddCell(new Phrase(string.Format("{0,-15}", itemName), font));

                    // Add Quantity to the second column (center-aligned)
                    table.AddCell(new Phrase(string.Format("{0,3}", quantity), font));

                    // Add Price (RS:) to the third column (right-aligned)
                    table.AddCell(new Phrase(string.Format("{0,9}", total), font));

                }

                // Add the table to the document
                document.Add(table);


           
                Paragraph totalParagraph = new Paragraph(string.Format("Total: RS:{0,9}", Convert.ToDecimal(lblTotal.Text)), font)
                {
                    Alignment = Element.ALIGN_RIGHT,
                    SpacingBefore = 5f
                };
                document.Add(totalParagraph);


                // Add Description at the bottom of the receipt
                Paragraph description = new Paragraph("\nThank you for shopping with us! \n" +
                                                      "For inquiries, contact us: 075-607-9914\n" +
                                                      "No returns accepted. All sales are final.",
                                                      FontFactory.GetFont(FontFactory.HELVETICA, 10))
                {
                    Alignment = Element.ALIGN_CENTER,
                    SpacingBefore = 10f,
                    SpacingAfter = 10f
                };
                document.Add(description);

               
                document.Close();

                // Show success message
                //MessageBox.Show("PDF Receipt generated successfully.");

             
                System.Diagnostics.Process.Start(filePath);

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while generating the PDF receipt: " + ex.Message);
            }
        }


        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        
          
        }

        private void button12_Click(object sender, EventArgs e)
        {
            
            if (comboBox4.Text.Length == 0) {
                MessageBox.Show("Select A Station");
                comboBox4.Focus();
            }
            if (comboBox5.Text.Length == 0)
            {
                MessageBox.Show("Select A Cashire Name");
                comboBox5.Focus();
            }
            if (textBox14.Text.Length == 0)
            {
                MessageBox.Show("Enter Your Cash Drawer Amount");
                textBox14.Focus();
            }
            
            if (comboBox5.Text == "Cashier_Trix" && textBox15.Text == "123")
            { 
                sign_in();
            }else if (comboBox5.Text == "Cashier_Pheonix" && textBox15.Text == "456")
            {
                sign_in();
            }
            else if (comboBox5.Text == "Cashire_Nick" && textBox15.Text == "789")
            {
                sign_in();
            }
            else if (comboBox5.Text == "Cashire_Ted" && textBox15.Text == "741")
            {
                sign_in();
            }
            else if (comboBox5.Text == "Cashire_Tim" && textBox15.Text == "852")
            {
                sign_in();
            }
            else if (comboBox5.Text == "Cashire_Tize" && textBox15.Text == "963")
            {
                sign_in();
            }
            else if (comboBox5.Text == "Admin" && textBox15.Text == "123456")
            {
                sign_in();
            }else
            {
                MessageBox.Show("Password Is Wrong");
            }


        }
        private void sign_in()
        {

            string query = "INSERT INTO Sign_in (station, c_name, d_amount, sign_in, sign_in_time, sign_off, sign_off_time) " +
              "VALUES (@station, @c_name, @d_amount, @sign_in, @sign_in_time, @sign_off, @sign_off_time)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        
                        cmd.Parameters.AddWithValue("@station", comboBox4.Text);
                        cmd.Parameters.AddWithValue("@c_name", comboBox5.Text);
                        cmd.Parameters.AddWithValue("@d_amount", Convert.ToDecimal(textBox14.Text));
                        cmd.Parameters.AddWithValue("@sign_in", "ON");
                        cmd.Parameters.AddWithValue("@sign_in_time", DateTime.Now);
                        cmd.Parameters.AddWithValue("@sign_off", DBNull.Value); 
                        cmd.Parameters.AddWithValue("@sign_off_time", DBNull.Value); 

                      
                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show(comboBox5.Text + " Signed In Successfully");
                            textBox3.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Failed to Sign In. Please try again.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (comboBox5.Text.Length == 0)
            {
                MessageBox.Show("Select a Cashier Name");
                comboBox5.Focus();
                return;
            }

            
            string checkQuery = "SELECT COUNT(*) FROM Sign_in WHERE c_name = @c_name AND sign_in = 'ON'";
            string updateQuery = "UPDATE Sign_in " +
                                 "SET sign_off = @sign_off, sign_off_time = @sign_off_time " +
                                 "WHERE c_name = @c_name AND sign_in = 'ON'";

            using (SqlConnection co = new SqlConnection(connectionString))
            {
                try
                {
                    co.Open();

                    // Check if the cashier is signed in
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, co))
                    {
                        checkCmd.Parameters.AddWithValue("@c_name", comboBox5.Text);

                        int count = (int)checkCmd.ExecuteScalar();
                        if (count == 0)
                        {
                            MessageBox.Show(comboBox5.Text + " is not signed in.");
                            return;
                        }
                    }

                    // Proceed to sign off
                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, co))
                    {
                        updateCmd.Parameters.AddWithValue("@sign_off", "OFF");
                        updateCmd.Parameters.AddWithValue("@sign_off_time", DateTime.Now);
                        updateCmd.Parameters.AddWithValue("@c_name", comboBox5.Text);

                        int result = updateCmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show(comboBox5.Text + " Signed Off Successfully");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Failed to sign off. Please try again.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { 
             textBox14.Focus();
            }
        }

        private void textBox15_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { button12.Focus(); }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Customers customers = new Customers();
            customers.Show();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') {
                e.Handled = true;
                long customerNumber = Convert.ToInt64(textBox1.Text);




                try
                {
                    string query = "SELECT loyality_points FROM Customers WHERE cus_no = @cus_no";

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@cus_no", customerNumber);

                         
                            object result = cmd.ExecuteScalar();

                            if (result != null && result != DBNull.Value)
                            {
                               
                                lblItemCount.Text = Convert.ToDouble(result).ToString();
                                
                            }
                            else
                            {
                                MessageBox.Show("No customer found with the entered number.");
                                lblItemCount.Text = "0"; 
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }

            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            checkBox3.Checked = true;
            int points = Convert.ToInt32(lblItemCount.Text);
            double payble = Convert.ToDouble(lblTotal.Text);


            double result = payble - points;

            lblTotal.Text = result.ToString();
            

        }
    }
    }
    

