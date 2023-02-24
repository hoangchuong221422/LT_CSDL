using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb; // Sử dụng với Access

namespace BT01_Truy_Xuat_Du_Lieu
{
    public partial class Form1 : Form
    {
        // Bài tập này thực hiện mô hình kết nối
        // 1. Khai báo các đối tượng cần sử dụng:

        // 1.1 Chuổi kết nối
        string strcon = @"provider=microsoft.jet.oledb.4.0; data source=..\..\..\Data\QLSINHVIEN.mdb";
        // 1.2 Đối tượng kết nối
        OleDbConnection cnn;

        // Khai báo các đối tượng lưu dữ liệu:    
        DataSet ds = new DataSet();   
        DataTable tblKhoa = new DataTable("KHOA");
        DataTable tblSinhVien = new DataTable("SINHVIEN");
        DataTable tblKetQua = new DataTable("KetQua");
        int stt = -1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Khởi tạo kết nối với database  // xíu làm
            cnn = new OleDbConnection(strcon);

            // Đọc dữ liệu từ CSDL và DataSet:
            Tao_Cau_Truc_Cac_Bang();
            // Mốc nối quan hệ giữa các DaTaTable
            Moc_Noi_Quan_He_Giua_Cac_Bang();

            // Nhập dữ liệu vào các DataTable từ tập tin .txt
            Nhap_Dieu_Lieu_Cac_Bang();

            // Khởi tạo cho combox Khoa
            Gan_Du_Lieu_Cbo_Khoa();

            // Hiện thị dữ liệu 
            stt = 0;
            Gan_Du_Lieu(stt);

            // Nhập dữ liệu vào các DataTable từ các bảng trong CSDL  // xíu làm
            Nhap_Lieu_Tu_CSDL();
        }

        private void Nhap_Lieu_Tu_CSDL()
        {
            // xíu làm

        }

        private void Gan_Du_Lieu_Cbo_Khoa()
        {
            cbokhoa.DisplayMember = "TenKH";
            cbokhoa.ValueMember = "MaKH";
            cbokhoa.DataSource = tblKhoa;
        }

        private void Nhap_Dieu_Lieu_Cac_Bang()
        {
            Nhap_Lieu_KHOA();
            Nhap_Lieu_SINHVIEN();
            Nhap_Lieu_KETQUA();
        }

        private void Nhap_Lieu_KETQUA()
        {
            string[] Mang_KQ = File.ReadAllLines(@"..\..\..\Data\KETQUA.txt");

            foreach (var Chuoi_KQ in Mang_KQ)
            {
                string[] Mang_ThanhPhan = Chuoi_KQ.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                DataRow rKQ = tblKetQua.NewRow();
                for (int i = 0; i < Mang_ThanhPhan.Length; i++)
                    rKQ[i] = Mang_ThanhPhan[i];

                tblKetQua.Rows.Add(rKQ);
            }
        }

        private void Nhap_Lieu_SINHVIEN()
        {
            string[] Mang_SINHVIEN = File.ReadAllLines(@"..\..\..\Data\SINHVIEN.txt");
            foreach (var Chuoi_SV in Mang_SINHVIEN)
            {
                string[] Mang_ThanhPhan = Chuoi_SV.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                DataRow rSV = tblSinhVien.NewRow();
                for (int i = 0; i < Mang_ThanhPhan.Length; i++)
                    rSV[i] = Mang_ThanhPhan[i];

                tblSinhVien.Rows.Add(rSV);
            }
        }

        private void Nhap_Lieu_KHOA()
        {
            string[] Mang_KHOA = File.ReadAllLines(@"..\..\..\Data\KHOA.txt");

            foreach (var Chuoi_Khoa in Mang_KHOA)
            {
                string[] Mang_ThanhPhan = Chuoi_Khoa.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                DataRow rKhoa = tblKhoa.NewRow();

                rKhoa[0] = Mang_ThanhPhan[0];
                rKhoa[1] = Mang_ThanhPhan[1];
                tblKhoa.Rows.Add(rKhoa);
            }
        }

