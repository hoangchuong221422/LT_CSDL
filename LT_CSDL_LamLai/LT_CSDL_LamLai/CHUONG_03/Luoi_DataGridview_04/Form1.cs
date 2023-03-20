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

namespace Luoi_DataGridview_04
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

        // Khai báo đối tượng bs
        BindingSource bs = new BindingSource();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Khoi_Tao_Doi_Tuong();
            Doc_Du_Lieu();
            Moc_Noi_Quan_He();

            bs.DataSource = ds;
            bs.DataMember = "MONHOC";


            dgvMH.DataSource = bs;
            //dgvMH.Columns["LoaiMH"].Visible = false; khi database có cột LoaiMH


            //lien ket dieu khien tren form voi bidingsource
            Lien_Ket_dieu_khien();
        }

        private void Lien_Ket_dieu_khien()
        {
            txtmamh.DataBindings.Add("text", bs, "MaMH", true);
            txttenmh.DataBindings.Add("text", bs, "TenMH", true);
            txtsotiet.DataBindings.Add("text", bs, "SoTiet", true);
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


        private void btnthem_Click(object sender, EventArgs e)
        {
            txtmamh.ReadOnly = false;
            bs.AddNew();
            txtmamh.Focus();
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            // lay ra dong can huy 
            DataRow rhuy = (bs.Current as DataRowView).Row;
            if (rhuy.GetChildRows("FK_MH_KQ").Length > 0)
            {
                MessageBox.Show("Khong huy duoc do co dong lien quan den bang ket qua");
                return;
            }
            rhuy.Delete();
            //xoa trong CSDL 
            int n = adpMonHoc.Update(ds, "MONHOC");
            if (n > 0)
            {
                MessageBox.Show("Huy mau tin thanh cong");
            }
        }

        private void btnghi_Click(object sender, EventArgs e)
        {
            if (!txtmamh.ReadOnly) // thêm mới 
            {
                DataRow r = ds.Tables["MONHOC"].Rows.Find(txtmamh.Text);
                if (r != null)
                {
                    MessageBox.Show("trùng khóa chính. Nhập lại ");
                    txtmamh.Focus();
                    return;
                }
            }
            txtmamh.ReadOnly = true;
            bs.EndEdit();
            //xoa trong CSDL 
            int n = adpMonHoc.Update(ds, "MONHOC");
            if (n > 0)
            {
                MessageBox.Show("Cap nhat mau tin thanh cong");
            }

        }

        private void btnkhong_Click(object sender, EventArgs e)
        {
            bs.CancelEdit();
        }

    }
}
