namespace WindowsForm
{
    partial class QuenMatKhau
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuenMatKhau));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblEmailDK = new System.Windows.Forms.Label();
            this.txtEmailDK = new System.Windows.Forms.TextBox();
            this.lblKQ = new System.Windows.Forms.Label();
            this.txtKQ = new System.Windows.Forms.TextBox();
            this.btnLayMK = new System.Windows.Forms.Button();
            this.bntThoat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(192, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(448, 150);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // lblEmailDK
            // 
            this.lblEmailDK.AutoSize = true;
            this.lblEmailDK.Location = new System.Drawing.Point(133, 227);
            this.lblEmailDK.Name = "lblEmailDK";
            this.lblEmailDK.Size = new System.Drawing.Size(92, 16);
            this.lblEmailDK.TabIndex = 14;
            this.lblEmailDK.Text = "Email đăng ký";
            // 
            // txtEmailDK
            // 
            this.txtEmailDK.Location = new System.Drawing.Point(274, 227);
            this.txtEmailDK.Name = "txtEmailDK";
            this.txtEmailDK.Size = new System.Drawing.Size(327, 22);
            this.txtEmailDK.TabIndex = 15;
            this.txtEmailDK.TextChanged += new System.EventHandler(this.txtEmailDK_TextChanged);
            // 
            // lblKQ
            // 
            this.lblKQ.AutoSize = true;
            this.lblKQ.Location = new System.Drawing.Point(123, 303);
            this.lblKQ.Name = "lblKQ";
            this.lblKQ.Size = new System.Drawing.Size(52, 16);
            this.lblKQ.TabIndex = 16;
            this.lblKQ.Text = "Kết quả";
            // 
            // txtKQ
            // 
            this.txtKQ.Location = new System.Drawing.Point(274, 297);
            this.txtKQ.Name = "txtKQ";
            this.txtKQ.Size = new System.Drawing.Size(327, 22);
            this.txtKQ.TabIndex = 17;
            // 
            // btnLayMK
            // 
            this.btnLayMK.BackColor = System.Drawing.SystemColors.Info;
            this.btnLayMK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnLayMK.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnLayMK.Location = new System.Drawing.Point(238, 367);
            this.btnLayMK.Name = "btnLayMK";
            this.btnLayMK.Size = new System.Drawing.Size(184, 42);
            this.btnLayMK.TabIndex = 18;
            this.btnLayMK.Text = "Lấy lại mật khẩu";
            this.btnLayMK.UseVisualStyleBackColor = false;
            this.btnLayMK.Click += new System.EventHandler(this.btnLayMK_Click);
            // 
            // bntThoat
            // 
            this.bntThoat.BackColor = System.Drawing.SystemColors.Info;
            this.bntThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.bntThoat.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.bntThoat.Location = new System.Drawing.Point(528, 367);
            this.bntThoat.Name = "bntThoat";
            this.bntThoat.Size = new System.Drawing.Size(184, 42);
            this.bntThoat.TabIndex = 19;
            this.bntThoat.Text = "Thoát";
            this.bntThoat.UseVisualStyleBackColor = false;
            this.bntThoat.Click += new System.EventHandler(this.bntThoat_Click);
            // 
            // QuenMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bntThoat);
            this.Controls.Add(this.btnLayMK);
            this.Controls.Add(this.txtKQ);
            this.Controls.Add(this.lblKQ);
            this.Controls.Add(this.txtEmailDK);
            this.Controls.Add(this.lblEmailDK);
            this.Controls.Add(this.pictureBox1);
            this.Name = "QuenMatKhau";
            this.Text = "Quên mật khẩu";
            this.Load += new System.EventHandler(this.QuenMatKhau_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblEmailDK;
        private System.Windows.Forms.TextBox txtEmailDK;
        private System.Windows.Forms.Label lblKQ;
        private System.Windows.Forms.TextBox txtKQ;
        private System.Windows.Forms.Button btnLayMK;
        private System.Windows.Forms.Button bntThoat;
    }
}