        private void Moc_Noi_Quan_He_Giua_Cac_Bang()
        {
            // Nối nối quan hệ giữa table KHOA và SINHVIEN
            ds.Relations.Add("FK_KH_SV", ds.Tables["KHOA"].Columns["MaKH"], ds.Tables["SINHVIEN"].Columns["MaKH"], true);

            // Nối nối quan hệ giữa table SINHVIEN và KETQUA
            ds.Relations.Add("FK_SV_KQ", ds.Tables["SINHVIEN"].Columns["MaSV"], ds.Tables["KETQUA"].Columns["MaSV"], true);

            // Loại bỏ CatCade delete
            ds.Relations["FK_KH_SV"].ChildKeyConstraint.DeleteRule = Rule.None;
            ds.Relations["FK_SV_KQ"].ChildKeyConstraint.DeleteRule = Rule.None;

        }

        private void Tao_Cau_Truc_Cac_Bang()
        {
            // Tạo các cột của bảng KHOA:
            tblKhoa.Columns.Add("MaKH", typeof(string));
            tblKhoa.Columns.Add("TenKH", typeof(string));
            // Tạo khóa chính cho bảng KHOA
            tblKhoa.PrimaryKey = new DataColumn[] { tblKhoa.Columns["MaKH"] };

            // Tạo các cột của bảng SINHVIEN:
            tblSinhVien.Columns.Add("MaSV", typeof(string));
            tblSinhVien.Columns.Add("HoSV", typeof(string));
            tblSinhVien.Columns.Add("TenSV", typeof(string));
            tblSinhVien.Columns.Add("Phai", typeof(Boolean));
            tblSinhVien.Columns.Add("NgaySinh", typeof(DateTime));
            tblSinhVien.Columns.Add("NoiSinh", typeof(string));
            tblSinhVien.Columns.Add("MaKH", typeof(string));
            tblSinhVien.Columns.Add("HocBong", typeof(double));
            // Tạo khóa chính cho bảng SINHVIEN: 
            tblSinhVien.PrimaryKey = new DataColumn[] { tblSinhVien.Columns["MaSV"] };

            // Tạo các cột của bảng KETQUA:
            tblKetQua.Columns.Add("MaSV", typeof(string));
            tblKetQua.Columns.Add("MaKH", typeof(string));
            tblKetQua.Columns.Add("Diem", typeof(Single));
            // Tạo khóa chính cho bảng KETQUA
            tblKetQua.PrimaryKey = new DataColumn[] { tblKetQua.Columns["MaSV"], tblKetQua.Columns["MaKH"] };

            // Thêm các DataTable và DataSet
            //ds.Tables.Add(tblKhoa);
            //ds.Tables.Add(tblSinhVien);
            //ds.Tables.Add(tblKetQua);

            ds.Tables.AddRange(new DataTable[] { tblKhoa, tblSinhVien, tblKetQua });
        }

        private void btntruoc_Click(object sender, EventArgs e)
        {
            stt--;
            Gan_Du_Lieu(stt);
        }
        private void btnsau_Click(object sender, EventArgs e)
        {
            stt++;
            Gan_Du_Lieu(stt);
        }
        private void Gan_Du_Lieu(int stt)
        {
            DataRow rSinhVien = tblSinhVien.Rows[stt];
            txtmasv.Text = rSinhVien["MaSV"].ToString();
            txthosv.Text = rSinhVien["HoSV"].ToString();
            txttensv.Text = rSinhVien["TenSV"].ToString();
            chkphai.Checked = (Boolean)rSinhVien["Phai"];
            dtpngaysinh.Value = (DateTime)rSinhVien["NgaySinh"];
            txtnoisinh.Text = rSinhVien["NoiSinh"].ToString();
            cbokhoa.SelectedValue = rSinhVien["MaKH"].ToString();
            txthocbong.Text = rSinhVien["HocBong"].ToString();

            // Tính tổng điểm 
            txttongdiem.Text = TinhTongDiem(txtmasv.Text).ToString();

            // Thể hiện số thứ tự mẫu tin hiện hành
            lblSTT.Text = (stt + 1) + " / " + tblSinhVien.Rows.Count;
        }

