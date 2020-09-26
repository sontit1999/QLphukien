using Qlphukien.DAO;
using Qlphukien.model;
using Qlphukien.utils;
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
    public partial class Form1 : Form
    {
        NhanVienDao nvDao = new NhanVienDao();
        public Form1()
        {
            InitializeComponent();
            txtMatKhau.PasswordChar = '\u25CF';
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string taikhoan = txtTaikhoan.Text;
            string matkhau = txtMatKhau.Text;
            if(taikhoan.Equals("") || matkhau.Equals(""))
            {
                MessageBox.Show("Không được bỏ trống trường nào ?");
            }
            else
            {
                NhanVien nv = nvDao.getNhanVien(taikhoan, matkhau);
                if (nv == null)
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác !!");
                }
                else
                {
                    txtMatKhau.Text = "";
                    txtTaikhoan.Text = "";
                    MenuForm menuForm = new MenuForm(nv);
                    menuForm.Show();
                }
            }
        }
    }
}
