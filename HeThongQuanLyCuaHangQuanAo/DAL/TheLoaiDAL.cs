using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeThongQuanLyCuaHangQuanAo.Models;

namespace HeThongQuanLyCuaHangQuanAo.DAL
{
    internal class TheLoaiDAL
    {
        public List<TheLoai> GetAllTheLoai()
        {
            List<TheLoai> list = new List<TheLoai>();
            string query = "SELECT MaLoai, TenLoai FROM TheLoai";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new TheLoai
                        {
                            MaLoai = reader["MaLoai"].ToString(),
                            TenLoai = reader["TenLoai"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public bool Add(TheLoai theLoai)
        {
            string query = "INSERT INTO TheLoai (MaLoai, TenLoai) VALUES (@MaLoai, @TenLoai)";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaLoai", theLoai.MaLoai);
                cmd.Parameters.AddWithValue("@TenLoai", theLoai.TenLoai);

                try
                {
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi thêm thể loại: " + ex.Message);
                }
            }
        }

    }
}
