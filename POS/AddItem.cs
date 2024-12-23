using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.Collections;

namespace POS
{
    public partial class AddItem : Form
    {
        public AddItem()
        {
            InitializeComponent();
            
        }
        public String connectionString = "Data Source=APSARA;Initial Catalog=SuperMarket;Integrated Security=True;Encrypt=False";
        private void AddItem_Load(object sender, EventArgs e)
        {

        }

     

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           

            long bar_code;
            if (long.TryParse(textBox2.Text, out bar_code)) { } ;

            String product_category = comboBox2.Text;

            String product_name = textBox1.Text;

            int quantity;
            if (int.TryParse(textBox1.Text, out quantity)) { } ;

            DateTime expire_date = dateTimePicker1.Value;


            int p_cost;
            if (int.TryParse (textBox4.Text, out p_cost)) { } ;

            int p_price;
            if (int.TryParse(textBox5.Text, out p_price)) { };



            
                                       
            String query = "INSERT INTO Products (bar_code , p_category , p_name , quantity , expire_date , p_cost , p_price) VALUES (@bar_code , @p_category , @p_name , @quentity ,@expire_date , @p_cost , @p_price) ";

            using (SqlConnection conn = new SqlConnection(connectionString)) 
            
            {
                try
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn)) 
                    {
                        cmd.Parameters.AddWithValue("@bar_code", bar_code);
                        cmd.Parameters.AddWithValue("@p_category", product_category);
                        cmd.Parameters.AddWithValue("@p_name",product_name);
                        cmd.Parameters.AddWithValue("@quentity", quantity);
                        cmd.Parameters.AddWithValue("@expire_date", expire_date);
                        cmd.Parameters.AddWithValue("@p_cost", p_cost);
                        cmd.Parameters.AddWithValue("@p_price", p_price);
                      
                        int result = cmd.ExecuteNonQuery();

                        if (result > 0) 
                        {
                            MessageBox.Show("Succesfully Stock Added");
                            this.Refresh();
                        }
                        else
                        {
                            MessageBox.Show("Faild");
                        }
                        

                    }
                }catch (Exception ex) 
                {
                    MessageBox.Show("An Error Occued" + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

        }



        // Update Part


        private void button5_Click(object sender, EventArgs e)
        {
            string categoryCode = textBox2.Text;
            string categoryName = textBox3.Text;


          
            String Query = "INSERT INTO category ( category_code,category_name) VALUES(@c_code,@c_name)";

            using (SqlConnection Conn = new SqlConnection(connectionString))
            {
                try
                {
                    Conn.Open();
                    using (SqlCommand cmdD = new SqlCommand(Query, Conn))
                    {

                        cmdD.Parameters.AddWithValue("@c_code", categoryCode);
                        cmdD.Parameters.AddWithValue("@c_name", categoryName);

                        int result = cmdD.ExecuteNonQuery();

                        if (result > 0)
                        {
                            DialogResult dialogResult = MessageBox.Show("Updated");
                            this.Refresh();
                        }
                        else
                        {
                            MessageBox.Show("Faild");
                        }

                    }






                } catch (Exception ex)
                {
                    MessageBox.Show("An Error Occued" + ex.Message);
                }
                finally
                {
                    Conn.Close();
                }







            }
        }

               
            






            







        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
