
namespace Luoi_DataGridview_03
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
            this.dgvMH = new System.Windows.Forms.DataGridView();
            this.btnkhong = new System.Windows.Forms.Button();
            this.btnghi = new System.Windows.Forms.Button();
            this.btnhuy = new System.Windows.Forms.Button();
            this.btnthem = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtsotiet = new System.Windows.Forms.TextBox();
            this.txttenmh = new System.Windows.Forms.TextBox();
            this.txtmamh = new System.Windows.Forms.TextBox();
            this.colMaMH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenMH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoTiet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMH)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMH
            // 
            this.dgvMH.AllowUserToAddRows = false;
            this.dgvMH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMH.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaMH,
            this.colTenMH,
            this.colSoTiet});
            this.dgvMH.Location = new System.Drawing.Point(12, 12);
            this.dgvMH.MultiSelect = false;
            this.dgvMH.Name = "dgvMH";
            this.dgvMH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMH.Size = new System.Drawing.Size(418, 189);
            this.dgvMH.TabIndex = 4;
            this.dgvMH.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMH_CellClick);
            // 
            // btnkhong
            // 
            this.btnkhong.Location = new System.Drawing.Point(313, 322);
            this.btnkhong.Name = "btnkhong";
            this.btnkhong.Size = new System.Drawing.Size(60, 31);
            this.btnkhong.TabIndex = 11;
            this.btnkhong.Text = "Không";
            this.btnkhong.UseVisualStyleBackColor = true;
            // 
            // btnghi
            // 
            this.btnghi.Location = new System.Drawing.Point(222, 322);
            this.btnghi.Name = "btnghi";
            this.btnghi.Size = new System.Drawing.Size(60, 31);
            this.btnghi.TabIndex = 12;
            this.btnghi.Text = "Ghi";
            this.btnghi.UseVisualStyleBackColor = true;
            // 
            // btnhuy
            // 
            this.btnhuy.Location = new System.Drawing.Point(131, 322);
            this.btnhuy.Name = "btnhuy";
            this.btnhuy.Size = new System.Drawing.Size(60, 31);
            this.btnhuy.TabIndex = 13;
            this.btnhuy.Text = "Hủy";
            this.btnhuy.UseVisualStyleBackColor = true;
            // 
            // btnthem
            // 
            this.btnthem.Location = new System.Drawing.Point(38, 322);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(60, 31);
            this.btnthem.TabIndex = 14;
            this.btnthem.Text = "Thêm";
            this.btnthem.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 277);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Số tiết";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 243);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Tên môn";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Mã môn";
            // 
            // txtsotiet
            // 
            this.txtsotiet.Location = new System.Drawing.Point(95, 274);
            this.txtsotiet.Name = "txtsotiet";
            this.txtsotiet.Size = new System.Drawing.Size(313, 25);
            this.txtsotiet.TabIndex = 5;
            // 
            // txttenmh
            // 
            this.txttenmh.Location = new System.Drawing.Point(95, 243);
            this.txttenmh.Name = "txttenmh";
            this.txttenmh.Size = new System.Drawing.Size(313, 25);
            this.txttenmh.TabIndex = 6;
            // 
            // txtmamh
            // 
            this.txtmamh.Location = new System.Drawing.Point(95, 212);
            this.txtmamh.Name = "txtmamh";
            this.txtmamh.Size = new System.Drawing.Size(313, 25);
            this.txtmamh.TabIndex = 7;
            // 
            // colMaMH
            // 
            this.colMaMH.DataPropertyName = "MaMH";
            this.colMaMH.HeaderText = "Mã môn học";
            this.colMaMH.Name = "colMaMH";
            this.colMaMH.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colMaMH.Width = 125;
            // 
            // colTenMH
            // 
            this.colTenMH.DataPropertyName = "TenMH";
            this.colTenMH.HeaderText = "Tên môn học";
            this.colTenMH.Name = "colTenMH";
            this.colTenMH.Width = 125;
            // 
            // colSoTiet
            // 
            this.colSoTiet.DataPropertyName = "SoTiet";
            this.colSoTiet.HeaderText = "Số tiết";
            this.colSoTiet.Name = "colSoTiet";
            this.colSoTiet.Width = 125;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 379);
            this.Controls.Add(this.dgvMH);
            this.Controls.Add(this.btnkhong);
            this.Controls.Add(this.btnghi);
            this.Controls.Add(this.btnhuy);
            this.Controls.Add(this.btnthem);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtsotiet);
            this.Controls.Add(this.txttenmh);
            this.Controls.Add(this.txtmamh);
            this.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMH;
        private System.Windows.Forms.Button btnkhong;
        private System.Windows.Forms.Button btnghi;
        private System.Windows.Forms.Button btnhuy;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtsotiet;
        private System.Windows.Forms.TextBox txttenmh;
        private System.Windows.Forms.TextBox txtmamh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaMH;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenMH;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoTiet;
    }
}

