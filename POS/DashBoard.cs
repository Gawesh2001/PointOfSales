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
            AddItem addItem = new AddItem() { TopLevel = false, TopMost = true };
            addItem.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(addItem);
            addItem.Show();
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
    }
}
