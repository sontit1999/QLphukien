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

    }
}
