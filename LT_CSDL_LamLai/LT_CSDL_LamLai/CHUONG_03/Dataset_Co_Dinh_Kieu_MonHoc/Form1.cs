using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dataset_Co_Dinh_Kieu_MonHoc
{
    public partial class Form1 : Form
    {
        // Khai bao dataset có định kiểu
        QLSinhVien ds = new QLSinhVien();
        // Khai báo các đối tượng DataAdapter
        QLSinhVienTableAdapters.MONHOCTableAdapter dapMonHoc = new QLSinhVienTableAdapters.MONHOCTableAdapter();
        QLSinhVienTableAdapters.KETQUATableAdapter dapKetQua = new QLSinhVienTableAdapters.KETQUATableAdapter();

        BindingSource bs = new BindingSource();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Doc_Du_Lieu();
            Khoi_Tao_BindingSource();
            Lien_Ket_Dieu_Khien();
        }

        private void Khoi_Tao_BindingSource()
        {
            bs.DataSource = ds;
            bs.DataMember = ds.MONHOC.TableName;
        }

        private void Doc_Du_Lieu()
        {
            dapMonHoc.Fill(ds.MONHOC);
            dapKetQua.Fill(ds.KETQUA);
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
            // Hủy trong DataTable
            // Kiểm tra có tồn tại các mẫu tin có liên quang trong KETQUA hay không trước khi xoa
            QLSinhVien.MONHOCRow rmh = (bs.Current as DataRowView).Row as QLSinhVien.MONHOCRow;
            if (rmh.GetKETQUARows().Length > 0)
            {
                MessageBox.Show("Không xóa được do tồn tại các dòng liên quan trong KETQUA");
                return;
            }

            bs.RemoveCurrent();

            // Hủy trong CSDL
            int n = dapMonHoc.Update(ds.MONHOC);
            if (n > 0)
            {
                MessageBox.Show("Hủy môn học thành công");
            }
        }

        private void btnghi_Click(object sender, EventArgs e)
        {
            if (!txtmamh.ReadOnly)
            {
                QLSinhVien.MONHOCRow rmh = ds.MONHOC.FindByMaMH(txtmamh.Text);
                if (rmh != null)
                {
                    MessageBox.Show("Trùng khóa chính nhập lại nhé");
                    txtloaimh.Focus();
                    return;
                }
            }
            // Cập nhật lại việc thêm mới hay sửa trong DataTable
            bs.EndEdit();
            // Cập nhật lại trong CSDL
            int n = dapMonHoc.Update(ds.MONHOC);
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

    }
}
