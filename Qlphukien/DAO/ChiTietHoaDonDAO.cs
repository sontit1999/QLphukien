using Qlphukien.model;
using Qlphukien.utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qlphukien.DAO
{
    
    class ChiTietHoaDonDAO
    {
        SqlConnection con;
        public ChiTietHoaDonDAO()
        {
            con = UtilsConnect.getConnection();
        }
        // hàm get all hóa đơn
        public List<ChiTietHoaDon> getAllChiTietHD()
        {
            List<ChiTietHoaDon> list = new List<ChiTietHoaDon>();
            ChiTietHoaDon chiTietHoaDon = null;
            con.Open();
            string sql = "select * from ChiTiet_HoaDon";
            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                chiTietHoaDon = new ChiTietHoaDon(dr["MaHoaDon"].ToString(), dr["MaSanPham"].ToString(), Convert.ToInt32(dr["SoLuong"]), Convert.ToInt32(dr["TienPhaiTra"]));
                list.Add(chiTietHoaDon);
            }
            con.Close();
            return list;
        }
        // hàm thêm hóa đơn vào cơ sở dữ liệu
        public bool AddCTHoaDon(ChiTietHoaDon cthd)
        {
            con.Open();

            string sql = "insert into ChiTiet_HoaDon values(@mahd, @masp, @sl, @tien)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("mahd", cthd.MaHD);
            cmd.Parameters.AddWithValue("masp", cthd.MaSP);
            cmd.Parameters.AddWithValue("sl",cthd.SoLuongSP);
            cmd.Parameters.AddWithValue("tien", cthd.TienPhaiTra);

            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }
        // hàm xóa hóa đơn 
        public bool DeleteHoaDon(string mahdon)
        {
            con.Open();

            string sql = "delete from ChiTiet_HoaDon where MaHoaDon = @mahd";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("mahd",mahdon);
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }
    }
}
