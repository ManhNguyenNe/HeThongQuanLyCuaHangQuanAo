using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeThongQuanLyCuaHangQuanAo.Models;

namespace HeThongQuanLyCuaHangQuanAo.DAL
{
    internal class MuaDAL
    {
        public List<Mua> GetAllMua()
        {
            List<Mua> list = new List<Mua>();
            string query = "SELECT MaMua, TenMua FROM Mua";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Mua
                        {
                            MaMua = reader["MaMua"].ToString(),
                            TenMua = reader["TenMua"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public bool Add(Mua mua)
        {
            string query = "INSERT INTO Mua (MaMua, TenMua) VALUES (@MaMua, @TenMua)";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaMua", mua.MaMua);
                cmd.Parameters.AddWithValue("@TenMua", mua.TenMua);

                try
                {
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi thêm mùa: " + ex.Message);
                }
            }
        }

    }
}
