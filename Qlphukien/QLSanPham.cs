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
    public partial class QLSanPham : Form
    {
        SanPhamDao spDao = new SanPhamDao();
        LoaiSanPhamDao lspDao = new LoaiSanPhamDao();
        public QLSanPham()
        {
            InitializeComponent();


            // set loại sản phẩm
            List<LoaiSanPham> list = lspDao.getAllLoaiSP();
            cbLoaiSP.DataSource = list;
            cbLoaiSP.DisplayMember = "TenLoaiSP";
            cbLoaiSP.ValueMember = "MaLoaiSP";



        }

        private void QLSanPham_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            displaySanPhamToDgv(dgvSanPham, spDao.getAllSP());
        }

        private void cbLoaiSP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string masp = txtMaSP.Text;
            string maloaisp = cbLoaiSP.SelectedValue.ToString();
            string tensp = txtTenSP.Text;
            string soluong = txtSoLuong.Text;
            string gianhap = txtGiaNhap.Text;
            string giaban = txtGiaBan.Text;
            string baohanh = dateTimePickerThoiGianBH.Value.ToString("yyyy-MM-dd");
            string donvi = txtDonvi.Text;
            string mota = txtMotaSP.Text;

            if (masp.Equals("") || maloaisp.Equals("") || tensp.Equals("") || soluong.Equals("") || gianhap.Equals("") || giaban.Equals("") || baohanh.Equals("") || donvi.Equals("") || mota.Equals(""))
            {
                MessageBox.Show("Không được bỏ  trống trường nào !!");
            }
            else
            {
                SanPham sp = new SanPham(masp,maloaisp,tensp,int.Parse(soluong), int.Parse(gianhap), int.Parse(giaban), baohanh, donvi, mota);
                SanPham sptimdc = spDao.CheckSP(sp.MaSP);
                if (sptimdc == null)
                {
                    spDao.AddSP(sp);
                    displaySanPhamToDgv(dgvSanPham,spDao.getAllSP());
                    clearAllField();
                    MessageBox.Show("Đã thêm loại sản phẩm !");
                }
                else
                {
                    MessageBox.Show("Đã tồn tại loại sản phẩm  có mã : " + sp.MaSP);
                }
            }
        }
        // hàm hiển thị list sản phẩm lên datagridview
        private void displaySanPhamToDgv(DataGridView dgv,List<SanPham> list)
        {
            dgv.Rows.Clear();

            dgv.ColumnCount = 9;

            int i = 0;
            foreach (SanPham item in list)
            {
               
                dgv.Rows.Add();
                dgv.Rows[i].Cells[0].Value = item.MaSP;
                dgv.Rows[i].Cells[1].Value = item.MaLoaiSP;
                dgv.Rows[i].Cells[2].Value = item.TenSP;
                dgv.Rows[i].Cells[3].Value = item.SoLuong;
                dgv.Rows[i].Cells[4].Value = item.GiaNhap;
                dgv.Rows[i].Cells[5].Value = item.GiaBan;
                dgv.Rows[i].Cells[6].Value = Convert.ToDateTime(item.ThoiGianBaoHanh.ToString()).ToString("dd-MM-yyyy");
                dgv.Rows[i].Cells[7].Value = item.DonVi;
                dgv.Rows[i].Cells[8].Value = item.MotaSP;
                i++;
            }
        }

        private void clearAllField()
        {
             txtMaSP.Text = "";
            
            txtTenSP.Text = "";
            txtSoLuong.Text = "";
             txtGiaNhap.Text = "";
            txtGiaBan.Text = "";
            txtDonvi.Text = "";
           txtMotaSP.Text = "";
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            txtMaSP.Text = dgvSanPham.Rows[row].Cells[0].Value.ToString();

            txtTenSP.Text = dgvSanPham.Rows[row].Cells[2].Value.ToString();
            txtSoLuong.Text = dgvSanPham.Rows[row].Cells[3].Value.ToString();
            txtGiaNhap.Text = dgvSanPham.Rows[row].Cells[4].Value.ToString();
            txtGiaBan.Text = dgvSanPham.Rows[row].Cells[5].Value.ToString();
            txtDonvi.Text = dgvSanPham.Rows[row].Cells[7].Value.ToString();
            txtMotaSP.Text = dgvSanPham.Rows[row].Cells[8].Value.ToString();
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            string masp = txtMaSP.Text;
            string maloaisp = cbLoaiSP.SelectedValue.ToString();
            string tensp = txtTenSP.Text;
            string soluong = txtSoLuong.Text;
            string gianhap = txtGiaNhap.Text;
            string giaban = txtGiaBan.Text;
            string baohanh = dateTimePickerThoiGianBH.Value.ToString("yyyy-MM-dd");
            string donvi = txtDonvi.Text;
            string mota = txtMotaSP.Text;

            if (masp.Equals("") || maloaisp.Equals("") || tensp.Equals("") || soluong.Equals("") || gianhap.Equals("") || giaban.Equals("") || baohanh.Equals("") || donvi.Equals("") || mota.Equals(""))
            {
                MessageBox.Show("Không được bỏ  trống trường nào !!");
            }
            else
            {
                SanPham sp = new SanPham(masp, maloaisp, tensp, int.Parse(soluong), int.Parse(gianhap), int.Parse(giaban), baohanh, donvi, mota);
                SanPham sptimdc = spDao.CheckSP(sp.MaSP);
                if (sptimdc == null)
                {
                   
                    MessageBox.Show("Không tồn tại sản phẩm mã :" + sp.MaSP + "!!");
                }
                else
                {

                    spDao.Updatesp(sp);
                    displaySanPhamToDgv(dgvSanPham, spDao.getAllSP());
                    clearAllField();
                    MessageBox.Show("Đã cập nhật thông tin nhân viên " + sp.TenSP);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string masp = txtMaSP.Text;
            if (masp.Equals(""))
            {
                MessageBox.Show("Phải nhập vào mã sản phẩm để xóa !!");
            }
            else
            {
                SanPham sp = spDao.CheckSP(masp);
                if (sp == null)
                {
                    MessageBox.Show("Không tồn tại sản phẩm mã:" + masp);
                }
                else
                {

                    DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa sản phẩm " + sp.TenSP, "Xóa Sản phẩm", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        spDao.Deletesp(masp);
                        displaySanPhamToDgv(dgvSanPham, spDao.getAllSP());
                        clearAllField();
                        MessageBox.Show("Đã xóa sản phẩm " + sp.TenSP + " !");

                    }
                }

            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            displaySanPhamToDgv(dgvSanPham, spDao.getAllSP());
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string tukhoa = txtTukhoa.Text;
          
            if (tukhoa.Equals(""))
            {
                MessageBox.Show("Phải nhập tên sản phẩm hoặc mô tả sản phẩm vào ô  để tìm kiếm !!!!");
            }
            else
            {

                List<SanPham> listSPtimdc = spDao.SearchSP(tukhoa);
                if (listSPtimdc.Count > 0)
                {
                    displaySanPhamToDgv(dgvSanPham, listSPtimdc);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm nào !!!!");
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
