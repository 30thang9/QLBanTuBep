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
    public partial class FormHoaDonNhap : Form
    {
        public FormHoaDonNhap()
        {
            InitializeComponent();
        }

        DBConfig db = new DBConfig();



        private void FormHoaDonNhap_Load(object sender, EventArgs e)
        {
            dgvDSHDN.DataSource = db.table("select * from tblHoaDonNhap");
        }

        private bool isCheck()
        {
            if (txtSoHDN.Text.Trim() == "")
            {
                MessageBox.Show("Xin mời nhập số hóa đơn nhập");
                txtSoHDN.Focus();
                return false;
            }
            if (txtMaNCC.Text.Trim() == "")
            {
                MessageBox.Show("Xin mời nhập mã nhà cung cấp");
                txtMaNCC.Focus();
                return false;
            }
            if (dtpNgayNhap.Text.Trim() == "")
            {
                MessageBox.Show("Xin mời nhập ngày nhập");
                dtpNgayNhap.Focus();
                return false;
            }
            if (txtMaNV.Text.Trim() == "")
            {
                MessageBox.Show("Xin mời nhập mã nhân viên");
                txtMaNV.Focus();
                return false;
            }
            if (!db.Check($"select * from tblNhanVien where MaNV = '{txtMaNV.Text}'"))
            {
                MessageBox.Show("Không tồn tại mã " + txtMaNV.Text, "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNV.Focus();
                return false;
            }
            if (!db.Check($"select * from tblNhaCungCap where MaNCC = '{txtMaNCC.Text}'"))
            {
                MessageBox.Show("Không tồn tại mã " + txtMaNCC.Text, "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNCC.Focus();
                return false;
            }

            return true;
        }

        private bool checkTonTai()
        {
            string checkHDN = "select SoHDN from tblHoaDonNhap where SoHdn ='" + txtSoHDN.Text + "'";
            if (db.Check(checkHDN))
            {
                MessageBox.Show("Số hóa đơn nhập này đã có vui lòng chọn nhập số hóa đơn nhập khác ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoHDN.Focus();
                return false;
            }
            return true;
        }

        private bool checkNgay()
        {
            string checkNgay = $"select * from tblHoaDonBan where ('{dtpNgayNhap.Text}' > getdate())";
            if (db.Check(checkNgay))
            {
                MessageBox.Show(dtpNgayNhap.Text + " vượt quá năm hiện tại ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpNgayNhap.Focus();
                return false;

            }
            return true;
        }

        private void CleanInput()
        {
            txtSoHDN.Text = "";
            txtMaNV.Text = "";
            txtMaNCC.Text = "";
            dtpNgayNhap.Value = DateTime.Now;

        }

        private void dgvDSHDN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtSoHDN.Text = dgvDSHDN.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
                txtMaNV.Text = dgvDSHDN.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                dtpNgayNhap.Text = dgvDSHDN.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
                txtMaNCC.Text = dgvDSHDN.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();
            }
          
        }

        
        

        private void btnCTHDN_Click(object sender, EventArgs e)
        {
            FormCTHDN formCTHDN = new FormCTHDN();
            formCTHDN.ShowDialog();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (isCheck() && checkTonTai() && checkNgay())
            {
                string query = $"insert into tblHoaDonNhap(SoHDN, MaNV, NgayNhap, MaNCC) values(N'{txtSoHDN.Text}', N'{txtMaNV.Text}','{dtpNgayNhap.Text}', N'{txtMaNCC.Text}')";
                try
                {
                    if (MessageBox.Show("Bạn có muốn thêm vào không", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        db.Excute(query);
                        CleanInput();
                        FormHoaDonNhap_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (isCheck() && checkNgay())
            {
                string query = $"update tblHoaDonNhap set MaNV = N'{txtMaNV.Text}', NgayNhap = '{dtpNgayNhap.Text}', MaNCC = N'{txtMaNCC.Text}' where SoHDN = N'{txtSoHDN.Text}'";
                try
                {
                    if (MessageBox.Show("Bạn chắc chắn muốn sửa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        db.Excute(query);
                        CleanInput();
                        FormHoaDonNhap_Load(sender, e);//load du lieu
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string query = $"delete from tblHoaDonNhap where SoHDN = N'{txtSoHDN.Text}'";
            string query1 = $"delete from tblChiTietHDN where SoHDN = N'{txtSoHDN.Text}'";
            try
            {
                if (MessageBox.Show("Bạn chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    db.Excute(query1);
                    db.Excute(query);
                    CleanInput();
                    FormHoaDonNhap_Load(sender, e);//load du lieu
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Excel.Application exApp = new Excel.Application();
            Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];
            exSheet.get_Range("B2").Font.Bold = true;
            exSheet.get_Range("B2").Value = "DANH SÁCH HÓA ĐƠN NHẬP";
            exSheet.get_Range("A3").Value = "Số TT";
            exSheet.get_Range("B3").Value = "Số Hóa Đơn Nhập";
            exSheet.get_Range("C3").Value = "Mã Nhân Viên";
            exSheet.get_Range("D3").Value = "Mã Nhà Cung Cấp";
            exSheet.get_Range("E3").Value = "Ngày Nhập";
            int n = dgvDSHDN.Rows.Count;
            for (int i = 0; i < n; i++)
            {
                exSheet.get_Range("A" + (i + 4).ToString()).Value
                    = (i + 1).ToString();
                exSheet.get_Range("B" + (i + 4).ToString()).Value
                    = dgvDSHDN.Rows[i].Cells[0].Value;
                exSheet.get_Range("C" + (i + 4).ToString()).Value
                    = dgvDSHDN.Rows[i].Cells[1].Value;
                exSheet.get_Range("D" + (i + 4).ToString()).Value
                    = dgvDSHDN.Rows[i].Cells[2].Value;
                exSheet.get_Range("E" + (i + 4).ToString()).Value
                    = dgvDSHDN.Rows[i].Cells[3].Value;
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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtSoHDN.Text.Trim() == "")
            {
                MessageBox.Show("Mời bạn nhập mã hàng muốn tìm kiếm");
                txtSoHDN.Focus();
            }
            else
            {
                if (db.table($"select * from tblHoaDonNhap where SoHDN = N'{txtSoHDN.Text}'").Rows.Count > 0)
                {
                    dgvDSHDN.DataSource = db.table($"select * from tblHoaDonNhap where SoHDN = N'{txtSoHDN.Text}'");
                    CleanInput();
                }
                else
                {
                    MessageBox.Show(txtSoHDN.Text + " không có trong danh sách", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoHDN.Focus();
                    FormHoaDonNhap_Load(sender, e);//load du lieu
                }

            }
        }
    }
}
