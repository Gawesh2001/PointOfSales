using System;
using System.Windows.Forms;

namespace POS
{
    public partial class DiscountForm : Form
    {
        public string DiscountType { get; set; } = "Fixed"; 
        public double DiscountAmount { get; set; } = 0.00; 

        public DiscountForm()
        {
            InitializeComponent();
        }

       
        private void DiscountForm_Load(object sender, EventArgs e)
        {
          
            cmbDiscountType.SelectedItem = DiscountType;

          
            txtDiscountAmount.Text = DiscountAmount.ToString("F2");
        }

        private void txtDiscountAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
        
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)  
            {
                e.Handled = true;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            DiscountAmount = double.TryParse(txtDiscountAmount.Text, out double discountAmount) ? discountAmount : 0.00;
            DiscountType = cmbDiscountType.SelectedItem.ToString();

         
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
           
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
