using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Luoi_DataGridview_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Them_du_lieu();

            DataGridViewRow r = dgvMH.Rows[2];
            r.Selected = true;
            Gan_du_lieu(r);

        }

        private void Gan_du_lieu(DataGridViewRow r)
        {
            txtmamh.Text = r.Cells["colMaMH"].Value.ToString();
            txttenmh.Text = r.Cells["colTenMH"].Value.ToString();
            txtsotiet.Text = r.Cells["colSoTiet"].Value.ToString();
        }

        private void Them_du_lieu()
        {
            dgvMH.Rows.Add("01", "Toán học sơ cấp", 48);
            dgvMH.Rows.Add("02", "Toán rời rạc", 43);
            dgvMH.Rows.Add("03", "Toán đại cương", 47);
            dgvMH.Rows.Add("04", "Toán cao cấp", 44);
            dgvMH.Rows.Add("05", "Vật lý", 49);
            dgvMH.Rows.Add("06", "Anh văn", 45);
        }

        private void dgvMH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow r = dgvMH.Rows[e.RowIndex];
            Gan_du_lieu(r);
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            txtmamh.ReadOnly = false;
            foreach (Control ctl in this.Controls)
            {
                if (ctl is TextBox)
                {
                    (ctl as TextBox).Clear();
                }
            }
            txtmamh.Focus();
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            DataGridViewRow rhuy = dgvMH.SelectedRows[0];
            dgvMH.Rows.Remove(rhuy);
        }

        private void btnghi_Click(object sender, EventArgs e)
        {
            if (txtmamh.ReadOnly == true)
            {
                DataGridViewRow rsua = dgvMH.SelectedRows[0];
                rsua.Cells[1].Value = txttenmh.Text;
                rsua.Cells[2].Value = txtsotiet.Text;
            }
            else if (txtmamh.ReadOnly == false)
            {
                int stt = dgvMH.Rows.Add(txtmamh.Text, txttenmh.Text, txtsotiet.Text);
                dgvMH.Rows[stt].Selected = true;
                txtmamh.ReadOnly = true;
            }
        }

        private void btnkhong_Click(object sender, EventArgs e)
        {
            Gan_du_lieu(dgvMH.SelectedRows[0]);
            txtmamh.ReadOnly = true;
        }
    }
}
