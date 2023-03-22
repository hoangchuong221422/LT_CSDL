using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Man_hinh_main_sub
{
    public partial class Form1 : Form
    {
        QLSV ds = new QLSV();
        QLSVTableAdapters.KHOATableAdapter dapKH = new QLSVTableAdapters.KHOATableAdapter();
        QLSVTableAdapters.SINHVIENTableAdapter dapSV = new QLSVTableAdapters.SINHVIENTableAdapter();
        QLSVTableAdapters.MONHOCTableAdapter dapMH = new QLSVTableAdapters.MONHOCTableAdapter();
        QLSVTableAdapters.KETQUATableAdapter dapKQ = new QLSVTableAdapters.KETQUATableAdapter();
        BindingSource bssv = new BindingSource();
        BindingSource bskq = new BindingSource();

        public Form1()
        {
            InitializeComponent();
            bssv.CurrentChanged += Bs_CurrentChanged;

        }

        private void Bs_CurrentChanged(object sender, EventArgs e)
        {
            // Phương thức này được tự động thi hành khi có sự di chuyển mẫu tin
            lblSTT.Text = bssv.Position + 1 + " / " + bssv.Count;
            txttongdiem.Text = TinhTongDiem(txtmasv.Text).ToString();
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

        private void Form1_Load(object sender, EventArgs e)
        {
            Doc_Du_Lieu();
            Lien_Ket_Dieu_Khien();
            txttongdiem.Text = TinhTongDiem(txtmasv.Text).ToString();


            // Không phát sinh cột khi hán nguồn.
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = ds.MONHOC;
        }

        private void Doc_Du_Lieu()
        {
            // nap du lieu cho các Datatable
            dapMH.Fill(ds.MONHOC);
            dapKH.Fill(ds.KHOA);
            dapSV.Fill(ds.SINHVIEN);
            dapKQ.Fill(ds.KETQUA);

            // nap nguồn cho combox
            cbomakh.DataSource = ds.KHOA;
            cbomakh.DisplayMember = "TenKH";
            cbomakh.ValueMember = "MaKH";

            // Nạp nguồn cho bssv;
            bssv.DataSource = ds.SINHVIEN;


            // Nạp nguồn cho bindingSoure bskq
            bskq.DataSource = bssv;
            bskq.DataMember = "SINHVIENKETQUA";

            // Gan nguon cho luoi

            dgvKQ.DataSource = bskq;

            // không hiển thi cot MaSV trong lưới
            dgvKQ.Columns["MaSV"].Visible = false;


        }

        private void Lien_Ket_Dieu_Khien()
        {
            foreach (Control ctl in this.Controls)
                if (ctl is TextBox && ctl.Name != "txttongdiem")
                    ctl.DataBindings.Add("text", bssv, ctl.Name.Substring(3));
                else if (ctl is CheckBox)
                    ctl.DataBindings.Add("checked", bssv, ctl.Name.Substring(3));
                else if (ctl is ComboBox)
                    ctl.DataBindings.Add("selectedvalue", bssv, ctl.Name.Substring(3));
                else if (ctl is DateTimePicker)
                    ctl.DataBindings.Add("value", bssv, ctl.Name.Substring(3));
            // Định dạng số tiết khi hiển thị:
            txthocbong.DataBindings[0].FormatString = "#,##0 đ";
        }


        private void btnhuy_Click(object sender, EventArgs e)
        {
            // Hủy trong DataTabke
            // Kiểm tra có tồn tại các mẫu tin có liên quang trong KETQUA hay không trước khi xoa
            // Dòng hiện hành đang hiển thị trên form => bs.Current có kiểu object 
            QLSV.SINHVIENRow r = (bssv.Current as DataRowView).Row as QLSV.SINHVIENRow;
            if (r.GetKETQUARows().Length > 0)
            {
                MessageBox.Show("Không xóa được do tồn tại các dòng liên quan trong KETQUA");
                return;
            }
            bssv.RemoveCurrent();

            // Hủy trong CSDL
            int n = dapSV.Update(ds.SINHVIEN);
            if (n > 0)
            {
                MessageBox.Show("Hủy sinh viên thành công");
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            txtmasv.ReadOnly = false;
            // Thêm mới
            bssv.AddNew();
            txtmasv.Focus();
        }

        private void btnkhong_Click(object sender, EventArgs e)
        {
            bssv.CancelEdit();
            txtmasv.ReadOnly = true;
        }

        private void btnghi_Click(object sender, EventArgs e)
        {
            if (!txtmasv.ReadOnly)
            {
                QLSV.SINHVIENRow r = (bssv.Current as DataRowView).Row as QLSV.SINHVIENRow;
                if (r != null)
                {
                    MessageBox.Show("Trùng khóa chính, Nhập lại nhé !!!");
                    txtmasv.Focus();
                    return;
                }
            }
            // Cập nhật lại việc thêm mới hay sửa trong DataTable
            txtmasv.ReadOnly = true;
            bssv.EndEdit();
            // Cập nhật lại trong CSDL
            int n = dapSV.Update(ds.SINHVIEN);
            if (n > 0)
            {
                MessageBox.Show("Cập nhật môn học thành công");
            }
        }

        private void btntruoc_Click(object sender, EventArgs e)
        {
            bssv.MovePrevious();
        }

        private void btnsau_Click(object sender, EventArgs e)
        {
            bssv.MoveNext();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Hãy xác định dòng chưa ô vừa click là loại dòng nào trong các dòng sau đây?
            // 1. Dòng mới ( chưa có dữ liệu)
            // 2. Dòng mới ( có dữ liệu)
            // 3. Dòng cũ ( có dữ liệu)

            // Xác định dòng hiện hành => dòng chứa ô vừa bị click
            DataGridViewRow r = dgv.CurrentRow;
            if (r.IsNewRow == true)
            {
                MessageBox.Show("Dòng mới chưa có dữ liệu");

            }
            else if ((r.DataBoundItem as DataRowView).IsNew == true)
            {
                MessageBox.Show("Dòng mới có chưa dữ liệu");

            }
            else
            {
                MessageBox.Show("Dòng cũ");

            }




        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
