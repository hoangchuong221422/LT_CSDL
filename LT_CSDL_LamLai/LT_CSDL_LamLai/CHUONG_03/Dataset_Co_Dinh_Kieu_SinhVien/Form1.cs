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

namespace Dataset_Co_Dinh_Kieu_SinhVien
{
    public partial class Form1 : Form
    {
        QLSVC21TH ds = new QLSVC21TH();
        QLSVC21THTableAdapters.KHOATableAdapter dapKhoa = new QLSVC21THTableAdapters.KHOATableAdapter();
        QLSVC21THTableAdapters.SINHVIENTableAdapter dapSinhVien = new QLSVC21THTableAdapters.SINHVIENTableAdapter();
        QLSVC21THTableAdapters.KETQUATableAdapter dapKetQua = new QLSVC21THTableAdapters.KETQUATableAdapter();
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
            Doc_Du_Lieu();
            Khoi_Tao_BindingSource();
            Khoi_Tao_Combo_Box();
            Lien_Ket_Dieu_Khien();

            txttongdiem.Text = TinhTongDiem(txtmasv.Text).ToString();

        }

        private void Khoi_Tao_Combo_Box()
        {
            cbomakh.DisplayMember = "TenKH";
            cbomakh.ValueMember = "MaKH";
            cbomakh.DataSource = ds.KHOA;
        }

        private void Lien_Ket_Dieu_Khien()
        {
            foreach (Control ctl in this.Controls)
                if (ctl is TextBox && ctl.Name != "txttongdiem")
                    ctl.DataBindings.Add("text", bs, ctl.Name.Substring(3));
                else if (ctl is CheckBox)
                    ctl.DataBindings.Add("checked", bs, ctl.Name.Substring(3));
                else if (ctl is ComboBox)
                    ctl.DataBindings.Add("selectedvalue", bs, ctl.Name.Substring(3));
                else if (ctl is DateTimePicker)
                    ctl.DataBindings.Add("value", bs, ctl.Name.Substring(3));
            // Định dạng số tiết khi hiển thị:
            txthocbong.DataBindings[0].FormatString = "#,##0 đ";
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
        private void Doc_Du_Lieu()
        {
            // 1. Đọc dữ liệu từ bảng KHOA
            // 1.1 Sao chép cấu trúc của table KHOA vào Datatable trong DataSet ds            
            dapKhoa.Fill(ds.KHOA);
            dapSinhVien.Fill(ds.SINHVIEN);
            dapKetQua.Fill(ds.KETQUA);

        }

        private void Khoi_Tao_BindingSource()
        {
            bs.DataSource = ds;
            bs.DataMember = ds.SINHVIEN.TableName;
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            // Hủy trong DataTabke
            // Kiểm tra có tồn tại các mẫu tin có liên quang trong KETQUA hay không trước khi xoa
            // Dòng hiện hành đang hiển thị trên form => bs.Current có kiểu object 
            QLSVC21TH.SINHVIENRow r = (bs.Current as DataRowView).Row as QLSVC21TH.SINHVIENRow;
            if (r.GetKETQUARows().Length > 0)
            {
                MessageBox.Show("Không xóa được do tồn tại các dòng liên quan trong KETQUA");
                return;
            }
            bs.RemoveCurrent();

            // Hủy trong CSDL
            int n = dapSinhVien.Update(ds.SINHVIEN);
            if (n > 0)
            {
                MessageBox.Show("Hủy sinh viên thành công");
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            txtmasv.ReadOnly = false;
            // Thêm mới
            bs.AddNew();
            txtmasv.Focus();
        }

        private void btnkhong_Click(object sender, EventArgs e)
        {
            bs.CancelEdit();
            txtmasv.ReadOnly = true;
        }

        private void btnghi_Click(object sender, EventArgs e)
        {
            if (!txtmasv.ReadOnly)
            {
                QLSVC21TH.SINHVIENRow r = (bs.Current as DataRowView).Row as QLSVC21TH.SINHVIENRow;
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
            int n = dapSinhVien.Update(ds.SINHVIEN);
            if (n > 0)
            {
                MessageBox.Show("Cập nhật môn học thành công");
            }
        }

        private void btntruoc_Click(object sender, EventArgs e)
        {
            bs.MovePrevious();
        }

        private void btnsau_Click(object sender, EventArgs e)
        {
            bs.MoveNext();
        }
    }
}
