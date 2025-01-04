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
            //LoadSalesReport();
        }
        private void LoadSalesReport()
        {
            // Initialize variables to store the total cash and card values
            decimal totalCash = 0;
            decimal totalCard = 0;

            // Query to fetch the data
            string query = "SELECT bill_id AS [Bill ID], c_name AS [Cashier], bill_amount AS [Sale], " +
                           "discount AS [Discounts], cash AS [Cash Settled], " +
                           "card AS [Card Settled], date AS [Bill Date] FROM Billings";

            // Create a connection and data adapter to fetch data from the database
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Open the connection
                conn.Open();

                // Create the data adapter to execute the query and fill the DataTable
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                // Create a DataTable to hold the query result
                DataTable dataTable = new DataTable();

                // Fill the DataTable with the query result
                adapter.Fill(dataTable);

                // Set the DataGridView data source
                dataGridView1.DataSource = dataTable;

                // Loop through the rows of the DataTable to calculate totals for cash and card
                foreach (DataRow row in dataTable.Rows)
                {
                    // Add the cash and card values from each row to the totals
                    totalCash += Convert.ToDecimal(row["Cash Settled"]);
                    totalCard += Convert.ToDecimal(row["Card Settled"]);
                }

                // Display the totals (optional: you could display them in labels or some other controls)
                label2.Text = "Total Cash RS: " + totalCash.ToString("F2");
                label3.Text = "Total Card RS: " + totalCard.ToString("F2");
                label4.Text = "Total Sale RS: " + (totalCard + totalCash).ToString("F2");
                // Customize the DataGridView for a modern look
                CustomizeDataGridView(dataGridView1);
            }
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

            // Row Height (Reduced column height)
            dgv.RowTemplate.Height = 30;  // Reduced height for rows
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Scrolling Option
            dgv.ScrollBars = ScrollBars.Both; // Enables both horizontal and vertical scrolling
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None; // Avoid automatic resizing of rows

            // Force the DataGridView layout update to apply scrollbars immediately
            dgv.PerformLayout();  // Force layout update for immediate visual changes

            // Ensure the container has scrolling enabled
            if (dgv.Parent is Panel panel)
            {
                panel.AutoScroll = true;  // This allows scrolling for the parent container if needed
            }

            // Ensure the DataGridView has enough height to display scrollbars
            dgv.Height = 450;  // Set a fixed height for the DataGridView if not set already
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
                string Title = label1.Text;

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

                // Add the labels (label2, label3, label4) at the bottom of the page
                // Create a table with 3 columns for the bottom labels
                PdfPTable bottomTable = new PdfPTable(3)
                {
                    WidthPercentage = 100 // Fit the table to the page width
                };

                if (btnLoadSalesReport.Enabled)
                {
                    // Add left-aligned label (label2)
                    PdfPCell leftCell = new PdfPCell(new Phrase(label2.Text, cellFont))
                    {
                        HorizontalAlignment = Element.ALIGN_LEFT,
                        Padding = 5,
                        Border = iTextSharp.text.Rectangle.NO_BORDER
                    };
                    bottomTable.AddCell(leftCell);

                    // Add center-aligned label (label3)
                    PdfPCell centerCell = new PdfPCell(new Phrase(label3.Text, cellFont))
                    {
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        Padding = 5,
                        Border = iTextSharp.text.Rectangle.NO_BORDER
                    };
                    bottomTable.AddCell(centerCell);

                    // Add right-aligned label (label4)
                    PdfPCell rightCell = new PdfPCell(new Phrase(label4.Text, cellFont))
                    {
                        HorizontalAlignment = Element.ALIGN_RIGHT,
                        Padding = 5,
                        Border = iTextSharp.text.Rectangle.NO_BORDER
                    };
                    bottomTable.AddCell(rightCell);
                }
                

                // Add the bottom table to the document
                document.Add(bottomTable);

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
            label1.Text = "Sales Report";
            LoadSalesReport();
        }

        private void btnLoadInventoryReport_Click_1(object sender, EventArgs e)
        {
            label1.Text = "Inventory Report";
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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        public static class InputDialog
        {
            public static string Show(string text, string caption, string defaultValue = "")
            {
                Form prompt = new Form()
                {
                    Width = 400,
                    Height = 200,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = caption,
                    StartPosition = FormStartPosition.CenterScreen
                };

                Label textLabel = new Label() { Left = 20, Top = 20, Text = text, Width = 340 };
                TextBox inputBox = new TextBox() { Left = 20, Top = 50, Width = 340, Text = defaultValue };
                Button confirmButton = new Button() { Text = "OK", Left = 200, Width = 100, Top = 100, DialogResult = DialogResult.OK };
                Button cancelButton = new Button() { Text = "Cancel", Left = 80, Width = 100, Top = 100, DialogResult = DialogResult.Cancel };

                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(inputBox);
                prompt.Controls.Add(confirmButton);
                prompt.Controls.Add(cancelButton);

                prompt.AcceptButton = confirmButton;
                prompt.CancelButton = cancelButton;

                return prompt.ShowDialog() == DialogResult.OK ? inputBox.Text : null;
            }
        }




        private void button1_Click(object sender, EventArgs e)
        {
            string inputDateString = InputDialog.Show(
    "Enter the date for the report (yyyy-MM-dd):",
    "Daily Report",
    DateTime.Now.ToString("yyyy-MM-dd")
);

            if (DateTime.TryParse(inputDateString, out DateTime selectedDate))
            {
                // Query with parameterized date
                string query = @"
        SELECT 
            bill_id AS [Bill ID], 
            c_name AS [Cashier], 
            bill_amount AS [Sale], 
            discount AS [Discounts], 
            cash AS [Cash Settled], 
            card AS [Card Settled], 
            date AS [Bill Date]
        FROM 
            Billings
        WHERE 
            CAST(date AS DATE) = @SelectedDate 
            AND date IS NOT NULL; -- Exclude NULL values
    ";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();

                        using (SqlCommand command = new SqlCommand(query, conn))
                        {
                            // Add the parameter explicitly
                            command.Parameters.Add(new SqlParameter("@SelectedDate", SqlDbType.Date)
                            {
                                Value = selectedDate.Date
                            });

                            SqlDataAdapter adapter = new SqlDataAdapter(command);
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            dataGridView1.DataSource = dataTable;

                            // Calculate totals
                            decimal totalCash = 0;
                            decimal totalCard = 0;

                            foreach (DataRow row in dataTable.Rows)
                            {
                                totalCash += row["Cash Settled"] != DBNull.Value ? Convert.ToDecimal(row["Cash Settled"]) : 0;
                                totalCard += row["Card Settled"] != DBNull.Value ? Convert.ToDecimal(row["Card Settled"]) : 0;
                            }

                            // Display totals
                            label2.Text = $"Total Cash RS: {totalCash:F2}";
                            label3.Text = $"Total Card RS: {totalCard:F2}";
                            label4.Text = $"Total Sale RS: {(totalCash + totalCard):F2}";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading daily report: {ex.Message}", "Error");
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid date entered. Please try again.", "Error");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string inputMonth = InputDialog.Show("Enter the month and year for the report (MM-yyyy):", "Monthly Report", DateTime.Now.ToString("MM-yyyy"));

            if (DateTime.TryParseExact(inputMonth, "MM-yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime selectedMonth))
            {
                string query = "SELECT bill_id AS [Bill ID], c_name AS [Cashier], bill_amount AS [Sale], \r\n  " +
                    "     discount AS [Discounts], cash AS [Cash Settled], \r\n" +
                    "       card AS [Card Settled], date AS [Bill Date]\r\nFROM Billings\r\nWHERE MONTH(date) = @Month \r\n" +
                    "      AND YEAR(date) = @Year\r\n      AND date IS NOT NULL; -- Exclude NULL values\r\n";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                        adapter.SelectCommand.Parameters.AddWithValue("@Month", selectedMonth.Month);
                        adapter.SelectCommand.Parameters.AddWithValue("@Year", selectedMonth.Year);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;

                        // Calculate totals
                        decimal totalCash = 0;
                        decimal totalCard = 0;
                        foreach (DataRow row in dataTable.Rows)
                        {
                            totalCash += Convert.ToDecimal(row["Cash Settled"]);
                            totalCard += Convert.ToDecimal(row["Card Settled"]);
                        }

                        // Display totals
                        label2.Text = "Total Cash RS: " + totalCash.ToString("F2");
                        label3.Text = "Total Card RS: " + totalCard.ToString("F2");
                        label4.Text = "Total Sale RS: " + (totalCash + totalCard).ToString("F2");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading monthly report: {ex.Message}", "Error");
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid month & year entered. Please try again.", "Error");
            }
        
        }
    }
}
