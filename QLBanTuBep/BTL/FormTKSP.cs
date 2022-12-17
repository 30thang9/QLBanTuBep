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
    public partial class FormTKSP : Form
    {
        public FormTKSP()
        {
            InitializeComponent();
        }

        private void FormTKSP_Load(object sender, EventArgs e)
        {

            this.rpvDSSP.RefreshReport();
        }

        DBConfig db = new DBConfig();
        private bool isCheck()
        {
            if (cmbQuy.Text == "") { MessageBox.Show("Mời bạn chọn quý"); return false; }
            if (txtNam.Text == "") { MessageBox.Show("Mời bạn nhập năm"); return false; }
            return true;
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (isCheck())
            {
                rpvDSSP.LocalReport.DataSources.Clear();
                string query = $"select * from F_cau6('{cmbQuy.Text}', '{txtNam.Text}')";
                rpvDSSP.LocalReport.ReportEmbeddedResource = "BTL.report.ReportTKHH.rdlc";
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "DataSet_TKSP";
                reportDataSource.Value = db.table(query);
                rpvDSSP.LocalReport.DataSources.Add(reportDataSource);
                FormTKSP_Load(sender, e);
                if (!db.Check(query))
                {
                    MessageBox.Show("không có dữ liệu");
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtNam.Text = "";
            cmbQuy.SelectedIndex = -1;
        }

        private void txtNam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                //nếu là chữ cái
                e.Handled = true;
        }
    }
}
