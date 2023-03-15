using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Luoi_DataGridview_03
{
    public partial class Form1 : Form
    {
        string strcon = @"server=.; database=C21TH2_LTCSDL; integrated security=true";


        // 1.2 Khai báo các đối tượng lưu trữ dữ liệu:
        DataSet ds = new DataSet();

        // 1.3  Khai báo các DataAdapter sử dụng với nguyên tắc: 1 DataTable tương ứng với 1 DataAdapter
        SqlDataAdapter adpMonHoc, adpKetQua;

        // 1.4 Khai báo đối tượng CommanBuilder tương ứng để cập nhật dữ liệu cho bảng SINHVIEN
        SqlCommandBuilder cmbMonHoc;

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Khoi_Tao_Doi_Tuong();
            Doc_Du_Lieu();
            Moc_Noi_Quan_He();

            dgvMH.DataSource = ds.Tables["MONHOC"];
            dgvMH.Columns["LoaiMH"].Visible = false;
            Gan_du_lieu(dgvMH.SelectedRows[0]);
        }
        private void Gan_du_lieu(DataGridViewRow r)
        {
            txtmamh.Text = r.Cells["colMaMH"].Value.ToString();
            txttenmh.Text = r.Cells["colTenMH"].Value.ToString();
            txtsotiet.Text = r.Cells["colSoTiet"].Value.ToString();
        }

        private void Moc_Noi_Quan_He()
        {
            ds.Relations.Add("FK_MH_KQ", ds.Tables["MONHOC"].Columns["MaMH"], ds.Tables["KETQUA"].Columns["MaMH"], true);
            ds.Relations["FK_MH_KQ"].ChildKeyConstraint.DeleteRule = Rule.None;

        }

        private void Doc_Du_Lieu()
        {
            adpMonHoc.FillSchema(ds, SchemaType.Source, "MONHOC");
            adpMonHoc.Fill(ds, "MONHOC");
            adpKetQua.FillSchema(ds, SchemaType.Source, "KETQUA");
            adpKetQua.Fill(ds, "KETQUA");
        }

        private void Khoi_Tao_Doi_Tuong()
        {
            adpMonHoc = new SqlDataAdapter("select * from monhoc", strcon);
            adpKetQua = new SqlDataAdapter("select * from ketqua", strcon);
            cmbMonHoc = new SqlCommandBuilder(adpMonHoc);
        }

        private void dgvMH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow r = dgvMH.Rows[e.RowIndex];
            Gan_du_lieu(r);
        }
    }
}
