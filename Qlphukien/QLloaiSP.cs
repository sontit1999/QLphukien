using Qlphukien.DAO;
using Qlphukien.model;
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
    public partial class QLloaiSP : Form
    {
        LoaiSanPhamDao lspDao = new LoaiSanPhamDao();
        public QLloaiSP()
        {
            InitializeComponent();
        }

        private void QLloaiSP_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            displayLoaiSP(dgvLoaiSP, lspDao.getAllLoaiSP());
        }
        public void displayLoaiSP(DataGridView dgv,List<LoaiSanPham> list)
        {
            dgv.Rows.Clear();

            dgv.ColumnCount = 3;

            int i = 0;
            foreach (LoaiSanPham item in list)
            {
                dgv.Rows.Add();
                dgv.Rows[i].Cells[0].Value = item.MaLoaiSP;
                dgv.Rows[i].Cells[1].Value = item.TenLoaiSP;
                dgv.Rows[i].Cells[2].Value = item.MotaSP;
               
                i++;
            }
        }
        public void clearAllField()
        {
            txtMaLoaisp.Text = "";
            txtTenLoaisp.Text = "";
            txtMotaLoaiSP.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maloaisp = txtMaLoaisp.Text;
            string tenloaisp = txtTenLoaisp.Text;
            string motaloaisp = txtMotaLoaiSP.Text;
            if(maloaisp.Equals("") || tenloaisp.Equals("") || motaloaisp.Equals(""))
            {
                MessageBox.Show("Không được bỏ  trống trường nào !!");
            }
            else
            {
                LoaiSanPham loaiSanPham = new LoaiSanPham(maloaisp, tenloaisp, motaloaisp);
                LoaiSanPham lsptimdc = lspDao.CheckLoaiSP(loaiSanPham.MaLoaiSP);
                if (lsptimdc == null)
                {
                    lspDao.AddLoaiSP(loaiSanPham);
                    displayLoaiSP(dgvLoaiSP, lspDao.getAllLoaiSP());
                    clearAllField();
                    MessageBox.Show("Đã thêm loại sản phẩm !");
                }
                else
                {
                    MessageBox.Show("Đã tồn tại loại sản phẩm  có mã : " + loaiSanPham.MaLoaiSP);
                }
            }
        }

        private void dgvLoaiSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexrow = e.RowIndex;
            if (indexrow >= 0)
            {
                txtMaLoaisp.Text = dgvLoaiSP.Rows[indexrow].Cells[0].Value.ToString();
                txtTenLoaisp.Text = dgvLoaiSP.Rows[indexrow].Cells[1].Value.ToString();
                txtMotaLoaiSP.Text = dgvLoaiSP.Rows[indexrow].Cells[2].Value.ToString();
                
            }
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            string maloaisp = txtMaLoaisp.Text;
            string tenloaisp = txtTenLoaisp.Text;
            string motaloaisp = txtMotaLoaiSP.Text;
            if (maloaisp.Equals("") || tenloaisp.Equals("") || motaloaisp.Equals(""))
            {
                MessageBox.Show("Không được bỏ  trống trường nào !!");
            }
            else
            {
                LoaiSanPham loaiSanPham = new LoaiSanPham(maloaisp, tenloaisp, motaloaisp);
                LoaiSanPham lsptimdc = lspDao.CheckLoaiSP(loaiSanPham.MaLoaiSP);
                if (lsptimdc == null)
                {
                  
                    MessageBox.Show("Không tồn tại loại sản phẩm mã " + loaiSanPham.MaLoaiSP );
                }
                else
                {
                    lspDao.UpdateLoaisp(loaiSanPham);
                    displayLoaiSP(dgvLoaiSP, lspDao.getAllLoaiSP());
                    clearAllField();
                    MessageBox.Show("Đã cập nhật thông tin loại sản phẩm " + loaiSanPham.TenLoaiSP);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maloaisp = txtMaLoaisp.Text;
            if (maloaisp.Equals(""))
            {
                MessageBox.Show("Phải nhập vào mã loại sản phẩm để xóa !!");
            }
            else
            {
                LoaiSanPham lsp = lspDao.CheckLoaiSP(maloaisp);
              
                if (lsp == null)
                {
                    MessageBox.Show("Không tồn tại loại sản phẩm mã " + maloaisp);
                }
                else
                {

                    DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa loại sản phẩm " + lsp.TenLoaiSP, "Xóa loại sản phẩm", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        lspDao.DeleteLoaisp(lsp.MaLoaiSP);
                        displayLoaiSP(dgvLoaiSP, lspDao.getAllLoaiSP());
                        clearAllField();
                        MessageBox.Show("Đã xóa loại sản phẩm :  " + lsp.TenLoaiSP + " !");

                    }
                }

            }
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string malsp = txtMaLoaisp.Text;
            string tenlsp = txtTenLoaisp.Text;
            if (malsp.Equals("") && tenlsp.Equals(""))
            {
                MessageBox.Show("Phải nhập mã loại sản phẩm hoặc tên loại sản phẩm để tìm kiếm !!!!");
            }
            else
            {
                LoaiSanPham lspcantim = new LoaiSanPham(malsp, tenlsp, "aaa");

                List<LoaiSanPham> listLoaiSPtimdc = lspDao.SearchLoaiSP(lspcantim);
                if (listLoaiSPtimdc.Count > 0)
                {
                    displayLoaiSP(dgvLoaiSP, listLoaiSPtimdc);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy loại sản phẩm nào !!!!");
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            displayLoaiSP(dgvLoaiSP, lspDao.getAllLoaiSP());
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
