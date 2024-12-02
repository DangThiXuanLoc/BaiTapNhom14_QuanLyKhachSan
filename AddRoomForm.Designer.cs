namespace WindowsForm
{
    partial class AddRoomForm
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
            this.lvListRoom = new System.Windows.Forms.ListView();
            this.IDPhong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SoPhong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Loai = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TinhTrang = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GiaTien = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ViTri = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SucChuaToiDa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GhiChu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.txtSoPhong = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbLoai = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGiaTien = new System.Windows.Forms.TextBox();
            this.btnAddRoom = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSucChua = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.rdLau2 = new System.Windows.Forms.RadioButton();
            this.rdLau1 = new System.Windows.Forms.RadioButton();
            this.txtTinhTrang = new System.Windows.Forms.TextBox();
            this.txtIDPhong = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvListRoom
            // 
            this.lvListRoom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvListRoom.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lvListRoom.CheckBoxes = true;
            this.lvListRoom.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IDPhong,
            this.SoPhong,
            this.Loai,
            this.TinhTrang,
            this.GiaTien,
            this.ViTri,
            this.SucChuaToiDa,
            this.GhiChu});
            this.lvListRoom.GridLines = true;
            this.lvListRoom.HideSelection = false;
            this.lvListRoom.Location = new System.Drawing.Point(331, 63);
            this.lvListRoom.Name = "lvListRoom";
            this.lvListRoom.Size = new System.Drawing.Size(709, 272);
            this.lvListRoom.TabIndex = 0;
            this.lvListRoom.UseCompatibleStateImageBehavior = false;
            this.lvListRoom.View = System.Windows.Forms.View.Details;
            this.lvListRoom.SelectedIndexChanged += new System.EventHandler(this.lvListRoom_SelectedIndexChanged);
            // 
            // IDPhong
            // 
            this.IDPhong.Text = "IDPhong";
            this.IDPhong.Width = 63;
            // 
            // SoPhong
            // 
            this.SoPhong.Text = "Số phòng";
            this.SoPhong.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SoPhong.Width = 92;
            // 
            // Loai
            // 
            this.Loai.Text = "Loại phòng";
            this.Loai.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Loai.Width = 97;
            // 
            // TinhTrang
            // 
            this.TinhTrang.Text = "Tình trạng";
            this.TinhTrang.Width = 88;
            // 
            // GiaTien
            // 
            this.GiaTien.Text = "Giá tiền";
            this.GiaTien.Width = 86;
            // 
            // ViTri
            // 
            this.ViTri.Text = "Vị trí";
            this.ViTri.Width = 75;
            // 
            // SucChuaToiDa
            // 
            this.SucChuaToiDa.Text = "Sức chứa";
            this.SucChuaToiDa.Width = 67;
            // 
            // GhiChu
            // 
            this.GhiChu.Text = "Ghi chú";
            this.GhiChu.Width = 131;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(231, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Số phòng";
            // 
            // txtSoPhong
            // 
            this.txtSoPhong.Location = new System.Drawing.Point(218, 75);
            this.txtSoPhong.Name = "txtSoPhong";
            this.txtSoPhong.Size = new System.Drawing.Size(81, 20);
            this.txtSoPhong.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(100, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Loại phòng";
            // 
            // cbbLoai
            // 
            this.cbbLoai.FormattingEnabled = true;
            this.cbbLoai.Items.AddRange(new object[] {
            "Phòng đơn",
            "Phòng đôi"});
            this.cbbLoai.Location = new System.Drawing.Point(103, 118);
            this.cbbLoai.Name = "cbbLoai";
            this.cbbLoai.Size = new System.Drawing.Size(196, 21);
            this.cbbLoai.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Giá tiền";
            // 
            // txtGiaTien
            // 
            this.txtGiaTien.Location = new System.Drawing.Point(103, 202);
            this.txtGiaTien.Name = "txtGiaTien";
            this.txtGiaTien.Size = new System.Drawing.Size(109, 20);
            this.txtGiaTien.TabIndex = 6;
            // 
            // btnAddRoom
            // 
            this.btnAddRoom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddRoom.Location = new System.Drawing.Point(221, 350);
            this.btnAddRoom.Name = "btnAddRoom";
            this.btnAddRoom.Size = new System.Drawing.Size(78, 23);
            this.btnAddRoom.TabIndex = 7;
            this.btnAddRoom.Text = "Add Room";
            this.btnAddRoom.UseVisualStyleBackColor = true;
            this.btnAddRoom.Click += new System.EventHandler(this.btnAddRoom_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtGhiChu);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtSucChua);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.rdLau2);
            this.groupBox2.Controls.Add(this.rdLau1);
            this.groupBox2.Controls.Add(this.txtTinhTrang);
            this.groupBox2.Controls.Add(this.txtIDPhong);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.btnThoat);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnAddRoom);
            this.groupBox2.Controls.Add(this.txtSoPhong);
            this.groupBox2.Controls.Add(this.txtGiaTien);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cbbLoai);
            this.groupBox2.Controls.Add(this.lvListRoom);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(43, 24);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(1058, 388);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(103, 303);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(196, 32);
            this.txtGhiChu.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(101, 287);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Ghi chú";
            // 
            // txtSucChua
            // 
            this.txtSucChua.Location = new System.Drawing.Point(103, 264);
            this.txtSucChua.Name = "txtSucChua";
            this.txtSucChua.Size = new System.Drawing.Size(95, 20);
            this.txtSucChua.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(100, 248);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Sức chứa";
            // 
            // rdLau2
            // 
            this.rdLau2.AutoSize = true;
            this.rdLau2.Location = new System.Drawing.Point(218, 229);
            this.rdLau2.Name = "rdLau2";
            this.rdLau2.Size = new System.Drawing.Size(52, 17);
            this.rdLau2.TabIndex = 17;
            this.rdLau2.TabStop = true;
            this.rdLau2.Text = "Lầu 2";
            this.rdLau2.UseVisualStyleBackColor = true;
            // 
            // rdLau1
            // 
            this.rdLau1.AutoSize = true;
            this.rdLau1.Location = new System.Drawing.Point(160, 228);
            this.rdLau1.Name = "rdLau1";
            this.rdLau1.Size = new System.Drawing.Size(52, 17);
            this.rdLau1.TabIndex = 16;
            this.rdLau1.TabStop = true;
            this.rdLau1.Text = "Lầu 1";
            this.rdLau1.UseVisualStyleBackColor = true;
            // 
            // txtTinhTrang
            // 
            this.txtTinhTrang.Location = new System.Drawing.Point(103, 158);
            this.txtTinhTrang.Name = "txtTinhTrang";
            this.txtTinhTrang.Size = new System.Drawing.Size(196, 20);
            this.txtTinhTrang.TabIndex = 15;
            // 
            // txtIDPhong
            // 
            this.txtIDPhong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtIDPhong.Location = new System.Drawing.Point(103, 75);
            this.txtIDPhong.Name = "txtIDPhong";
            this.txtIDPhong.ReadOnly = true;
            this.txtIDPhong.Size = new System.Drawing.Size(71, 20);
            this.txtIDPhong.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(101, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Vị trí";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(100, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Tình trạng";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(119, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "ID";
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Location = new System.Drawing.Point(947, 341);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 9;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(429, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "ADD ROOM";
            // 
            // AddRoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1126, 500);
            this.Controls.Add(this.groupBox2);
            this.Name = "AddRoomForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADD ROOM";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AddRoomForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvListRoom;
        private System.Windows.Forms.ColumnHeader IDPhong;
        private System.Windows.Forms.ColumnHeader SoPhong;
        private System.Windows.Forms.ColumnHeader Loai;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSoPhong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbLoai;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGiaTien;
        private System.Windows.Forms.Button btnAddRoom;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.ColumnHeader TinhTrang;
        private System.Windows.Forms.ColumnHeader GiaTien;
        private System.Windows.Forms.ColumnHeader ViTri;
        private System.Windows.Forms.ColumnHeader SucChuaToiDa;
        private System.Windows.Forms.ColumnHeader GhiChu;
        private System.Windows.Forms.TextBox txtIDPhong;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTinhTrang;
        private System.Windows.Forms.RadioButton rdLau2;
        private System.Windows.Forms.RadioButton rdLau1;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSucChua;
        private System.Windows.Forms.Label label8;
    }
}