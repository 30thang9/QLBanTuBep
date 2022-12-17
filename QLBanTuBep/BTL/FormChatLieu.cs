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
    public partial class FormChatLieu : Form
    {
        public FormChatLieu()
        {
            InitializeComponent();
        }

        DBConfig db = new DBConfig();
        private void FormChatLieu_Load(object sender, EventArgs e)
        {
            dgvChatLieu.DataSource = db.table("Select * from tblChatLieu");
        }


        private bool isCheck()
        {
            if (txtMaChatLieu.Text.Trim() == "") { MessageBox.Show("Xin mời nhập mã chất liệu"); return false; }
            if (txtTenChatLieu.Text.Trim() == "") { MessageBox.Show("Xin mời nhập tên chất liệu"); return false; }
           
            return true;
        }

        private bool checkTonTai()
        {
            string checkCL = "select MaChatLieu from tblChatLieu where MaChatLieu ='" + txtMaChatLieu.Text + "'";
            if (db.Check(checkCL))
            {
                MessageBox.Show("Chất Liệu này đã có vui lòng chọn nhập mã khác ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaChatLieu.Focus();
                return false;

            }
            return true;
        }

        private bool checkCL()
        {
            string checkCL = $"select MaChatLieu from tblHangHoa where MaChatLieu = N'{txtMaChatLieu.Text}'";
            if (db.Check(checkCL))
            {
                MessageBox.Show(txtMaChatLieu.Text + " không thể xoá do hàng hoá tồn tại trong chi tiết hàng hoá ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaChatLieu.Focus();
                return false;
            }
            return true;
        }

        private void CleanInput()
        {
            txtMaChatLieu.Text = "";
            txtTenChatLieu.Text = "";
        }

      

        private void dgvChatLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >=0)
            {
                txtMaChatLieu.Text = dgvChatLieu.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTenChatLieu.Text = dgvChatLieu.Rows[e.RowIndex].Cells[1].Value.ToString();

            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtMaChatLieu.Text.Trim() == "")
            {
                MessageBox.Show("Mời bạn nhập mã chất liệu muốn tìm kiếm");
                txtMaChatLieu.Focus();
            }
            else
            {
                if (db.table($"SELECT * from tblChatLieu where MaChatLieu = '{txtMaChatLieu.Text}'").Rows.Count > 0)
                {
                    dgvChatLieu.DataSource = db.table($"SELECT * from tblChatLieu where MaChatLieu = '{txtMaChatLieu.Text}'");
                    CleanInput();
                }
                else
                {
                    MessageBox.Show(txtMaChatLieu.Text + " không có trong danh sách", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaChatLieu.Focus();
                    FormChatLieu_Load(sender, e);//load du lieu
                }

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (checkCL())
            {
                string query = $"Delete from tblChatLieu where MaChatLieu = '{txtMaChatLieu.Text}'";
                try
                {
                    if (MessageBox.Show("Bạn chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        db.Excute(query);
                        CleanInput();
                        FormChatLieu_Load(sender, e);
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
                string query = $"UPDATE tblChatLieu SET tblChatLieu.TenChatLieu=N'{txtTenChatLieu.Text}' where tblChatLieu.MaChatLieu='{txtMaChatLieu.Text}'";
                try
                {
                    if (MessageBox.Show("Bạn có muốn sửa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        db.Excute(query);
                        FormChatLieu_Load(sender, e);//load du lieu
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
            exSheet.get_Range("B2").Value = "DANH SÁCH CHẤT LIỆU";
            exSheet.get_Range("A3").Value = "Số TT";
            exSheet.get_Range("B3").Value = "Mã Chất Liệu";
            exSheet.get_Range("C3").Value = "Tên Chất Liệu";
            int n = dgvChatLieu.Rows.Count;
            for (int i = 0; i < n; i++)
            {
                exSheet.get_Range("A" + (i + 4).ToString()).Value
                    = (i + 1).ToString();
                exSheet.get_Range("B" + (i + 4).ToString()).Value
                    = dgvChatLieu.Rows[i].Cells[0].Value;
                exSheet.get_Range("C" + (i + 4).ToString()).Value
                    = dgvChatLieu.Rows[i].Cells[1].Value;
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
                MessageBox.Show("Không có danh sách chất liệu để in");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (isCheck() && checkTonTai())
            {
                string query = $"INSERT INTO tblChatLieu " +
                    $"VALUES('{txtMaChatLieu.Text}',N'{txtTenChatLieu.Text}')";
                
              
                try
                {
                    if (MessageBox.Show("Bạn có muốn thêm vào không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        db.Excute(query);
                        FormChatLieu_Load(sender, e);//load du lieu
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
