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

namespace BTL
{
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
        }

        DBConfig db = new DBConfig();
        private void FormDangNhap_Load(object sender, EventArgs e)
        {

        }

        private bool isCheck()
        {
            if (txtUsername.Text == "")
            {
                MessageBox.Show("Vui lòng nhập user name !");
                txtUsername.Focus();
                return false;
            }
            if (txtPassword.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu !");
                txtPassword.Focus();
                return false;
            }
            return true;
        }

        private void CleanInput()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (isCheck())
            {
                if (db.table($"select * from tblLogin where TenTaiKhoan = N'{txtUsername.Text}' and MatKhau = N'{txtPassword.Text}'").Rows.Count != 0)
                {
                    this.Hide();
                    Form1 form1 = new Form1();
                    form1.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tên tài khoản hoặc mật khẩu không chính xác !", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CleanInput();
                }

            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDangKi formDangKi = new FormDangKi();
            formDangKi.ShowDialog();
            this.Close();
        }
    }
}
