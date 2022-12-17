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
    public partial class FormCongViec : Form
    {
        public FormCongViec()
        {
            InitializeComponent();
        }
        DBConfig db = new DBConfig();
        private void FormCongViec_Load(object sender, EventArgs e)
        {
            dgvCongViec.DataSource = db.table("select * from tblCongViec");
        }

        private bool isCheck()
        {
            if (txtMaCV.Text.Trim() == "") { MessageBox.Show("Xin mời nhập mã công việc"); return false; }
            if (txtTenCV.Text.Trim() == "") { MessageBox.Show("Xin mời nhập tên công việc"); return false; }
            if (txtML.Text.Trim() == "") { MessageBox.Show("Xin mời nhập mức lương"); return false; }
            
            return true;
        }

        private bool checkTonTai()
        {
            string checkCV = "select MaCV from tblCongViec where MaCV ='" + txtMaCV.Text + "'";
            if (db.Check(checkCV))
            {
                MessageBox.Show("Mã công việc này đã có vui lòng chọn nhập mã khác ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaCV.Focus();
                return false;

            }
            return true;
        }

        private bool checkCV()
        {
            string CheckCV = $"select MaCV from tblNhanVien where MaCV = '{txtMaCV.Text}'";
            if (db.Check(CheckCV))
            {
                MessageBox.Show(txtMaCV.Text + " không thể xoá do công việc tồn tại trong nhân viên ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaCV.Focus();
                return false;

            }
            return true;
        }
        private void CleanInput()
        {
            txtMaCV.Text = "";
            txtTenCV.Text = "";
            txtML.Text = "";
        }

        private void dgvCongViec_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaCV.Text = dgvCongViec.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTenCV.Text = dgvCongViec.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtML.Text = dgvCongViec.Rows[e.RowIndex].Cells[2].Value.ToString();

            }
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (isCheck() && checkTonTai() )
            {
                string query = $"INSERT INTO tblCongViec " +
                    $"VALUES('{txtMaCV.Text}',N'{txtTenCV.Text}','{txtML.Text}')";
                try
                {
                    if (MessageBox.Show("Bạn có muốn thêm vào không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        db.Excute(query);
                        FormCongViec_Load(sender, e);//load du lieu
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
            if (isCheck())
            {
                string query = $"UPDATE tblCongViec SET TenCV=N'{txtTenCV.Text}',MucLuong='{txtML.Text}' where MaCV=N'{txtMaCV.Text}'";
                try
                {
                    if (MessageBox.Show("Bạn có muốn sửa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        db.Excute(query);
                        FormCongViec_Load(sender, e);//load du lieu
                        CleanInput();
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
            if (checkCV())
            {
                string query = $"Delete from tblCongViec where MaCV = N'{txtMaCV.Text}'";
                try
                {
                    if (MessageBox.Show("Bạn chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        db.Excute(query);
                        CleanInput();
                        FormCongViec_Load(sender, e);//load du lieu
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
            exSheet.get_Range("B2").Value = "Danh sách công việc";
            exSheet.get_Range("A3").Value = "Số TT";
            exSheet.get_Range("B3").Value = "Mã Công Việc";
            exSheet.get_Range("C3").Value = "Tên Công Việc";
            exSheet.get_Range("D3").Value = "Mức Lương";
            int n = dgvCongViec.Rows.Count;
            for (int i = 0; i < n; i++)
            {
                exSheet.get_Range("A" + (i + 4).ToString()).Value
                    = (i + 1).ToString();
                exSheet.get_Range("B" + (i + 4).ToString()).Value
                    = dgvCongViec.Rows[i].Cells[0].Value;
                exSheet.get_Range("C" + (i + 4).ToString()).Value
                    = dgvCongViec.Rows[i].Cells[1].Value;
                exSheet.get_Range("D" + (i + 4).ToString()).Value
                    = dgvCongViec.Rows[i].Cells[2].Value;
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
            if (txtMaCV.Text.Trim() == "")
            {
                MessageBox.Show("Mời bạn mã công việc muốn tìm kiếm");
                txtMaCV.Focus();
            }
            else
            {
                if (db.table($"select  *  from tblCongViec where MaCV = N'{txtMaCV.Text}'").Rows.Count > 0)
                {
                    dgvCongViec.DataSource = db.table($"select  *  from tblCongViec where MaCV = N'{txtMaCV.Text}'");
                    CleanInput();
                }
                else
                {
                    MessageBox.Show(txtMaCV.Text + " không có trong danh sách", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaCV.Focus();
                    FormCongViec_Load(sender, e);//load du lieu
                }

            }
        }
    }
}
