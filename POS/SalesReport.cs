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
using Font = System.Drawing.Font;

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

            // Customize the DataGridView for a modern look
            CustomizeDataGridView(dataGridView1);
        }

        private void CustomizeDataGridView(DataGridView dgv)
        {
            // General Appearance
            dgv.BorderStyle = BorderStyle.None;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(39, 99, 184);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.BackgroundColor = Color.White;

            // Header Style
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Font
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            // Row Height
            dgv.RowTemplate.Height = 40;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
        //private void ExportToPdf(DataGridView gridView, string filePath)
        //{
        //    try
        //    {
        //        Document document = new Document();
        //        PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
        //        document.Open();

        //        PdfPTable pdfTable = new PdfPTable(gridView.Columns.Count);

        //        // Add headers
        //        foreach (DataGridViewColumn column in gridView.Columns)
        //        {
        //            PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
        //            pdfTable.AddCell(cell);
        //        }

        //        // Add rows
        //        foreach (DataGridViewRow row in gridView.Rows)
        //        {
        //            if (!row.IsNewRow)
        //            {
        //                foreach (DataGridViewCell cell in row.Cells)
        //                {
        //                    pdfTable.AddCell(cell.Value?.ToString() ?? string.Empty);
        //                }
        //            }
        //        }
        //        document.Add(pdfTable);
        //        document.Close();

        //        MessageBox.Show("PDF saved successfully.", "Success");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error exporting to PDF: {ex.Message}", "Error");
        //    }
        //}




        private void ExportToPdf(DataGridView gridView, string filePath)
        {
            try
            {
                // Create a new PDF document with margins
                Document document = new Document(PageSize.A4, 20f, 20f, 30f, 30f);
                PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
                document.Open();

                // Set the title font size to 16px and bold
                iTextSharp.text.Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);

                // Determine the title based on which button is enabled
                string Title = "";
                if (btnLoadInventoryReport.Enabled)
                {
                    Title = "Inventory report";
                }
                else if (btnLoadSalesReport.Enabled)
                {
                    Title = "Sales Report";
                }

                // Create title paragraph with the selected font
                Paragraph titleParagraph = new Paragraph(Title, titleFont);
                titleParagraph.Alignment = Element.ALIGN_CENTER; // Center the title
                titleParagraph.SpacingAfter = 15f; // Space after title
                document.Add(titleParagraph); // Add the title to the document


                // Create a table with the number of columns in the DataGridView
                PdfPTable pdfTable = new PdfPTable(gridView.Columns.Count)
                {
                    WidthPercentage = 100 // Fit the table to the page width
                };

                // Set font for table headers (14px)
                iTextSharp.text.Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14);

                // Add table headers
                foreach (DataGridViewColumn column in gridView.Columns)
                {
                    PdfPCell headerCell = new PdfPCell(new Phrase(column.HeaderText, headerFont))
                    {
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        Padding = 5,
                        BackgroundColor = new BaseColor(220, 220, 220) // Light gray background for headers
                    };
                    pdfTable.AddCell(headerCell);
                }

                // Set font for table cells (12px)
                iTextSharp.text.Font cellFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);

                // Add table rows
                foreach (DataGridViewRow row in gridView.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            PdfPCell dataCell = new PdfPCell(new Phrase(cell.Value?.ToString() ?? string.Empty, cellFont))
                            {
                                HorizontalAlignment = Element.ALIGN_CENTER,
                                Padding = 5
                            };
                            pdfTable.AddCell(dataCell);
                        }
                    }
                }

                // Add the table to the document
                document.Add(pdfTable);

                // Close the document
                document.Close();

                // Notify the user
                MessageBox.Show("PDF report generated successfully.", "Success");
            }
            catch (Exception ex)
            {
                // Display an error message if something goes wrong
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
