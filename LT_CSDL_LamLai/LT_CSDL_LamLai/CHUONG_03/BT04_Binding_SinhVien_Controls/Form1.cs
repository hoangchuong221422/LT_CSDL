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


namespace BT04_Binding_SinhVien_Controls
{
    public partial class Form1 : Form
    {
        string strcon = @"provider=microsoft.jet.oledb.4.0; data source=..\..\..\Data\QLSINHVIEN.mdb";
        DataSet ds = new DataSet();
        OleDbDataAdapter adpKhoa, adpKetQua, adpSinhVien;
        OleDbCommandBuilder cmdSinhVien;
        BindingSource bs = new BindingSource();
        public Form1()
        {
            InitializeComponent();
            bs.CurrentChanged += Bs_CurrentChanged;
        }


        private void Bs_CurrentChanged(object sender, EventArgs e)
        {
            // Phương thức này được tự động thi hành khi có sự di chuyển mẫu tin
            lblSTT.Text = bs.Position + 1 + " / " + bs.Count;
            txttongdiem.Text = TinhTongDiem(txtmasv.Text).ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Khoi_Tao_Doi_Tuong();
            Doc_Du_Lieu();
            Moc_Noi_Quan_He();
            Khoi_Tao_BingdingSource();
            Khoi_Tao_Combo_Khoa();
            Lien_Ket_Dieu_Khien();
        }

        private void Khoi_Tao_Combo_Khoa()
        {
            cbomakh.DisplayMember = "TenKH";
            cbomakh.ValueMember = "MaKH";
            cbomakh.SelectedValue = "OK";
            cbomakh.DataSource = ds.Tables["KHOA"];
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

        private void Moc_Noi_Quan_He()
        {
            // Nối nối quan hệ giữa table KHOA và SINHVIEN
            ds.Relations.Add("FK_KH_SV", ds.Tables["KHOA"].Columns["MaKH"], ds.Tables["SINHVIEN"].Columns["MaKH"], true);

            // Nối nối quan hệ giữa table SINHVIEN và KETQUA
            ds.Relations.Add("FK_SV_KQ", ds.Tables["SINHVIEN"].Columns["MaSV"], ds.Tables["KETQUA"].Columns["MaSV"], true);

            // Loại bỏ CatCade delete            
            ds.Relations["FK_SV_KQ"].ChildKeyConstraint.DeleteRule = Rule.None;
        }

        private void Khoi_Tao_BingdingSource()
        {
            bs.DataSource = ds;
            bs.DataMember = "SINHVIEN";
        }

        private void Lien_Ket_Dieu_Khien()
        {
            // Mỗi điều khiển trên form liên kết thông qua tập hợp DataBingdings
            foreach (Control ctl in this.Controls)
                if (ctl is TextBox && ctl.Name != "txttongdiem")
                    ctl.DataBindings.Add("text", bs, ctl.Name.Substring(3), true);
                else if (ctl is CheckBox)
                    ctl.DataBindings.Add("checked", bs, ctl.Name.Substring(3), true);
                else if (ctl is ComboBox)
                    ctl.DataBindings.Add("selectedvalue", bs, ctl.Name.Substring(3), true);
                else if (ctl is DateTimePicker)
                    ctl.DataBindings.Add("value", bs, ctl.Name.Substring(3), true);
            // Định dạng lại học bổng trước khi hiển thị
            txthocbong.DataBindings[0].FormatString = "#,##0 đ";


        }

        private void btntruoc_Click(object sender, EventArgs e)
        {
            bs.MovePrevious();
        }

        private void btnsau_Click(object sender, EventArgs e)
        {
            bs.MoveNext();
        }


        private void btnthem_Click(object sender, EventArgs e)
        {
            txtmasv.ReadOnly = false;
            // Thêm mới
            bs.AddNew();
            txtmasv.Focus();
            cbomakh.SelectedIndex = 0;
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            // Hủy trong DataTabke
            // Kiểm tra có tồn tại các mẫu tin có liên quang trong KETQUA hay không trước khi xoa
            // Dòng hiện hành đang hiển thị trên form => bs.Current có kiểu object 
            DataRow r = (bs.Current as DataRowView).Row;
            DataRow[] Mang_dong_lien_quan = r.GetChildRows("FK_SV_KQ");
            if (Mang_dong_lien_quan.Length > 0)
            {
                MessageBox.Show("Không xóa được do tồn tại các dòng liên quan trong KETQUA");
                return;
            }
            bs.RemoveCurrent();

            // Hủy trong CSDL
            int n = adpSinhVien.Update(ds, "SINHVIEN");
            if (n > 0)
            {
                MessageBox.Show("Hủy sinh viên thành công");
            }
        }

        private void btnghi_Click(object sender, EventArgs e)
        {
            if (!txtmasv.ReadOnly)
            {
                DataRow r = ds.Tables["SINHVIEN"].Rows.Find(txtmasv.Text);
                if (r != null)
                {
                    MessageBox.Show("Trùng khóa chính, Nhập lại nhé !!!");
                    txtmasv.Focus();
                    return;
                }
            }
            // Cập nhật lại việc thêm mới hay sửa trong DataTable
            txtmasv.ReadOnly = true;
            bs.EndEdit();
            // Cập nhật lại trong CSDL
            int n = adpSinhVien.Update(ds, "MONHOC");
            if (n > 0)
            {
                MessageBox.Show("Cập nhật môn học thành công");
            }

        }

        private void btnkhong_Click(object sender, EventArgs e)
        {
            bs.CancelEdit();
            txtmasv.ReadOnly = true;
        }

        private double TinhTongDiem(string masv)
        {
            double kq = 0;
            Object td = ds.Tables["KETQUA"].Compute("sum(Diem)", "MaSV='" + masv + "'");
            // Lưu ý: trường hợp sinh viên không có điểm thì phương thức Compuete trả về DBNull
            if (td == DBNull.Value)
                kq = 0;
            else
                kq = Convert.ToDouble(td);
            return kq;
        }
    }
}
