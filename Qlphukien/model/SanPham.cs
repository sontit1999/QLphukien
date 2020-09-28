using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qlphukien.model
{
    class SanPham
    {
        public string MaSP { get; set; }
        public string MaLoaiSP { get; set; }
        public string TenSP { get; set; }
        public int SoLuong { get; set; }
        public int GiaNhap { get; set; }
        public int GiaBan { get; set; }
        public string ThoiGianBaoHanh { get; set; }
        public string DonVi { get; set; }
        public string MotaSP { get; set; }
        public SanPham()
        {

        }
        public SanPham(string masp,string maloaisp,string tensp,int soluong,int gianhap,int giaban,string baohanh,string donvi,string motasp)
        {
            this.MaSP = masp;
            this.MaLoaiSP = maloaisp;
            this.TenSP = tensp;
            this.SoLuong = soluong;
            this.GiaNhap = gianhap;
            this.GiaBan = giaban;
            this.ThoiGianBaoHanh = baohanh;
            this.DonVi = donvi;
            this.MotaSP = motasp;
        }
    }
}
