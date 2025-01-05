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

           
            txtPassword.PasswordChar = '●'; 

          
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
            const string correctPassword = "1234"; 
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

        private void btnOk_Click_2(object sender, EventArgs e)
        {

        }
    }

}
