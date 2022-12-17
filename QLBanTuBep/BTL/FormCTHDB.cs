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
    public partial class FormCTHDB : Form
    {
        public FormCTHDB()
        {
            InitializeComponent();
        }

        DBConfig db = new DBConfig();
        private void FormCTHDB_Load(object sender, EventArgs e)
        {
            dgvCTHDB.DataSource = db.table("select * from tblChiTietHDB");
        }

        private bool isCheck()
        {
            if (txtSoHDB.Text.Trim() == "") { MessageBox.Show("Xin mời nhập số hóa đơn bán"); txtSoHDB.Focus(); return false; }
            if (txtMH.Text.Trim() == "") { MessageBox.Show("Xin mời nhập mã hàng"); txtMH.Focus(); return false; }
            if (txtSL.Text.Trim() == "") { MessageBox.Show("Xin mời nhập số lượng"); txtSL.Focus(); return false; }
            if (txtGG.Text.Trim() == "") { MessageBox.Show("Xin mời nhập giảm giá"); txtGG.Focus(); return false; }
            if (!db.Check($"select * from tblHoaDonBan where SoHDB = '{txtSoHDB.Text}'"))
            {
                MessageBox.Show("Không tồn tại mã " + txtSoHDB.Text, "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoHDB.Focus();
                return false;
            }
            if (!db.Check($"select * from tblHangHoa where MaHang = '{txtMH.Text}'"))
            {
                MessageBox.Show("Không tồn tại mã " + txtMH.Text, "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMH.Focus();
                return false;
            }
            return true;
        }

        private bool checkTonTai()
        {
            string checkChiTietHDB = "select SoHDB from tblChiTietHDB where SoHDB ='" + txtSoHDB.Text + "' and MaHang ='" + txtMH.Text + "'";
            if (db.Check(checkChiTietHDB))
            {
                MessageBox.Show("Số Hoá Đơn Bán và mã hàng  này đã có vui lòng chọn nhập số hóa đơn bán và mã hàng  khác ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoHDB.Focus();
                return false;

            }
            return true;
        }
        private void CleanInput()
        {
            txtSoHDB.Text = "";
            txtMH.Text = "";
            txtSL.Text = "";
            txtGG.Text = "";
        }

        private void dgvCTHDB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtSoHDB.Text = dgvCTHDB.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtMH.Text = dgvCTHDB.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtSL.Text = dgvCTHDB.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtGG.Text = dgvCTHDB.Rows[e.RowIndex].Cells[3].Value.ToString();

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string sqlCheckHDB = "select * from tblHoaDonBan where SoHDB = N'" + txtSoHDB.Text + "' ";
            if (isCheck() && checkTonTai())
            {
                string sqlcheckSL = "select SoLuong from tblHangHoa where MaHang ='" + txtMH.Text + "'";
                if (Convert.ToInt32(db.getValues(sqlcheckSL)) - Convert.ToInt32(txtSL.Text) < 0)
                {
                    MessageBox.Show("Số lượng tồn không đủ ");
                    txtSL.Focus();
                    return;
                }
                else
                {
                    string query = $"insert into tblChiTietHDB(SoHDB, MaHang, SoLuong, GiamGia) values(N'{txtSoHDB.Text}', N'{txtMH.Text}', N'{txtSL.Text}', N'{txtGG.Text}')";
                    try
                    {
                        if (MessageBox.Show("Bạn có muốn thêm vào không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            if (!db.Check(sqlCheckHDB))
                            {
                                MessageBox.Show("Không có " + txtSoHDB.Text + " trong danh sách hóa đơn bán");
                                txtSoHDB.Focus();
                                return;
                            }
                            else
                            {
                                db.Excute(query);
                                FormCTHDB_Load(sender, e);//load du lieu
                                CleanInput();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (isCheck())
            {
                string query = $"UPDATE tblChiTietHDB SET  tblChiTietHDB.SoLuong='{txtSL.Text}',tblChiTietHDB.GiamGia='{txtGG.Text}' where tblChiTietHDB.SoHDB='{txtSoHDB.Text}' and tblChiTietHDB.MaHang=N'{txtMH.Text}'";
                try
                {
                    if (MessageBox.Show("Bạn có muốn sửa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        db.Excute(query);
                        FormCTHDB_Load(sender, e);//load du lieu
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
            string query = $"delete tblChiTietHDB where SoHDB = '{txtSoHDB.Text}' and MaHang=N'{txtMH.Text}'";
            try
            {
                if (MessageBox.Show("Bạn chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    db.Excute(query);
                    CleanInput();
                    FormCTHDB_Load(sender, e);//load du lieu
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
            exSheet.get_Range("B2").Value = "DANH SÁCH CHI TIẾT HÓA ĐƠN BÁN";
            exSheet.get_Range("A3").Value = "Số TT";
            exSheet.get_Range("B3").Value = "Số Hóa Đơn Bán";
            exSheet.get_Range("C3").Value = "Mã Hàng";
            exSheet.get_Range("D3").Value = "Số Lượng";
            exSheet.get_Range("E3").Value = "Giảm Giá";
            exSheet.get_Range("F3").Value = "Thành Tiền";
            int n = dgvCTHDB.Rows.Count;
            for (int i = 0; i < n; i++)
            {
                exSheet.get_Range("A" + (i + 4).ToString()).Value
                    = (i + 1).ToString();
                exSheet.get_Range("B" + (i + 4).ToString()).Value
                    = dgvCTHDB.Rows[i].Cells[0].Value;
                exSheet.get_Range("C" + (i + 4).ToString()).Value
                    = dgvCTHDB.Rows[i].Cells[1].Value;
                exSheet.get_Range("D" + (i + 4).ToString()).Value
                    = dgvCTHDB.Rows[i].Cells[2].Value;
                exSheet.get_Range("E" + (i + 4).ToString()).Value
                    = dgvCTHDB.Rows[i].Cells[3].Value;
                exSheet.get_Range("F" + (i + 4).ToString()).Value
                    = dgvCTHDB.Rows[i].Cells[4].Value;
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
            if (txtSoHDB.Text.Trim() == "")
            {
                MessageBox.Show("Mời bạn nhập số hóa đơn bán muốn tìm kiếm");
                txtSoHDB.Focus();
            }
            else
            {
                if (db.table($"select  *  from tblChiTietHDB where SoHDB = N'{txtSoHDB.Text}'").Rows.Count > 0)
                {
                    dgvCTHDB.DataSource = db.table($"select  *  from tblChiTietHDB where SoHDB = N'{txtSoHDB.Text}'");
                    CleanInput();
                }
                else
                {
                    MessageBox.Show(txtSoHDB.Text + " không có trong danh sách", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoHDB.Focus();
                    FormCTHDB_Load(sender, e);//load du lieu
                }

            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtGG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                //nếu là chữ cái
                e.Handled = true;
        }

        private void txtSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                //nếu là chữ cái
                e.Handled = true;
        }
    }
}
