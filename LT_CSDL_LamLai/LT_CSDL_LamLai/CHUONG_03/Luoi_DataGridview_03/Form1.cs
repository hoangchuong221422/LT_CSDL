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

        // Bài này không có đối tượng bs để liên kết dữ liệu
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

        private void btnthem_Click(object sender, EventArgs e)
        {
            txtmamh.ReadOnly = false;
            foreach (Control ctl in this.Controls)
            {
                if (ctl is TextBox)
                {
                    (ctl as TextBox).Clear();
                }
            }
            txtmamh.Focus();
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            // xac dinh dong can huy 
            DataGridViewRow rhuy = dgvMH.SelectedRows[0];
            //chuyen doi dong rhuy sang datarow 
            DataRow r = (rhuy.DataBoundItem as DataRowView).Row;
            //++kiem tra xem co ton tai nhung dong co lien quan den dong r trong ketqua 
            if (r.GetChildRows("FK_MH_KQ").Length > 0)
            {
                MessageBox.Show("Khong xoa duoc ! Dong nay co lien quan den bang KETQUA");
                return;
            }
            //xoa dong r dataTables
            r.Delete();
            //xoa trong CSDL 
            int n = adpMonHoc.Update(ds, "MONHOC");
            if (n > 0)
            {
                MessageBox.Show("Huy mau tin thanh cong");
            }
            Gan_du_lieu(dgvMH.Rows[0]);
        }

        private void btnghi_Click(object sender, EventArgs e)
        {
            if (txtmamh.ReadOnly) //sua
            {
                // xac dinh dong can sua 
                DataGridViewRow rsua = dgvMH.SelectedRows[0];
                //chuyen doi dong rhuy sang datarow 
                DataRow r = (rsua.DataBoundItem as DataRowView).Row;
                //sua trong dataTable
                // r[0] = txtmamh.Text; k có sửa
                r[1] = txttenmh.Text;
                r[2] = txtsotiet.Text;
                //cap nhat ve CSDL

                int n = adpMonHoc.Update(ds, "MONHOC");
                if (n > 0)
                {
                    MessageBox.Show("Cap nhat mau tin thanh cong");
                }
            }
            else  // ghi moi
            {
                DataRow rmoi = ds.Tables["MONHOC"].NewRow();
                rmoi[0] = txtmamh.Text;
                rmoi[1] = txttenmh.Text;
                rmoi[2] = txtsotiet.Text;
               
                ds.Tables["MONHOC"].Rows.Add(rmoi);
                int n = adpMonHoc.Update(ds, "MONHOC");
                if (n > 0)
                {
                    MessageBox.Show("Ghi moi mau tin thanh cong");
                }
                txtmamh.ReadOnly = true;
                dgvMH.Rows[ds.Tables["MONHOC"].Rows.Count - 1].Selected = true;
            }
        }

        private void btnkhong_Click(object sender, EventArgs e)
        {
            Gan_du_lieu(dgvMH.SelectedRows[0]);
            txtmamh.ReadOnly = true;
        }

        private void dgvMH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow r = dgvMH.Rows[e.RowIndex];
            Gan_du_lieu(r);
        }


    }
}
