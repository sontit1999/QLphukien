namespace Qlphukien
{
    partial class MenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            this.lblChaomung = new System.Windows.Forms.Label();
            this.btnSanPham = new System.Windows.Forms.Button();
            this.btnLoaiSP = new System.Windows.Forms.Button();
            this.btnNhanVien = new System.Windows.Forms.Button();
            this.btnHoaDon = new System.Windows.Forms.Button();
            this.btnThongke = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblChaomung
            // 
            this.lblChaomung.AutoSize = true;
            this.lblChaomung.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChaomung.ForeColor = System.Drawing.Color.Red;
            this.lblChaomung.Location = new System.Drawing.Point(150, 24);
            this.lblChaomung.Name = "lblChaomung";
            this.lblChaomung.Size = new System.Drawing.Size(485, 24);
            this.lblChaomung.TabIndex = 0;
            this.lblChaomung.Text = "Chào mừng bạn đến với hệ thống quản lý phụ kiện";
            // 
            // btnSanPham
            // 
            this.btnSanPham.Image = ((System.Drawing.Image)(resources.GetObject("btnSanPham.Image")));
            this.btnSanPham.Location = new System.Drawing.Point(76, 82);
            this.btnSanPham.Name = "btnSanPham";
            this.btnSanPham.Size = new System.Drawing.Size(171, 104);
            this.btnSanPham.TabIndex = 1;
            this.btnSanPham.Text = "Sản Phẩm";
            this.btnSanPham.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSanPham.UseVisualStyleBackColor = false;
            this.btnSanPham.Click += new System.EventHandler(this.btnSanPham_Click);
            // 
            // btnLoaiSP
            // 
            this.btnLoaiSP.Image = ((System.Drawing.Image)(resources.GetObject("btnLoaiSP.Image")));
            this.btnLoaiSP.Location = new System.Drawing.Point(76, 214);
            this.btnLoaiSP.Name = "btnLoaiSP";
            this.btnLoaiSP.Size = new System.Drawing.Size(171, 97);
            this.btnLoaiSP.TabIndex = 2;
            this.btnLoaiSP.Text = "Loại Sản Phẩm";
            this.btnLoaiSP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLoaiSP.UseVisualStyleBackColor = true;
            this.btnLoaiSP.Click += new System.EventHandler(this.btnLoaiSP_Click);
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.Image = ((System.Drawing.Image)(resources.GetObject("btnNhanVien.Image")));
            this.btnNhanVien.Location = new System.Drawing.Point(336, 82);
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.Size = new System.Drawing.Size(171, 104);
            this.btnNhanVien.TabIndex = 3;
            this.btnNhanVien.Text = "Nhân Viên";
            this.btnNhanVien.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNhanVien.UseVisualStyleBackColor = true;
            this.btnNhanVien.Click += new System.EventHandler(this.btnNhanVien_Click);
            // 
            // btnHoaDon
            // 
            this.btnHoaDon.Image = ((System.Drawing.Image)(resources.GetObject("btnHoaDon.Image")));
            this.btnHoaDon.Location = new System.Drawing.Point(336, 214);
            this.btnHoaDon.Name = "btnHoaDon";
            this.btnHoaDon.Size = new System.Drawing.Size(171, 97);
            this.btnHoaDon.TabIndex = 4;
            this.btnHoaDon.Text = "Hóa Đơn";
            this.btnHoaDon.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnHoaDon.UseVisualStyleBackColor = true;
            // 
            // btnThongke
            // 
            this.btnThongke.Image = ((System.Drawing.Image)(resources.GetObject("btnThongke.Image")));
            this.btnThongke.Location = new System.Drawing.Point(586, 82);
            this.btnThongke.Name = "btnThongke";
            this.btnThongke.Size = new System.Drawing.Size(171, 104);
            this.btnThongke.TabIndex = 5;
            this.btnThongke.Text = "Thống Kê";
            this.btnThongke.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnThongke.UseVisualStyleBackColor = true;
            // 
            // btnThoat
            // 
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.Location = new System.Drawing.Point(586, 214);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(171, 97);
            this.btnThoat.TabIndex = 6;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.button6_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 482);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnThongke);
            this.Controls.Add(this.btnHoaDon);
            this.Controls.Add(this.btnNhanVien);
            this.Controls.Add(this.btnLoaiSP);
            this.Controls.Add(this.btnSanPham);
            this.Controls.Add(this.lblChaomung);
            this.Name = "MenuForm";
            this.Text = "MenuForm";
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblChaomung;
        private System.Windows.Forms.Button btnSanPham;
        private System.Windows.Forms.Button btnLoaiSP;
        private System.Windows.Forms.Button btnNhanVien;
        private System.Windows.Forms.Button btnHoaDon;
        private System.Windows.Forms.Button btnThongke;
        private System.Windows.Forms.Button btnThoat;
    }
}