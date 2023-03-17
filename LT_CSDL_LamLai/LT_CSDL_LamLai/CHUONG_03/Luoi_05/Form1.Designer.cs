namespace Luoi_05
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.colTenMH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaMH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colsotiet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dtpngaysinh = new System.Windows.Forms.DateTimePicker();
            this.cbomakh = new System.Windows.Forms.ComboBox();
            this.txthosv = new System.Windows.Forms.TextBox();
            this.txttongdiem = new System.Windows.Forms.TextBox();
            this.txthocbong = new System.Windows.Forms.TextBox();
            this.txtnoisinh = new System.Windows.Forms.TextBox();
            this.txttensv = new System.Windows.Forms.TextBox();
            this.txtmasv = new System.Windows.Forms.TextBox();
            this.btnkhong = new System.Windows.Forms.Button();
            this.btnghi = new System.Windows.Forms.Button();
            this.btnhuy = new System.Windows.Forms.Button();
            this.btnsau = new System.Windows.Forms.Button();
            this.btnthem = new System.Windows.Forms.Button();
            this.btntruoc = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.chkphai = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblSTT = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // colTenMH
            // 
            this.colTenMH.HeaderText = "ten mon hoc";
            this.colTenMH.Name = "colTenMH";
            this.colTenMH.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colMaMH
            // 
            this.colMaMH.HeaderText = "Ma mon hoc";
            this.colMaMH.Name = "colMaMH";
            this.colMaMH.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colsotiet
            // 
            this.colsotiet.HeaderText = "So tiet";
            this.colsotiet.Name = "colsotiet";
            this.colsotiet.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaMH,
            this.colTenMH,
            this.colsotiet});
            this.dataGridView1.Location = new System.Drawing.Point(45, 266);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(503, 169);
            this.dataGridView1.TabIndex = 169;
            // 
            // dtpngaysinh
            // 
            this.dtpngaysinh.CustomFormat = "dd/MM/yyyy";
            this.dtpngaysinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpngaysinh.Location = new System.Drawing.Point(365, 117);
            this.dtpngaysinh.Name = "dtpngaysinh";
            this.dtpngaysinh.Size = new System.Drawing.Size(183, 25);
            this.dtpngaysinh.TabIndex = 155;
            // 
            // cbomakh
            // 
            this.cbomakh.FormattingEnabled = true;
            this.cbomakh.Location = new System.Drawing.Point(365, 147);
            this.cbomakh.Name = "cbomakh";
            this.cbomakh.Size = new System.Drawing.Size(183, 25);
            this.cbomakh.TabIndex = 158;
            // 
            // txthosv
            // 
            this.txthosv.Location = new System.Drawing.Point(122, 87);
            this.txthosv.Name = "txthosv";
            this.txthosv.Size = new System.Drawing.Size(321, 25);
            this.txthosv.TabIndex = 151;
            // 
            // txttongdiem
            // 
            this.txttongdiem.Location = new System.Drawing.Point(365, 177);
            this.txttongdiem.Name = "txttongdiem";
            this.txttongdiem.Size = new System.Drawing.Size(183, 25);
            this.txttongdiem.TabIndex = 161;
            // 
            // txthocbong
            // 
            this.txthocbong.Location = new System.Drawing.Point(122, 177);
            this.txthocbong.Name = "txthocbong";
            this.txthocbong.Size = new System.Drawing.Size(155, 25);
            this.txthocbong.TabIndex = 159;
            // 
            // txtnoisinh
            // 
            this.txtnoisinh.Location = new System.Drawing.Point(122, 147);
            this.txtnoisinh.Name = "txtnoisinh";
            this.txtnoisinh.Size = new System.Drawing.Size(155, 25);
            this.txtnoisinh.TabIndex = 156;
            // 
            // txttensv
            // 
            this.txttensv.Location = new System.Drawing.Point(445, 87);
            this.txttensv.Name = "txttensv";
            this.txttensv.Size = new System.Drawing.Size(103, 25);
            this.txttensv.TabIndex = 152;
            // 
            // txtmasv
            // 
            this.txtmasv.Location = new System.Drawing.Point(122, 57);
            this.txtmasv.Name = "txtmasv";
            this.txtmasv.ReadOnly = true;
            this.txtmasv.Size = new System.Drawing.Size(426, 25);
            this.txtmasv.TabIndex = 150;
            // 
            // btnkhong
            // 
            this.btnkhong.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnkhong.Location = new System.Drawing.Point(477, 208);
            this.btnkhong.Name = "btnkhong";
            this.btnkhong.Size = new System.Drawing.Size(72, 34);
            this.btnkhong.TabIndex = 168;
            this.btnkhong.Text = "Không";
            this.btnkhong.UseVisualStyleBackColor = false;
            // 
            // btnghi
            // 
            this.btnghi.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnghi.Location = new System.Drawing.Point(405, 208);
            this.btnghi.Name = "btnghi";
            this.btnghi.Size = new System.Drawing.Size(72, 34);
            this.btnghi.TabIndex = 167;
            this.btnghi.Text = "Ghi";
            this.btnghi.UseVisualStyleBackColor = false;
            // 
            // btnhuy
            // 
            this.btnhuy.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnhuy.Location = new System.Drawing.Point(333, 208);
            this.btnhuy.Name = "btnhuy";
            this.btnhuy.Size = new System.Drawing.Size(72, 34);
            this.btnhuy.TabIndex = 166;
            this.btnhuy.Text = "Huỷ";
            this.btnhuy.UseVisualStyleBackColor = false;
            // 
            // btnsau
            // 
            this.btnsau.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnsau.Location = new System.Drawing.Point(189, 208);
            this.btnsau.Name = "btnsau";
            this.btnsau.Size = new System.Drawing.Size(72, 34);
            this.btnsau.TabIndex = 164;
            this.btnsau.Text = "Sau";
            this.btnsau.UseVisualStyleBackColor = false;
            // 
            // btnthem
            // 
            this.btnthem.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnthem.Location = new System.Drawing.Point(261, 208);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(72, 34);
            this.btnthem.TabIndex = 165;
            this.btnthem.Text = "Thêm";
            this.btnthem.UseVisualStyleBackColor = false;
            // 
            // btntruoc
            // 
            this.btntruoc.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btntruoc.Location = new System.Drawing.Point(45, 208);
            this.btntruoc.Name = "btntruoc";
            this.btntruoc.Size = new System.Drawing.Size(72, 34);
            this.btntruoc.TabIndex = 162;
            this.btntruoc.Text = "Trước";
            this.btntruoc.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(281, 181);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 17);
            this.label7.TabIndex = 160;
            this.label7.Text = "Tổng điểm";
            // 
            // chkphai
            // 
            this.chkphai.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkphai.Location = new System.Drawing.Point(23, 120);
            this.chkphai.Name = "chkphai";
            this.chkphai.Size = new System.Drawing.Size(121, 24);
            this.chkphai.TabIndex = 153;
            this.chkphai.Text = "Phái";
            this.chkphai.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 17);
            this.label6.TabIndex = 149;
            this.label6.Text = "Học bỗng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(316, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 17);
            this.label5.TabIndex = 157;
            this.label5.Text = "Khoa";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 17);
            this.label4.TabIndex = 148;
            this.label4.Text = "Nơi sinh";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(286, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 17);
            this.label3.TabIndex = 154;
            this.label3.Text = "Ngày sinh";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 147;
            this.label2.Text = "Họ tên SV";
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(565, 49);
            this.label8.TabIndex = 145;
            this.label8.Text = "DANH SÁCH SINH VIÊN";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSTT
            // 
            this.lblSTT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSTT.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSTT.Location = new System.Drawing.Point(117, 208);
            this.lblSTT.Name = "lblSTT";
            this.lblSTT.Size = new System.Drawing.Size(72, 34);
            this.lblSTT.TabIndex = 163;
            this.lblSTT.Text = "STT";
            this.lblSTT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 146;
            this.label1.Text = "Mã SV";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 449);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dtpngaysinh);
            this.Controls.Add(this.cbomakh);
            this.Controls.Add(this.txthosv);
            this.Controls.Add(this.txttongdiem);
            this.Controls.Add(this.txthocbong);
            this.Controls.Add(this.txtnoisinh);
            this.Controls.Add(this.txttensv);
            this.Controls.Add(this.txtmasv);
            this.Controls.Add(this.btnkhong);
            this.Controls.Add(this.btnghi);
            this.Controls.Add(this.btnhuy);
            this.Controls.Add(this.btnsau);
            this.Controls.Add(this.btnthem);
            this.Controls.Add(this.btntruoc);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chkphai);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblSTT);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn colTenMH;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaMH;
        private System.Windows.Forms.DataGridViewTextBoxColumn colsotiet;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker dtpngaysinh;
        private System.Windows.Forms.ComboBox cbomakh;
        private System.Windows.Forms.TextBox txthosv;
        private System.Windows.Forms.TextBox txttongdiem;
        private System.Windows.Forms.TextBox txthocbong;
        private System.Windows.Forms.TextBox txtnoisinh;
        private System.Windows.Forms.TextBox txttensv;
        private System.Windows.Forms.TextBox txtmasv;
        private System.Windows.Forms.Button btnkhong;
        private System.Windows.Forms.Button btnghi;
        private System.Windows.Forms.Button btnhuy;
        private System.Windows.Forms.Button btnsau;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.Button btntruoc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkphai;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblSTT;
        private System.Windows.Forms.Label label1;
    }
}

