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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace POS
{
    public partial class DashBoard : Form
    {
        private string username;
        public DashBoard(string username)
        {
            InitializeComponent();
            this.username = username;
        }
        private void DashBoard_Load(object sender, EventArgs e)
        {
            
            label3.Text = username;
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Workspace workspaceForm = new Workspace() { TopLevel = false, TopMost = true };
            //workspaceForm.FormBorderStyle = FormBorderStyle.None;
            //panel3.Controls.Add(workspaceForm);
            //workspaceForm.Show();

            Workspace workspace = new Workspace();
            workspace.Show();
        }
        private bool authentication()
        {
            string username = label3.Text.ToLower();
           

            // Check if the user is allowed to access the SalesReport
            string connectionString = "Data Source=GAWESH\\SQLEXPRESS;Initial Catalog=SuperMarket;Integrated Security=True;Encrypt=False";
            string query = "SELECT user_level FROM Users WHERE username = @username";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);

                        // Execute the query
                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            int userLevel = Convert.ToInt32(result);
                            

                            if (userLevel == 1)
                            {
                                // If user_level is 1, allow access
                                return true;
                            }
                            else
                            {
                                // If the user is not authorized (user_level is not 1)
                                MessageBox.Show("You are not allowed to go to this page.");
                                return false;
                            }
                        }
                        else
                        {
                            // If no result found (user doesn't exist)
                            MessageBox.Show("User not found.");
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                    return false;
                }
            }
        }



        private void button4_Click(object sender, EventArgs e)
        {

            if (authentication())
            {
                // Proceed with the AddItem form if authentication is successful
                AddItem addItem = new AddItem() { TopLevel = false, TopMost = true };
                addItem.FormBorderStyle = FormBorderStyle.None;
                panel3.Controls.Add(addItem);
                addItem.Show();
            }
           
        }

        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (authentication())
            {

                // If user_level is 1, allow access to the SalesReport form
                SalesReport salesReportForm = new SalesReport() { TopLevel = false, TopMost = true };
                salesReportForm.FormBorderStyle = FormBorderStyle.None;
                panel3.Controls.Add(salesReportForm);
                salesReportForm.Show();
            }
        }

        

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (authentication())
            {
                CreateAcc createAcc = new CreateAcc();
                createAcc.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
