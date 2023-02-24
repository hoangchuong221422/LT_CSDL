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
using System.IO;

namespace BT01_Truy_Xuat_Du_Lieu
{
    public partial class Form2 : Form
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

        // Khai báo các command để đọc ghi dữ liệu với CSDL:
        OleDbCommand cmdKhoa, cmdSinhVien, cmdKetQua;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Khởi tạo kết nối với database  // xíu làm
            cnn = new OleDbConnection(strcon);

            // Đọc dữ liệu từ CSDL và DataSet:
            Tao_Cau_Truc_Cac_Bang();
            // Mốc nối quan hệ giữa các DaTaTable
            Moc_Noi_Quan_He_Giua_Cac_Bang();

            // Nhập dữ liệu vào các DataTable từ tập tin .txt
            //Nhap_Dieu_Lieu_Cac_Bang();

            // Nhập dữ liệu vào các DataTable từ các bảng trong CSDL  // xíu làm
            Nhap_Lieu_Tu_CSDL();

            // Khởi tạo cho combox Khoa
            Gan_Du_Lieu_Cbo_Khoa();

            // Hiện thị dữ liệu 
            stt = 0;
            Gan_Du_Lieu(stt);


        }
        private void Nhap_Lieu_Tu_CSDL()
        {
            Nhap_Lieu_tblKhoa();
            Nhap_Lieu_tblSinhVien();
            Nhap_Lieu_tblKetQua();
        }

        private void Nhap_Lieu_tblKetQua()
        {
            // Nhập liệu từ tblKhoa 
            // 1. Mở kết nối
            cnn.Open();
            // 2. Khởi tạo đối tượng command tương ứng để đọc dữ liệu từ table KHOA
            cmdKetQua = new OleDbCommand("select * from ketqua", cnn);
            // 3. Tạo đối tượng DataReader để tiến hành đọc từng dòng dữ liệu trong KHOA
            OleDbDataReader rKQ = cmdKetQua.ExecuteReader();
            // 4. Tiến hành đọc dữ liệu với đối tượng DataReader như sau:
            while (rKQ.Read()) // mỗi lần lập DataReader lại trỏ đến từng dòng trong table KHOA
            {
                DataRow r = tblKetQua.NewRow();
                for (int i = 0; i < rKQ.FieldCount; i++)
                {
                    r[i] = rKQ[i];
                }
                tblKetQua.Rows.Add(r);
            }

            // Đóng DataRead và đối tượng kết nối:
            rKQ.Close();
            cnn.Close();
        }

        private void Nhap_Lieu_tblSinhVien()
        {
            // Nhập liệu từ tblKhoa 
            // 1. Mở kết nối
            cnn.Open();
            // 2. Khởi tạo đối tượng command tương ứng để đọc dữ liệu từ table KHOA
            cmdSinhVien = new OleDbCommand("select * from sinhvien", cnn);
            // 3. Tạo đối tượng DataReader để tiến hành đọc từng dòng dữ liệu trong KHOA
            OleDbDataReader rSV = cmdSinhVien.ExecuteReader();
            // 4. Tiến hành đọc dữ liệu với đối tượng DataReader như sau:
            while (rSV.Read()) // mỗi lần lập DataReader lại trỏ đến từng dòng trong table KHOA
            {
                DataRow r = tblSinhVien.NewRow();
                for (int i = 0; i < rSV.FieldCount; i++)
                {
                    r[i] = rSV[i];
                }
                tblSinhVien.Rows.Add(r);
            }

            // Đóng DataRead và đối tượng kết nối:
            rSV.Close();
            cnn.Close();
        }

        private void Nhap_Lieu_tblKhoa()
        {
            // đã xong

            // Nhập liệu từ tblKhoa 
            // 1. Mở kết nối
            cnn.Open();
            // 2. Khởi tạo đối tượng command tương ứng để đọc dữ liệu từ table KHOA
            cmdKhoa = new OleDbCommand("select * from khoa", cnn);
            // 3. Tạo đối tượng DataReader để tiến hành đọc từng dòng dữ liệu trong KHOA
            OleDbDataReader rkh = cmdKhoa.ExecuteReader();
            // 4. Tiến hành đọc dữ liệu với đối tượng DataReader như sau:
            while (rkh.Read()) // mỗi lần lập DataReader lại trỏ đến từng dòng trong table KHOA
            {
                DataRow r = tblKhoa.NewRow();
                r[0] = rkh[0];
                r[1] = rkh[1];
                tblKhoa.Rows.Add(r);
            }

            // Đóng DataRead và đối tượng kết nối:
            rkh.Close();
            cnn.Close();
        }

        private void Gan_Du_Lieu_Cbo_Khoa()
        {
            cbokhoa.DisplayMember = "TenKH";
            cbokhoa.ValueMember = "MaKH";
            cbokhoa.DataSource = tblKhoa;
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
            //txttongdiem.Text = TinhTongDiem(txtmasv.Text).ToString();

            // Thể hiện số thứ tự mẫu tin hiện hành
            lblSTT.Text = (stt + 1) + " / " + tblSinhVien.Rows.Count;
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
                cnn.Open();

                // Xóa cách 1: sử dụng phương pháp nối chuỗi
                //string Chuoi_Xoa = "delete from sinhvien where mavs='" + txtmasv.Text + "'";
                //cmdSinhVien = new OleDbCommand(Chuoi_Xoa,cnn);

                // Xóa cách 2: sử dụng parametter của đối tượng command
                string Chuoi_Xoa = "delete from sinhvien where masv=@masv";
                cmdSinhVien = new OleDbCommand(Chuoi_Xoa, cnn);
                // Khai báo parametter trên như sau:
                cmdSinhVien.Parameters.Add("@masv", OleDbType.Char).Value = txtmasv.Text;
                int n = cmdSinhVien.ExecuteNonQuery();
                if (n > 0)
                {
                    MessageBox.Show("Hủy sinh viên thành công");
                }
                stt = 0;
                Gan_Du_Lieu(stt);
                cnn.Close();
            }

        }

        private void btnghi_Click(object sender, EventArgs e)
        {
            cnn.Open();
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

                // 2. Sửa trong CSDL

                string Chuoi_Sua = "update sinhvien set hosv=@hsv, tensv=@tsv, phai=@ph, ngaysinh=@ngsinh, noisinh=@nsinh, makh=@mak, hocbong=@hb where masv=@msv";
                cmdSinhVien = new OleDbCommand(Chuoi_Sua, cnn);
                // Khai báo các parametter trên như sau:                 
                cmdSinhVien.Parameters.Add("@hsv",OleDbType.VarWChar).Value = txthosv.Text;
                cmdSinhVien.Parameters.Add("@tsv",OleDbType.VarWChar).Value = txttensv.Text;
                cmdSinhVien.Parameters.Add("@ph", OleDbType.Boolean).Value = chkphai.Checked;
                cmdSinhVien.Parameters.Add("@ngsinh", OleDbType.Date).Value = dtpngaysinh.Value;
                cmdSinhVien.Parameters.Add("@nsinh", OleDbType.VarWChar).Value = txtnoisinh.Text;
                cmdSinhVien.Parameters.Add("@mak", OleDbType.Char).Value = cbokhoa.SelectedValue.ToString();
                cmdSinhVien.Parameters.Add("@hb", OleDbType.Double).Value = txthocbong.Text;
                cmdSinhVien.Parameters.Add("@msv", OleDbType.Char).Value = txtmasv.Text;

                int n = cmdSinhVien.ExecuteNonQuery();
                if (n > 0 )
                {
                    MessageBox.Show("Cập nhật sinh viên thành công");
                }

            }
            else // Ghi mới
            {
                // Kiểm tra khóa chính có trùng hay không
                DataRow rsv = tblSinhVien.Rows.Find(txtmasv.Text);
                if (rsv != null) // Đã trùng khóa
                {
                    MessageBox.Show("Trùng khóa chính. Nhập lại");
                    txtmasv.Focus();
                    cnn.Close();
                    return;
                }


                // Tạo mới sinh viên vào DataTable 
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
                txtmasv.ReadOnly = true;

                // Thêm sinh viên mới vào CSDL
                string Chuoi_Sua = "insert into sinhvien values(@msv,@hsv,@tsv,@ph,@ngsinh,@nsinh,@mak,@hb)";
                cmdSinhVien = new OleDbCommand(Chuoi_Sua,cnn);

                // Khai báo các parametter trên như sau:                 
                cmdSinhVien.Parameters.Add("@msv", OleDbType.Char).Value = txtmasv.Text; // MaSV chỉ nhập 3 ký tự nếu không sẽ sai
                cmdSinhVien.Parameters.Add("@hsv", OleDbType.VarWChar).Value = txthosv.Text;
                cmdSinhVien.Parameters.Add("@tsv", OleDbType.VarWChar).Value = txttensv.Text;
                cmdSinhVien.Parameters.Add("@ph", OleDbType.Boolean).Value = chkphai.Checked;
                cmdSinhVien.Parameters.Add("@ngsinh", OleDbType.Date).Value = dtpngaysinh.Value;
                cmdSinhVien.Parameters.Add("@nsinh", OleDbType.VarWChar).Value = txtnoisinh.Text;
                cmdSinhVien.Parameters.Add("@mak", OleDbType.Char).Value = cbokhoa.SelectedValue.ToString();
                cmdSinhVien.Parameters.Add("@hb", OleDbType.Double).Value = txthocbong.Text;

                  int n = cmdSinhVien.ExecuteNonQuery(); // MaSV chỉ nhập 3 ký tự nếu không sẽ sai
                if (n > 0 )
                {
                    MessageBox.Show("Thêm sinh viên sinh viên thành công");
                }
            }
            cnn.Close();
        }

        private void btnkhong_Click(object sender, EventArgs e)
        {
            Gan_Du_Lieu(stt);
        }

      
    }
}
