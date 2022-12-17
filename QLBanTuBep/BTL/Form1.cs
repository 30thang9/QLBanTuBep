using BTL.Properties;
using BTL.system;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL
{
    public partial class Form1 : Form
    {
        
        private bool isCollapsed;
        public Form1()
        {
            InitializeComponent();
            hideSubMenu();
        }
        private Form currentFormChild;

        DBConfig db = new DBConfig();
        private void OpenChildForm(Form childForm)
        {
            if(currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_Body.Controls.Add(childForm);
            panel_Body.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void hideSubMenu()
        {
            panelDropDownDSHD.Visible = false;
            panelDropDownCTHH.Visible = false;
            panelDropDownTK.Visible = false;
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }


        //click đổi màu BackColor Button
        private void btnActiveColor(object sender, EventArgs e)
        {
            foreach(Control c in panel_Left.Controls)
            {
                c.BackColor = Color.White;
                c.ForeColor = Color.Black;
            }

            Control click = (Control)sender;
            click.BackColor = Color.FromArgb(186, 148, 209);
            click.ForeColor = Color.White;
        }

        private void btnActiveColorDropDown(object sender, EventArgs e)
        {
            foreach (Control c in panelDropDownDSHD.Controls)
            {
                c.BackColor = Color.White;
                c.ForeColor = Color.Black;
            }
            foreach (Control c in panelDropDownCTHH.Controls)
            {
                c.BackColor = Color.White;
                c.ForeColor = Color.Black;
            }
            foreach (Control c in panelDropDownTK.Controls)
            {
                c.BackColor = Color.White;
                c.ForeColor = Color.Black;
            }
            Control click = (Control)sender;
            click.BackColor = Color.FromArgb(186, 148, 209);
            click.ForeColor = Color.White;
        }

        private void cleanColorDropDown(object sender, EventArgs e)
        {
            foreach (Control c in panelDropDownDSHD.Controls)
            {
                c.BackColor = Color.White;
                c.ForeColor = Color.Black;
            }
            foreach (Control c in panelDropDownCTHH.Controls)
            {
                c.BackColor = Color.White;
                c.ForeColor = Color.Black;
            }
            foreach (Control c in panelDropDownTK.Controls)
            {
                c.BackColor = Color.White;
                c.ForeColor = Color.Black;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OpenChildForm(new FormDSTuBep());
            lblTieuDe.Text = "Danh Sách Tủ Bếp";
            btnActiveColor(btnDSTB, null);
        }

        //Button DS Tủ Bếp
        private void btnDSTB_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormDSTuBep());
            btnActiveColor(btnDSTB, null);
            cleanColorDropDown(sender, null);
            lblTieuDe.Text = "Danh Sách Tủ Bếp";
            //slidePanel.Height = btnDSTB.Height;
            //slidePanel.Top = btnDSTB.Top;

        }

        //Button DS Hóa Đơn
        private void btnDSHD_Click(object sender, EventArgs e)
        {
            showSubMenu(panelDropDownDSHD);
            btnActiveColor(btnDSHD, null);
            lblTieuDe.Text = "Danh Sách Hóa Đơn";
        }


        //Button Nhân Viên
        private void btnNV_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormNhanVien());
            btnActiveColor(btnNV, null);
            cleanColorDropDown(sender, null);
            lblTieuDe.Text = "Nhân Viên";
        }

        //Button Nhà Cung Cấp
        private void btnNCC_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormNhaCungCap());
            btnActiveColor(btnNCC, null);
            cleanColorDropDown(sender, null);
            lblTieuDe.Text = "Nhà Cung Cấp";
        }

        //Button Hóa đơn bán
        private void btnHDB_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormHoaDonBan());
            btnActiveColor(btnDSHD, null);
            btnActiveColorDropDown(btnHDB, null);
            lblTieuDe.Text = "Hóa Đơn Bán";
        }

        //Button Hóa Đơn Nhập
        private void btnHDN_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormHoaDonNhap());
            btnActiveColor(btnDSHD, null);
            btnActiveColorDropDown(btnHDN, null);
            lblTieuDe.Text = "Hóa Đơn Nhập";
        }

        //Button Khách Hàng
        private void btnKH_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormKhachHang());
            btnActiveColor(btnKH, null);
            cleanColorDropDown(sender, null);
            lblTieuDe.Text = "Khách Hàng";
        }

        private void btnCTHH_Click(object sender, EventArgs e)
        {
            showSubMenu(panelDropDownCTHH);
            btnActiveColor(btnCTHH, null);
            lblTieuDe.Text = "Chi Tiết Hàng Hóa";
        }

        private void btnKT_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormKichThuoc());
            btnActiveColor(btnCTHH, null);
            btnActiveColorDropDown(btnKT, null);
            lblTieuDe.Text = "Kích Thước";
        }

        private void btnNSX_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormNuocSanXuat());
            btnActiveColor(btnCTHH, null);
            btnActiveColorDropDown(btnNSX, null);
            lblTieuDe.Text = "Nước Sản Xuất";
        }

        private void btnCL_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormChatLieu());
            btnActiveColor(btnCTHH, null);
            btnActiveColorDropDown(btnCL, null);
            lblTieuDe.Text = "Chất Liệu";
            
        }

        private void btnMS_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormMauSac());
            btnActiveColor(btnCTHH, null);
            btnActiveColorDropDown(btnMS, null);
            lblTieuDe.Text = "Màu Sắc";
        }


        private void btnTK_Click(object sender, EventArgs e)
        {
            showSubMenu(panelDropDownTK);
            btnActiveColor(btnTK, null);
            lblTieuDe.Text = "Thống Kê";
        }

        private void btnTKHD_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormTKHD());
            btnActiveColor(btnTK, null);
            btnActiveColorDropDown(btnTKHD, null);
            lblTieuDe.Text = "Thống Kê Hóa Đơn";
        }

        private void btnTKKH_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormTKKH());
            btnActiveColor(btnTK, null);
            btnActiveColorDropDown(btnTKKH, null);
            lblTieuDe.Text = "Thống Kê Khách Hàng";
        }

        private void btnTKSP_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormTKSP());
            btnActiveColor(btnTK, null);
            btnActiveColorDropDown(btnTKSP, null);
            lblTieuDe.Text = "Thống Kê Sản Phẩm";
        }

        private void btnCV_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormCongViec());
            btnActiveColor(btnCV, null);
            cleanColorDropDown(sender, null);
            lblTieuDe.Text = "Công Việc";
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Hide();
                FormDangNhap formDangNhap = new FormDangNhap();
                formDangNhap.ShowDialog();
                this.Close();
            }
        }
    }
}
