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
    public partial class FormCTHDN : Form
    {
        public FormCTHDN()
        {
            InitializeComponent();
        }

        DBConfig db = new DBConfig();

        private void FormCTHDN_Load(object sender, EventArgs e)
        {
            dgvCTHDN.DataSource = db.table("select * from tblChiTietHDN");
        }

        private bool isCheck()
        {
            if (txtSoHDN.Text.Trim() == "") { MessageBox.Show("Xin mời nhập số hóa đơn bán"); txtSoHDN.Focus(); return false; }
            if (txtMH.Text.Trim() == "") { MessageBox.Show("Xin mời nhập mã hàng"); txtMH.Focus(); return false; }
            if (txtSL.Text.Trim() == "") { MessageBox.Show("Xin mời nhập số lượng"); txtSL.Focus(); return false; }
            if (txtDG.Text.Trim() == "") { MessageBox.Show("Xin mời nhập đơn giá"); txtDG.Focus(); return false; }
            if (txtGG.Text.Trim() == "") { MessageBox.Show("Xin mời nhập giảm giá"); txtGG.Focus(); return false; }
            if (!db.Check($"select * from tblHoaDonNhap where SoHDN = '{txtSoHDN.Text}'"))
            {
                MessageBox.Show("Không tồn tại mã " + txtSoHDN.Text, "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoHDN.Focus();
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
            string checkChiTietHDN = "select SoHDN from tblChiTietHDN where SoHDN ='" + txtSoHDN.Text + "' and MaHang ='" + txtMH.Text + "'";
            if (db.Check(checkChiTietHDN))
            {
                MessageBox.Show("Chi Tiết Hoá Đơn Nhập này đã có vui lòng chọn nhập mã khác ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoHDN.Focus();
                return false;

            }
            return true;
        }
        private void CleanInput()
        {
            txtSoHDN.Text = "";
            txtMH.Text = "";
            txtSL.Text = "";
            txtGG.Text = "";
            txtDG.Text = "";
        }

        private void dgvCTHDN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtSoHDN.Text = dgvCTHDN.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtMH.Text = dgvCTHDN.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtSL.Text = dgvCTHDN.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtDG.Text = dgvCTHDN.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtGG.Text = dgvCTHDN.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (isCheck()  && checkTonTai())
            {
                string query = $"insert into tblChiTietHDN(SoHDN, MaHang, SoLuong, DonGia, GiamGia) values(N'{txtSoHDN.Text}', N'{txtMH.Text}', N'{txtSL.Text}', '{txtDG.Text}', N'{txtGG.Text}')";
                string sqlCheckHDN = "select * from tblHoaDonNhap where SoHDN = N'" + txtSoHDN.Text + "'";
                try
                {
                    if (MessageBox.Show("Bạn có muốn thêm vào không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        if (!db.Check(sqlCheckHDN))
                        {
                            MessageBox.Show("Không có " + txtSoHDN.Text + " trong danh sách hóa đơn nhập");
                            txtSoHDN.Focus();
                            return;
                        }
                        else
                        {
                            db.Excute(query);
                            FormCTHDN_Load(sender, e);//load du lieu
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string query = $"delete tblChiTietHDN where SoHDN = '{txtSoHDN.Text}' and MaHang = '{txtMH.Text}'";
            try
            {
                if (MessageBox.Show("Bạn chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    db.Excute(query);
                    CleanInput();
                    FormCTHDN_Load(sender, e);//load du lieu
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (isCheck())
            {
                string query = $"UPDATE tblChiTietHDN SET tblChiTietHDN.SoLuong='{txtSL.Text}',tblChiTietHDN.DonGia='{txtDG.Text}' ,tblChiTietHDN.GiamGia='{txtGG.Text}' where tblChiTietHDN.SoHDN='{txtSoHDN.Text}' and MaHang = '{txtMH.Text}'";
                try
                {
                    if (MessageBox.Show("Bạn có muốn sửa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        db.Excute(query);
                        FormCTHDN_Load(sender, e);//load du lieu
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
            exSheet.get_Range("B2").Value = "DANH SÁCH CHI TIẾT HÓA ĐƠN NHẬP";
            exSheet.get_Range("A3").Value = "Số TT";
            exSheet.get_Range("B3").Value = "Số Hóa Đơn Nhập";
            exSheet.get_Range("C3").Value = "Mã Hàng";
            exSheet.get_Range("D3").Value = "Số Lượng";
            exSheet.get_Range("E3").Value = "Đơn Giá";
            exSheet.get_Range("F3").Value = "Giảm Giá";
            exSheet.get_Range("G3").Value = "Thành Tiền";
            int n = dgvCTHDN.Rows.Count;
            for (int i = 0; i < n; i++)
            {
                exSheet.get_Range("A" + (i + 4).ToString()).Value
                    = (i + 1).ToString();
                exSheet.get_Range("B" + (i + 4).ToString()).Value
                    = dgvCTHDN.Rows[i].Cells[0].Value;
                exSheet.get_Range("C" + (i + 4).ToString()).Value
                    = dgvCTHDN.Rows[i].Cells[1].Value;
                exSheet.get_Range("D" + (i + 4).ToString()).Value
                    = dgvCTHDN.Rows[i].Cells[2].Value;
                exSheet.get_Range("E" + (i + 4).ToString()).Value
                    = dgvCTHDN.Rows[i].Cells[3].Value;
                exSheet.get_Range("F" + (i + 4).ToString()).Value
                   = dgvCTHDN.Rows[i].Cells[4].Value;
                exSheet.get_Range("G" + (i + 4).ToString()).Value
                    = dgvCTHDN.Rows[i].Cells[5].Value;
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
                MessageBox.Show("Không có danh sách chi tiết hóa đơn nhập để in");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtSoHDN.Text.Trim() == "")
            {
                MessageBox.Show("Mời bạn nhập số hóa đơn nhập muốn tìm kiếm");
                txtSoHDN.Focus();
            }
            else
            {
                if (db.table($"select  *  from tblChiTietHDN where SoHDN = N'{txtSoHDN.Text}'").Rows.Count > 0)
                {
                    dgvCTHDN.DataSource = db.table($"select  *  from tblChiTietHDN where SoHDN = N'{txtSoHDN.Text}'");
                    CleanInput();
                }
                else
                {
                    MessageBox.Show(txtSoHDN.Text + " không có trong danh sách", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoHDN.Focus();
                    FormCTHDN_Load(sender, e);//load du lieu
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

        private void txtDG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                //nếu là chữ cái
                e.Handled = true;
            }
        }
    }
}
