using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeThongQuanLyCuaHangQuanAo.Models;

namespace HeThongQuanLyCuaHangQuanAo.DAL
{
    internal class MauDAL
    {
        public List<Mau> GetAllMau()
        {
            List<Mau> list = new List<Mau>();
            string query = "SELECT MaMau, TenMau FROM Mau";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Mau
                        {
                            MaMau = reader["MaMau"].ToString(),
                            TenMau = reader["TenMau"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public bool Add(Mau mau)
        {
            string query = "INSERT INTO Mau (MaMau, TenMau) VALUES (@MaMau, @TenMau)";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaMau", mau.MaMau);
                cmd.Parameters.AddWithValue("@TenMau", mau.TenMau);

                try
                {
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi thêm màu: " + ex.Message);
                }
            }
        }

    }
}
