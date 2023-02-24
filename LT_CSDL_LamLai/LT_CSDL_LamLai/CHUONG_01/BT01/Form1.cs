using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT01
{
    public partial class Form1 : Form
    {
        // Khai báo các đối tượng:
        // 1. Khai báo một biến ( Đối tượng Dataset)
        DataSet ds = new DataSet();
        // 2. Khai báo các DataTable tương ứng với các bảng có chứa dữ liệu
        DataTable tblKhoa = new DataTable("KHOA");
        DataTable tblSinhVien = new DataTable("SINHVIEN");
        DataTable tblKetQua = new DataTable("KETQUA");
        int stt = -1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Tạo cấu trúc cho các bảng:

            Tao_Cau_Truc_Cac_Bang();
            Moc_Noi_Quan_He_Cac_Bang();
            Nhap_Lieu_Cac_Bang();
            Khoi_Tao_ComBo_Khoa();
            //btndau.PerformClick(); // mở lại
        }

        private void Khoi_Tao_ComBo_Khoa()
        {
            cbokhoa.DisplayMember = "TenKH";
            cbokhoa.ValueMember = "MaKH";
            cbokhoa.DataSource = tblKhoa;
        }

        private void Nhap_Lieu_Cac_Bang()
        {
            Nhap_Lieu_tblKhoa();
            Nhap_Lieu_tblSinhVien();
            Nhap_Lieu_tblKetQua();
        }

        private void Nhap_Lieu_tblKetQua()
        {
            // Nhập liệu cho tblKhoa => Đọc dữ liệu từ tập tin KETQUA.txt
            string[] Mang_KQ = File.ReadAllLines(@"..\..\..\Data\KETQUA.txt");
            foreach (var ChuoiKQ in Mang_KQ)
            {
                // Tách chuỗi ChuoiKhoa thành các thành phần tương ứng với MaKH và TenKH
                string[] Mang_Thanh_Phan = ChuoiKQ.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                // Tạo một dòng mới có cấc trúc giống cấu trúc của một dòng trong tblKetQua
                DataRow rKQ = tblKetQua.NewRow();

                // Gán giá trị cho các cột của dòng mới tạo ra
                for (int i = 0; i < Mang_Thanh_Phan.Length; i++)
                    rKQ[i] = Mang_Thanh_Phan[i];

                // Thêm dòng vừa tạo vào tblKetQua
                tblKetQua.Rows.Add(rKQ);
            }
        }

        private void Nhap_Lieu_tblSinhVien()
        {
            // Nhập liệu cho tblKhoa => Đọc dữ liệu từ tập tin KHOA.txt
            string[] Mang_SV = File.ReadAllLines(@"..\..\..\Data\SINHVIEN.txt");
            foreach (var ChuoiSV in Mang_SV)
            {
                // Tách chuỗi ChuoiKhoa thành các thành phần tương ứng với MaKH và TenKH
                string[] Mang_Thanh_Phan = ChuoiSV.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                // Tạo một dòng mới có cấc trúc giống cấu trúc của một dòng trong tblKhoa
                DataRow rSV = tblSinhVien.NewRow();

                // Gán giá trị cho các cột của dòng mới tạo ra

                for (int i = 0; i < Mang_Thanh_Phan.Length; i++)
                    rSV[i] = Mang_Thanh_Phan[i];

                // Thêm dòng vừa tạo vào tblKhoa 
                tblSinhVien.Rows.Add(rSV);
            }
        }

        private void Nhap_Lieu_tblKhoa()
        {
            // Nhập liệu cho tblKhoa => Đọc dữ liệu từ tập tin KHOA.txt
            string[] Mang_Khoa = File.ReadAllLines(@"..\..\..\Data\KHOA.txt");
            foreach (var ChuoiKhoa in Mang_Khoa)
            {
                // Tách chuỗi ChuoiKhoa thành các thành phần tương ứng với MaKH và TenKH
                string[] Mang_Thanh_Phan = ChuoiKhoa.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                // Tạo một dòng mới có cấc trúc giống cấu trúc của một dòng trong tblKhoa
                DataRow rkh = tblKhoa.NewRow();

                // Gán giá trị cho các cột của dòng mới tạo ra
                rkh[0] = Mang_Thanh_Phan[0];
                rkh[1] = Mang_Thanh_Phan[1];

                // Thêm dòng vừa tạo vào tblKhoa 
                tblKhoa.Rows.Add(rkh);
            }
        }

        private void Moc_Noi_Quan_He_Cac_Bang()
        {
            // Tạo quan hệ giữa tblKhoa và tblSinhVien
            ds.Relations.Add("FK_KH_SV", ds.Tables["KHOA"].Columns["MaKH"], ds.Tables["SINHVIEN"].Columns["MaKH"], true);

            // Tạo quan hệ giữa tblSinhVien và tblKetQua
            ds.Relations.Add("FK_SV_KQ", ds.Tables["SINHVIEN"].Columns["MaSV"], ds.Tables["KETQUA"].Columns["MaSV"], true);

            // Loại bỏ  Cascade delete trong các quan hệ 
            ds.Relations["FK_KH_SV"].ChildKeyConstraint.DeleteRule = Rule.None;
            ds.Relations["FK_SV_KQ"].ChildKeyConstraint.DeleteRule = Rule.None;
        }

        private void Tao_Cau_Truc_Cac_Bang()
        {

            // Tạo cấu trúc các DataTable tương ứng với bảng KHOA
            tblKhoa.Columns.Add("MaKH", typeof(string));
            tblKhoa.Columns.Add("TenKH", typeof(string));
            // Tạo khóa chính cho tblKhoa
            tblKhoa.PrimaryKey = new DataColumn[] { tblKhoa.Columns["MaKH"] };

            // Tạo cấu trúc các DataTable tương ứng với bảng SINHVIEN
            tblSinhVien.Columns.Add("MaSV", typeof(string));
            tblSinhVien.Columns.Add("HoSV", typeof(string));
            tblSinhVien.Columns.Add("TenSV", typeof(string));
            tblSinhVien.Columns.Add("Phai", typeof(Boolean));
            tblSinhVien.Columns.Add("NgaySinh", typeof(DateTime));
            tblSinhVien.Columns.Add("NoiSinh", typeof(string));
            tblSinhVien.Columns.Add("MaKH", typeof(string));
            tblSinhVien.Columns.Add("HocBong", typeof(string));
            // Tạo khóa chính cho tblSinhVien
            tblSinhVien.PrimaryKey = new DataColumn[] { tblSinhVien.Columns["MaSV"] };

            // Tạo cấu trúc các DataTable tương ứng với bảng KETQUA
            tblKetQua.Columns.Add("MaSV", typeof(string));
            tblKetQua.Columns.Add("MaKH", typeof(string));
            tblKetQua.Columns.Add("Diem", typeof(Single));
            tblKetQua.PrimaryKey = new DataColumn[] { tblKetQua.Columns["MaSV"], tblKetQua.Columns["MaKH"] };

            // Thêm các DataTable vào Dataset:
            //ds.Tables.Add(tblKhoa);
            //ds.Tables.Add(tblSinhVien);
            //ds.Tables.Add(tblKetQua);
            ds.Tables.AddRange(new DataTable[] { tblKhoa, tblSinhVien, tblKetQua });
        }

        private void btncuoi_Click(object sender, EventArgs e)
        {
            stt = tblSinhVien.Rows.Count;
            GanDuLieu(stt);
        }

        private void btnsau_Click(object sender, EventArgs e)
        {
            stt++;
            GanDuLieu(stt);
        }

        private void btntruoc_Click(object sender, EventArgs e)
        {
            stt--;
            GanDuLieu(stt);
        }

        private void btndau_Click(object sender, EventArgs e)
        {
            stt = 0;
            GanDuLieu(stt);
        }

        private void GanDuLieu(int stt)
        {
           // Lấy dòng dữ liệu thứ stt trong tblSinhVien
           DataRow rsv = tblSinhVien.Rows[stt];
            txtmasv.Text = rsv["MaSV"].ToString();
            txthosv.Text = rsv["HoSV"].ToString();
            txttensv.Text = rsv["TenSV"].ToString();
            chkphai.Checked = (Boolean)rsv["Phai"];
            txtnoisinh.Text = rsv["NoiSinh"].ToString();
            txtngaysinh.Text = rsv["NgaySinh"].ToString();
            txthocbong.Text = rsv["HocBong"].ToString();
            cbokhoa.SelectedValue = rsv["MaKH"].ToString();

            //// Tính tổng điểm
            //txttongdiem.Text = TongDiem(txtmasv.Text);

            //// Thể hiện số thứ tự mẫu tin hiện hành: 
            //lblSTT.text = (stt + 1) + " / " + tblSinhVien.Rows.Count;
        }

        private string TongDiem(string text)
        {
            throw new NotImplementedException();
        }
    }
}
