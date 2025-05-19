using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeThongQuanLyCuaHangQuanAo.Models;

namespace HeThongQuanLyCuaHangQuanAo.DAL
{
    internal class CongViecDAL
    {
        public List<CongViec> GetAllCongViec()
        {
            List<CongViec> list = new List<CongViec>();
            string query = "SELECT MaCV, TenCV FROM CongViec";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new CongViec
                        {
                            MaCV = reader["MaCV"].ToString(),
                            TenCV = reader["TenCV"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        //public CongViec GetCongViecById(string maCV)
        //{
        //    string query = "SELECT MaCV, TenCV FROM CongViec WHERE MaCV = @MaCV";

        //    using (SqlConnection conn = DBHelper.GetConnection())
        //    using (SqlCommand cmd = new SqlCommand(query, conn))
        //    {
        //        cmd.Parameters.AddWithValue("@MaCV", maCV);

        //        conn.Open();
        //        using (SqlDataReader reader = cmd.ExecuteReader())
        //        {
        //            if (reader.Read())
        //            {
        //                return new CongViec
        //                {
        //                    MaCV = reader["MaCV"].ToString(),
        //                    TenCV = reader["TenCV"].ToString()
        //                };
        //            }
        //        }
        //    }
        //    return null;
        //}

        public bool Add(CongViec congViec)
        {
            string query = "INSERT INTO CongViec (MaCV, TenCV) VALUES (@MaCV, @TenCV)";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaCV", congViec.MaCV);
                cmd.Parameters.AddWithValue("@TenCV", congViec.TenCV);

                try
                {
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi thêm công việc: " + ex.Message);
                }
            }
        }
    }
}
