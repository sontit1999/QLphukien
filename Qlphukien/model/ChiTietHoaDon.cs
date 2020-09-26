using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qlphukien.model
{
    class ChiTietHoaDon
    {
        public string MaHD { get; set; }
        public string MaSP { get; set; }
        public int SoLuongSP { get; set; }
        public int TienPhaiTra { get; set; }
        public ChiTietHoaDon()
        {

        }
        public ChiTietHoaDon(string mahd, string masp, int soluongsp, int tienphaitra)
        {
            this.MaHD = mahd;
            this.MaSP = masp;
            this.SoLuongSP = soluongsp;
            this.TienPhaiTra = tienphaitra;
        }
    }
}
