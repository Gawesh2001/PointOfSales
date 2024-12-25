using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class Workspace : Form
    {
        public Workspace()
        {
            InitializeComponent();

            double subtotal = 0;
            double total = 0;

            // Adding rows to the DataGridView and calculating subtotal and total
            for (int i = 1; i <= 10; i++)
            {
                double quantity = 12;
                double unitPrice = 30.00;
                subtotal = quantity * unitPrice;

                // Add row to the DataGridView
                billGridView.Rows.Add(i, "CS001", "Tikiri Marie", quantity, unitPrice.ToString("F2"), subtotal.ToString("F2"));

                // Update item count label
                lblItemCount.Text = i.ToString();

                // Calculate and display total
                total += subtotal; // Add to total dynamically
            }

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
    }
}
