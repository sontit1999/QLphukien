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
    class NhanVienDao
    {
        SqlConnection con;
        public NhanVienDao()
        {
            con = UtilsConnect.getConnection();
        }
        public NhanVien getNhanVien(string username,string password)
        {
            NhanVien nv = null;
            con.Open();
            string sql = "select * from NhanVien where MaNhanVien = @manv and MatKhau = @pass";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("manv", username);
            cmd.Parameters.AddWithValue("pass", password);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                nv = new NhanVien(dr["MaNhanVien"].ToString(), dr["HoTenNhanVien"].ToString(), dr["GioiTinh"].ToString(), dr["NgaySinh"].ToString(), dr["DiaChi"].ToString(), dr["SoDienThoai"].ToString(), dr["MatKhau"].ToString(), dr["PhanQuyen"].ToString());
                break;
            }
            con.Close();
            return nv;
        }
    }
}