        private double TinhTongDiem(string masv)
        {
            double kq = 0;
            Object td = tblKetQua.Compute("sum(Diem)", "MaSV='" + masv + "'");
            // Lưu ý: trường hợp sinh viên không có điểm thì phương thức Compuete trả về DBNull
            if (td == DBNull.Value)
                kq = 0;
            else
                kq = Convert.ToDouble(td);
            return kq;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            txtmasv.ReadOnly = false;
            foreach (var ctl in this.Controls)
            {
                if (ctl is TextBox)
                    (ctl as TextBox).Clear();
                else if (ctl is CheckBox)
                    (ctl as CheckBox).Checked = true;
                else if (ctl is ComboBox)
                    (ctl as ComboBox).SelectedIndex = 0;
                else if (ctl is DateTimePicker)
                    (ctl as DateTimePicker).Value = new DateTime(2005, 1, 1);
            }
            txtmasv.Focus();
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            // Xác định dòng cần hủy ==> sử dụng hàm Find tìm theo khóa chính của DataTable 
            DataRow rSV = tblSinhVien.Rows.Find(txtmasv.Text);
            // Cần kiểm tra: Nếu rsv có tồn tại những dòng liên quan trong tblKetQua => không được xóa. Ngược lại thì được xóa
            // Sử dụng hàm GetChildRow để kiểm tra những dòng liên quan hay tồn tại hay không? Giá trị trả về của hàm là một mảng.
            DataRow[] MangDongLienQuan = rSV.GetChildRows("FK_SV_KQ");
            if (MangDongLienQuan.Length > 0) // Có tồn tại dòng liên quan trong tblKetQua
            {
                MessageBox.Show("Không xóa được do đã tồn tại những dòng liên quan trong KETQUA");
            }
            else
            {
                rSV.Delete();
                stt = 0;
                Gan_Du_Lieu(stt);
            }
        }

        private void btnghi_Click(object sender, EventArgs e)
        {
            if (txtmasv.ReadOnly) // Ghi sửa
            {
                // Xác định dòng cần sửa 
                DataRow rsv = tblSinhVien.Rows.Find(txtmasv.Text);
                // Tiến hành sửa
                rsv["HoSV"] = txthosv.Text;
                rsv["TenSV"] = txttensv.Text;
                rsv["Phai"] = chkphai.Checked;
                rsv["NgaySinh"] = dtpngaysinh.Value;
                rsv["NoiSinh"] = txtnoisinh.Text;
                rsv["MaKH"] = cbokhoa.SelectedValue.ToString();
                rsv["HocBong"] = txthocbong.Text;
            }
            else // Ghi mới
            {
                // Kiểm tra khóa chính có trùng hay không
                DataRow rsv = tblSinhVien.Rows.Find(txtmasv.Text);
                if (rsv != null) // Đã trùng khóa
                {
                    MessageBox.Show("Trùng khóa chính. Nhập lại");
                    txtmasv.Focus();
                    return;
                }


                // Tạo mới sinh viên
                rsv = tblSinhVien.NewRow();
                rsv["MaSV"] = txthosv.Text;
                rsv["HoSV"] = txthosv.Text;
                rsv["TenSV"] = txttensv.Text;
                rsv["Phai"] = chkphai.Checked;
                rsv["NgaySinh"] = dtpngaysinh.Value;
                rsv["NoiSinh"] = txtnoisinh.Text;
                rsv["MaKH"] = cbokhoa.SelectedValue.ToString();
                rsv["HocBong"] = txthocbong.Text;
                tblSinhVien.Rows.Add(rsv);              
                txtmasv.ReadOnly= true;
            }
            stt = 0;
            Gan_Du_Lieu(0);
        }

        private void btnkhong_Click(object sender, EventArgs e)
        {
            Gan_Du_Lieu(stt);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Ghi tập tin:
            // Lưu ý: tblSinhVien.Rows => tập hợp dòng ( Không phải mảng) => chuyển thành mảng => ItemArray
            //        Để chuyển một mảng thành chuổi => Join =>
            // Thuật toán ghi một DataTable vào tập tin
            // 1. Khai báo một mảng chuỗi với mỗi phần tử sẽ chứa một chuỗi tương ứng với 1 dòng trong DataBase
            // 2. Duyệt qua tập hợp Rows của DataTable và đưa từng dòng vào mảng chuỗi với hàm Join
            // 3. Sử dụng phương thức WiteAllLine để ghi mảng chuỗi vào tập tin SINHVIEN.txt
            List <string> Mang_Chuoi_SV= new List<string>();
            foreach (DataRow rSV in tblSinhVien.Rows)
            {
                string Chuoi_dong_SV = string.Join("|", rSV.ItemArray);
                Mang_Chuoi_SV.Add(Chuoi_dong_SV);
            }
            File.WriteAllLines(@"..\..\..\Data\SINHVIEN.txt",Mang_Chuoi_SV);
        }
    }
}
