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
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
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

        private void button4_Click(object sender, EventArgs e)
        {
            AddItem addItem = new AddItem() { TopLevel = false, TopMost = true };
            addItem.FormBorderStyle = FormBorderStyle.None;
            panel3.Controls.Add(addItem);
            addItem.Show();
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            SalesReport salesReportForm = new SalesReport() { TopLevel = false, TopMost = true };
            salesReportForm.FormBorderStyle = FormBorderStyle.None;
            panel3.Controls.Add(salesReportForm);
            salesReportForm.Show();

          
        }
    }
}
