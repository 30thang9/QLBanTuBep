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
    public partial class FormMauSac : Form
    {
        public FormMauSac()
        {
            InitializeComponent();
        }

        DBConfig db = new DBConfig();

        private bool isCheck()
        {
            if (txtMaMau.Text.Trim() == "") { MessageBox.Show("Xin mời nhập mã màu"); return false; }
            if (txtTenMau.Text.Trim() == "") { MessageBox.Show("Xin mời nhập tên màu"); return false; }
          
            return true;
        }

        private bool checkTonTai()
        {
            string checkMS = "select MaMau from tblMauSac where MaMau ='" + txtMaMau.Text + "'";
            if (db.Check(checkMS))
            {
                MessageBox.Show("Mã Màu sắc này đã có vui lòng chọn nhập mã khác ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaMau.Focus();
                return false;

            }
            return true;
        }

        private bool checkMS()
        {
            string checkMS = $"select MaMau from tblHangHoa where MaMau = N'{txtMaMau.Text}'";
            if (db.Check(checkMS))
            {
                MessageBox.Show(txtMaMau.Text + " không thể xoá do hàng hoá tồn tại trong chi tiết hàng hoá ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaMau.Focus();
                return false;
            }
            return true;
        }

        private void CleanInput()
        {
            txtMaMau.Text = "";
            txtTenMau.Text = "";
        }
        private void FormMauSac_Load(object sender, EventArgs e)
        {
            dgvMauSac.DataSource = db.table("Select * from tblMauSac");
        }

        private void dgvMauSac_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaMau.Text = dgvMauSac.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
                txtTenMau.Text = dgvMauSac.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
            }
        }


        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtMaMau.Text.Trim() == "")
            {
                MessageBox.Show("Mời bạn nhập mã màu muốn tìm kiếm");
                txtMaMau.Focus();
            }
            else
            {
                if (db.table($"SELECT * from tblMauSac where MaMau = '{txtMaMau.Text}'").Rows.Count > 0)
                {
                    dgvMauSac.DataSource = db.table($"SELECT * from tblMauSac where MaMau = '{txtMaMau.Text}'");
                    CleanInput();
                }
                else
                {
                    MessageBox.Show(txtMaMau.Text + " không có trong danh sách", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaMau.Focus();
                    FormMauSac_Load(sender, e);//load du lieu
                }

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (isCheck() && checkTonTai())
            {
                string query = $"INSERT INTO tblMauSac " +
                    $"VALUES('{txtMaMau.Text}',N'{txtTenMau.Text}')";
                try
                {
                    if (MessageBox.Show("Bạn có muốn thêm vào không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        db.Excute(query);
                        FormMauSac_Load(sender, e);//load du lieu
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
            exSheet.get_Range("B2").Value = "DANH SÁCH Màu";
            exSheet.get_Range("A3").Value = "Số TT";
            exSheet.get_Range("B3").Value = "Mã Màu";
            exSheet.get_Range("C3").Value = "Tên Màu";
            int n = dgvMauSac.Rows.Count;
            for (int i = 0; i < n; i++)
            {
                exSheet.get_Range("A" + (i + 4).ToString()).Value
                    = (i + 1).ToString();
                exSheet.get_Range("B" + (i + 4).ToString()).Value
                    = dgvMauSac.Rows[i].Cells[0].Value;
                exSheet.get_Range("C" + (i + 4).ToString()).Value
                    = dgvMauSac.Rows[i].Cells[1].Value;
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
                MessageBox.Show("Không có danh sách màu để in");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (checkMS())
            {
                string query = $"Delete from tblMauSac where MaMau = '{txtMaMau.Text}'";
                try
                {
                    if (MessageBox.Show("Bạn chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        db.Excute(query);
                        CleanInput();
                        FormMauSac_Load(sender, e);
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
                string query = $"UPDATE tblMauSac SET tblMauSac.TenMau=N'{txtTenMau.Text}' where tblMauSac.MaMau='{txtMaMau.Text}'";
                try
                {
                    if (MessageBox.Show("Bạn có muốn sửa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        db.Excute(query);
                        FormMauSac_Load(sender, e);//load du lieu
                        CleanInput();
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
