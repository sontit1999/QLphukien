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
    class LoaiSanPhamDao
    {
        SqlConnection con;
        public LoaiSanPhamDao()
        {
            con = UtilsConnect.getConnection();
        }
        // hàm get all loại sản phẩm
        public List<LoaiSanPham> getAllLoaiSP()
        {
            List<LoaiSanPham> list = new List<LoaiSanPham>();
            LoaiSanPham loaiSanPham = null;
            con.Open();
            string sql = "select * from LoaiSanPham";
            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                loaiSanPham = new LoaiSanPham(dr["MaLoaiSanPham"].ToString(), dr["TenLoaiSanPham"].ToString(), dr["MoTa"].ToString());
                list.Add(loaiSanPham);
            }
            con.Close();
            return list;
        }
        // hàm thêm Loại sản phẩm vào cơ sở dữ liệu
        public bool AddLoaiSP(LoaiSanPham loaisp)
        {
            con.Open();
           
            string sql = "insert into LoaiSanPham values(@malsp,@tenlsp,@mota)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("malsp",loaisp.MaLoaiSP);
            cmd.Parameters.AddWithValue("tenlsp", loaisp.TenLoaiSP);
            cmd.Parameters.AddWithValue("mota", loaisp.MotaSP);
         
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }
        // hàm sửa thông tin Loại sản phẩm
        public bool UpdateLoaisp(LoaiSanPham loaisp)
        {
            con.Open();
           
            string sql = "update LoaiSanPham set TenLoaiSanPham = @tenlsp , MoTa = @mota  where MaLoaiSanPham = @malsp ";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("tenlsp", loaisp.TenLoaiSP);
            cmd.Parameters.AddWithValue("mota", loaisp.MotaSP);
            cmd.Parameters.AddWithValue("malsp", loaisp.MaLoaiSP);
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }
        // hàm xóa  loại sản phẩm
        public bool DeleteLoaisp(string maloaisp)
        {
            con.Open();
           
            string sql = "delete from LoaiSanPham where MaLoaiSanPham = @malsp";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("malsp", maloaisp);
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }
        // hàm tìm kiếm loại sản phẩm theo mã hoặc theo tên
        public List<LoaiSanPham> SearchLoaiSP(LoaiSanPham loaisp)
        {
            List<LoaiSanPham> list = new List<LoaiSanPham>();
            con.Open();
            string sql = "select * from LoaiSanPham where TenLoaiSanPham LIKE N'%" + loaisp.TenLoaiSP + "%'"; 
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("malsp", loaisp.MaLoaiSP);
            cmd.Parameters.AddWithValue("tenlsp", loaisp.TenLoaiSP);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                LoaiSanPham loaiSanPham = new LoaiSanPham(dr["MaLoaiSanPham"].ToString(), dr["TenLoaiSanPham"].ToString(), dr["MoTa"].ToString());
                list.Add(loaiSanPham);
            }
            con.Close();
            return list;
        }
        // hàm check sản phẩm  đã có hay chưa
        public LoaiSanPham CheckLoaiSP(string MaLoaiSPCantim)
        {
            LoaiSanPham loaiSanPham = null;
            con.Open();
            string sql = "select * from LoaiSanPham where MaLoaiSanPham = @malsp ";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("malsp", MaLoaiSPCantim);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                loaiSanPham = new LoaiSanPham(dr["MaLoaiSanPham"].ToString(), dr["TenLoaiSanPham"].ToString(), dr["MoTa"].ToString());
                break;
            }
            con.Close();
            return loaiSanPham;
        }
    }
}
