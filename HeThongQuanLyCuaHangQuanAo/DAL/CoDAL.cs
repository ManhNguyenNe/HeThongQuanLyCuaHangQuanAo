using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeThongQuanLyCuaHangQuanAo.Models;

namespace HeThongQuanLyCuaHangQuanAo.DAL
{
    internal class CoDAL
    {
        public List<Co> GetAllCo()
        {
            List<Co> list = new List<Co>();
            string query = "SELECT MaCo, TenCo FROM Co";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Co
                        {
                            MaCo = reader["MaCo"].ToString(),
                            TenCo = reader["TenCo"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public bool Add(Co co)
        {
            string query = "INSERT INTO Co (MaCo, TenCo) VALUES (@MaCo, @TenCo)";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaCo", co.MaCo);
                cmd.Parameters.AddWithValue("@TenCo", co.TenCo);

                try
                {
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi thêm kích cỡ: " + ex.Message);
                }
            }
        }

    }
}
