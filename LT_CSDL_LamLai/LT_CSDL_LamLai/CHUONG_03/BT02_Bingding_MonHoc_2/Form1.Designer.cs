namespace BT02_Bingding_MonHoc_2
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtloaimh = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txttenmh
            // 
            this.txttenmh.Location = new System.Drawing.Point(148, 67);
            this.txttenmh.Margin = new System.Windows.Forms.Padding(2);
            this.txttenmh.Name = "txttenmh";
            this.txttenmh.Size = new System.Drawing.Size(320, 20);
            this.txttenmh.TabIndex = 101;
            // 
            // txtsotiet
            // 
            this.txtsotiet.Location = new System.Drawing.Point(148, 94);
            this.txtsotiet.Margin = new System.Windows.Forms.Padding(2);
            this.txtsotiet.Name = "txtsotiet";
            this.txtsotiet.Size = new System.Drawing.Size(320, 20);
            this.txtsotiet.TabIndex = 102;
            // 
            // txtmamh
            // 
            this.txtmamh.Location = new System.Drawing.Point(148, 42);
            this.txtmamh.Margin = new System.Windows.Forms.Padding(2);
            this.txtmamh.Name = "txtmamh";
            this.txtmamh.ReadOnly = true;
            this.txtmamh.Size = new System.Drawing.Size(320, 20);
            this.txtmamh.TabIndex = 100;
            // 
            // btnkhong
            // 
            this.btnkhong.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnkhong.Location = new System.Drawing.Point(421, 199);
            this.btnkhong.Margin = new System.Windows.Forms.Padding(2);
            this.btnkhong.Name = "btnkhong";
            this.btnkhong.Size = new System.Drawing.Size(54, 28);
            this.btnkhong.TabIndex = 111;
            this.btnkhong.Text = "Không";
            this.btnkhong.UseVisualStyleBackColor = false;
            // 
            // btnghi
            // 
            this.btnghi.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnghi.Location = new System.Drawing.Point(324, 199);
            this.btnghi.Margin = new System.Windows.Forms.Padding(2);
            this.btnghi.Name = "btnghi";
            this.btnghi.Size = new System.Drawing.Size(54, 28);
            this.btnghi.TabIndex = 110;
            this.btnghi.Text = "Ghi";
            this.btnghi.UseVisualStyleBackColor = false;
            // 
            // btnhuy
            // 
            this.btnhuy.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnhuy.Location = new System.Drawing.Point(227, 199);
            this.btnhuy.Margin = new System.Windows.Forms.Padding(2);
            this.btnhuy.Name = "btnhuy";
            this.btnhuy.Size = new System.Drawing.Size(54, 28);
            this.btnhuy.TabIndex = 109;
            this.btnhuy.Text = "Huỷ";
            this.btnhuy.UseVisualStyleBackColor = false;
            // 
            // btncuoi
            // 
            this.btncuoi.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btncuoi.Location = new System.Drawing.Point(421, 159);
            this.btncuoi.Margin = new System.Windows.Forms.Padding(2);
            this.btncuoi.Name = "btncuoi";
            this.btncuoi.Size = new System.Drawing.Size(54, 28);
            this.btncuoi.TabIndex = 106;
            this.btncuoi.Text = "Cuối";
            this.btncuoi.UseVisualStyleBackColor = false;
            this.btncuoi.Click += new System.EventHandler(this.btncuoi_Click);
            // 
            // btnsau
            // 
            this.btnsau.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnsau.Location = new System.Drawing.Point(324, 159);
            this.btnsau.Margin = new System.Windows.Forms.Padding(2);
            this.btnsau.Name = "btnsau";
            this.btnsau.Size = new System.Drawing.Size(54, 28);
            this.btnsau.TabIndex = 107;
            this.btnsau.Text = "Sau";
            this.btnsau.UseVisualStyleBackColor = false;
            this.btnsau.Click += new System.EventHandler(this.btnsau_Click);
            // 
            // btndau
            // 
            this.btndau.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btndau.Location = new System.Drawing.Point(131, 159);
            this.btndau.Margin = new System.Windows.Forms.Padding(2);
            this.btndau.Name = "btndau";
            this.btndau.Size = new System.Drawing.Size(54, 28);
            this.btndau.TabIndex = 103;
            this.btndau.Text = "Đầu";
            this.btndau.UseVisualStyleBackColor = false;
            this.btndau.Click += new System.EventHandler(this.btndau_Click);
            // 
            // btnthem
            // 
            this.btnthem.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnthem.Location = new System.Drawing.Point(131, 199);
            this.btnthem.Margin = new System.Windows.Forms.Padding(2);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(54, 28);
            this.btnthem.TabIndex = 108;
            this.btnthem.Text = "Thêm";
            this.btnthem.UseVisualStyleBackColor = false;
            // 
            // btntruoc
            // 
            this.btntruoc.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btntruoc.Location = new System.Drawing.Point(216, 159);
            this.btntruoc.Margin = new System.Windows.Forms.Padding(2);
            this.btntruoc.Name = "btntruoc";
            this.btntruoc.Size = new System.Drawing.Size(54, 28);
            this.btntruoc.TabIndex = 104;
            this.btntruoc.Text = "Trước";
            this.btntruoc.UseVisualStyleBackColor = false;
            this.btntruoc.Click += new System.EventHandler(this.btntruoc_Click);
            // 
            // lblsotiet
            // 
            this.lblsotiet.AutoSize = true;
            this.lblsotiet.Location = new System.Drawing.Point(74, 100);
            this.lblsotiet.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblsotiet.Name = "lblsotiet";
            this.lblsotiet.Size = new System.Drawing.Size(41, 13);
            this.lblsotiet.TabIndex = 99;
            this.lblsotiet.Text = "Số Tiết";
            // 
            // tenmh
            // 
            this.tenmh.AutoSize = true;
            this.tenmh.Location = new System.Drawing.Point(74, 72);
            this.tenmh.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.tenmh.Name = "tenmh";
            this.tenmh.Size = new System.Drawing.Size(46, 13);
            this.tenmh.TabIndex = 98;
            this.tenmh.Text = "Tên MH";
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(562, 40);
            this.label8.TabIndex = 96;
            this.label8.Text = "DANH SÁCH SINH VIÊN";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSTT
            // 
            this.lblSTT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSTT.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSTT.Location = new System.Drawing.Point(270, 159);
            this.lblSTT.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSTT.Name = "lblSTT";
            this.lblSTT.Size = new System.Drawing.Size(54, 28);
            this.lblSTT.TabIndex = 105;
            this.lblSTT.Text = "STT";
            this.lblSTT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblmamh
            // 
            this.lblmamh.AutoSize = true;
            this.lblmamh.Location = new System.Drawing.Point(74, 48);
            this.lblmamh.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblmamh.Name = "lblmamh";
            this.lblmamh.Size = new System.Drawing.Size(42, 13);
            this.lblmamh.TabIndex = 97;
            this.lblmamh.Text = "Mã MH";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 124);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 99;
            this.label1.Text = "Loại môn";
            // 
            // txtloaimh
            // 
            this.txtloaimh.Location = new System.Drawing.Point(148, 118);
            this.txtloaimh.Margin = new System.Windows.Forms.Padding(2);
            this.txtloaimh.Name = "txtloaimh";
            this.txtloaimh.Size = new System.Drawing.Size(320, 20);
            this.txtloaimh.TabIndex = 102;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 234);
            this.Controls.Add(this.txttenmh);
            this.Controls.Add(this.txtloaimh);
            this.Controls.Add(this.txtsotiet);
            this.Controls.Add(this.txtmamh);
            this.Controls.Add(this.btnkhong);
            this.Controls.Add(this.btnghi);
            this.Controls.Add(this.btnhuy);
            this.Controls.Add(this.btncuoi);
            this.Controls.Add(this.btnsau);
            this.Controls.Add(this.btndau);
            this.Controls.Add(this.btnthem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btntruoc);
            this.Controls.Add(this.lblsotiet);
            this.Controls.Add(this.tenmh);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblSTT);
            this.Controls.Add(this.lblmamh);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtloaimh;
    }
}

