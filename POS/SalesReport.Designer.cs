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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnLoadSalesReport = new System.Windows.Forms.Button();
            this.btnLoadInventoryReport = new System.Windows.Forms.Button();
            this.btnExportToPdf = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 308);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1650, 432);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnLoadSalesReport
            // 
            this.btnLoadSalesReport.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnLoadSalesReport.Font = new System.Drawing.Font("Aharoni", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadSalesReport.ForeColor = System.Drawing.Color.White;
            this.btnLoadSalesReport.Location = new System.Drawing.Point(420, 120);
            this.btnLoadSalesReport.Name = "btnLoadSalesReport";
            this.btnLoadSalesReport.Size = new System.Drawing.Size(194, 93);
            this.btnLoadSalesReport.TabIndex = 1;
            this.btnLoadSalesReport.Text = "Load Sales Report";
            this.btnLoadSalesReport.UseVisualStyleBackColor = false;
            this.btnLoadSalesReport.Click += new System.EventHandler(this.btnLoadSalesReport_Click_1);
            // 
            // btnLoadInventoryReport
            // 
            this.btnLoadInventoryReport.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnLoadInventoryReport.Font = new System.Drawing.Font("Aharoni", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadInventoryReport.ForeColor = System.Drawing.Color.White;
            this.btnLoadInventoryReport.Location = new System.Drawing.Point(689, 120);
            this.btnLoadInventoryReport.Name = "btnLoadInventoryReport";
            this.btnLoadInventoryReport.Size = new System.Drawing.Size(191, 93);
            this.btnLoadInventoryReport.TabIndex = 2;
            this.btnLoadInventoryReport.Text = "Load Inventory Report";
            this.btnLoadInventoryReport.UseVisualStyleBackColor = false;
            this.btnLoadInventoryReport.Click += new System.EventHandler(this.btnLoadInventoryReport_Click_1);
            // 
            // btnExportToPdf
            // 
            this.btnExportToPdf.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnExportToPdf.Font = new System.Drawing.Font("Aharoni", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportToPdf.ForeColor = System.Drawing.Color.White;
            this.btnExportToPdf.Location = new System.Drawing.Point(968, 120);
            this.btnExportToPdf.Name = "btnExportToPdf";
            this.btnExportToPdf.Size = new System.Drawing.Size(185, 93);
            this.btnExportToPdf.TabIndex = 3;
            this.btnExportToPdf.Text = "Export to PDF";
            this.btnExportToPdf.UseVisualStyleBackColor = false;
            this.btnExportToPdf.Click += new System.EventHandler(this.btnExportToPdf_Click_1);
            // 
            // SalesReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1650, 740);
            this.Controls.Add(this.btnExportToPdf);
            this.Controls.Add(this.btnLoadInventoryReport);
            this.Controls.Add(this.btnLoadSalesReport);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "SalesReport";
            this.Text = "55";
            this.Load += new System.EventHandler(this.SalesReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnLoadSalesReport;
        private System.Windows.Forms.Button btnLoadInventoryReport;
        private System.Windows.Forms.Button btnExportToPdf;
    }
}