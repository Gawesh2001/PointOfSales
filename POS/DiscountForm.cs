using System;
using System.Windows.Forms;

namespace POS
{
    public partial class DiscountForm : Form
    {
        public string DiscountType { get; set; } = "Fixed"; // Make this a public property
        public double DiscountAmount { get; set; } = 0.00; // Make this a public property

        public DiscountForm()
        {
            InitializeComponent();
        }

        // Load discount settings into controls when the form is loaded
        private void DiscountForm_Load(object sender, EventArgs e)
        {
            // Set the discount type (Fixed or Percentage)
            cmbDiscountType.SelectedItem = DiscountType;

            // Set the discount amount
            txtDiscountAmount.Text = DiscountAmount.ToString("F2");
        }

        private void txtDiscountAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits and Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)  // 46 is the decimal point (.)
            {
                e.Handled = true;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Get the discount amount and type
            DiscountAmount = double.TryParse(txtDiscountAmount.Text, out double discountAmount) ? discountAmount : 0.00;
            DiscountType = cmbDiscountType.SelectedItem.ToString();

            // Close the form with OK result
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Close the form with Cancel result
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
