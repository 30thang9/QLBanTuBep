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
    public partial class FormNhaCungCap : Form
    {
        public FormNhaCungCap()
        {
            InitializeComponent();
        }


        DBConfig db = new DBConfig();
        private void FormNhaCungCap_Load(object sender, EventArgs e)
        {
            dgvNCC.DataSource = db.table("Select * from tblNhaCungCap");
        }

        private bool isCheck()
        {
            if (txtMaNCC.Text.Trim() == "")
            {
                MessageBox.Show("Xin mời nhập mã NCC");
                txtMaNCC.Focus();
                return false;
            }
            if (txtTenNCC.Text.Trim() == "")
            {
                MessageBox.Show("Xin mời nhập tên NCC");
                txtTenNCC.Focus();
                return false;
            }
            if (txtSDT.Text.Trim() == "")
            {
                MessageBox.Show("Xin mời nhập số điện thoại");
                txtSDT.Focus();
                return false;
            }
            if (txtDC.Text.Trim() == "")
            {
                MessageBox.Show("Xin mời nhập địa chỉ");
                txtDC.Focus();
                return false;
            }
           
            return true;
        }

        private bool checkTonTai()
        {
            string checkNCC = "select MaNCC from tblNhaCungCap where MaNCC ='" + txtMaNCC.Text + "'";
            if (db.Check(checkNCC))
            {
                MessageBox.Show("Mã Nhà cung cấp này đã có vui lòng chọn nhập mã khác ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNCC.Focus();
                return false;

            }
            return true;
        }

        private bool isCheckTK()
        {
            if (txtMaNCC.Text.Trim() == "")
            {
                MessageBox.Show("Xin mời nhập mã NCC để tìm kiếm");
                txtMaNCC.Focus();
                return false;
            }

            return true;

        }
        private void CleanInput()
        {
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtSDT.Text = "";
            txtDC.Text = "";
        }


        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                //nếu là chữ cái
                e.Handled = true;
            }
        }

        private void dgvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaNCC.Text = dgvNCC.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
                txtTenNCC.Text = dgvNCC.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                txtDC.Text = dgvNCC.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
                txtSDT.Text = dgvNCC.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (isCheck() && checkTonTai())
            {
                string query = $"INSERT INTO tblNhaCungCap VALUES('{txtMaNCC.Text}',N'{txtTenNCC.Text}','{txtDC.Text}',N'{txtSDT.Text}')";
                try
                {
                    if (MessageBox.Show("Bạn có muốn thêm vào không", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        db.Excute(query);
                        FormNhaCungCap_Load(sender, e); //load dữ liệu
                        CleanInput();
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
            string query = $"UPDATE tblNhaCungCap SET MaNCC = '{txtMaNCC.Text}', TenNCC = N'{txtTenNCC.Text}', DienThoai = N'{txtSDT.Text}', DC = N'{txtDC.Text}'WHERE MaNCC = N'{txtMaNCC.Text}'";
            try
            {
                if (MessageBox.Show("Bạn chắc chắn muốn sửa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    db.Excute(query);
                    CleanInput();
                    FormNhaCungCap_Load(sender, e);//load du lieu
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string query = $"Delete from tblNhaCungCap where MaNCC = '{txtMaNCC.Text}'";
            try
            {
                if (MessageBox.Show("Bạn chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    db.Excute(query);
                    CleanInput();
                    FormNhaCungCap_Load(sender, e);//load du lieu
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
            exSheet.get_Range("B2").Value = "Danh sách nhà cung cấp";
            exSheet.get_Range("A3").Value = "Số TT";
            exSheet.get_Range("B3").Value = "Mã NCC";
            exSheet.get_Range("C3").Value = "Tên NCC";
            exSheet.get_Range("D3").Value = "Địa Chỉ";
            exSheet.get_Range("E3").Value = "Điện Thoại";
            int n = dgvNCC.Rows.Count;
            for (int i = 0; i < n; i++)
            {
                exSheet.get_Range("A" + (i + 4).ToString()).Value
                    = (i + 1).ToString();
                exSheet.get_Range("B" + (i + 4).ToString()).Value
                    = dgvNCC.Rows[i].Cells[0].Value;
                exSheet.get_Range("C" + (i + 4).ToString()).Value
                    = dgvNCC.Rows[i].Cells[1].Value;
                exSheet.get_Range("D" + (i + 4).ToString()).Value
                    = dgvNCC.Rows[i].Cells[2].Value;
                exSheet.get_Range("E" + (i + 4).ToString()).Value
                    = dgvNCC.Rows[i].Cells[3].Value;
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
                MessageBox.Show("Không có danh sách Nhà cung cấp để in");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTenNCC.Text.Trim() == "")
            {
                MessageBox.Show("Mời bạn nhập tên NCC muốn tìm kiếm");
                txtTenNCC.Focus();
            }
            else
            {
                if (db.table($"select  *  from tblNhaCungCap where TenNCC = N'{txtTenNCC.Text}'").Rows.Count > 0)
                {
                    dgvNCC.DataSource = db.table($"select  *  from tblNhaCungCap where TenNCC = N'{txtTenNCC.Text}'");
                    CleanInput();
                }
                else
                {
                    MessageBox.Show(txtTenNCC.Text + " không có trong danh sách", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenNCC.Focus();
                    FormNhaCungCap_Load(sender, e);//load du lieu
                }

            }
        }
    }
}
