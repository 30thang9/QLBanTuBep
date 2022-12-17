using BTL.system;
using Microsoft.Reporting.WinForms;
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
    public partial class FormTKHD : Form
    {
        public FormTKHD()
        {
            InitializeComponent();
        }

        DBConfig db = new DBConfig();
        private void FormTKHD_Load(object sender, EventArgs e)
        {
            this.rpvDSHD.RefreshReport();
        }

        private bool ischeck()
        {
            if (rdbTKHDB.Checked == true || rdbTKHDN.Checked == true)
            {
                if (rdbTKHDB.Checked == true)
                {
                    if (cmbQuy.Text == "") { 
                        MessageBox.Show("Mời bạn chọn quý");
                        cmbQuy.Focus();
                        return false; 
                    }
                    if (txtNam.Text == "") { 
                        MessageBox.Show("Mời bạn nhập năm"); 
                        txtNam.Focus();
                        return false; 
                    }

                    return true;
                }
                else
                {
                    if (txtMaNV.Text == "") { 
                        MessageBox.Show("Mời bạn nhập mã nhân viên");
                        txtMaNV.Focus();
                        return false; 
                    }
                    return true;
                }
            }
            else
            {
                MessageBox.Show("Mời bạn chọn loại thống kê");
                return false;
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (ischeck())
            {
                if (rdbTKHDN.Checked == true)
                {
                  
                    string query = $"SELECT * FROM F_cau7('{txtMaNV.Text}')";
                    rpvDSHD.LocalReport.DataSources.Clear();
                    rpvDSHD.LocalReport.ReportEmbeddedResource = "BTL.report.ReportTKHDN.rdlc";
                    ReportDataSource reportDataSource = new ReportDataSource();
                    reportDataSource.Name = "DataSet_TKHDN";
                    reportDataSource.Value = db.table(query);
                    rpvDSHD.LocalReport.DataSources.Add(reportDataSource);
                    FormTKHD_Load(sender, e);
                    if (!db.Check(query))
                    {
                        MessageBox.Show("không có dữ liệu");
                    }
                }
                else if (rdbTKHDB.Checked == true)
                {
                   rpvDSHD.LocalReport.DataSources.Clear();
                   string query = $"select * from F_cau8('{cmbQuy.Text}', '{txtNam.Text}') ";
                   rpvDSHD.LocalReport.ReportEmbeddedResource = "BTL.report.ReportTKHDB.rdlc";
                   ReportDataSource reportDataSource = new ReportDataSource();
                   reportDataSource.Name = "DataSet_TKHDB";
                   reportDataSource.Value = db.table(query);
                   rpvDSHD.LocalReport.DataSources.Add(reportDataSource);
                   FormTKHD_Load(sender, e);
                    if (!db.Check(query))
                    {
                        MessageBox.Show("không có dữ liệu");
                    }
                }
            }
           
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaNV.Text = "";
            txtNam.Text = "";
            cmbQuy.SelectedIndex = -1;
            rdbTKHDB.Checked = false;
            rdbTKHDN.Checked = false;
        }

        private void txtNam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                //nếu là chữ cái
                e.Handled = true;
        }

    }
}
