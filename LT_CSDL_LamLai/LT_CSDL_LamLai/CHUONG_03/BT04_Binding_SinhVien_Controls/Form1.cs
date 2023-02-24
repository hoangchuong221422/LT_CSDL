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
        OleDbCommandBuilder cmbMonHoc;
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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Khoi_Tao_Doi_Tuong();
            Doc_Du_Lieu();
            Moc_Noi_Quan_He();
            Khoi_Tao_BingdingSource();
            Lien_Ket_Dieu_Khien();
        }
    }
}
