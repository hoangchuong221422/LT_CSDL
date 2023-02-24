using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace BT01_Mo_Hinh_Ngat_Ket_Noi_SinhVien
{
    public partial class Form1 : Form
    {
        int stt =  -1;
        // Khai báo các đối tượng cần sử dụng: 
        // 1.1 Chuỗi kết nối:
        string strcon = @"provider=microsoft.jet.oledb.4.0; data source=..\..\..\Data\QLSINHVIEN.mdb";

        // 1.2 Khai báo các đối tượng lưu trữ dữ liệu:
        DataSet ds = new DataSet();

        // 1.3  Khai báo các DataAdapter sử dụng với nguyên tắc: 1 DataTable tương ứng với 1 DataAdapter
        OleDbDataAdapter adpKhoa, adpSinhVien, adpKetQua;

        // 1.4 Khai báo đối tượng CommanBuilder tương ứng để cập nhật dữ liệu cho bảng SINHVIEN
        // Lưu ý: Chỉ khai báo CommanBuilder cho đối tượng bảng cần cập nhật
        OleDbCommandBuilder cmdSinhVien;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Khoi_Tao_Doi_Tuong();
            Doc_Du_Lieu();
            Moc_Noi_Quan_He();
            Khoi_Tao_Combo_Khoa();
            stt = 0;
            Gan_Du_Lieu(stt);
        }

        private void Khoi_Tao_Combo_Khoa()
        {
            cbokhoa.DisplayMember = "TenKH";
            cbokhoa.ValueMember = "MaKH";
            cbokhoa.DataSource = ds.Tables["KHOA"];
        }

        private void Moc_Noi_Quan_He()
        {
            // Nối nối quan hệ giữa table KHOA và SINHVIEN
            ds.Relations.Add("FK_KH_SV", ds.Tables["KHOA"].Columns["MaKH"], ds.Tables["SINHVIEN"].Columns["MaKH"], true);

            // Nối nối quan hệ giữa table SINHVIEN và KETQUA
            ds.Relations.Add("FK_SV_KQ", ds.Tables["SINHVIEN"].Columns["MaSV"], ds.Tables["KETQUA"].Columns["MaSV"], true);

            // Loại bỏ CatCade delete
            ds.Relations["FK_KH_SV"].ChildKeyConstraint.DeleteRule = Rule.None;
            ds.Relations["FK_SV_KQ"].ChildKeyConstraint.DeleteRule = Rule.None;
        }

        private void Doc_Du_Lieu()
        {
            // 1. Đọc dữ liệu từ bảng KHOA
            // 1.1 Sao chép cấu trúc của table KHOA vào Datatable trong DataSet ds
            adpKhoa.FillSchema(ds, SchemaType.Source, "KHOA");
            adpKhoa.Fill(ds, "KHOA");

            adpSinhVien.FillSchema(ds, SchemaType.Source, "SINHVIEN");
            adpSinhVien.Fill(ds, "SINHVIEN");

            adpKetQua.FillSchema(ds, SchemaType.Source, "KETQUA");
            adpKetQua.Fill(ds, "KETQUA");

        }

        private void Khoi_Tao_Doi_Tuong()
        {
            // 1. Khởi tạo các đối tượng DataAdapter
            adpKhoa = new OleDbDataAdapter("select * from khoa", strcon);
            adpSinhVien = new OleDbDataAdapter("select * from sinhvien", strcon);
            adpKetQua = new OleDbDataAdapter("select * from ketqua", strcon);


            // 2. Khởi tạo đối tượng CommanBuider
            cmdSinhVien = new OleDbCommandBuilder(adpSinhVien);

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
            DataRow rSinhVien = ds.Tables["SINHVIEN"].Rows[stt];
            txtmasv.Text = rSinhVien["MaSV"].ToString();
            txthosv.Text = rSinhVien["HoSV"].ToString();
            txttensv.Text = rSinhVien["TenSV"].ToString();
            chkphai.Checked = (Boolean)rSinhVien["Phai"];
            dtpngaysinh.Value = (DateTime)rSinhVien["NgaySinh"];
            txtnoisinh.Text = rSinhVien["NoiSinh"].ToString();
            cbokhoa.SelectedValue = rSinhVien["MaKH"].ToString();
            txthocbong.Text = rSinhVien["HocBong"].ToString();

            // Tính tổng điểm 
            //txttongdiem.Text = TinhTongDiem(txtmasv.Text).ToString();

            // Thể hiện số thứ tự mẫu tin hiện hành
            lblSTT.Text = (stt + 1) + " / " + ds.Tables["SINHVIEN"].Rows.Count;
        }

        //private double TinhTongDiem(string masv)
        //{
        //    double kq = 0;
        //    Object td = tblKetQua.Compute("sum(Diem)", "MaSV='" + masv + "'");
        //    // Lưu ý: trường hợp sinh viên không có điểm thì phương thức Compuete trả về DBNull
        //    if (td == DBNull.Value)
        //        kq = 0;
        //    else
        //        kq = Convert.ToDouble(td);
        //    return kq;
        //}

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
            // nút hủy chuẩn bị làm


            //// Xác định dòng cần hủy ==> sử dụng hàm Find tìm theo khóa chính của DataTable 
            //DataRow rSV = tblSinhVien.Rows.Find(txtmasv.Text);
            //// Cần kiểm tra: Nếu rsv có tồn tại những dòng liên quan trong tblKetQua => không được xóa. Ngược lại thì được xóa
            //// Sử dụng hàm GetChildRow để kiểm tra những dòng liên quan hay tồn tại hay không? Giá trị trả về của hàm là một mảng.
            //DataRow[] MangDongLienQuan = rSV.GetChildRows("FK_SV_KQ");
            //if (MangDongLienQuan.Length > 0) // Có tồn tại dòng liên quan trong tblKetQua
            //{
            //    MessageBox.Show("Không xóa được do đã tồn tại những dòng liên quan trong KETQUA");
            //}
            //else
            //{
            //    rSV.Delete();
            //    stt = 0;
            //    Gan_Du_Lieu(stt);
            //}

            // Sự khác biệt

            // Xác định dòng cần hủy ==> sử dụng hàm Find tìm theo khóa chính của DataTable 
            DataTable tblSinhVien = ds.Tables["SINHVIEN"];
            DataRow rSV = tblSinhVien.Rows.Find(txtmasv.Text);
            //Cần kiểm tra: Nếu rsv có tồn tại những dòng liên quan trong tblKetQua => không được xóa. Ngược lại thì được xóa
            // Sử dụng hàm GetChildRow để kiểm tra nững dòng liên quan hay tồn tại hay không? Giá trị trả về của hàm là một mảng.
            DataRow[] MangDongLienQuan = rSV.GetChildRows("FK_SV_KQ");
            if (MangDongLienQuan.Length > 0) // Có tồn tại dòng liên quan trong tblKetQua
            {
                MessageBox.Show("Không xóa được do đã tồn tại những dòng liên quan trong KETQUA");
            }
            else
            {
                // Xóa trong DataTable
                rSV.Delete();

                // Xóa trong CSDL 

                int n = adpSinhVien.Update(ds, "SINHVIEN");
                if (n > 0)
                {
                    MessageBox.Show("Hủy sinh viên thành công");
                }
                stt = 0;
                Gan_Du_Lieu(stt);

            }

        }

        private void btnghi_Click(object sender, EventArgs e)
        {
            DataTable tblSinhVien = ds.Tables["SINHVIEN"];
            if (txtmasv.ReadOnly) // Ghi sửa
            {
                // Xác định dòng cần sửa 
           
                DataRow rsv = tblSinhVien.Rows.Find(txtmasv.Text);

                // Tiến hành sửa
                // 1. Sửa trong DataTable
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
            }
            int n = adpSinhVien.Update(ds, "SINHVIEN");
            if (n > 0)
            {
                MessageBox.Show("Cập nhật sinh viên thành công");
            }
        }

        private void btnkhong_Click(object sender, EventArgs e)
        {
            Gan_Du_Lieu(stt);
        }

    }
}
