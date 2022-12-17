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
    public partial class FormKichThuoc : Form
    {
        public FormKichThuoc()
        {
            InitializeComponent();
        }

        DBConfig db = new DBConfig();
        private void FormKichThuoc_Load(object sender, EventArgs e)
        {
            dgvKichThuoc.DataSource = db.table("Select * from tblKichThuoc");
        }

        private bool isCheck()
        {
            if (txtMaKT.Text.Trim() == "") { MessageBox.Show("Xin mời nhập mã kích thước"); return false; }
            if (txtTenKT.Text.Trim() == "") { MessageBox.Show("Xin mời nhập tênkích thước"); return false; }
            
         
            return true;
        }

        private bool checkKT()
        {
            string checkKT = $"select MaKichThuoc from tblHangHoa where MaKichThuoc = N'{txtMaKT.Text}'";
            if (db.Check(checkKT))
            {
                MessageBox.Show(txtMaKT.Text + " không thể xoá do hàng hoá tồn tại trong chi tiết hàng hoá ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKT.Focus();
                return false;
            }
            return true;
        }

        private bool checkTonTai()
        {
            string checkKT = "select MaKichThuoc from tblKichThuoc where MaKichThuoc ='" + txtMaKT.Text + "'";
            if (db.Check(checkKT))
            {
                MessageBox.Show("Mã Kích Thước này đã có vui lòng chọn nhập mã khác ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKT.Focus();
                return false;

            }
            return true;
        }


        private void CleanInput()
        {
            txtMaKT.Text = "";
            txtTenKT.Text = "";
        }


        private void dgvKichThuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaKT.Text = dgvKichThuoc.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
                txtTenKT.Text = dgvKichThuoc.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
            }
        }

        

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (isCheck() && checkTonTai())
            {
                string query = $"INSERT INTO tblKichThuoc " +
                    $"VALUES('{txtMaKT.Text}',N'{txtTenKT.Text}')";
                try
                {
                    if (MessageBox.Show("Bạn có muốn thêm vào không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        db.Excute(query);
                        FormKichThuoc_Load(sender, e);//load du lieu
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
            if (checkKT())
            {
                string query = $"Delete from tblKichThuoc where MaKichThuoc = '{txtMaKT.Text}'";
                try
                {
                    if (MessageBox.Show("Bạn chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        db.Excute(query);
                        CleanInput();
                        FormKichThuoc_Load(sender, e);
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
                string query = $"UPDATE tblKichThuoc SET tblKichThuoc.TenKichThuoc=N'{txtTenKT.Text}' where tblKichThuoc.MaKichThuoc='{txtMaKT.Text}'";
                try
                {
                    if (MessageBox.Show("Bạn có muốn sửa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        db.Excute(query);
                        FormKichThuoc_Load(sender, e);//load du lieu
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
            exSheet.get_Range("B2").Value = "DANH SÁCH KÍCH THƯỚC";
            exSheet.get_Range("A3").Value = "Số TT";
            exSheet.get_Range("B3").Value = "Mã Kích Thước";
            exSheet.get_Range("C3").Value = "Tên Kích Thước";
            int n = dgvKichThuoc.Rows.Count;
            for (int i = 0; i < n; i++)
            {
                exSheet.get_Range("A" + (i + 4).ToString()).Value
                    = (i + 1).ToString();
                exSheet.get_Range("B" + (i + 4).ToString()).Value
                    = dgvKichThuoc.Rows[i].Cells[0].Value;
                exSheet.get_Range("C" + (i + 4).ToString()).Value
                    = dgvKichThuoc.Rows[i].Cells[1].Value;
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
                MessageBox.Show("Không có danh sách kích thước để in");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtMaKT.Text.Trim() == "")
            {
                MessageBox.Show("Mời bạn nhập mã kích thước muốn tìm kiếm");
                txtMaKT.Focus();
            }
            else
            {
                if (db.table($"SELECT * from tblKichThuoc where MaKichThuoc = '{txtMaKT.Text}'").Rows.Count > 0)
                {
                    dgvKichThuoc.DataSource = db.table($"SELECT * from tblKichThuoc where MaKichThuoc = '{txtMaKT.Text}'");
                    CleanInput();
                }
                else
                {
                    MessageBox.Show(txtMaKT.Text + " không có trong danh sách", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaKT.Focus();
                    FormKichThuoc_Load(sender, e);//load du lieu
                }

            }
        }
    }
}
