using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class SalesReport : Form
    {
        public String connectionString = "Data Source=GAWESH\\SQLEXPRESS;Initial Catalog=SuperMarket;Integrated Security=True;Encrypt=False";
      //  public String connectionString = "Data Source=DESKTOP-EN95E81\\SQLEXPRESS;Initial Catalog=SuperMarket;Integrated Security=True;Encrypt=False";
        public SalesReport()
        {
            InitializeComponent();
            LoadSalesReport();
        }
        private void LoadSalesReport()
        {
            string query = "SELECT p_id AS [Product ID], bar_code AS [Barcode], p_name AS [Product Name], " +
                           "quantity AS [Quantity], expire_date AS [Expiration Date], " +
                           "p_cost AS [Cost Price], p_price AS [Selling Price] FROM Products";
            LoadData(query);

        }
        // Method to Load Inventory Report
        private void LoadInventoryReport()
        {
            string query = "SELECT p_id AS [Product ID], p_name AS [Product Name], quantity AS [Stock Available] FROM Products";
            LoadData(query);
        }
        // General Method to Load Data into DataGridView
        private void LoadData(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data: {ex.Message}", "Error");
                }
            }
        }
        // Method to Export DataGridView to PDF
        private void ExportToPdf(DataGridView gridView, string filePath)
        {
            try
            {
                Document document = new Document();
                PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
                document.Open();

                PdfPTable pdfTable = new PdfPTable(gridView.Columns.Count);

                // Add headers
                foreach (DataGridViewColumn column in gridView.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                    pdfTable.AddCell(cell);
                }

                // Add rows
                foreach (DataGridViewRow row in gridView.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            pdfTable.AddCell(cell.Value?.ToString() ?? string.Empty);
                        }
                    }
                }
                document.Add(pdfTable);
                document.Close();

                MessageBox.Show("PDF saved successfully.", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting to PDF: {ex.Message}", "Error");
            }
        }







        private void SalesReport_Load(object sender, EventArgs e)
{
//empty
}

        private void btnLoadSalesReport_Click_1(object sender, EventArgs e)
        {
            LoadSalesReport();
        }

        private void btnLoadInventoryReport_Click_1(object sender, EventArgs e)
        {
            LoadInventoryReport();
        }

        private void btnExportToPdf_Click_1(object sender, EventArgs e)
        {

            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PDF Files (.pdf)|.pdf",
                    FileName = "Report.pdf"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportToPdf(dataGridView1, saveFileDialog.FileName);
                }
            }
            else
            {
                MessageBox.Show("No data to export.", "Info");
            }
        }
    }
}
