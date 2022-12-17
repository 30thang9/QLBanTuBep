namespace BTL
{
    partial class FormTKHD
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
            this.cmbQuy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLamMoi = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnThongKe = new Guna.UI2.WinForms.Guna2GradientButton();
            this.rdbTKHDN = new System.Windows.Forms.RadioButton();
            this.rdbTKHDB = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNam = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rpvDSHD = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbQuy
            // 
            this.cmbQuy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQuy.FormattingEnabled = true;
            this.cmbQuy.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04"});
            this.cmbQuy.Location = new System.Drawing.Point(633, 39);
            this.cmbQuy.Name = "cmbQuy";
            this.cmbQuy.Size = new System.Drawing.Size(149, 28);
            this.cmbQuy.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(71, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mã Nhân Viên";
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(234, 142);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(154, 27);
            this.txtMaNV.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLamMoi);
            this.groupBox1.Controls.Add(this.btnThongKe);
            this.groupBox1.Controls.Add(this.rdbTKHDN);
            this.groupBox1.Controls.Add(this.rdbTKHDB);
            this.groupBox1.Controls.Add(this.cmbQuy);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtNam);
            this.groupBox1.Controls.Add(this.txtMaNV);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1168, 214);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLamMoi.Animated = true;
            this.btnLamMoi.AutoRoundedCorners = true;
            this.btnLamMoi.BorderColor = System.Drawing.Color.Silver;
            this.btnLamMoi.BorderRadius = 21;
            this.btnLamMoi.BorderThickness = 1;
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLamMoi.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLamMoi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLamMoi.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLamMoi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLamMoi.FillColor = System.Drawing.Color.White;
            this.btnLamMoi.FillColor2 = System.Drawing.Color.White;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.btnLamMoi.ForeColor = System.Drawing.Color.Black;
            this.btnLamMoi.Image = global::BTL.Properties.Resources.icons8_update_left_rotation_24;
            this.btnLamMoi.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLamMoi.Location = new System.Drawing.Point(937, 125);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(160, 45);
            this.btnLamMoi.TabIndex = 57;
            this.btnLamMoi.Text = "Làm Mới";
            this.btnLamMoi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.Animated = true;
            this.btnThongKe.AutoRoundedCorners = true;
            this.btnThongKe.BorderColor = System.Drawing.Color.Silver;
            this.btnThongKe.BorderRadius = 21;
            this.btnThongKe.BorderThickness = 1;
            this.btnThongKe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThongKe.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThongKe.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThongKe.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThongKe.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThongKe.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThongKe.FillColor = System.Drawing.Color.White;
            this.btnThongKe.FillColor2 = System.Drawing.Color.White;
            this.btnThongKe.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.btnThongKe.ForeColor = System.Drawing.Color.Black;
            this.btnThongKe.Image = global::BTL.Properties.Resources.icons8_analytics_24;
            this.btnThongKe.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnThongKe.ImageSize = new System.Drawing.Size(24, 24);
            this.btnThongKe.Location = new System.Drawing.Point(937, 30);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(160, 45);
            this.btnThongKe.TabIndex = 7;
            this.btnThongKe.Text = "Thống Kê";
            this.btnThongKe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // rdbTKHDN
            // 
            this.rdbTKHDN.AutoSize = true;
            this.rdbTKHDN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbTKHDN.Location = new System.Drawing.Point(76, 85);
            this.rdbTKHDN.Name = "rdbTKHDN";
            this.rdbTKHDN.Size = new System.Drawing.Size(254, 29);
            this.rdbTKHDN.TabIndex = 5;
            this.rdbTKHDN.TabStop = true;
            this.rdbTKHDN.Text = "Thống Kê Hóa Đơn Nhập";
            this.rdbTKHDN.UseVisualStyleBackColor = true;
            // 
            // rdbTKHDB
            // 
            this.rdbTKHDB.AutoSize = true;
            this.rdbTKHDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbTKHDB.Location = new System.Drawing.Point(76, 35);
            this.rdbTKHDB.Name = "rdbTKHDB";
            this.rdbTKHDB.Size = new System.Drawing.Size(242, 29);
            this.rdbTKHDB.TabIndex = 5;
            this.rdbTKHDB.TabStop = true;
            this.rdbTKHDB.Text = "Thống Kê Hóa Đơn Bán";
            this.rdbTKHDB.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(509, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Chọn Năm";
            // 
            // txtNam
            // 
            this.txtNam.Location = new System.Drawing.Point(633, 142);
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(149, 27);
            this.txtNam.TabIndex = 4;
            this.txtNam.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNam_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(509, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Chọn Qúy";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rpvDSHD);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 214);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1168, 429);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh Sách Hóa Đơn";
            // 
            // rpvDSHD
            // 
            this.rpvDSHD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvDSHD.Location = new System.Drawing.Point(3, 23);
            this.rpvDSHD.Name = "rpvDSHD";
            this.rpvDSHD.ServerReport.BearerToken = null;
            this.rpvDSHD.Size = new System.Drawing.Size(1162, 403);
            this.rpvDSHD.TabIndex = 0;
            // 
            // FormTKHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(222)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(1168, 643);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormTKHD";
            this.Text = "FormTKHD";
            this.Load += new System.EventHandler(this.FormTKHD_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbQuy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbTKHDN;
        private System.Windows.Forms.RadioButton rdbTKHDB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private Guna.UI2.WinForms.Guna2GradientButton btnThongKe;
        private System.Windows.Forms.TextBox txtNam;
        private Microsoft.Reporting.WinForms.ReportViewer rpvDSHD;
        private Guna.UI2.WinForms.Guna2GradientButton btnLamMoi;
    }
}