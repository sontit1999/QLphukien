using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qlphukien.model
{
    public class NhanVien
    {
        public string MaNv { get; set; }
        public string TenNv { get; set; }
        public string Gioitinh { get; set; }
        public string NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string SoDienthoai { get; set; }
        public string MatKhau { get; set; }
        public string Role { get; set; }
        public NhanVien()
        {

        }
        public NhanVien(string manv,string tennv,string gioitinh,string ngaysinh,string diachi,string sodienthoai,string matkhau,string role)
        {
            this.MaNv = manv;
            this.TenNv = tennv;
            this.Gioitinh = gioitinh;
            this.NgaySinh = ngaysinh;
            this.DiaChi = diachi;
            this.SoDienthoai = sodienthoai;
            this.MatKhau = matkhau;
            this.Role = role;
        }
    }
}
