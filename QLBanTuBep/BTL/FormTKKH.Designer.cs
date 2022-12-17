namespace BTL
{
    partial class FormTKKH
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLamMoi = new Guna.UI2.WinForms.Guna2GradientButton();
            this.txtNam = new System.Windows.Forms.TextBox();
            this.btnThongKe = new Guna.UI2.WinForms.Guna2GradientButton();
            this.cmbThang = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rpvTKDSKH = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLamMoi);
            this.groupBox1.Controls.Add(this.txtNam);
            this.groupBox1.Controls.Add(this.btnThongKe);
            this.groupBox1.Controls.Add(this.cmbThang);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1168, 214);
            this.groupBox1.TabIndex = 8;
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
            this.btnLamMoi.Location = new System.Drawing.Point(834, 140);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(160, 45);
            this.btnLamMoi.TabIndex = 12;
            this.btnLamMoi.Text = "Làm Mới";
            this.btnLamMoi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // txtNam
            // 
            this.txtNam.Location = new System.Drawing.Point(323, 158);
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(200, 27);
            this.txtNam.TabIndex = 13;
            this.txtNam.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNam_KeyPress);
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
            this.btnThongKe.Location = new System.Drawing.Point(834, 39);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(160, 45);
            this.btnThongKe.TabIndex = 12;
            this.btnThongKe.Text = "Thống Kê";
            this.btnThongKe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // cmbThang
            // 
            this.cmbThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbThang.FormattingEnabled = true;
            this.cmbThang.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.cmbThang.Location = new System.Drawing.Point(323, 39);
            this.cmbThang.Name = "cmbThang";
            this.cmbThang.Size = new System.Drawing.Size(200, 28);
            this.cmbThang.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(176, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "Chọn Năm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(176, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "Chọn Tháng";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rpvTKDSKH);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 214);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1168, 429);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh Sách Khách Hàng";
            // 
            // rpvTKDSKH
            // 
            this.rpvTKDSKH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvTKDSKH.Location = new System.Drawing.Point(3, 23);
            this.rpvTKDSKH.Name = "rpvTKDSKH";
            this.rpvTKDSKH.ServerReport.BearerToken = null;
            this.rpvTKDSKH.Size = new System.Drawing.Size(1162, 403);
            this.rpvTKDSKH.TabIndex = 0;
            // 
            // FormTKKH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(222)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(1168, 643);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormTKKH";
            this.Text = "FormTKKH";
            this.Load += new System.EventHandler(this.FormTKKH_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbThang;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private Guna.UI2.WinForms.Guna2GradientButton btnThongKe;
        private System.Windows.Forms.TextBox txtNam;
        private Microsoft.Reporting.WinForms.ReportViewer rpvTKDSKH;
        private Guna.UI2.WinForms.Guna2GradientButton btnLamMoi;
    }
}