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

namespace xx_Huynh_Hoang_Chuong_xx
{
    public partial class Form1 : Form
    {
        QLSV ds = new QLSV();
        QLSVTableAdapters.KHOATableAdapter dapkh = new QLSVTableAdapters.KHOATableAdapter();
        QLSVTableAdapters.SINHVIENTableAdapter dapsv = new QLSVTableAdapters.SINHVIENTableAdapter();
        QLSVTableAdapters.KETQUATableAdapter dapkq = new QLSVTableAdapters.KETQUATableAdapter();
        BindingSource bs = new BindingSource();


        public Form1()
        {
            InitializeComponent();
            bs.CurrentChanged += Bs_CurrentChanged;
        }

        private void Bs_CurrentChanged(object sender, EventArgs e)
        {
            lblSTT.Text = bs.Position + 1 + " / " + bs.Count;
            txttongdiem.Text = TongDiem(txtmasv.Text).ToString();
        }

        public double TongDiem(string masv)
        {
            double kq = 0;
            object td = ds.KETQUA.Compute("sum(Diem)", "MaSV = '" + masv + "'");
            if (td == DBNull.Value)
            {
                kq = 0;
            }
            else
            {
                kq = Convert.ToDouble(td);
            }

            return kq;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            KhoiTaoDuLieu();
            LienKetControl();
            KhoiTaoCBBox();
            txttongdiem.Text = TongDiem(txtmasv.Text).ToString();
        }

        private void LienKetControl()
        {
            foreach (Control ctl in this.Controls)
            {
                if (ctl is TextBox && ctl.Name != "txttongdiem")
                    ctl.DataBindings.Add("text", bs, ctl.Name.Substring(3), true);
                else if (ctl is CheckBox)
                    ctl.DataBindings.Add("checked", bs, ctl.Name.Substring(3), true);
                else if (ctl is DateTimePicker)
                    ctl.DataBindings.Add("value", bs, ctl.Name.Substring(3), true);
                else if (ctl is ComboBox)
                    ctl.DataBindings.Add("selectedvalue", bs, ctl.Name.Substring(3), true);

            }
            txthocbong.DataBindings[0].FormatString = "#,##0 đ";
        }

        private void KhoiTaoCBBox()
        {
            cbomakh.DisplayMember = "TenKH";
            cbomakh.ValueMember = "MaKH";
            cbomakh.DataSource = ds.KHOA;

        }

        private void KhoiTaoDuLieu()
        {
            dapkh.Fill(ds.KHOA);
            dapsv.Fill(ds.SINHVIEN);
            dapkq.Fill(ds.KETQUA);

            bs.DataSource = ds;
            bs.DataMember = ds.SINHVIEN.TableName;
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
            bs.AddNew();
            txtmasv.Focus();

        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            QLSV.SINHVIENRow rsv = (bs.Current as DataRowView).Row as QLSV.SINHVIENRow;
            if (rsv.GetKETQUARows().Length > 0)
            {
                MessageBox.Show("Không xóa được do tồn tại những dòng liên quan trong bảng KETQUA");
                return;
            }
            bs.RemoveCurrent();
            int n = dapsv.Update(ds.SINHVIEN);
            MessageBox.Show("Xóa mẫu tin thành công");

        }

        private void btnghi_Click(object sender, EventArgs e)
        {
            if (!txtmasv.ReadOnly)
            {
                QLSV.SINHVIENRow rsv = ds.SINHVIEN.FindByMaSV(txtmasv.Text);
                if (rsv != null)
                {
                    txtmasv.Focus();
                    return;
                }
                bs.EndEdit();
                int n = dapsv.Update(ds.SINHVIEN);
                if (n > 0)
                {
                    MessageBox.Show("Cập nhật mẫu tin thành công");
                }
            }
        }

        private void btnkhong_Click(object sender, EventArgs e)
        {
            bs.CancelEdit();
        }
    }
}
