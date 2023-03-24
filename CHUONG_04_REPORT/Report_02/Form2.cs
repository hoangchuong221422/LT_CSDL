using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Report_02
{
    public partial class Form2 : Form
    {
        QLSV ds = new QLSV();
        QLSVTableAdapters.KHOATableAdapter dapKhoa = new QLSVTableAdapters.KHOATableAdapter();
        QLSVTableAdapters.SINHVIENTableAdapter dapSinhVien = new QLSVTableAdapters.SINHVIENTableAdapter();

        BindingSource bs = new BindingSource();
        ReportDataSource rds = new ReportDataSource();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            rds.Name = "DS_SinhVien";
            rds.Value = bs;

            // khai báo điều khiển ReportViewer
            ReportViewer rv = new ReportViewer();

            rv.LocalReport.DataSources.Add(rds);

            rv.LocalReport.ReportEmbeddedResource = "Report_02.RSinhVien_04.rdlc";

            // thiết laapjk báo cáo mở ở chế độ print layout
            rv.SetDisplayMode(DisplayMode.PrintLayout);
            rv.Dock = DockStyle.Fill;
            bs.DataSource = ds.SINHVIEN;



            Form f = new Form();
            f.WindowState = FormWindowState.Maximized;
            f.Controls.Add(rv);
            f.ShowDialog();


            rv.RefreshReport();
        }
    }
}
