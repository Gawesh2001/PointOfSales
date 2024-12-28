namespace POS
{
    partial class SalesReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnLoadSalesReport = new System.Windows.Forms.Button();
            this.btnLoadInventoryReport = new System.Windows.Forms.Button();
            this.btnExportToPdf = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Location = new System.Drawing.Point(3, 216);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1650, 994);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnLoadSalesReport
            // 
            this.btnLoadSalesReport.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnLoadSalesReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoadSalesReport.FlatAppearance.BorderSize = 0;
            this.btnLoadSalesReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadSalesReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadSalesReport.ForeColor = System.Drawing.Color.White;
            this.btnLoadSalesReport.Location = new System.Drawing.Point(12, 27);
            this.btnLoadSalesReport.Name = "btnLoadSalesReport";
            this.btnLoadSalesReport.Size = new System.Drawing.Size(327, 65);
            this.btnLoadSalesReport.TabIndex = 1;
            this.btnLoadSalesReport.Text = "Load Sales Report";
            this.btnLoadSalesReport.UseVisualStyleBackColor = false;
            this.btnLoadSalesReport.Click += new System.EventHandler(this.btnLoadSalesReport_Click_1);
            // 
            // btnLoadInventoryReport
            // 
            this.btnLoadInventoryReport.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnLoadInventoryReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoadInventoryReport.FlatAppearance.BorderSize = 0;
            this.btnLoadInventoryReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadInventoryReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadInventoryReport.ForeColor = System.Drawing.Color.White;
            this.btnLoadInventoryReport.Location = new System.Drawing.Point(345, 27);
            this.btnLoadInventoryReport.Name = "btnLoadInventoryReport";
            this.btnLoadInventoryReport.Size = new System.Drawing.Size(324, 65);
            this.btnLoadInventoryReport.TabIndex = 2;
            this.btnLoadInventoryReport.Text = "Load Inventory Report";
            this.btnLoadInventoryReport.UseVisualStyleBackColor = false;
            this.btnLoadInventoryReport.Click += new System.EventHandler(this.btnLoadInventoryReport_Click_1);
            // 
            // btnExportToPdf
            // 
            this.btnExportToPdf.BackColor = System.Drawing.Color.Red;
            this.btnExportToPdf.FlatAppearance.BorderSize = 0;
            this.btnExportToPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportToPdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportToPdf.ForeColor = System.Drawing.Color.White;
            this.btnExportToPdf.Location = new System.Drawing.Point(1434, 27);
            this.btnExportToPdf.Name = "btnExportToPdf";
            this.btnExportToPdf.Size = new System.Drawing.Size(185, 93);
            this.btnExportToPdf.TabIndex = 3;
            this.btnExportToPdf.Text = "Export to PDF";
            this.btnExportToPdf.UseVisualStyleBackColor = false;
            this.btnExportToPdf.Click += new System.EventHandler(this.btnExportToPdf_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(800, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = " ";
            // 
            // SalesReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1651, 1055);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnExportToPdf);
            this.Controls.Add(this.btnLoadInventoryReport);
            this.Controls.Add(this.btnLoadSalesReport);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "SalesReport";
            this.ShowIcon = false;
            this.Text = "Reports";
            this.Load += new System.EventHandler(this.SalesReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnLoadSalesReport;
        private System.Windows.Forms.Button btnLoadInventoryReport;
        private System.Windows.Forms.Button btnExportToPdf;
        private System.Windows.Forms.Label label1;
    }
}