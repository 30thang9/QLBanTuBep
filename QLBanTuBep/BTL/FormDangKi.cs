using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using BTL.system;

namespace BTL
{
    public partial class FormDangKi : Form
    {
        public FormDangKi()
        {
            InitializeComponent();
        }
        DBConfig db = new DBConfig();
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDangNhap formDangNhap = new FormDangNhap();
            formDangNhap.ShowDialog();
            this.Close();
        }

        public bool checkEmail(string Email)
        {
            return Regex.IsMatch(Email, "^[a-zA-Z0-9_.]{3,20}@gmail.com$");
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
            if (txtETPassword.Text == "")
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu !");
                txtETPassword.Focus();
                return false;
            }
            return true;
        }

        private void btnDK_Click(object sender, EventArgs e)
        {
            string Email = txtUsername.Text;
            string Password = txtPassword.Text;
            string ETPassword = txtETPassword.Text;
            if (isCheck())
            {
                if (!checkEmail(Email))
                {
                    MessageBox.Show("Vui lòng nhập Email đúng định dạng !");
                    txtUsername.Focus();
                    return;
                }
                if(ETPassword != Password)
                {
                    MessageBox.Show("Mật khẩu nhập lại không chính xác !");
                    txtETPassword.Focus();
                    return;
                }
                if (db.table($"select * from tblLogin where TenTaiKhoan = N'{txtUsername.Text}'").Rows.Count != 0)
                {
                    MessageBox.Show("Email này đã tồn tại");
                    txtUsername.Focus();
                    return;
                }
                try
                {
                    string query = $"insert into tblLogin values(N'{txtUsername.Text}', N'{txtPassword.Text}')";
                    db.Excute(query);
                    MessageBox.Show("Đăng kí thành công");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
