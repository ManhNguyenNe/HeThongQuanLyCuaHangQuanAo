using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeThongQuanLyCuaHangQuanAo.Models;

namespace HeThongQuanLyCuaHangQuanAo.DAL
{
    internal class DoiTuongDAL
    {
        public List<DoiTuong> GetAllDoiTuong()
        {
            List<DoiTuong> list = new List<DoiTuong>();
            string query = "SELECT MaDoiTuong, TenDoiTuong FROM DoiTuong";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new DoiTuong
                        {
                            MaDoiTuong = reader["MaDoiTuong"].ToString(),
                            TenDoiTuong = reader["TenDoiTuong"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public bool Add(DoiTuong doiTuong)
        {
            string query = "INSERT INTO DoiTuong (MaDoiTuong, TenDoiTuong) VALUES (@MaDoiTuong, @TenDoiTuong)";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaDoiTuong", doiTuong.MaDoiTuong);
                cmd.Parameters.AddWithValue("@TenDoiTuong", doiTuong.TenDoiTuong);

                try
                {
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi thêm đối tượng: " + ex.Message);
                }
            }
        }

    }
}
