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
    public partial class FormDSTuBep : Form
    {
        public FormDSTuBep()
        {
            InitializeComponent();
        }

        DBConfig db = new DBConfig();
        DataTable dt = new DataTable();
        private void FormDSTuBep_Load(object sender, EventArgs e)
        {
            dgvTuBep.DataSource = db.table("select * from tblHangHoa");
            txtSL.Enabled = false;
        }

        private bool isCheck()
        {
            if (txtMaHang.Text.Trim() == "")
            {
                MessageBox.Show("Xin mời nhập mã hàng");
                txtMaHang.Focus();
                return false;
            }
            if (txtTenHang.Text.Trim() == "")
            {
                MessageBox.Show("Xin mời nhập tên hàng");
                txtTenHang.Focus();
                return false;
            }
            if (txtMaKT.Text.Trim() == "")
            {
                MessageBox.Show("Xin mời nhập mã kích thước");
                txtMaKT.Focus();
                return false;
            }
            if (txtMaCL.Text.Trim() == "")
            {
                MessageBox.Show("Xin mời nhập mã chất liệu");
                txtMaCL.Focus();
                return false;
            }
            if (txtMaMau.Text.Trim() == "")
            {
                MessageBox.Show("Xin mời nhập mã màu");
                txtMaMau.Focus();
                return false;
            }
            if (txtMaNSX.Text.Trim() == "")
            {
                MessageBox.Show("Xin mời nhập mã nước sản xuất");
                txtMaNSX.Focus();
                return false;
            }
            if (cmbBH.Text.Trim() == "")
            {
                MessageBox.Show("Xin mời nhập thời gian bảo hành");
                cmbBH.Focus();
                return false;
            }
            if (ptbAnh.Image == null)
            {
                MessageBox.Show("xin mời chọn ảnh");
                ptbAnh.Focus();
                return false;
            }
            //check mã kích thước
            if (!db.Check($"select * from tblKichThuoc where MaKichThuoc = '{txtMaKT.Text}'")) 
            {
                MessageBox.Show("Không tồn tại mã " + txtMaKT.Text, "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKT.Focus();
                return false;
            }
            if (!db.Check($"select * from tblChatLieu where MaChatLieu = '{txtMaCL.Text}'"))
            {
                MessageBox.Show("Không tồn tại mã " + txtMaCL.Text, "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaCL.Focus();
                return false;
            }
            if (!db.Check($"select * from tblMauSac where MaMau = '{txtMaMau.Text}'"))
            {
                MessageBox.Show("Không tồn tại mã " + txtMaMau.Text, "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaMau.Focus();
                return false;
            }
            if (!db.Check($"select * from tblNuocSX where MaNuocSX = '{txtMaNSX.Text}'"))
            {
                MessageBox.Show("Không tồn tại mã " + txtMaNSX.Text, "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNSX.Focus();
                return false;
            }

            return true;
        }

        private bool checkTonTai()
        {
            string checkMH = $"select MaHang from tblHangHoa where MaHang =N'{txtMaHang.Text}'";
            if (db.Check(checkMH))
            {
                MessageBox.Show("Tên hãng này đã có vui lòng chọn nhập mã khác ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHang.Focus();
                return false;
            }
            return true;
        }

        private bool checkHH()
        {
            string checkHHHDB = $"select MaHang from tblChiTietHDB where MaHang = N'{txtMaHang.Text}'";
            string checkHHHDN = $"select MaHang from tblChiTietHDN where MaHang = N'{txtMaHang.Text}'";
            if (db.Check(checkHHHDB) || db.Check(checkHHHDN))
            {
                MessageBox.Show(txtMaHang.Text + " không thể xoá do hàng hoá tồn tại trong chi tiết hàng hoá ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHang.Focus();
                return false;
            }
            return true;
        }
        private bool ischeckTK()
        {

            if (cmbTimKiem.Text == "")
            {
                MessageBox.Show("Mời bạn chọn loại tìm kiếm");
                cmbTimKiem.Focus();
                return false;

            }
            else if (cmbTimKiem.Text == "Theo thời gian bảo hành")
            {
                txtTimKiemTenCL.Text = "";
                txtTimKiemTenNSX.Text = "";
                if (cmbBH.Text.Trim() == "")
                {
                    MessageBox.Show("Mời bạn nhập thời gian bảo hành");
                    cmbBH.Focus();
                    return false;
                }
                return true;
            }
            else if (cmbTimKiem.Text == "Theo tên chất liệu")
            {
                cmbBH.Text = "";
                txtTimKiemTenNSX.Text = "";
                if (txtTimKiemTenCL.Text == "")
                {
                    MessageBox.Show("Mời bạn nhập tên chất liệu ");
                    txtTimKiemTenCL.Focus();
                    return false;
                }
                return true;
            }
            else if (cmbTimKiem.Text == "Theo nước sản xuất")
            {
                cmbBH.Text = "";
                txtTimKiemTenCL.Text = "";
                if (txtTimKiemTenNSX.Text == "")
                {
                    MessageBox.Show("Mời bạn nhập nước sản xuất ");
                    txtTimKiemTenNSX.Focus();
                    return false;
                }

                return true;
            }

            return true;


        }

        private void CleanInput()
        {
            txtMaHang.Text = "";
            txtTenHang.Text = "";
            txtMaKT.Text = "";
            txtMaCL.Text = "";
            txtMaMau.Text = "";
            txtMaNSX.Text = "";
            txtSL.Text = "";
            cmbBH.Text = "";
            ptbAnh.ImageLocation = "";
            txtGhiChu.Text = "";
        }

        private void txtSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                //nếu là chữ cái
                e.Handled = true;
            }
        }

        private void txtDGN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                //nếu là chữ cái
                e.Handled = true;
            }
        }

        private void txtDGB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                //nếu là chữ cái
                e.Handled = true;
            }
        }




        private void dgvTuBep_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                txtMaHang.Text = dgvTuBep.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
                txtTenHang.Text = dgvTuBep.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                txtMaKT.Text = dgvTuBep.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
                txtMaCL.Text = dgvTuBep.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();
                txtMaNSX.Text = dgvTuBep.Rows[e.RowIndex].Cells[4].Value.ToString().Trim();
                txtMaMau.Text = dgvTuBep.Rows[e.RowIndex].Cells[5].Value.ToString().Trim();
                txtSL.Text = dgvTuBep.Rows[e.RowIndex].Cells[6].Value.ToString().Trim();
                cmbBH.Text = dgvTuBep.Rows[e.RowIndex].Cells[9].Value.ToString().Trim();
                ptbAnh.ImageLocation = dgvTuBep.Rows[e.RowIndex].Cells[10].Value.ToString().Trim();
                txtGhiChu.Text = dgvTuBep.Rows[e.RowIndex].Cells[11].Value.ToString().Trim();
            }
        }



        private void btnThem_Click(object sender, EventArgs e)
        {
            if (isCheck() && checkTonTai())
            {
                string query = $"INSERT INTO tblHangHoa(MaHang, TenHangHoa, MaKichThuoc, MaChatLieu, MaNuocSX, MaMau,  ThoiGianBaoHanh, Anh, GhiChu) VALUES(N'{txtMaHang.Text}',N'{txtTenHang.Text}',N'{txtMaKT.Text}',N'{txtMaCL.Text}',N'{txtMaNSX.Text}',N'{txtMaMau.Text}',N'{cmbBH.Text}',N'{ptbAnh.ImageLocation}',N'{txtGhiChu.Text}')";
                    try
                    {
                        if (MessageBox.Show("Bạn có muốn thêm vào không", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            db.Excute(query);
                            FormDSTuBep_Load(sender, e); //load dữ liệu
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
            if (checkHH())
            {
                string query = $"delete tblHangHoa where MaHang = '{txtMaHang.Text}'";
                try
                {
                    if (MessageBox.Show("Bạn chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        db.Excute(query);
                        CleanInput();
                        FormDSTuBep_Load(sender, e);//load du lieu
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
                string query = "update tblHangHoa set TenHangHoa=N'" + txtTenHang.Text + "', MaKichThuoc=N'" + txtMaKT.Text + "', MaChatLieu=N'" + txtMaCL.Text + "', MaNuocSX=N'" + txtMaNSX.Text + "', MaMau=N'" + txtMaMau.Text + "', SoLuong='" + txtSL.Text + "', ThoiGianBaoHanh=N'" + cmbBH.Text + "', Anh=N'" + ptbAnh.ImageLocation + "', GhiChu=N'" + txtGhiChu.Text + "' where MaHang=N'" + txtMaHang.Text + "'";
                try
                {
                    if (MessageBox.Show("Bạn chắc chắn muốn sửa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        db.Excute(query);
                        CleanInput();
                        FormDSTuBep_Load(sender, e);//load du lieu
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

       

       
        private void btnAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "chọn ảnh";
            openFileDialog.Filter = "File image (.png; *.jpg;*.jpeg)|*.png; *.jpg;*.jpeg";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ptbAnh.ImageLocation = openFileDialog.FileName;
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
                exSheet.get_Range("B3").Value = "Mã hàng ";
                exSheet.get_Range("C3").Value = "Tên Hàng";
                exSheet.get_Range("D3").Value = "Mã Kích Thước";
                exSheet.get_Range("E3").Value = "Mã Chất Liệu";
                exSheet.get_Range("F3").Value = "Mã Nước Sản Xuất";
                exSheet.get_Range("G3").Value = "Mã Màu";
                exSheet.get_Range("H3").Value = "Số Lượng";
                exSheet.get_Range("I3").Value = "Giá Nhập";
                exSheet.get_Range("J3").Value = "Giá Bán";
                exSheet.get_Range("K3").Value = "Thời Gian Bảo Hành";
                exSheet.get_Range("L3").Value = "Hình Ảnh";
                exSheet.get_Range("M3").Value = "Ghi Chú";
                int n = dgvTuBep.Rows.Count;
                for (int i = 0; i < n; i++)
                {
                    exSheet.get_Range("A" + (i + 4).ToString()).Value
                        = (i + 1).ToString();
                    exSheet.get_Range("B" + (i + 4).ToString()).Value
                        = dgvTuBep.Rows[i].Cells[0].Value;
                    exSheet.get_Range("C" + (i + 4).ToString()).Value
                        = dgvTuBep.Rows[i].Cells[1].Value;
                    exSheet.get_Range("D" + (i + 4).ToString()).Value
                        = dgvTuBep.Rows[i].Cells[2].Value;
                    exSheet.get_Range("E" + (i + 4).ToString()).Value
                        = dgvTuBep.Rows[i].Cells[3].Value;
                    exSheet.get_Range("F" + (i + 4).ToString()).Value
                        = dgvTuBep.Rows[i].Cells[4].Value;
                    exSheet.get_Range("G" + (i + 4).ToString()).Value
                       = dgvTuBep.Rows[i].Cells[5].Value;
                    exSheet.get_Range("H" + (i + 4).ToString()).Value
                       = dgvTuBep.Rows[i].Cells[6].Value;
                    exSheet.get_Range("I" + (i + 4).ToString()).Value
                       = dgvTuBep.Rows[i].Cells[7].Value;
                    exSheet.get_Range("J" + (i + 4).ToString()).Value
                        = dgvTuBep.Rows[i].Cells[8].Value;
                    exSheet.get_Range("K" + (i + 4).ToString()).Value
                        = dgvTuBep.Rows[i].Cells[9].Value;
                    exSheet.get_Range("L" + (i + 4).ToString()).Value
                        = dgvTuBep.Rows[i].Cells[10].Value;
                    exSheet.get_Range("M" + (i + 4).ToString()).Value
                       = dgvTuBep.Rows[i].Cells[11].Value;

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
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (ischeckTK())
            {   
                if (txtTimKiemTenCL.Text.Trim() != "")
                {
                    dgvTuBep.DataSource = db.table($"select * from F1_cau4(N'{txtTimKiemTenCL.Text}')");
                    if (dgvTuBep.Rows.Count <= 0)
                    {
                        MessageBox.Show("Chât liệu " + txtTimKiemTenCL.Text + " không có trong danh sách", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        FormDSTuBep_Load(sender, e);
                    }
                }
                else if (txtTimKiemTenNSX.Text.Trim() != "")
                {
                    dgvTuBep.DataSource = db.table($"select * from F2_cau4(N'{txtTimKiemTenNSX.Text}')");
                    if (dgvTuBep.Rows.Count <= 0)
                    {
                        MessageBox.Show("Nước " + txtTimKiemTenNSX.Text + " không có trong danh sách", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        FormDSTuBep_Load(sender, e);
                    }

                }
                else if (cmbBH.Text != "")
                {
                    dgvTuBep.DataSource = db.table($"select * from tblHangHoa where ThoiGianBaoHanh = N'{cmbBH.Text}'");
                    if (dgvTuBep.Rows.Count <= 0)
                    {
                        MessageBox.Show("Thời gian bảo hành " + cmbBH.Text + " không có trong danh sách", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        FormDSTuBep_Load(sender, e);
                    }

                }
            }
        }
    }
}
