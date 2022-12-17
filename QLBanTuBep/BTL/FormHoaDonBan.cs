using BTL.system;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace BTL
{
    public partial class FormHoaDonBan : Form
    {
        public FormHoaDonBan()
        {
            InitializeComponent();
        }

        DBConfig db = new DBConfig();
   

        private void FormHoaDonBan_Load(object sender, EventArgs e)
        {
            dgvDSHDB.DataSource = db.table("select * from tblHoaDonBan");
            
        }

        private bool isCheck()
        {
            if (txtSoHDB.Text.Trim() == "")
            {
                MessageBox.Show("Xin mời nhập số hóa đơn bán");
                txtSoHDB.Focus();
                return false;
            }
            if (txtMaNV.Text.Trim() == "")
            {
                MessageBox.Show("Xin mời nhập mã nhân viên");
                txtMaNV.Focus();
                return false;
            }
            if (dtpNgayBan.Text.Trim() == "")
            {
                MessageBox.Show("Xin mời nhập ngày bán");
                dtpNgayBan.Focus();
                return false;
            }
            if (txtMaKH.Text.Trim() == "")
            {
                MessageBox.Show("Xin mời nhập mã khách hàng");
                txtMaKH.Focus();
                return false;
            }
            if (!db.Check($"select * from tblNhanVien where MaNV = '{txtMaNV.Text}'"))
            {
                MessageBox.Show("Không tồn tại mã " + txtMaNV.Text, "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNV.Focus();
                return false;
            }
            if (!db.Check($"select * from tblKhachHang where MaKhach = '{txtMaKH.Text}'"))
            {
                MessageBox.Show("Không tồn tại mã " + txtMaKH.Text, "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKH.Focus();
                return false;
            }

            return true;
        }

        private bool checkTonTai()
        {
            string checkHDB = "select SoHDB from tblHoaDonBan where SoHDB ='" + txtSoHDB.Text + "'";
            if (db.Check(checkHDB))
            {
                MessageBox.Show("Số hóa đơn bán này đã có vui lòng chọn nhập số hóa đơn bán khác ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoHDB.Focus();
                return false;

            }
            return true;
        }

        private bool ischeckTK()
        {

            if (cmbTimKiem.Text == "")
            {
                MessageBox.Show("Mời bạn chọn loại tìm kiếm");
                cmbTimKiem.Focus();
                return false;

            }
            else if (cmbTimKiem.Text == "Theo ngày")
            {
                txtTimKiemMH.Text = "";
                cmbTongTien.SelectedIndex = -1;
                if (dtpNgayBan.Text.Trim() == "")
                {
                    MessageBox.Show("Mời bạn nhập ngày bán");
                    dtpNgayBan.Focus();
                    return false;
                }
            }
            else if (cmbTimKiem.Text == "Theo mã hàng")
            {
                cmbTongTien.SelectedIndex = -1;
                dtpNgayBan.Text = "";
                if (txtTimKiemMH.Text == "")
                {
                    MessageBox.Show("Mời bạn nhập mã hàng ");
                    txtTimKiemMH.Focus();
                    return false;

                }
            }

            else if (cmbTimKiem.Text == "Theo tổng tiền")
            {
                txtTimKiemMH.Text = "";
                dtpNgayBan.Text = "";
                if (cmbTongTien.Text == "")
                {
                    MessageBox.Show("Mời bạn chọn tổng tiền ");
                    cmbTongTien.Focus();
                    return false;

                }
            }

            return true;
        }

        private bool checkNgay()
        {
            string checkNgay = $"select * from tblHoaDonBan where ('{dtpNgayBan.Text}' > getdate())";
            if (db.Check(checkNgay))
            {
                MessageBox.Show("Năm vướt quá năm hiện tại ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpNgayBan.Focus();
                return false;

            }
            return true;
        }

        private void CleanInput()
        {
            txtMaKH.Text = "";
            txtMaNV.Text = "";
            txtSoHDB.Text = "";
            dtpNgayBan.Value = DateTime.Now;
         
        }

        private void dgvDSHDB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtSoHDB.Text = dgvDSHDB.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
                txtMaNV.Text = dgvDSHDB.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                dtpNgayBan.Text = dgvDSHDB.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
                txtMaKH.Text = dgvDSHDB.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (isCheck() && checkTonTai() && checkNgay())
            {
                string query = $"insert into tblHoaDonBan(SoHDB,MaNV,NgayBan,MaKhach) values(N'{txtSoHDB.Text}',N'{txtMaNV.Text}' , '{dtpNgayBan.Text}', N'{txtMaKH.Text}')";
                try
                {
                    if (MessageBox.Show("Bạn có muốn thêm vào không", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        db.Excute(query);
                        FormHoaDonBan_Load(sender, e);
                        CleanInput();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (ischeckTK())
            {
                if (txtTimKiemMH.Text != "")
                {
                    dgvDSHDB.DataSource = db.table($"select * from F1_cau5 (N'{txtTimKiemMH.Text}')");
                    if (dgvDSHDB.Rows.Count <= 0)
                    {
                        MessageBox.Show("Mã hàng " + txtTimKiemMH.Text + " không có trong danh sách", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        FormHoaDonBan_Load(sender, e);
                    }
                }
                else if (cmbTongTien.Text != "")
                {
                    if (cmbTongTien.Text == "Dưới 2 triệu")
                    {
                        string sqlTongTien = $"select * from tblHoaDonBan where TongTien < 2000000";
                        if (!db.Check(sqlTongTien))
                        {
                            dgvDSHDB.DataSource = db.table(sqlTongTien);
                            MessageBox.Show("Tổng tiền " + cmbTongTien.Text + " không có trong danh sách", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            FormHoaDonBan_Load(sender, e);
                        }
                        else
                        {
                            dgvDSHDB.DataSource = db.table(sqlTongTien);
                        }
                        
                    }
                    else if (cmbTongTien.Text == "Từ 2 triệu đến 5 triệu")
                    {
                        string sqlTongTien = $"select * from tblHoaDonBan where TongTien between 2000000 and 5000000";
                        if (!db.Check(sqlTongTien))
                        {
                            dgvDSHDB.DataSource = db.table(sqlTongTien);
                            MessageBox.Show("Tổng tiền " + cmbTongTien.Text + " không có trong danh sách", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            FormHoaDonBan_Load(sender, e);
                        }
                        else
                        {
                            dgvDSHDB.DataSource = db.table(sqlTongTien);
                        }
                    }
                    else
                    {
                        string sqlTongTien = $"select * from tblHoaDonBan where TongTien > 5000000";
                        if (!db.Check(sqlTongTien))
                        {
                            dgvDSHDB.DataSource = db.table(sqlTongTien);
                            MessageBox.Show("Tổng tiền " + cmbTongTien.Text + " không có trong danh sách", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            FormHoaDonBan_Load(sender, e);
                        }
                        else
                        {
                            dgvDSHDB.DataSource = db.table(sqlTongTien);

                        }
                    }
                }
                else if (dtpNgayBan.Text != "")
                {
                    dgvDSHDB.DataSource = db.table($"select * from tblHoaDonBan where NgayBan =N'{dtpNgayBan.Text}'");
                    if (dgvDSHDB.Rows.Count <= 0)
                    {
                        MessageBox.Show("Ngày " + dtpNgayBan.Text + " không có trong danh sách", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        FormHoaDonBan_Load(sender, e);
                    }

                }
            }
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (isCheck() && checkNgay())
            {
                string query = $"update tblHoaDonBan set MaNV = N'{txtMaNV.Text}', NgayBan = '{dtpNgayBan.Text}', MaKhach = N'{txtMaKH.Text}' where SoHDB = N'{txtSoHDB.Text}'";
                try
                {
                    if (MessageBox.Show("Bạn chắc chắn muốn sửa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        db.Excute(query);
                        CleanInput();
                        FormHoaDonBan_Load(sender, e);//load du lieu
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Excel.Application exApp = new Excel.Application();
            Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];
            exSheet.get_Range("B2").Font.Bold = true;
            exSheet.get_Range("B2").Value = "DANH SÁCH HÓA ĐƠN BÁN";
            exSheet.get_Range("A3").Value = "Số TT";
            exSheet.get_Range("B3").Value = "Số Hóa Đơn Bán";
            exSheet.get_Range("C3").Value = "Mã Nhân Viên";
            exSheet.get_Range("D3").Value = "Mã Khách";
            exSheet.get_Range("E3").Value = "Ngày Bán";
            int n = dgvDSHDB.Rows.Count;
            for (int i = 0; i < n; i++)
            {
                exSheet.get_Range("A" + (i + 4).ToString()).Value
                    = (i + 1).ToString();
                exSheet.get_Range("B" + (i + 4).ToString()).Value
                    = dgvDSHDB.Rows[i].Cells[0].Value;
                exSheet.get_Range("C" + (i + 4).ToString()).Value
                    = dgvDSHDB.Rows[i].Cells[1].Value;
                exSheet.get_Range("D" + (i + 4).ToString()).Value
                    = dgvDSHDB.Rows[i].Cells[2].Value;
                exSheet.get_Range("E" + (i + 4).ToString()).Value
                    = dgvDSHDB.Rows[i].Cells[3].Value;
            }
            exBook.Activate();
            SaveFileDialog sdlg = new SaveFileDialog();
            sdlg.Filter = "Excel Document(*.xls)|*.xls | Word Document(*.doc) |*.doc | All files(*.*) |*.*";
            sdlg.FilterIndex = 1;
            sdlg.AddExtension = true;
            sdlg.DefaultExt = "*.xls";
            if (sdlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                exBook.SaveAs(sdlg.FileName.ToString());
                exApp.Quit();
            }
            else
            {
                MessageBox.Show("Không có danh sách chi tiết hóa đơn bán để in");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string query = $"delete tblHoaDonBan where SoHDB = N'{txtSoHDB.Text}'";
            string query1 = $"delete tblChiTietHDB where SoHDB = N'{txtSoHDB.Text}'";
            try
            {
                if (MessageBox.Show("Bạn chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    db.Excute(query1);
                    db.Excute(query);
                    CleanInput();
                    FormHoaDonBan_Load(sender, e);//load du lieu
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCTHDB_Click(object sender, EventArgs e)
        {
            FormCTHDB formCTHDB = new FormCTHDB();
            formCTHDB.ShowDialog();
        }
    }
}
