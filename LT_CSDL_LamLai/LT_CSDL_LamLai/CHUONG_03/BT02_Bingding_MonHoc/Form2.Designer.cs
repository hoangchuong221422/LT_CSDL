namespace BT02_Bingding_MonHoc
{
    partial class Form2
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
            this.txttenmh = new System.Windows.Forms.TextBox();
            this.txtsotiet = new System.Windows.Forms.TextBox();
            this.txtmamh = new System.Windows.Forms.TextBox();
            this.btnkhong = new System.Windows.Forms.Button();
            this.btnghi = new System.Windows.Forms.Button();
            this.btnhuy = new System.Windows.Forms.Button();
            this.btncuoi = new System.Windows.Forms.Button();
            this.btnsau = new System.Windows.Forms.Button();
            this.btndau = new System.Windows.Forms.Button();
            this.btnthem = new System.Windows.Forms.Button();
            this.btntruoc = new System.Windows.Forms.Button();
            this.lblsotiet = new System.Windows.Forms.Label();
            this.tenmh = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblSTT = new System.Windows.Forms.Label();
            this.lblmamh = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txttenmh
            // 
            this.txttenmh.Location = new System.Drawing.Point(112, 92);
            this.txttenmh.Name = "txttenmh";
            this.txttenmh.Size = new System.Drawing.Size(426, 28);
            this.txttenmh.TabIndex = 101;
            // 
            // txtsotiet
            // 
            this.txtsotiet.Location = new System.Drawing.Point(112, 126);
            this.txtsotiet.Name = "txtsotiet";
            this.txtsotiet.Size = new System.Drawing.Size(426, 28);
            this.txtsotiet.TabIndex = 102;
            // 
            // txtmamh
            // 
            this.txtmamh.Location = new System.Drawing.Point(112, 62);
            this.txtmamh.Name = "txtmamh";
            this.txtmamh.ReadOnly = true;
            this.txtmamh.Size = new System.Drawing.Size(426, 28);
            this.txtmamh.TabIndex = 100;
            // 
            // btnkhong
            // 
            this.btnkhong.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnkhong.Location = new System.Drawing.Point(485, 231);
            this.btnkhong.Name = "btnkhong";
            this.btnkhong.Size = new System.Drawing.Size(72, 34);
            this.btnkhong.TabIndex = 111;
            this.btnkhong.Text = "Không";
            this.btnkhong.UseVisualStyleBackColor = false;
            // 
            // btnghi
            // 
            this.btnghi.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnghi.Location = new System.Drawing.Point(348, 231);
            this.btnghi.Name = "btnghi";
            this.btnghi.Size = new System.Drawing.Size(72, 34);
            this.btnghi.TabIndex = 110;
            this.btnghi.Text = "Ghi";
            this.btnghi.UseVisualStyleBackColor = false;
            // 
            // btnhuy
            // 
            this.btnhuy.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnhuy.Location = new System.Drawing.Point(211, 231);
            this.btnhuy.Name = "btnhuy";
            this.btnhuy.Size = new System.Drawing.Size(72, 34);
            this.btnhuy.TabIndex = 109;
            this.btnhuy.Text = "Huỷ";
            this.btnhuy.UseVisualStyleBackColor = false;
            // 
            // btncuoi
            // 
            this.btncuoi.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btncuoi.Location = new System.Drawing.Point(475, 175);
            this.btncuoi.Name = "btncuoi";
            this.btncuoi.Size = new System.Drawing.Size(72, 34);
            this.btncuoi.TabIndex = 106;
            this.btncuoi.Text = "Cuối";
            this.btncuoi.UseVisualStyleBackColor = false;
            this.btncuoi.Click += new System.EventHandler(this.btncuoi_Click);
            // 
            // btnsau
            // 
            this.btnsau.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnsau.Location = new System.Drawing.Point(346, 175);
            this.btnsau.Name = "btnsau";
            this.btnsau.Size = new System.Drawing.Size(72, 34);
            this.btnsau.TabIndex = 107;
            this.btnsau.Text = "Sau";
            this.btnsau.UseVisualStyleBackColor = false;
            this.btnsau.Click += new System.EventHandler(this.btnsau_Click);
            // 
            // btndau
            // 
            this.btndau.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btndau.Location = new System.Drawing.Point(88, 175);
            this.btndau.Name = "btndau";
            this.btndau.Size = new System.Drawing.Size(72, 34);
            this.btndau.TabIndex = 103;
            this.btndau.Text = "Đầu";
            this.btndau.UseVisualStyleBackColor = false;
            this.btndau.Click += new System.EventHandler(this.btndau_Click);
            // 
            // btnthem
            // 
            this.btnthem.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnthem.Location = new System.Drawing.Point(74, 231);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(72, 34);
            this.btnthem.TabIndex = 108;
            this.btnthem.Text = "Thêm";
            this.btnthem.UseVisualStyleBackColor = false;
            // 
            // btntruoc
            // 
            this.btntruoc.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btntruoc.Location = new System.Drawing.Point(202, 175);
            this.btntruoc.Name = "btntruoc";
            this.btntruoc.Size = new System.Drawing.Size(72, 34);
            this.btntruoc.TabIndex = 104;
            this.btntruoc.Text = "Trước";
            this.btntruoc.UseVisualStyleBackColor = false;
            this.btntruoc.Click += new System.EventHandler(this.btntruoc_Click);
            // 
            // lblsotiet
            // 
            this.lblsotiet.AutoSize = true;
            this.lblsotiet.Location = new System.Drawing.Point(13, 133);
            this.lblsotiet.Name = "lblsotiet";
            this.lblsotiet.Size = new System.Drawing.Size(67, 21);
            this.lblsotiet.TabIndex = 99;
            this.lblsotiet.Text = "Số Tiết";
            // 
            // tenmh
            // 
            this.tenmh.AutoSize = true;
            this.tenmh.Location = new System.Drawing.Point(13, 99);
            this.tenmh.Name = "tenmh";
            this.tenmh.Size = new System.Drawing.Size(75, 21);
            this.tenmh.TabIndex = 98;
            this.tenmh.Text = "Tên MH";
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(602, 49);
            this.label8.TabIndex = 96;
            this.label8.Text = "DANH SÁCH SINH VIÊN";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSTT
            // 
            this.lblSTT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSTT.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSTT.Location = new System.Drawing.Point(274, 175);
            this.lblSTT.Name = "lblSTT";
            this.lblSTT.Size = new System.Drawing.Size(72, 34);
            this.lblSTT.TabIndex = 105;
            this.lblSTT.Text = "STT";
            this.lblSTT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblmamh
            // 
            this.lblmamh.AutoSize = true;
            this.lblmamh.Location = new System.Drawing.Point(13, 69);
            this.lblmamh.Name = "lblmamh";
            this.lblmamh.Size = new System.Drawing.Size(68, 21);
            this.lblmamh.TabIndex = 97;
            this.lblmamh.Text = "Mã MH";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 279);
            this.Controls.Add(this.txttenmh);
            this.Controls.Add(this.txtsotiet);
            this.Controls.Add(this.txtmamh);
            this.Controls.Add(this.btnkhong);
            this.Controls.Add(this.btnghi);
            this.Controls.Add(this.btnhuy);
            this.Controls.Add(this.btncuoi);
            this.Controls.Add(this.btnsau);
            this.Controls.Add(this.btndau);
            this.Controls.Add(this.btnthem);
            this.Controls.Add(this.btntruoc);
            this.Controls.Add(this.lblsotiet);
            this.Controls.Add(this.tenmh);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblSTT);
            this.Controls.Add(this.lblmamh);
            this.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txttenmh;
        private System.Windows.Forms.TextBox txtsotiet;
        private System.Windows.Forms.TextBox txtmamh;
        private System.Windows.Forms.Button btnkhong;
        private System.Windows.Forms.Button btnghi;
        private System.Windows.Forms.Button btnhuy;
        private System.Windows.Forms.Button btncuoi;
        private System.Windows.Forms.Button btnsau;
        private System.Windows.Forms.Button btndau;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.Button btntruoc;
        private System.Windows.Forms.Label lblsotiet;
        private System.Windows.Forms.Label tenmh;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblSTT;
        private System.Windows.Forms.Label lblmamh;
    }
}