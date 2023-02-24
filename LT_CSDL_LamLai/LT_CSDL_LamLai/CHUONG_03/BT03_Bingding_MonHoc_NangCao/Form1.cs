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

namespace BT03_Bingding_MonHoc_NangCao
{
    public partial class Form1 : Form
    {
        string strcon = @"server=.; database=C21TH2_LTCSDL; integrated security=true";
        DataSet ds = new DataSet();
        SqlDataAdapter adpMonHoc, adpKetQua;
        SqlCommandBuilder cmbMonHoc;
        BindingSource bs = new BindingSource();
        public Form1()
        {
            InitializeComponent();
            // Phát sinh sự kiện Curren_Changed của BingdingSource
            bs.CurrentChanged += Bs_CurrentChanged;
        }

        private void Bs_CurrentChanged(object sender, EventArgs e)
        {
            // Phương thức này được tự động thi hành khi có sự di chuyển mẫu tin
            lblSTT.Text = bs.Position + 1 + " / " + bs.Count;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Khoi_Tao_Doi_Tuong();
            Doc_Du_Lieu();
            Moc_Noi_Quan_He();
            Khoi_Tao_BingdingSource();
            Lien_Ket_Dieu_Khien();
        }
        private void Khoi_Tao_BingdingSource()
        {
            bs.DataSource = ds;
            bs.DataMember = "MONHOC";

            // Khởi tạo đối tượng BingdingNavigator
            bdnMonhoc.BindingSource = bs;
        }
        private void Lien_Ket_Dieu_Khien()
        {
            foreach (Control ctl in this.Controls)
                if (ctl is TextBox && ctl.Name != "txtloaimh")
                    ctl.DataBindings.Add("text", bs, ctl.Name.Substring(3));

            // Định dạng số tiết khi hiển thị:
            txtsotiet.DataBindings[0].FormatString = "00 tiết";

            // Bingding riêng cho txtloaimh chứa dữ liệu kiểu Boolean
            Binding bdmh = new Binding("text", bs, "LoaiMH", true);
            // Phát sinh sự kiện Format và Parse cho đối tượng bdmh
            bdmh.Format += Bdmh_Format;
            bdmh.Parse += Bdmh_Parse;
            // Thêm đối tượng binding bdmh vào điều khiển txtloaimh
            txtloaimh.DataBindings.Add(bdmh);
        }

        private void Bdmh_Parse(object sender, ConvertEventArgs e)
        {
            // xảy ra khi dữ liệu được chuyển từ điều khiển trên form về DataTable ( dữ liệu được chứa trong e.Value)
            if (e.Value == null) return;
            {
                e.Value = e.Value.ToString().ToUpper() == "BẮT BUỘC" ? true : false;
            }
        }

        private void Bdmh_Format(object sender, ConvertEventArgs e)
        {
            // xảy ra khi dữ liệu (e.value) được chuyển từ DataTable đến form hoặc khi chỉnh sửa dữ liệu của điều khiển trên form
            if (e.Value == DBNull.Value || e.Value == null) return;
            {
                e.Value = (Boolean)e.Value ? "Bắt buộc" : "Tự chọn";
            }
        }

        private void Moc_Noi_Quan_He()
        {
            // Nối nối quan hệ giữa table KHOA và SINHVIEN
            ds.Relations.Add("FK_MH_KQ", ds.Tables["MONHOC"].Columns["MaMH"], ds.Tables["KETQUA"].Columns["MaMH"], true);

            // Loại bỏ CatCade delete
            ds.Relations["FK_MH_KQ"].ChildKeyConstraint.DeleteRule = Rule.None;

        }

        private void Doc_Du_Lieu()
        {
            adpMonHoc.FillSchema(ds, SchemaType.Source, "MONHOC");
            adpMonHoc.Fill(ds, "MONHOC");

            adpKetQua.FillSchema(ds, SchemaType.Source, "KETQUA");
            adpKetQua.Fill(ds, "KETQUA");
        }

        private void btndau_Click(object sender, EventArgs e)
        {
            bs.MoveFirst();
        }

        private void btntruoc_Click(object sender, EventArgs e)
        {
            bs.MovePrevious();
        }

        private void btnsau_Click(object sender, EventArgs e)
        {
            bs.MoveNext();
        }

        private void btncuoi_Click(object sender, EventArgs e)
        {
            bs.MoveLast();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            txtmamh.ReadOnly = false;
            // Thêm mới
            bs.AddNew();
            txtmamh.Focus();
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            // Hủy trong DataTabke
            // Kiểm tra có tồn tại các mẫu tin có liên quang trong KETQUA hay không trước khi xoa
            DataRow[] Mang_dong_lien_quan = ds.Tables["KETQUA"].Select("MaMH = '" + txtmamh.Text + "'");
            if (Mang_dong_lien_quan.Length > 0)
            {
                MessageBox.Show("Không xóa được do tồn tại các dòng liên quan trong KETQUA");
                return;
            }

            bs.RemoveCurrent();

            // Hủy trong CSDL
            int n = adpMonHoc.Update(ds, "MONHOC");
            if (n > 0)
            {
                MessageBox.Show("Hủy môn học thành công");
            }
        }

        private void btnghi_Click(object sender, EventArgs e)
        {
            if (!txtmamh.ReadOnly)
            {
                DataRow[] Mang_dong = ds.Tables["MONHOC"].Select("MaMH = '" + txtmamh.Text + "'");
                if (Mang_dong.Length > 0)
                {
                    MessageBox.Show("Không xóa được do tồn tại các dòng liên quan trong KETQUA");
                    txtloaimh.Focus();
                    return;
                }
            }
            // Cập nhật lại việc thêm mới hay sửa trong DataTable
            bs.EndEdit();
            // Cập nhật lại trong CSDL
            int n = adpMonHoc.Update(ds, "MONHOC");
            if (n > 0)
            {
                MessageBox.Show("Cập nhật môn học thành công");
            }

        }

        private void btnkhong_Click(object sender, EventArgs e)
        {
            bs.CancelEdit();
            txtmamh.ReadOnly = true;
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {

        }

        private void Khoi_Tao_Doi_Tuong()
        {
            // 1. Khởi tạo các đối tượng DataAdapter
            adpMonHoc = new SqlDataAdapter("select * from monhoc", strcon);
            adpKetQua = new SqlDataAdapter("select * from ketqua", strcon);

            // 2. Khởi tạo đối tượng CommanBuilder 
            cmbMonHoc = new SqlCommandBuilder(adpMonHoc);
        }

    }
}
