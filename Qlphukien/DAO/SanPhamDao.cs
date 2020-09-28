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
    class SanPhamDao
    {
        SqlConnection con;
        public SanPhamDao()
        {
            con = UtilsConnect.getConnection();
        }
        // hàm get all sản phẩm
        public List<SanPham> getAllSP()
        {
            List<SanPham> list = new List<SanPham>();
            SanPham SanPham = null;
            con.Open();
            string sql = "select * from SanPham";
            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                SanPham = new SanPham(dr["MaSanPham"].ToString(), dr["MaLoaiSanPham"].ToString(), dr["TenSanPham"].ToString(), Convert.ToInt32(dr["SoLuong"]), Convert.ToInt32(dr["GiaNhap"]), Convert.ToInt32(dr["GiaBan"]), dr["ThoiGianBaoHanh"].ToString(), dr["DonVi"].ToString(), dr["MoTa"].ToString());

                list.Add(SanPham);
            }
            con.Close();
            return list;
        }
        // hàm thêm sản phẩm vào cơ sở dữ liệu
        public bool AddSP(SanPham sp)
        {
            con.Open();

            string sql = "insert into SanPham values(@masp, @malsp, @tensp, @sl, @gianhap, @giaban, @baohanh, @donvi,@mota)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("masp", sp.MaSP);
            cmd.Parameters.AddWithValue("malsp", sp.MaLoaiSP);
            cmd.Parameters.AddWithValue("tensp", sp.TenSP);
            cmd.Parameters.AddWithValue("sl", sp.SoLuong);
            cmd.Parameters.AddWithValue("gianhap", sp.GiaNhap);
            cmd.Parameters.AddWithValue("giaban", sp.GiaBan);
            cmd.Parameters.AddWithValue("baohanh", sp.ThoiGianBaoHanh);
            cmd.Parameters.AddWithValue("donvi", sp.DonVi);
            cmd.Parameters.AddWithValue("mota", sp.MotaSP);
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }
        // hàm sửa thông tin Loại sản phẩm
        public bool Updatesp(SanPham sp)
        {
            con.Open();

            string sql = "update SanPham set MaLoaiSanPham = @malsp,TenSanPham = @tensp , SoLuong  = @sl, GiaNhap = @gianhap, GiaBan = @giaban, ThoiGianBaoHanh =  @baohanh,DonVi = @donvi, MoTa = @mota where MaSanPham = @masp";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("malsp", sp.MaLoaiSP);
            cmd.Parameters.AddWithValue("tensp", sp.TenSP);
            cmd.Parameters.AddWithValue("sl", sp.SoLuong);
            cmd.Parameters.AddWithValue("gianhap", sp.GiaNhap);
            cmd.Parameters.AddWithValue("giaban", sp.GiaBan);
            cmd.Parameters.AddWithValue("baohanh", sp.ThoiGianBaoHanh);
            cmd.Parameters.AddWithValue("donvi", sp.DonVi);
            cmd.Parameters.AddWithValue("mota", sp.MotaSP);
            cmd.Parameters.AddWithValue("masp", sp.MaSP);
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }
        // hàm xóa  loại sản phẩm
        public bool Deletesp(string masp)
        {
            con.Open();

            string sql = "delete from SanPham where MaSanPham = @masp";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("masp", masp);
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }
        // hàm tìm kiếm  sản phẩm theo mã hoặc theo tên
        public List<SanPham> SearchSP(string keyword)
        {
            List<SanPham> list = new List<SanPham>();
            con.Open();
            string sql = "select * from SanPham where TenSanPham LIKE N'%" + keyword +"%' or MoTa LIKE N'%"+ keyword + "%'";     
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                SanPham sp = new SanPham(dr["MaSanPham"].ToString(), dr["MaLoaiSanPham"].ToString(), dr["TenSanPham"].ToString(), Convert.ToInt32(dr["SoLuong"]), Convert.ToInt32(dr["GiaNhap"]), Convert.ToInt32(dr["GiaBan"]), dr["ThoiGianBaoHanh"].ToString(), dr["DonVi"].ToString(), dr["MoTa"].ToString());

                list.Add(sp);
            }
            con.Close();
            return list;
        }
        // hàm check sản phẩm  đã có hay chưa
        public SanPham CheckSP(string MaSPCantim)
        {
            SanPham sp = null;
            con.Open();
            string sql = "select * from SanPham where MaSanPham = @masp";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("masp", MaSPCantim);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                sp = new SanPham(dr["MaSanPham"].ToString(), dr["MaLoaiSanPham"].ToString(), dr["TenSanPham"].ToString(), Convert.ToInt32(dr["SoLuong"]), Convert.ToInt32(dr["GiaNhap"]), Convert.ToInt32(dr["GiaBan"]), dr["ThoiGianBaoHanh"].ToString(), dr["DonVi"].ToString(), dr["MoTa"].ToString());
                break;
            }
            con.Close();
            return sp;
        }
    }
}
