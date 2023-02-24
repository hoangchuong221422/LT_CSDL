using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BT02_Bingding_MonHoc
{
    public partial class Form3 : Form
    {
        int stt = -1;
        // Khai báo các đối tượng cần sử dụng: 
        // 1.1 Chuỗi kết nối:
        string strcon = @"server=.; database=C21TH2_LTCSDL; integrated security=true";


        // 1.2 Khai báo các đối tượng lưu trữ dữ liệu:
        DataSet ds = new DataSet();

        // 1.3  Khai báo các DataAdapter sử dụng với nguyên tắc: 1 DataTable tương ứng với 1 DataAdapter
        SqlDataAdapter adpMonHoc, adpKetQua;

        // 1.4 Khai báo đối tượng CommanBuilder tương ứng để cập nhật dữ liệu cho bảng SINHVIEN
        SqlCommandBuilder cmbMonHoc;

        // 1.5 Khai báo đối tượng môn BingdingSource: để liên kết thực hiện một số chức năng trên form
        BindingSource bs = new BindingSource();
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
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
        }
        private void Lien_Ket_Dieu_Khien()
        {
            // Mỗi điều khiển trên form liên kết thông qua tập hợp DataBingdings
            txtmamh.DataBindings.Add("text", bs, "MaMH", true);
            txttenmh.DataBindings.Add("text", bs, "TenMH", true);
            txtsotiet.DataBindings.Add("text", bs, "SoTiet", true);
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
