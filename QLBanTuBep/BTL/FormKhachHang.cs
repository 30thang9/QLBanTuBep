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
    public partial class FormKhachHang : Form
    {
        public FormKhachHang()
        {
            InitializeComponent();
        }
        DBConfig db = new DBConfig();
        private void FormKhachHang_Load(object sender, EventArgs e)
        {
            dgvKhachHang.DataSource = db.table("select * from tblKhachHang");
        }

        private void CleanInput()
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtDC.Text = "";
            txtSDT.Text = "";
            txtTimMaKH.Text = "";
            txtTimTenKH.Text = "";

        }
        private bool ischeck()
        {
            if (txtMaKH.Text.Trim() == "")
            {
                MessageBox.Show("không được để trống mã khách hàng");
                return false;
            }
            if (txtTenKH.Text.Trim() == "")
            {
                MessageBox.Show("không được để trống tên khách hàng");
                return false;
            }
            if (txtDC.Text.Trim() == "")
            {
                MessageBox.Show("Không được để trống địa chỉ");
                return false;
            }
            if (txtSDT.Text.Trim() == "")
            {
                MessageBox.Show("Không được để trống số điện thoại");
                return false;
            }
      
            return true;
        }

        private bool checkTonTai()
        {
            string checkKH = "select MaKhach from tblKhachHang where MaKhach ='" + txtMaKH.Text + "'";
            if (db.Check(checkKH))
            {
                MessageBox.Show("Mã Khách Hàng này đã có vui lòng chọn nhập mã khác ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKH.Focus();
                return false;

            }
            return true;
        }
        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaKH.Text = dgvKhachHang.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
                txtTenKH.Text = dgvKhachHang.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                txtDC.Text = dgvKhachHang.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
                txtSDT.Text = dgvKhachHang.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();
            }
           
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                //nếu là chữ cái
                e.Handled = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (ischeck() && checkTonTai())
            {
                string query = $"INSERT INTO tblKhachHang VALUES('{txtMaKH.Text}',N'{txtTenKH.Text}',N'{txtDC.Text}',N'{txtSDT.Text}')";
                try
                {
                    if (MessageBox.Show("Bạn có muốn thêm vào không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        db.Excute(query);
                        FormKhachHang_Load(sender, e); // load du lieu
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
            string query = $"UPDATE tblKhachHang SET TenKhach = N'{txtTenKH.Text}' , DC= N'{txtDC.Text}' , DienThoai=N'{txtSDT.Text}' where MaKhach = N'{txtMaKH.Text}'";
            try
            {
                if (MessageBox.Show("Bạn có muốn sửa vào không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    db.Excute(query);
                    FormKhachHang_Load(sender, e); // load du lieu
                    CleanInput();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string query = $"DELETE from tblKhachHang where MaKhach = '{txtMaKH.Text}'";
            try
            {
                if (MessageBox.Show("Bạn chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    db.Excute(query);
                    CleanInput();
                    FormKhachHang_Load(sender, e);//load du lieu
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimTenKH.Text.Trim() == "")
            {
                MessageBox.Show("Mời bạn nhập tên khách hàng muốn tìm kiếm");
                txtTimTenKH.Focus();
            }
            else
            {
                if (db.table($"select  *  from tblKhachHang where TenKhach = N'{txtTimTenKH.Text}'").Rows.Count > 0)
                {
                    dgvKhachHang.DataSource = db.table($"select  *  from tblKhachHang where TenKhach = N'{txtTimTenKH.Text}'");
                    CleanInput();
                }
                else
                {
                    MessageBox.Show(txtTimTenKH.Text + " không có trong danh sách", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTimTenKH.Focus();
                    FormKhachHang_Load(sender, e);//load du lieu
                }

            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Excel.Application exApp = new Excel.Application();
            Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];
            exSheet.get_Range("B2").Font.Bold = true;
            exSheet.get_Range("B2").Value = "Danh sách khách hàng";
            exSheet.get_Range("A3").Value = "Số TT";
            exSheet.get_Range("B3").Value = "Mã Khách Hàng";
            exSheet.get_Range("C3").Value = "Tên Khách Hàng";
            exSheet.get_Range("D3").Value = "Địa Chỉ";
            exSheet.get_Range("E3").Value = "Điện Thoại";
            int n = dgvKhachHang.Rows.Count;
            for (int i = 0; i < n; i++)
            {
                exSheet.get_Range("A" + (i + 4).ToString()).Value
                    = (i + 1).ToString();
                exSheet.get_Range("B" + (i + 4).ToString()).Value
                    = dgvKhachHang.Rows[i].Cells[0].Value;
                exSheet.get_Range("C" + (i + 4).ToString()).Value
                    = dgvKhachHang.Rows[i].Cells[1].Value;
                exSheet.get_Range("D" + (i + 4).ToString()).Value
                    = dgvKhachHang.Rows[i].Cells[2].Value;
                exSheet.get_Range("E" + (i + 4).ToString()).Value
                    = dgvKhachHang.Rows[i].Cells[3].Value;
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
                MessageBox.Show("Không có danh sách khách hàng để in");
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimMaKH.Text = "";
            txtTimTenKH.Text = "";
            FormKhachHang_Load(sender, e);
            CleanInput();
        }
    }
}
