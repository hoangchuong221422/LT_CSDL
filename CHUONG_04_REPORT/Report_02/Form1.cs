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
    public partial class Form1 : Form
    {
        QLSV ds = new QLSV();
        QLSVTableAdapters.KHOATableAdapter dapKhoa = new QLSVTableAdapters.KHOATableAdapter();
        QLSVTableAdapters.SINHVIENTableAdapter dapSinhVien = new QLSVTableAdapters.SINHVIENTableAdapter();

        BindingSource bs = new BindingSource();
        ReportDataSource rds = new ReportDataSource();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rds.Name = "DS_SinhVien";
            rds.Value = bs;

            rv.LocalReport.DataSources.Add(rds);
            rv.LocalReport.ReportEmbeddedResource = "Report_02.RSinhVien_04.rdlc";

            rv.SetDisplayMode(DisplayMode.PrintLayout);

            dapKhoa.Fill(ds.KHOA);
            dapSinhVien.Fill(ds.SINHVIEN);
            bs.DataSource = ds.SINHVIEN;

            this.WindowState = FormWindowState.Maximized;

            this.rv.RefreshReport();
        }
    }
}
