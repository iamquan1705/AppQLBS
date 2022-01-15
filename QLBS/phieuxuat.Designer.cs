
namespace QLBS
{
    partial class phieuxuat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(phieuxuat));
            this.label9 = new System.Windows.Forms.Label();
            this.dgvPX = new System.Windows.Forms.DataGridView();
            this.st = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mpx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnTK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCTPX = new System.Windows.Forms.Button();
            this.tbMaPX = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bntThoat = new System.Windows.Forms.Button();
            this.btnSuaPX = new System.Windows.Forms.Button();
            this.btnXoaPX = new System.Windows.Forms.Button();
            this.btnThemPX = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbTenKhachHang = new System.Windows.Forms.TextBox();
            this.tbSDT = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbDiaChi = new System.Windows.Forms.TextBox();
            this.tbThemKhachHang = new System.Windows.Forms.Button();
            this.btCheck = new System.Windows.Forms.Button();
            this.lbThongBao = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.datetimeToday = new System.Windows.Forms.DateTimePicker();
            this.cbNhanVien = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPX)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(472, 0);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(172, 46);
            this.label9.TabIndex = 45;
            this.label9.Text = "Hóa đơn";
            // 
            // dgvPX
            // 
            this.dgvPX.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPX.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.st,
            this.mpx,
            this.nv,
            this.kh,
            this.dt});
            this.dgvPX.Location = new System.Drawing.Point(418, 92);
            this.dgvPX.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvPX.Name = "dgvPX";
            this.dgvPX.RowHeadersWidth = 51;
            this.dgvPX.RowTemplate.Height = 24;
            this.dgvPX.Size = new System.Drawing.Size(513, 452);
            this.dgvPX.TabIndex = 49;
            this.dgvPX.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPX_CellClick);
            this.dgvPX.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvPX_RowPrePaint);
            this.dgvPX.DoubleClick += new System.EventHandler(this.dgvPX_DoubleClick);
            // 
            // st
            // 
            this.st.HeaderText = "STT";
            this.st.MinimumWidth = 6;
            this.st.Name = "st";
            this.st.Width = 125;
            // 
            // mpx
            // 
            this.mpx.DataPropertyName = "maHoaDon";
            this.mpx.HeaderText = "Mã";
            this.mpx.MinimumWidth = 6;
            this.mpx.Name = "mpx";
            this.mpx.Width = 125;
            // 
            // nv
            // 
            this.nv.DataPropertyName = "tenNhanVien";
            this.nv.HeaderText = "Tên NV";
            this.nv.MinimumWidth = 6;
            this.nv.Name = "nv";
            this.nv.Width = 125;
            // 
            // kh
            // 
            this.kh.DataPropertyName = "sdtKhachHang";
            this.kh.HeaderText = "Sđt Khách hàng";
            this.kh.MinimumWidth = 6;
            this.kh.Name = "kh";
            this.kh.Width = 125;
            // 
            // dt
            // 
            this.dt.DataPropertyName = "ngayXuat";
            this.dt.HeaderText = "Ngày xuất";
            this.dt.MinimumWidth = 6;
            this.dt.Name = "dt";
            this.dt.Width = 125;
            // 
            // btnTK
            // 
            this.btnTK.ForeColor = System.Drawing.Color.Blue;
            this.btnTK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTK.Location = new System.Drawing.Point(98, 557);
            this.btnTK.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnTK.Name = "btnTK";
            this.btnTK.Size = new System.Drawing.Size(70, 25);
            this.btnTK.TabIndex = 51;
            this.btnTK.Text = "Tìm kiếm ";
            this.btnTK.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCTPX);
            this.groupBox1.Controls.Add(this.tbMaPX);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.bntThoat);
            this.groupBox1.Controls.Add(this.btnSuaPX);
            this.groupBox1.Controls.Add(this.btnXoaPX);
            this.groupBox1.Controls.Add(this.btnThemPX);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.datetimeToday);
            this.groupBox1.Controls.Add(this.cbNhanVien);
            this.groupBox1.Location = new System.Drawing.Point(47, 92);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(349, 452);
            this.groupBox1.TabIndex = 56;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // btnCTPX
            // 
            this.btnCTPX.ForeColor = System.Drawing.Color.Blue;
            this.btnCTPX.Location = new System.Drawing.Point(77, 403);
            this.btnCTPX.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCTPX.Name = "btnCTPX";
            this.btnCTPX.Size = new System.Drawing.Size(52, 25);
            this.btnCTPX.TabIndex = 67;
            this.btnCTPX.Text = "CTPX";
            this.btnCTPX.UseVisualStyleBackColor = true;
            // 
            // tbMaPX
            // 
            this.tbMaPX.Location = new System.Drawing.Point(156, 24);
            this.tbMaPX.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbMaPX.Name = "tbMaPX";
            this.tbMaPX.ReadOnly = true;
            this.tbMaPX.Size = new System.Drawing.Size(76, 20);
            this.tbMaPX.TabIndex = 66;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 65;
            this.label2.Text = "Mã phiếu xuất";
            // 
            // bntThoat
            // 
            this.bntThoat.ForeColor = System.Drawing.Color.Blue;
            this.bntThoat.Location = new System.Drawing.Point(156, 403);
            this.bntThoat.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bntThoat.Name = "bntThoat";
            this.bntThoat.Size = new System.Drawing.Size(52, 25);
            this.bntThoat.TabIndex = 64;
            this.bntThoat.Text = "Thoát";
            this.bntThoat.UseVisualStyleBackColor = true;
            // 
            // btnSuaPX
            // 
            this.btnSuaPX.ForeColor = System.Drawing.Color.Blue;
            this.btnSuaPX.Image = ((System.Drawing.Image)(resources.GetObject("btnSuaPX.Image")));
            this.btnSuaPX.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSuaPX.Location = new System.Drawing.Point(207, 357);
            this.btnSuaPX.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSuaPX.Name = "btnSuaPX";
            this.btnSuaPX.Size = new System.Drawing.Size(52, 25);
            this.btnSuaPX.TabIndex = 58;
            this.btnSuaPX.Text = "    Sửa";
            this.btnSuaPX.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSuaPX.UseVisualStyleBackColor = true;
            // 
            // btnXoaPX
            // 
            this.btnXoaPX.ForeColor = System.Drawing.Color.Blue;
            this.btnXoaPX.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaPX.Image")));
            this.btnXoaPX.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaPX.Location = new System.Drawing.Point(125, 357);
            this.btnXoaPX.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnXoaPX.Name = "btnXoaPX";
            this.btnXoaPX.Size = new System.Drawing.Size(52, 25);
            this.btnXoaPX.TabIndex = 57;
            this.btnXoaPX.Text = "Xóa";
            this.btnXoaPX.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoaPX.UseVisualStyleBackColor = true;
            // 
            // btnThemPX
            // 
            this.btnThemPX.ForeColor = System.Drawing.Color.Blue;
            this.btnThemPX.Image = ((System.Drawing.Image)(resources.GetObject("btnThemPX.Image")));
            this.btnThemPX.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemPX.Location = new System.Drawing.Point(46, 357);
            this.btnThemPX.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnThemPX.Name = "btnThemPX";
            this.btnThemPX.Size = new System.Drawing.Size(52, 25);
            this.btnThemPX.TabIndex = 56;
            this.btnThemPX.Text = "   Thêm";
            this.btnThemPX.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThemPX.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tbTenKhachHang);
            this.groupBox2.Controls.Add(this.tbSDT);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.tbDiaChi);
            this.groupBox2.Controls.Add(this.tbThemKhachHang);
            this.groupBox2.Controls.Add(this.btCheck);
            this.groupBox2.Controls.Add(this.lbThongBao);
            this.groupBox2.Location = new System.Drawing.Point(42, 151);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(264, 185);
            this.groupBox2.TabIndex = 63;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Khách hàng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 24);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Số điện thoại";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 78);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Tên khách hàng";
            // 
            // tbTenKhachHang
            // 
            this.tbTenKhachHang.Location = new System.Drawing.Point(92, 78);
            this.tbTenKhachHang.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbTenKhachHang.Name = "tbTenKhachHang";
            this.tbTenKhachHang.Size = new System.Drawing.Size(88, 20);
            this.tbTenKhachHang.TabIndex = 29;
            // 
            // tbSDT
            // 
            this.tbSDT.Location = new System.Drawing.Point(92, 22);
            this.tbSDT.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbSDT.Name = "tbSDT";
            this.tbSDT.Size = new System.Drawing.Size(88, 20);
            this.tbSDT.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 110);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Địa chỉ";
            // 
            // tbDiaChi
            // 
            this.tbDiaChi.Location = new System.Drawing.Point(92, 110);
            this.tbDiaChi.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbDiaChi.Name = "tbDiaChi";
            this.tbDiaChi.Size = new System.Drawing.Size(126, 20);
            this.tbDiaChi.TabIndex = 33;
            // 
            // tbThemKhachHang
            // 
            this.tbThemKhachHang.Location = new System.Drawing.Point(92, 141);
            this.tbThemKhachHang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbThemKhachHang.Name = "tbThemKhachHang";
            this.tbThemKhachHang.Size = new System.Drawing.Size(125, 19);
            this.tbThemKhachHang.TabIndex = 40;
            this.tbThemKhachHang.Text = "Thêm khách hàng";
            this.tbThemKhachHang.UseVisualStyleBackColor = true;
            this.tbThemKhachHang.Visible = false;
            // 
            // btCheck
            // 
            this.btCheck.Location = new System.Drawing.Point(197, 20);
            this.btCheck.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btCheck.Name = "btCheck";
            this.btCheck.Size = new System.Drawing.Size(56, 19);
            this.btCheck.TabIndex = 38;
            this.btCheck.Text = "Check";
            this.btCheck.UseVisualStyleBackColor = true;
