using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Man_hinh_main_sub
{
    public partial class Form1 : Form
    {
        QLSV ds = new QLSV();
        QLSVTableAdapters.KHOATableAdapter dapKH = new QLSVTableAdapters.KHOATableAdapter();
        QLSVTableAdapters.SINHVIENTableAdapter dapSV = new QLSVTableAdapters.SINHVIENTableAdapter();
        QLSVTableAdapters.MONHOCTableAdapter dapMH = new QLSVTableAdapters.MONHOCTableAdapter();
        QLSVTableAdapters.KETQUATableAdapter dapKQ = new QLSVTableAdapters.KETQUATableAdapter();
        BindingSource bssv = new BindingSource();
        BindingSource bskq = new BindingSource();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Doc_Du_Lieu();
            Lien_Ket_Dieu_Khien();
        }

        private void Doc_Du_Lieu()
        {
            // nap du lieu cho các Datatable
            dapMH.Fill(ds.MONHOC);
            dapKH.Fill(ds.KHOA);
            dapSV.Fill(ds.SINHVIEN);
            dapKQ.Fill(ds.KETQUA);

            // nap nguồn cho combox
            cbomakh.DataSource = ds.KHOA;
            cbomakh.DisplayMember = "TenKH";
            cbomakh.ValueMember = "MaKH";

            // Nạp nguồn cho bssv;
            bssv.DataSource = ds.SINHVIEN;


            // Nạp nguồn cho bindingSoure bskq
            bskq.DataSource = bssv;
            bskq.DataMember = "FK_KETQUA_SINHVIEN";

            // Gan nguon cho luoi

            dgvKQ.DataSource = bskq;

        }

        private void Lien_Ket_Dieu_Khien()
        {
            foreach (Control ctl in this.Controls)
                if (ctl is TextBox && ctl.Name != "txttongdiem")
                    ctl.DataBindings.Add("text", bssv, ctl.Name.Substring(3));
                else if (ctl is CheckBox)
                    ctl.DataBindings.Add("checked", bssv, ctl.Name.Substring(3));
                else if (ctl is ComboBox)
                    ctl.DataBindings.Add("selectedvalue", bssv, ctl.Name.Substring(3));
                else if (ctl is DateTimePicker)
                    ctl.DataBindings.Add("value", bssv, ctl.Name.Substring(3));
            // Định dạng số tiết khi hiển thị:
            txthocbong.DataBindings[0].FormatString = "#,##0 đ";
        }
    }
}
