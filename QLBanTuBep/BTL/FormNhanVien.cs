using BTL.system;
using System;
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
    public partial class FormNhanVien : Form
    {
        public FormNhanVien()
        {
            InitializeComponent();
        }
        
        DBConfig db = new DBConfig();
        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            dgvNhanVien.DataSource = db.table("select * from tblNhanVien");
        }

        private bool isCheck()
        {
            if (txtMaNV.Text.Trim() == "") { MessageBox.Show("Xin mời nhập mã nhân viên"); return false; }
            if (txtTenNV.Text.Trim() == "") { MessageBox.Show("Xin mời nhập tên nhân viên"); return false; }
            if (rdbNam.Checked == false && rdbNu.Checked == false) { MessageBox.Show("Xin mời chọn giới tính"); return false; }
            if (dtpNgaySinh.Text.Trim() == "") { MessageBox.Show("Xin mời nhập ngày sinh"); return false; }
            if (txtSDT.Text.Trim() == "") { MessageBox.Show("Xin mời nhập số điện thoại"); return false; }
            if (txtDiaChi.Text.Trim() == "") { MessageBox.Show("Xin mời nhập số địa chỉ"); return false; }
            if (txtMaCV.Text.Trim() == "") { MessageBox.Show("Xin mời nhập mã công việc"); return false; }
            if (!db.Check($"select * from tblCongViec where MaCV = '{txtMaCV.Text}'"))
            {
                MessageBox.Show("Không tồn tại mã " + txtMaCV.Text, "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaCV.Focus();
                return false;
            }
            return true;
        }

        private bool checkTonTai()
        {
            string checkNV = "select MaNV from tblNhanVien where MaNV ='" + txtMaNV.Text + "'";
            if (db.Check(checkNV))
            {
                MessageBox.Show("Mã Nhân viên này đã có vui lòng chọn nhập mã khác ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNV.Focus();
                return false;

            }
            return true;
        }

        private bool checkNgay()
        {
            string checkNgay = $"select * from tblNhanVien where ('{dtpNgaySinh.Text}' > getdate())";
            if (db.Check(checkNgay))
            {
                MessageBox.Show("Năm vướt quá năm hiện tại ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpNgaySinh.Focus();
                return false;

            }
            return true;
        }
        private void dvgNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaNV.Text = dgvNhanVien.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTenNV.Text = dgvNhanVien.Rows[e.RowIndex].Cells[1].Value.ToString();
                if (dgvNhanVien.Rows[e.RowIndex].Cells[2].Value.ToString().Trim() == "Nam")
                {
                    rdbNam.Checked = true;
                }
                else
                {
                    rdbNu.Checked = true;
                }
                dtpNgaySinh.Text = dgvNhanVien.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtSDT.Text = dgvNhanVien.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtDiaChi.Text = dgvNhanVien.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtMaCV.Text = dgvNhanVien.Rows[e.RowIndex].Cells[6].Value.ToString();
            }
            
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                //nếu là chữ cái
                e.Handled = true;
        }

        private void CleanInput()
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            rdbNam.Checked = false;
            rdbNu.Checked = false;
            dtpNgaySinh.Value = DateTime.Now;
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            txtMaCV.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (isCheck() && checkTonTai() && checkNgay())
            {
                string rdbText = "";
                if (rdbNam.Checked == true)
                {
                    rdbText = rdbNam.Text;
                }
                else
                {
                    rdbText = rdbNu.Text;
                }
                string queryInsert = "insert into tblNhanVien values(N'" + txtMaNV.Text + "',N'" + txtTenNV.Text + "',N'" + rdbText + "','" + dtpNgaySinh.Text + "',N'" + txtSDT.Text + "',N'" + txtDiaChi.Text + "',N'" + txtMaCV.Text + "')";
                try
                {
                    if (MessageBox.Show("Bạn có muốn thêm vào không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        db.Excute(queryInsert);
                        FormNhanVien_Load(sender, e);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimMaNV.Text = "";
            txtTimTenNV.Text = "";
            CleanInput();
            FormNhanVien_Load(sender, e);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimTenNV.Text.Trim() == "")
            {
                MessageBox.Show("Mời bạn nhập tên tìm kiếm");
                txtTimTenNV.Focus();
            }
            else
            {
                if (db.table("select * from tblNhanVien where TenNV=N'" + txtTimTenNV.Text + "'").Rows.Count > 0)
                {
                    dgvNhanVien.DataSource = db.table("select * from tblNhanVien where TenNV=N'" + txtTimTenNV.Text + "'");
                    CleanInput();
                }
                else
                {
                    MessageBox.Show(txtTimTenNV.Text + " không có trong danh sách", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTimTenNV.Focus();
                    FormNhanVien_Load(sender, e);//load du lieu
                }

            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xuất dữ liệu ra file Excel không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Excel.Application exApp = new Excel.Application();
                Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
                Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];
                exSheet.get_Range("C2").Font.Bold = true;
                exSheet.get_Range("C2").Value = "Danh sách Nhân Viên";
                exSheet.get_Range("A3").Value = "Số TT";
                exSheet.get_Range("B3").Value = "Mã nhân viên ";
                exSheet.get_Range("C3").Value = "Tên nhân viên";
                exSheet.get_Range("D3").Value = "Giới tính";
                exSheet.get_Range("E3").Value = "Ngày sinh";
                exSheet.get_Range("F3").Value = "Số điện thoại";
                exSheet.get_Range("G3").Value = "Địa chỉ";
                exSheet.get_Range("H3").Value = "Mã công việc";
                int n = dgvNhanVien.Rows.Count;
                for (int i = 0; i < n; i++)
                {
                    exSheet.get_Range("A" + (i + 4).ToString()).Value
                        = (i + 1).ToString();
                    exSheet.get_Range("B" + (i + 4).ToString()).Value
                        = dgvNhanVien.Rows[i].Cells[0].Value;
                    exSheet.get_Range("C" + (i + 4).ToString()).Value
                        = dgvNhanVien.Rows[i].Cells[1].Value;
                    exSheet.get_Range("D" + (i + 4).ToString()).Value
                        = dgvNhanVien.Rows[i].Cells[2].Value;
                    exSheet.get_Range("E" + (i + 4).ToString()).Value
                        = dgvNhanVien.Rows[i].Cells[3].Value;
                    exSheet.get_Range("F" + (i + 4).ToString()).Value
                        = dgvNhanVien.Rows[i].Cells[4].Value;
                    exSheet.get_Range("G" + (i + 4).ToString()).Value
                       = dgvNhanVien.Rows[i].Cells[5].Value;
                    exSheet.get_Range("H" + (i + 4).ToString()).Value
                       = dgvNhanVien.Rows[i].Cells[6].Value;
                }
                exBook.Activate();
                SaveFileDialog openFileDialog = new SaveFileDialog();
                openFileDialog.Title = "Xuất file Excel";
                openFileDialog.Filter = "Excel (*.xlsx;*.xls;*.xlsm;)|*.xlsx;*.xls;*.xlsm;";
                openFileDialog.ShowDialog();
                exBook.SaveAs(openFileDialog.FileName.ToString());
                exApp.Quit();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string queryDelete = "delete from tblNhanVien where MaNV=N'" + txtMaNV.Text.Trim() + "' ";
            try
            {
                if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    db.Excute(queryDelete);
                    FormNhanVien_Load(sender, e);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (isCheck() && checkNgay())
            {
                string rdbText = "";
                if (rdbNam.Checked == true)
                {
                    rdbText = rdbNam.Text;
                }
                else
                {
                    rdbText = rdbNu.Text;
                }
                string queryUpdate = "update tblNhanVien set TenNV=N'" + txtTenNV.Text + "',GioiTinh=N'" + rdbText + "',NgaySinh='" + dtpNgaySinh.Text + "',DienThoai=N'" + txtSDT.Text + "',DC=N'" + txtDiaChi.Text + "',MaCV=N'" + txtMaCV.Text + "' where MaNV=N'" + txtMaNV.Text + "'";
                try
                {
                    if (MessageBox.Show("Bạn có muốn sửa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        db.Excute(queryUpdate);
                        FormNhanVien_Load(sender, e);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