//            this.btCheck.Click += new System.EventHandler(this.btCheck_Click_1);
            // 
            // lbThongBao
            // 
            this.lbThongBao.AutoSize = true;
            this.lbThongBao.ForeColor = System.Drawing.Color.Red;
            this.lbThongBao.Location = new System.Drawing.Point(30, 43);
            this.lbThongBao.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbThongBao.Name = "lbThongBao";
            this.lbThongBao.Size = new System.Drawing.Size(157, 13);
            this.lbThongBao.TabIndex = 39;
            this.lbThongBao.Text = "_________________________";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(50, 98);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 13);
            this.label12.TabIndex = 62;
            this.label12.Text = "Ngày Xuất";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 61);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 61;
            this.label1.Text = "NViên";
            // 
            // datetimeToday
            // 
            this.datetimeToday.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datetimeToday.Location = new System.Drawing.Point(156, 98);
            this.datetimeToday.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.datetimeToday.Name = "datetimeToday";
            this.datetimeToday.Size = new System.Drawing.Size(151, 20);
            this.datetimeToday.TabIndex = 60;
            // 
            // cbNhanVien
            // 
            this.cbNhanVien.FormattingEnabled = true;
            this.cbNhanVien.Location = new System.Drawing.Point(156, 61);
            this.cbNhanVien.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbNhanVien.Name = "cbNhanVien";
            this.cbNhanVien.Size = new System.Drawing.Size(92, 21);
            this.cbNhanVien.TabIndex = 59;
            // 
            // phieuxuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QLBS.Properties.Resources.sach;
            this.ClientSize = new System.Drawing.Size(1028, 609);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnTK);
            this.Controls.Add(this.dgvPX);
            this.Controls.Add(this.label9);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "phieuxuat";
            this.Text = "phieuxuat";
            this.Load += new System.EventHandler(this.phieuxuat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPX)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgvPX;
        private System.Windows.Forms.DataGridViewTextBoxColumn st;
        private System.Windows.Forms.DataGridViewTextBoxColumn mpx;
        private System.Windows.Forms.DataGridViewTextBoxColumn nv;
        private System.Windows.Forms.DataGridViewTextBoxColumn kh;
        private System.Windows.Forms.DataGridViewTextBoxColumn dt;
        private System.Windows.Forms.Button btnTK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCTPX;
        private System.Windows.Forms.TextBox tbMaPX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bntThoat;
        private System.Windows.Forms.Button btnSuaPX;
        private System.Windows.Forms.Button btnXoaPX;
        private System.Windows.Forms.Button btnThemPX;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbTenKhachHang;
        private System.Windows.Forms.TextBox tbSDT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbDiaChi;
        private System.Windows.Forms.Button tbThemKhachHang;
        private System.Windows.Forms.Button btCheck;
        private System.Windows.Forms.Label lbThongBao;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker datetimeToday;
        private System.Windows.Forms.ComboBox cbNhanVien;
    }
}