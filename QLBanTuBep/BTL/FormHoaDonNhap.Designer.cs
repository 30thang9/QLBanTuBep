namespace BTL
{
    partial class FormHoaDonNhap
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
            this.btnCTHDN = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnTimKiem = new Guna.UI2.WinForms.Guna2GradientButton();
            this.dtpNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.txtSoHDN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaNCC = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnThem = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnXoa = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnSua = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnExcel = new Guna.UI2.WinForms.Guna2GradientButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvDSHDN = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSHDN)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCTHDN);
            this.groupBox1.Controls.Add(this.btnTimKiem);
            this.groupBox1.Controls.Add(this.dtpNgayNhap);
            this.groupBox1.Controls.Add(this.txtSoHDN);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtMaNCC);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtMaNV);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1182, 265);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin hóa đơn nhập";
            // 
            // btnCTHDN
            // 
            this.btnCTHDN.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCTHDN.Animated = true;
            this.btnCTHDN.AutoRoundedCorners = true;
            this.btnCTHDN.BorderColor = System.Drawing.Color.Silver;
            this.btnCTHDN.BorderRadius = 21;
            this.btnCTHDN.BorderThickness = 1;
            this.btnCTHDN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCTHDN.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCTHDN.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCTHDN.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCTHDN.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCTHDN.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCTHDN.FillColor = System.Drawing.Color.White;
            this.btnCTHDN.FillColor2 = System.Drawing.Color.White;
            this.btnCTHDN.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.btnCTHDN.ForeColor = System.Drawing.Color.Black;
            this.btnCTHDN.Image = global::BTL.Properties.Resources.icons8_purchase_order_24;
            this.btnCTHDN.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCTHDN.Location = new System.Drawing.Point(285, 183);
            this.btnCTHDN.Name = "btnCTHDN";
            this.btnCTHDN.Size = new System.Drawing.Size(170, 45);
            this.btnCTHDN.TabIndex = 59;
            this.btnCTHDN.Text = "Chi tiết HDN";
            this.btnCTHDN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnCTHDN.Click += new System.EventHandler(this.btnCTHDN_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnTimKiem.Animated = true;
            this.btnTimKiem.AutoRoundedCorners = true;
            this.btnTimKiem.BorderColor = System.Drawing.Color.Silver;
            this.btnTimKiem.BorderRadius = 21;
            this.btnTimKiem.BorderThickness = 1;
            this.btnTimKiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimKiem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTimKiem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTimKiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTimKiem.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTimKiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTimKiem.FillColor = System.Drawing.Color.White;
            this.btnTimKiem.FillColor2 = System.Drawing.Color.White;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.btnTimKiem.ForeColor = System.Drawing.Color.Black;
            this.btnTimKiem.Image = global::BTL.Properties.Resources.icons8_search_24__1_;
            this.btnTimKiem.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTimKiem.Location = new System.Drawing.Point(804, 183);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(150, 45);
            this.btnTimKiem.TabIndex = 58;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // dtpNgayNhap
            // 
            this.dtpNgayNhap.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpNgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayNhap.Location = new System.Drawing.Point(804, 39);
            this.dtpNgayNhap.Name = "dtpNgayNhap";
            this.dtpNgayNhap.Size = new System.Drawing.Size(200, 27);
            this.dtpNgayNhap.TabIndex = 45;
            // 
            // txtSoHDN
            // 
            this.txtSoHDN.Location = new System.Drawing.Point(285, 43);
            this.txtSoHDN.Name = "txtSoHDN";
            this.txtSoHDN.Size = new System.Drawing.Size(200, 27);
            this.txtSoHDN.TabIndex = 43;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(88, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 25);
            this.label2.TabIndex = 41;
            this.label2.Text = "Số hóa đơn nhập";
            // 
            // txtMaNCC
            // 
            this.txtMaNCC.Location = new System.Drawing.Point(285, 122);
            this.txtMaNCC.Name = "txtMaNCC";
            this.txtMaNCC.Size = new System.Drawing.Size(200, 27);
            this.txtMaNCC.TabIndex = 44;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(88, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 25);
            this.label4.TabIndex = 42;
            this.label4.Text = "Mã nhà cung cấp";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(641, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 25);
            this.label5.TabIndex = 37;
            this.label5.Text = "Ngày nhập";
            // 
            // txtMaNV
            // 
            this.txtMaNV.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtMaNV.Location = new System.Drawing.Point(804, 122);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(200, 27);
            this.txtMaNV.TabIndex = 40;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(641, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 25);
            this.label3.TabIndex = 38;
            this.label3.Text = "Mã nhân viên";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnThem);
            this.panel2.Controls.Add(this.btnXoa);
            this.panel2.Controls.Add(this.btnSua);
            this.panel2.Controls.Add(this.btnExcel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 509);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1182, 100);
            this.panel2.TabIndex = 12;
            // 
            // btnThem
            // 
            this.btnThem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnThem.Animated = true;
            this.btnThem.AutoRoundedCorners = true;
            this.btnThem.BorderColor = System.Drawing.Color.Silver;
            this.btnThem.BorderRadius = 21;
            this.btnThem.BorderThickness = 1;
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThem.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThem.FillColor = System.Drawing.Color.White;
            this.btnThem.FillColor2 = System.Drawing.Color.White;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.btnThem.ForeColor = System.Drawing.Color.Black;
            this.btnThem.Image = global::BTL.Properties.Resources.icons8_plus_math_30;
            this.btnThem.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnThem.Location = new System.Drawing.Point(280, 28);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(120, 45);
            this.btnThem.TabIndex = 37;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnXoa.Animated = true;
            this.btnXoa.AutoRoundedCorners = true;
            this.btnXoa.BorderColor = System.Drawing.Color.Silver;
            this.btnXoa.BorderRadius = 21;
            this.btnXoa.BorderThickness = 1;
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXoa.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXoa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXoa.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXoa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXoa.FillColor = System.Drawing.Color.White;
            this.btnXoa.FillColor2 = System.Drawing.Color.White;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.btnXoa.ForeColor = System.Drawing.Color.Black;
            this.btnXoa.Image = global::BTL.Properties.Resources.icons8_remove_24;
            this.btnXoa.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnXoa.ImageSize = new System.Drawing.Size(24, 24);
            this.btnXoa.Location = new System.Drawing.Point(588, 28);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(120, 45);
            this.btnXoa.TabIndex = 40;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSua.Animated = true;
            this.btnSua.AutoRoundedCorners = true;
            this.btnSua.BorderColor = System.Drawing.Color.Silver;
            this.btnSua.BorderRadius = 21;
            this.btnSua.BorderThickness = 1;
            this.btnSua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSua.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSua.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSua.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSua.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSua.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSua.FillColor = System.Drawing.Color.White;
            this.btnSua.FillColor2 = System.Drawing.Color.White;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.btnSua.ForeColor = System.Drawing.Color.Black;
            this.btnSua.Image = global::BTL.Properties.Resources.icons8_pencil_24;
            this.btnSua.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSua.ImageSize = new System.Drawing.Size(24, 24);
            this.btnSua.Location = new System.Drawing.Point(433, 28);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(120, 45);
            this.btnSua.TabIndex = 39;
            this.btnSua.Text = "Sửa";
            this.btnSua.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnExcel.Animated = true;
            this.btnExcel.AutoRoundedCorners = true;
            this.btnExcel.BorderColor = System.Drawing.Color.Silver;
            this.btnExcel.BorderRadius = 21;
            this.btnExcel.BorderThickness = 1;
            this.btnExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExcel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExcel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExcel.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExcel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExcel.FillColor = System.Drawing.Color.White;
            this.btnExcel.FillColor2 = System.Drawing.Color.White;
            this.btnExcel.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.btnExcel.ForeColor = System.Drawing.Color.Black;
            this.btnExcel.Image = global::BTL.Properties.Resources.icons8_microsoft_excel_30;
            this.btnExcel.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnExcel.Location = new System.Drawing.Point(742, 28);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(160, 45);
            this.btnExcel.TabIndex = 38;
            this.btnExcel.Text = "Xuất Excel";
            this.btnExcel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvDSHDN);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 265);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1182, 244);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách hóa đơn nhập";
            // 
            // dgvDSHDN
            // 
            this.dgvDSHDN.AllowUserToAddRows = false;
            this.dgvDSHDN.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDSHDN.BackgroundColor = System.Drawing.Color.White;
            this.dgvDSHDN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSHDN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDSHDN.Location = new System.Drawing.Point(3, 23);
            this.dgvDSHDN.Name = "dgvDSHDN";
            this.dgvDSHDN.RowHeadersWidth = 51;
            this.dgvDSHDN.RowTemplate.Height = 24;
            this.dgvDSHDN.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDSHDN.Size = new System.Drawing.Size(1176, 218);
            this.dgvDSHDN.TabIndex = 0;
            this.dgvDSHDN.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSHDN_CellClick);
            // 
            // FormHoaDonNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(222)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(1182, 609);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormHoaDonNhap";
            this.Text = "FormHoaDonNhap";
            this.Load += new System.EventHandler(this.FormHoaDonNhap_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSHDN)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvDSHDN;
        private System.Windows.Forms.TextBox txtSoHDN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaNCC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpNgayNhap;
        private Guna.UI2.WinForms.Guna2GradientButton btnThem;
        private Guna.UI2.WinForms.Guna2GradientButton btnXoa;
        private Guna.UI2.WinForms.Guna2GradientButton btnSua;
        private Guna.UI2.WinForms.Guna2GradientButton btnExcel;
        private Guna.UI2.WinForms.Guna2GradientButton btnCTHDN;
        private Guna.UI2.WinForms.Guna2GradientButton btnTimKiem;
    }
}