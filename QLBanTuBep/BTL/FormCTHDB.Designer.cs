namespace BTL
{
    partial class FormCTHDB
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
            this.dgvCTHDB = new System.Windows.Forms.DataGridView();
            this.txtSL = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGG = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMH = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSoHDB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnTimKiem = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnThem = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnXoa = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnSua = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnExcel = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnThoat = new Guna.UI2.WinForms.Guna2GradientButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTHDB)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCTHDB
            // 
            this.dgvCTHDB.AllowUserToAddRows = false;
            this.dgvCTHDB.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCTHDB.BackgroundColor = System.Drawing.Color.White;
            this.dgvCTHDB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCTHDB.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvCTHDB.Location = new System.Drawing.Point(0, 122);
            this.dgvCTHDB.Name = "dgvCTHDB";
            this.dgvCTHDB.RowHeadersWidth = 51;
            this.dgvCTHDB.RowTemplate.Height = 24;
            this.dgvCTHDB.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCTHDB.Size = new System.Drawing.Size(982, 200);
            this.dgvCTHDB.TabIndex = 6;
            this.dgvCTHDB.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCTHDB_CellClick);
            // 
            // txtSL
            // 
            this.txtSL.Location = new System.Drawing.Point(563, 27);
            this.txtSL.Name = "txtSL";
            this.txtSL.Size = new System.Drawing.Size(140, 27);
            this.txtSL.TabIndex = 1;
            this.txtSL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSL_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(462, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Số Lượng";
            // 
            // txtGG
            // 
            this.txtGG.Location = new System.Drawing.Point(563, 74);
            this.txtGG.Name = "txtGG";
            this.txtGG.Size = new System.Drawing.Size(140, 27);
            this.txtGG.TabIndex = 1;
            this.txtGG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGG_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(462, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Giảm Giá";
            // 
            // txtMH
            // 
            this.txtMH.Location = new System.Drawing.Point(208, 74);
            this.txtMH.Name = "txtMH";
            this.txtMH.Size = new System.Drawing.Size(140, 27);
            this.txtMH.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mã Hàng";
            // 
            // txtSoHDB
            // 
            this.txtSoHDB.Location = new System.Drawing.Point(208, 24);
            this.txtSoHDB.Name = "txtSoHDB";
            this.txtSoHDB.Size = new System.Drawing.Size(140, 27);
            this.txtSoHDB.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Số hóa đơn bán";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnTimKiem);
            this.panel2.Controls.Add(this.txtSL);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtGG);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtMH);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtSoHDB);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(982, 122);
            this.panel2.TabIndex = 5;
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
            this.btnTimKiem.Location = new System.Drawing.Point(829, 74);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(150, 45);
            this.btnTimKiem.TabIndex = 59;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
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
            this.btnThem.Location = new System.Drawing.Point(114, 388);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(120, 45);
            this.btnThem.TabIndex = 41;
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
            this.btnXoa.Location = new System.Drawing.Point(422, 388);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(120, 45);
            this.btnXoa.TabIndex = 44;
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
            this.btnSua.Location = new System.Drawing.Point(267, 388);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(120, 45);
            this.btnSua.TabIndex = 43;
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
            this.btnExcel.Location = new System.Drawing.Point(576, 388);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(160, 45);
            this.btnExcel.TabIndex = 42;
            this.btnExcel.Text = "Xuất Excel";
            this.btnExcel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnThoat.Animated = true;
            this.btnThoat.AutoRoundedCorners = true;
            this.btnThoat.BorderColor = System.Drawing.Color.Silver;
            this.btnThoat.BorderRadius = 21;
            this.btnThoat.BorderThickness = 1;
            this.btnThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThoat.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThoat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThoat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThoat.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThoat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThoat.FillColor = System.Drawing.Color.White;
            this.btnThoat.FillColor2 = System.Drawing.Color.White;
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.btnThoat.ForeColor = System.Drawing.Color.Black;
            this.btnThoat.Image = global::BTL.Properties.Resources.icons8_close_24;
            this.btnThoat.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnThoat.ImageSize = new System.Drawing.Size(24, 24);
            this.btnThoat.Location = new System.Drawing.Point(772, 388);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(120, 45);
            this.btnThoat.TabIndex = 44;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // FormCTHDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(222)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(982, 513);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.dgvCTHDB);
            this.Controls.Add(this.panel2);
            this.Name = "FormCTHDB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormCTHDB";
            this.Load += new System.EventHandler(this.FormCTHDB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTHDB)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvCTHDB;
        private System.Windows.Forms.TextBox txtSL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGG;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSoHDB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2GradientButton btnThem;
        private Guna.UI2.WinForms.Guna2GradientButton btnXoa;
        private Guna.UI2.WinForms.Guna2GradientButton btnSua;
        private Guna.UI2.WinForms.Guna2GradientButton btnExcel;
        private Guna.UI2.WinForms.Guna2GradientButton btnThoat;
        private Guna.UI2.WinForms.Guna2GradientButton btnTimKiem;
    }
}