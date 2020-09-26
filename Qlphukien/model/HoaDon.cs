using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qlphukien.model
{
    class HoaDon
    {
        public string  MaHD { get; set; }
        public string MaNV { get; set; }
        public string NgayLap { get; set; }
        public int TongTienHD { get; set; }
        public HoaDon()
        {

        }
        public HoaDon(string mahd,string manv,string ngaylap , int tongtienhd)
        {
            this.MaHD = mahd;
            this.MaNV = manv;
            this.NgayLap = ngaylap;
            this.TongTienHD = tongtienhd;
        }
    }
}
