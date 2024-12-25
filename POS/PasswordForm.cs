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
    public partial class PasswordForm : Form
    {
        public bool IsPasswordValid { get; private set; } = false;

        public PasswordForm()
        {
            InitializeComponent();

            // Set up the password TextBox to mask input
            txtPassword.PasswordChar = '●'; // Masking character

            // Attach KeyDown event for handling Enter key
            txtPassword.KeyDown += TxtPassword_KeyDown;
        }



        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ValidatePassword();
            }
        }

        private void ValidatePassword()
        {
            const string correctPassword = "1234"; // Replace with your password
            if (txtPassword.Text == correctPassword)
            {
                IsPasswordValid = true;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                lblError.Text = "Incorrect password!";
                txtPassword.Clear();
            }
        }

        private void btnOk_Click_1(object sender, EventArgs e)
        {
            ValidatePassword();
        }
    }

}
