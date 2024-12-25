using System.Drawing;
using System.Windows.Forms;

namespace POS
{
    partial class DiscountForm
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
            label1 = new Label();
            label2 = new Label();
            cmbDiscountType = new ComboBox();
            label3 = new Label();
            txtDiscountAmount = new TextBox();
            panel1 = new Panel();
            label5 = new Label();
            label4 = new Label();
            btnUpdate = new Button();
            btnCancel = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(92, 28);
            label1.TabIndex = 0;
            label1.Text = "Discount";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 93);
            label2.Name = "label2";
            label2.Size = new Size(128, 25);
            label2.TabIndex = 1;
            label2.Text = "Discount Type:";
            // 
            // cmbDiscountType
            // 
            cmbDiscountType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDiscountType.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbDiscountType.FormattingEnabled = true;
            cmbDiscountType.Items.AddRange(new object[] { "Fixed", "Percentage" });
            cmbDiscountType.Location = new Point(12, 131);
            cmbDiscountType.Name = "cmbDiscountType";
            cmbDiscountType.Size = new Size(320, 36);
            cmbDiscountType.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(420, 93);
            label3.Name = "label3";
            label3.Size = new Size(128, 25);
            label3.TabIndex = 3;
            label3.Text = "Discount Type:";
            // 
            // txtDiscountAmount
            // 
            txtDiscountAmount.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtDiscountAmount.Location = new Point(423, 131);
            txtDiscountAmount.Multiline = true;
            txtDiscountAmount.Name = "txtDiscountAmount";
            txtDiscountAmount.Size = new Size(320, 36);
            txtDiscountAmount.TabIndex = 4;
            txtDiscountAmount.Text = "0.00";
            txtDiscountAmount.KeyPress += txtDiscountAmount_KeyPress;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLight;
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Location = new Point(0, 235);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 79);
            panel1.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Red;
            label5.Location = new Point(26, 45);
            label5.Name = "label5";
            label5.Size = new Size(0, 23);
            label5.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(23, 14);
            label4.Name = "label4";
            label4.Size = new Size(208, 31);
            label4.TabIndex = 0;
            label4.Text = "Gift Card Redeem :";
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = SystemColors.Highlight;
            btnUpdate.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(532, 398);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(112, 43);
            btnUpdate.TabIndex = 6;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(650, 398);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(112, 43);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // DiscountForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 453);
            Controls.Add(btnCancel);
            Controls.Add(btnUpdate);
            Controls.Add(panel1);
            Controls.Add(txtDiscountAmount);
            Controls.Add(label3);
            Controls.Add(cmbDiscountType);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "DiscountForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DiscountForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

            this.Load += new System.EventHandler(this.DiscountForm_Load);
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox cmbDiscountType;
        private Label label3;
        private TextBox txtDiscountAmount;
        private Panel panel1;
        private Label label5;
        private Label label4;
        private Button btnUpdate;
        private Button btnCancel;
    }
}