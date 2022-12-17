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
    public partial class FormNuocSanXuat : Form
    {
        public FormNuocSanXuat()
        {
            InitializeComponent();
        }
        DBConfig db = new DBConfig();
        private void FormNuocSanXuat_Load(object sender, EventArgs e)
        {
            dgvNSX.DataSource = db.table("Select * from tblNuocSX");
        }

        private bool isCheck()
        {
            if (txtMaNSX.Text.Trim() == "") { MessageBox.Show("Xin mời nhập mã nước sản xuất"); return false; }
            if (txtTenNSX.Text.Trim() == "") { MessageBox.Show("Xin mời nhập tên nước sản xuất"); return false; }
           
            return true;
        }

        private bool checkTonTai()
        {
            string checkNSX = "select MaNuocSX from tblNuocSX where MaNuocSX ='" + txtMaNSX.Text + "'";
            if (db.Check(checkNSX))
            {
                MessageBox.Show("Mã Nước sản xuất này đã có vui lòng chọn nhập mã khác ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNSX.Focus();
                return false;

            }
            return true;
        }

        private bool checkNSX()
        {
            string checkNSX = $"select MaNuocSX from tblHangHoa where MaNuocSX = N'{txtMaNSX.Text}'";
            if (db.Check(checkNSX))
            {
                MessageBox.Show(txtMaNSX.Text + " không thể xoá do hàng hoá tồn tại trong chi tiết hàng hoá ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNSX.Focus();
                return false;
            }
            return true;
        }

        private void CleanInput()
        {
            txtMaNSX.Text = "";
            txtTenNSX.Text = "";
        }

        private void dgvNSX_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaNSX.Text = dgvNSX.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
                txtTenNSX.Text = dgvNSX.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
            }
        }

       

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (isCheck() && checkTonTai())
            {
                string query = $"INSERT INTO tblNuocSX " +
                    $"VALUES('{txtMaNSX.Text}',N'{txtTenNSX.Text}')";
                try
                {
                    if (MessageBox.Show("Bạn có muốn thêm vào không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        db.Excute(query);
                        FormNuocSanXuat_Load(sender, e);//load du lieu
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
            if (txtMaNSX.Text.Trim() == "")
            {
                MessageBox.Show("Mời bạn nhập mã NSX muốn tìm kiếm");
                txtMaNSX.Focus();
            }
            else
            {
                if (db.table($"SELECT * from tblNuocSX where MaNuocSX = '{txtMaNSX.Text}'").Rows.Count > 0)
                {
                    dgvNSX.DataSource = db.table($"SELECT * from tblNuocSX where MaNuocSX = '{txtMaNSX.Text}'");
                    CleanInput();
                }
                else
                {
                    MessageBox.Show(txtMaNSX.Text + " không có trong danh sách", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    FormNuocSanXuat_Load(sender, e);//load du lieu
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (checkNSX())
            {
                string query = $"Delete from tblNuocSX where MaNuocSX = N'{txtMaNSX.Text}'";
                try
                {
                    if (MessageBox.Show("Bạn chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        db.Excute(query);
                        CleanInput();
                        FormNuocSanXuat_Load(sender, e);
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
            if (isCheck())
            {
                string query = $"UPDATE tblNuocSX SET TenNuocSX=N'{txtTenNSX.Text}' where MaNuocSX='{txtMaNSX.Text}'";
                try
                {
                    if (MessageBox.Show("Bạn có muốn sửa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        db.Excute(query);
                        FormNuocSanXuat_Load(sender, e);//load du lieu
                        CleanInput();
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
            exSheet.get_Range("B2").Value = "DANH SÁCH NƯỚC SẢN XUẤT";
            exSheet.get_Range("A3").Value = "Số TT";
            exSheet.get_Range("B3").Value = "Mã Nước Sản Xuất";
            exSheet.get_Range("C3").Value = "Tên Nước Sản Xuất";
            int n = dgvNSX.Rows.Count;
            for (int i = 0; i < n; i++)
            {
                exSheet.get_Range("A" + (i + 4).ToString()).Value
                    = (i + 1).ToString();
                exSheet.get_Range("B" + (i + 4).ToString()).Value
                    = dgvNSX.Rows[i].Cells[0].Value;
                exSheet.get_Range("C" + (i + 4).ToString()).Value
                    = dgvNSX.Rows[i].Cells[1].Value;
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
                MessageBox.Show("Không có danh sách nước sản xuất để in");
            }
        }
    }
}
