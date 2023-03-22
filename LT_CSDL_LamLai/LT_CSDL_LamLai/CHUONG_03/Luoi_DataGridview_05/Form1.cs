using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Luoi_DataGridview_05
{
    public partial class Form1 : Form
    {
        QLSV ds = new QLSV();
        // Khai báo các đối tượng DataAdapter
        QLSVTableAdapters.MONHOCTableAdapter dapMonHoc = new QLSVTableAdapters.MONHOCTableAdapter();
        QLSVTableAdapters.KETQUATableAdapter dapKetQua = new QLSVTableAdapters.KETQUATableAdapter();



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Doc_Du_Lieu();
            dgvMH.DataSource = ds.MONHOC;
            dgvMH.Columns["LoaiMH"].Visible = false;


        }

        private void Doc_Du_Lieu()
        {
            dapMonHoc.Fill(ds.MONHOC);
            dapKetQua.Fill(ds.KETQUA);
        }

        private void dgvMH_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            // sự kiện này xảy ra khi dữ liệu kiểm tra tính hợp lệ
            // Thuộc tính IsNewRow => true: Dòng hiện hành là dòng mới và chưa có dữ liệu
            // Thuộc tính IsNew của đối tượng DataViewRow tương ứng với dòng hiện hành (currentRow) => true
            // => Dòng mới có dữ liệu
            // Thuộc tính IsRowDirty có giá trị là true => Dòng bị chỉnh sửa (có thể là dòng mới hay dòng đã có)

            if (dgvMH.CurrentRow.IsNewRow == true) return;
            if (dgvMH.IsCurrentRowDirty == true)
            {
                if ((dgvMH.CurrentRow.DataBoundItem as DataRowView).IsNew == true)
                {
                    // Kiểm tra khóa chính có trùng không
                    if (ds.MONHOC.FindByMaMH(dgvMH.CurrentRow.Cells["MaMH"].Value.ToString()) != null)
                    {
                        MessageBox.Show("Trùng khóa chính! Nhập lại");
                        e.Cancel = true;
                        dgvMH.CurrentCell = dgvMH.CurrentRow.Cells["MaMH"];
                        return;
                    }
                }
                // kết húc qui trình chỉnh sửa
                (dgvMH.CurrentRow.DataBoundItem as DataRowView).EndEdit();
                // cập nhật về csdl
                int n = dapMonHoc.Update(ds.MONHOC);
                if (n > 0)
                {
                    MessageBox.Show("Cập nhật về môn học thành công");
                }
            }


        }

        private void dgvMH_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {

            QLSV.MONHOCRow r = (dgvMH.CurrentRow.DataBoundItem as DataRowView).Row as QLSV.MONHOCRow;
            if (r.GetKETQUARows().Length > 0)
            {
                MessageBox.Show("Không xóa được do có những dòng liên quan trong bảng KETQUA");
                e.Cancel = true;
                return;
            }
        }

        private void dgvMH_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            int n = dapMonHoc.Update(ds.MONHOC);


        }
    }
}
