using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeThongQuanLyCuaHangQuanAo.Models;

namespace HeThongQuanLyCuaHangQuanAo.DAL
{
    internal class NoiSanXuatDAL
    {
        public List<NoiSanXuat> GetAllNSX()
        {
            List<NoiSanXuat> list = new List<NoiSanXuat>();
            string query = "SELECT MaNSX, TenNSX FROM NoiSanXuat";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new NoiSanXuat
                        {
                            MaNSX = reader["MaNSX"].ToString(),
                            TenNSX = reader["TenNSX"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public bool Add(NoiSanXuat noiSanXuat)
        {
            string query = "INSERT INTO NoiSanXuat (MaNSX, TenNSX) VALUES (@MaNSX, @TenNSX)";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaNSX", noiSanXuat.MaNSX);
                cmd.Parameters.AddWithValue("@TenNSX", noiSanXuat.TenNSX);

                try
                {
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi thêm nơi sản xuất: " + ex.Message);
                }
            }
        }

    }
}
