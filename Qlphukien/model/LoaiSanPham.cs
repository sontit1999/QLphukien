using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qlphukien.model
{
    public class LoaiSanPham
    {
        public string MaLoaiSP { get; set; }
        public string TenLoaiSP { get; set; }
        public string MotaSP { get; set; }
        public LoaiSanPham()
        {

        }
        public LoaiSanPham(string maloaisp,string tenloaisp,string motasp)
        {
            this.MaLoaiSP = maloaisp;
            this.TenLoaiSP = tenloaisp;
            this.MotaSP = motasp;
        }

    }
}
