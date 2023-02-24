using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BT02_Bingding_MonHoc
{
    public partial class Form1 : Form
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
        SqlCommandBuilder cmdMonHoc;

        // 1.5 Khai báo đối tượng môn BingdingSource: để liên kết thực hiện một số chức năng trên form
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
        }

        private void Moc_Noi_Quan_He()
        {
            //// Nối nối quan hệ giữa table KHOA và SINHVIEN
            //ds.Relations.Add("FK_MH_KQ", ds.Tables["MONHOC"].Columns["MaMH"], ds.Tables["KETQUA"].Columns["MaMH"], true);

            //// Loại bỏ CatCade delete
            //ds.Relations["FK_MH_KQ"].ChildKeyConstraint.DeleteRule = Rule.None;

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
            // 1. Khởi tạo các đối tượng DataAdapter
            adpMonHoc = new SqlDataAdapter("select * from monhoc", strcon);
            adpKetQua = new SqlDataAdapter("select * from ketqua", strcon);

            // 2. Khởi tạo đối tượng CommanBuilder 
            cmdMonHoc = new SqlCommandBuilder(adpMonHoc);
        }


    }
}
