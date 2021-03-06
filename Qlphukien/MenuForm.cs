﻿using Qlphukien.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Qlphukien
{
    public partial class MenuForm : Form
    {
        NhanVien nv;
        public MenuForm()
        {
            InitializeComponent();
        }
        public MenuForm(NhanVien nhanvien)
        {
            InitializeComponent();
            this.nv = nhanvien;
            if (!nv.Role.Equals("admin"))
            {
                btnNhanVien.Enabled = false;
            }
        }
        private void MenuForm_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            if (nv != null)
            {
                lblChaomung.Text = "Chào mừng " + nv.TenNv + " đến với hệ thống quản lý phụ kiện <3";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            QLnhanvien qLnhanvien = new QLnhanvien();
            qLnhanvien.Show();
        }

        private void btnLoaiSP_Click(object sender, EventArgs e)
        {
            QLloaiSP qLloaiSP = new QLloaiSP();
            qLloaiSP.Show();
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            QLSanPham qLSanPham = new QLSanPham();
            qLSanPham.Show();
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            QliHoadon qliHoadon = new QliHoadon();
            qliHoadon.Show();
        }
    }
}
