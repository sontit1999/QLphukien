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
    public partial class QLnhanvien : Form
    {
        NhanVienDao nvDao = new NhanVienDao();
        public QLnhanvien()
        {
            InitializeComponent();
            txtMatkhau.PasswordChar = '\u25CF';
            cbRole.SelectedIndex = 0;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void QLnhanvien_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            // custom display date
            dateTimePickerNgaysinh.CustomFormat = "dd/MM/yyyy";
            // set default time
            dateTimePickerNgaysinh.Value = new DateTime(1997, 10, 10);
            dateTimePickerNgaysinh.MaxDate = DateTime.Now;

            // load all nhân viên to datagridview
            displayNhanVien(dgvNhanVien, nvDao.getAllNhanVien());

        }

        private void txtSodt_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtSodt.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txtSodt.Text = "";
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string manv = txtManv.Text;
            string tennv = txtTenNv.Text;
            string gioitinh = "";
            if (rbNam.Checked)
            {
                gioitinh = "Nam";
            }
            else
            {
                gioitinh = "Nữ";
            }
            string ngaysinh = dateTimePickerNgaysinh.Value.ToString("yyyy-MM-dd");
            string diachi = txtDiachi.Text;
            string sdt = txtSodt.Text;
            string matkhau = txtMatkhau.Text;
            string role = "";
            if(cbRole.SelectedIndex == 0)
            {
                role = "user";
            }
            else
            {
                role = "admin";
            }
            if(manv.Equals("") || tennv.Equals("") || gioitinh.Equals("") || ngaysinh.Equals("") || diachi.Equals("") || sdt.Equals("") || matkhau.Equals("") || role.Equals(""))
            {
                MessageBox.Show("Không được bỏ trống trường nào !!!");
            }
            else
            {
                NhanVien nvResult = nvDao.CheckPhoneExist(sdt);
                NhanVien nv = new NhanVien(manv, tennv, gioitinh, ngaysinh, diachi, sdt, matkhau, role);
                NhanVien nvTimdc = nvDao.CheckNhanVien(nv.MaNv);
                if(nvTimdc == null)
                {
                    if (nvResult == null)
                    {
                        nvDao.AddNhanVien(nv);
                        displayNhanVien(dgvNhanVien, nvDao.getAllNhanVien());
                        clearAllFiled();
                        MessageBox.Show("Đã thêm nhân viên !");
                    }
                    else
                    {
                        MessageBox.Show("Nhân viên " + nvResult.TenNv + " đã sử dụng số điện thoại này !! Vui lòng kiểm tra lại");
                    }
                }
                else
                {
                    MessageBox.Show("Đã tồn tại nhân viên có mã nv: " + nv.MaNv);
                }
            }
        }
        // hàm xóa nội dung trong các textbox 
        private void clearAllFiled()
        {
            txtManv.Text = "";
            txtTenNv.Text = "";
            txtDiachi.Text = "";
            txtSodt.Text = "";
            txtMatkhau.Text = "";
        }

        // hàm hiển thị ds nhân viên lên datagridview
        public void displayNhanVien(DataGridView dgv , List<NhanVien> list)
        {
            dgv.Rows.Clear();

            dgv.ColumnCount = 8;

            int i = 0;
            foreach (NhanVien item in list)
            {
                dgv.Rows.Add();
                dgv.Rows[i].Cells[0].Value = item.MaNv;
                dgv.Rows[i].Cells[1].Value = item.TenNv;
                dgv.Rows[i].Cells[2].Value = item.Gioitinh;
                dgv.Rows[i].Cells[3].Value = Convert.ToDateTime(item.NgaySinh.ToString()).ToString("dd-MM-yyyy");
                dgv.Rows[i].Cells[4].Value = item.DiaChi;
                dgv.Rows[i].Cells[5].Value = item.SoDienthoai;
                dgv.Rows[i].Cells[6].Value = item.MatKhau;
                dgv.Rows[i].Cells[7].Value = item.Role;
                i++;
            }
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            string manv = txtManv.Text;
            string tennv = txtTenNv.Text;
            string gioitinh = "";
            if (rbNam.Checked)
            {
                gioitinh = "Nam";
            }
            else
            {
                gioitinh = "Nữ";
            }
            string ngaysinh = dateTimePickerNgaysinh.Value.ToString("yyyy-MM-dd");
            string diachi = txtDiachi.Text;
            string sdt = txtSodt.Text;
            string matkhau = txtMatkhau.Text;
            string role = "";
            if (cbRole.SelectedIndex == 0)
            {
                role = "user";
            }
            else
            {
                role = "admin";
            }
            if (manv.Equals("") || tennv.Equals("") || gioitinh.Equals("") || ngaysinh.Equals("") || diachi.Equals("") || sdt.Equals("") || matkhau.Equals("") || role.Equals(""))
            {
                MessageBox.Show("Không được bỏ trống trường nào !!!");
            }
            else
            {
                NhanVien nv = new NhanVien(manv, tennv, gioitinh, ngaysinh, diachi, sdt, matkhau, role);
                NhanVien nvTimdc = nvDao.CheckNhanVien(nv.MaNv);
                if (nvTimdc == null)
                {
                    MessageBox.Show("Không có nhân viên nào có mã  !" + nv.MaNv);
                }
                else
                {
                    nvDao.UpdateNhanVien(nv);
                    displayNhanVien(dgvNhanVien, nvDao.getAllNhanVien());
                    clearAllFiled();
                    MessageBox.Show("Đã cập nhật thông tin nhân viên "  + nv.TenNv);

                }
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexrow = e.RowIndex;
            if (indexrow >= 0)
            {
                txtManv.Text = dgvNhanVien.Rows[indexrow].Cells[0].Value.ToString();
                txtTenNv.Text = dgvNhanVien.Rows[indexrow].Cells[1].Value.ToString();
                txtDiachi.Text = dgvNhanVien.Rows[indexrow].Cells[4].Value.ToString();
                txtSodt.Text = dgvNhanVien.Rows[indexrow].Cells[5].Value.ToString();
                txtMatkhau.Text = dgvNhanVien.Rows[indexrow].Cells[6].Value.ToString();
            }
           
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string manv = txtManv.Text;
            if (manv.Equals(""))
            {
                MessageBox.Show("Phải nhập vào mã nhân viên để xóa !!");
            }
            else
            {
                NhanVien nv = nvDao.CheckNhanVien(manv);
                if (nv == null)
                {
                    MessageBox.Show("Không tồn tại nhân viên này!");
                }
                else
                {
                    
                    DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa nhân viên " + nv.TenNv,"Xóa nhân viên",MessageBoxButtons.YesNo);
                    if(result == DialogResult.Yes)
                    {
                        nvDao.DeleteNhanVien(manv);
                        displayNhanVien(dgvNhanVien, nvDao.getAllNhanVien());
                        clearAllFiled();
                        MessageBox.Show("Đã xóa nhân viên " + nv.TenNv + " !");
                        
                    }
                }
               
            }
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string tukhoa = txtTukhoa.Text;
         
            if(tukhoa.Equals(""))
            {
                MessageBox.Show("Phải nhập mã nhân viên hoặc tên nhân viên vào ô  để tìm kiếm !!!!");
            }
            else
            {
                NhanVien nvcantim = new NhanVien(tukhoa, tukhoa, "Nam", "2020-10-10", "Hà nội", "0151520221", "adasd", "user");
                List<NhanVien> listNVtimdc = nvDao.SearchNhanVien(nvcantim);
                if (listNVtimdc.Count > 0)
                {
                    displayNhanVien(dgvNhanVien, listNVtimdc);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên nào !!!!");
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            displayNhanVien(dgvNhanVien, nvDao.getAllNhanVien());
        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
