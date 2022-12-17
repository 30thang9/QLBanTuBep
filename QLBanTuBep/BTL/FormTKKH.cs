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
    public partial class FormTKKH : Form
    {
        public FormTKKH()
        {
            InitializeComponent();
        }

        DBConfig db = new DBConfig();

        private void FormTKKH_Load(object sender, EventArgs e)
        {
            this.rpvTKDSKH.RefreshReport();
        }

        private bool ischeckTK()
        {
            if (cmbThang.Text == "")
            {
                MessageBox.Show("Vui lòng chọn tháng");
                cmbThang.Focus();
                return false;

            }
            if (txtNam.Text == "")
            {
                MessageBox.Show("Vui lòng chọn năm");
                txtNam.Focus();
                return false;

            }
            return true;
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (ischeckTK())
            {
                rpvTKDSKH.LocalReport.DataSources.Clear();
                string query = $"select * from F_cau9('{cmbThang.Text}', '{txtNam.Text}')";
                rpvTKDSKH.LocalReport.ReportEmbeddedResource = "BTL.report.ReportTKDSKH.rdlc";
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "DataSet_DSKH";
                reportDataSource.Value = db.table(query);
                rpvTKDSKH.LocalReport.DataSources.Add(reportDataSource);
                FormTKKH_Load(sender, e);
                if (!db.Check(query))
                {
                    MessageBox.Show("không có dữ liệu");
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cmbThang.SelectedIndex = -1;
            txtNam.Text = "";
        }

        private void txtNam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                //nếu là chữ cái
                e.Handled = true;
        }
    }
}
