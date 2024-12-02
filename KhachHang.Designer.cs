namespace WindowsForm
{
    partial class KhachHang
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
            this.grbKhachHang = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIDKH = new System.Windows.Forms.TextBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnMacDinh = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.dtpNgayRa = new System.Windows.Forms.DateTimePicker();
            this.lblNgayRa = new System.Windows.Forms.Label();
            this.dtpNgayVao = new System.Windows.Forms.DateTimePicker();
            this.lblNgayVao = new System.Windows.Forms.Label();
            this.mktbSoDT = new System.Windows.Forms.MaskedTextBox();
            this.lblSoDT = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtSoCCCD = new System.Windows.Forms.TextBox();
            this.lblSoCCCD = new System.Windows.Forms.Label();
            this.dgvKhachHang = new System.Windows.Forms.DataGridView();
            this.IDKhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoCCCD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbKhachHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).BeginInit();
            this.SuspendLayout();
            // 
            // grbKhachHang
            // 
            this.grbKhachHang.Controls.Add(this.label1);
            this.grbKhachHang.Controls.Add(this.txtIDKH);
            this.grbKhachHang.Controls.Add(this.btnThoat);
            this.grbKhachHang.Controls.Add(this.btnXoa);
            this.grbKhachHang.Controls.Add(this.btnMacDinh);
            this.grbKhachHang.Controls.Add(this.btnLuu);
            this.grbKhachHang.Controls.Add(this.dtpNgayRa);
            this.grbKhachHang.Controls.Add(this.lblNgayRa);
            this.grbKhachHang.Controls.Add(this.dtpNgayVao);
            this.grbKhachHang.Controls.Add(this.lblNgayVao);
            this.grbKhachHang.Controls.Add(this.mktbSoDT);
            this.grbKhachHang.Controls.Add(this.lblSoDT);
            this.grbKhachHang.Controls.Add(this.txtDiaChi);
            this.grbKhachHang.Controls.Add(this.lblDiaChi);
            this.grbKhachHang.Controls.Add(this.txtHoTen);
            this.grbKhachHang.Controls.Add(this.lblHoTen);
            this.grbKhachHang.Controls.Add(this.txtSoCCCD);
            this.grbKhachHang.Controls.Add(this.lblSoCCCD);
            this.grbKhachHang.Controls.Add(this.dgvKhachHang);
            this.grbKhachHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbKhachHang.Location = new System.Drawing.Point(0, 0);
            this.grbKhachHang.Name = "grbKhachHang";
            this.grbKhachHang.Size = new System.Drawing.Size(908, 470);
            this.grbKhachHang.TabIndex = 0;
            this.grbKhachHang.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(145, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "ID KHách hàng";
            // 
            // txtIDKH
            // 
            this.txtIDKH.Location = new System.Drawing.Point(262, 21);
            this.txtIDKH.Multiline = true;
            this.txtIDKH.Name = "txtIDKH";
            this.txtIDKH.ReadOnly = true;
            this.txtIDKH.Size = new System.Drawing.Size(128, 20);
            this.txtIDKH.TabIndex = 17;
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btnThoat.Location = new System.Drawing.Point(827, 426);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 16;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btnXoa.Location = new System.Drawing.Point(494, 191);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 15;
            this.btnXoa.Text = "Xoá";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnMacDinh
            // 
            this.btnMacDinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btnMacDinh.Location = new System.Drawing.Point(356, 191);
            this.btnMacDinh.Name = "btnMacDinh";
            this.btnMacDinh.Size = new System.Drawing.Size(75, 23);
            this.btnMacDinh.TabIndex = 14;
            this.btnMacDinh.Text = "Mặc định";
            this.btnMacDinh.UseVisualStyleBackColor = false;
            this.btnMacDinh.Click += new System.EventHandler(this.btnMacDinh_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btnLuu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLuu.Location = new System.Drawing.Point(214, 191);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 13;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // dtpNgayRa
            // 
            this.dtpNgayRa.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayRa.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayRa.Location = new System.Drawing.Point(582, 139);
            this.dtpNgayRa.Name = "dtpNgayRa";
            this.dtpNgayRa.Size = new System.Drawing.Size(176, 20);
            this.dtpNgayRa.TabIndex = 12;
            // 
            // lblNgayRa
            // 
            this.lblNgayRa.AutoSize = true;
            this.lblNgayRa.Location = new System.Drawing.Point(512, 139);
            this.lblNgayRa.Name = "lblNgayRa";
            this.lblNgayRa.Size = new System.Drawing.Size(47, 13);
            this.lblNgayRa.TabIndex = 11;
            this.lblNgayRa.Text = "Ngày ra:";
            // 
            // dtpNgayVao
            // 
            this.dtpNgayVao.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayVao.Enabled = false;
            this.dtpNgayVao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayVao.Location = new System.Drawing.Point(262, 139);
            this.dtpNgayVao.Name = "dtpNgayVao";
            this.dtpNgayVao.Size = new System.Drawing.Size(187, 20);
            this.dtpNgayVao.TabIndex = 10;
            // 
            // lblNgayVao
            // 
            this.lblNgayVao.AutoSize = true;
            this.lblNgayVao.Location = new System.Drawing.Point(145, 146);
            this.lblNgayVao.Name = "lblNgayVao";
            this.lblNgayVao.Size = new System.Drawing.Size(56, 13);
            this.lblNgayVao.TabIndex = 9;
            this.lblNgayVao.Text = "Ngày vào:";
            // 
            // mktbSoDT
            // 
            this.mktbSoDT.Location = new System.Drawing.Point(611, 60);
            this.mktbSoDT.Mask = "0000.000.000";
            this.mktbSoDT.Name = "mktbSoDT";
            this.mktbSoDT.Size = new System.Drawing.Size(147, 20);
            this.mktbSoDT.TabIndex = 8;
            // 
            // lblSoDT
            // 
            this.lblSoDT.AutoSize = true;
            this.lblSoDT.Location = new System.Drawing.Point(507, 63);
            this.lblSoDT.Name = "lblSoDT";
            this.lblSoDT.Size = new System.Drawing.Size(73, 13);
            this.lblSoDT.TabIndex = 7;
            this.lblSoDT.Text = "Số điện thoại:";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(262, 95);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(496, 20);
            this.txtDiaChi.TabIndex = 6;
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Location = new System.Drawing.Point(145, 102);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(43, 13);
            this.lblDiaChi.TabIndex = 5;
            this.lblDiaChi.Text = "Địa chỉ:";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(262, 60);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(208, 20);
            this.txtHoTen.TabIndex = 4;
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(145, 63);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(42, 13);
            this.lblHoTen.TabIndex = 3;
            this.lblHoTen.Text = "Họ tên:";
            // 
            // txtSoCCCD
            // 
            this.txtSoCCCD.Location = new System.Drawing.Point(611, 24);
            this.txtSoCCCD.Name = "txtSoCCCD";
            this.txtSoCCCD.Size = new System.Drawing.Size(147, 20);
            this.txtSoCCCD.TabIndex = 2;
            // 
            // lblSoCCCD
            // 
            this.lblSoCCCD.AutoSize = true;
            this.lblSoCCCD.Location = new System.Drawing.Point(507, 28);
            this.lblSoCCCD.Name = "lblSoCCCD";
            this.lblSoCCCD.Size = new System.Drawing.Size(52, 13);
            this.lblSoCCCD.TabIndex = 1;
            this.lblSoCCCD.Text = "SốCCCD:";
            // 
            // dgvKhachHang
            // 
            this.dgvKhachHang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKhachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhachHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDKhachHang,
            this.SoCCCD,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dgvKhachHang.Location = new System.Drawing.Point(6, 230);
            this.dgvKhachHang.MultiSelect = false;
            this.dgvKhachHang.Name = "dgvKhachHang";
            this.dgvKhachHang.RowHeadersWidth = 51;
            this.dgvKhachHang.Size = new System.Drawing.Size(896, 179);
            this.dgvKhachHang.TabIndex = 0;
            this.dgvKhachHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKhachHang_CellClick);
            // 
            // IDKhachHang
            // 
            this.IDKhachHang.DataPropertyName = "IDKhachHang";
            this.IDKhachHang.HeaderText = "ID Khách hàng";
            this.IDKhachHang.MinimumWidth = 6;
            this.IDKhachHang.Name = "IDKhachHang";
            // 
            // SoCCCD
            // 
            this.SoCCCD.DataPropertyName = "SoCCCD";
            this.SoCCCD.HeaderText = "Số CCCD";
            this.SoCCCD.Name = "SoCCCD";
            this.SoCCCD.Width = 120;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "HoTenKH";
            this.Column2.HeaderText = "Họ tên";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "DiaChiKH";
            this.Column3.HeaderText = "Địa chỉ";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 170;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "SoDT";
            this.Column4.HeaderText = "Số điện thoại";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "NgayVao";
            this.Column5.HeaderText = "Ngày vào";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 120;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "NgayRa";
            this.Column6.HeaderText = "Ngày ra";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Width = 120;
            // 
            // KhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 470);
            this.Controls.Add(this.grbKhachHang);
            this.Name = "KhachHang";
            this.Text = "Khách Hàng";
            this.Load += new System.EventHandler(this.KhachHang_Load);
            this.grbKhachHang.ResumeLayout(false);
            this.grbKhachHang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbKhachHang;
        private System.Windows.Forms.DataGridView dgvKhachHang;
        private System.Windows.Forms.DateTimePicker dtpNgayRa;
        private System.Windows.Forms.Label lblNgayRa;
        private System.Windows.Forms.DateTimePicker dtpNgayVao;
        private System.Windows.Forms.Label lblNgayVao;
        private System.Windows.Forms.MaskedTextBox mktbSoDT;
        private System.Windows.Forms.Label lblSoDT;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtSoCCCD;
        private System.Windows.Forms.Label lblSoCCCD;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnMacDinh;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIDKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDKhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoCCCD;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}