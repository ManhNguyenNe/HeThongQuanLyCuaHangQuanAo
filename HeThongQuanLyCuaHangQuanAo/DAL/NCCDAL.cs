using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeThongQuanLyCuaHangQuanAo.Models;

namespace HeThongQuanLyCuaHangQuanAo.DAL
{
    internal class NCCDAL
    {
        public List<NCC> GetAllNCC()
        {
            List<NCC> list = new List<NCC>();
            string query = "SELECT MaNCC, TenNCC, DiaChi, DienThoai FROM NhaCungCap";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new NCC
                        {
                            MaNCC = reader["MaNCC"].ToString(),
                            TenNCC = reader["TenNCC"].ToString(),
                            DiaChi = reader["DiaChi"].ToString(),
                            DienThoai = reader["DienThoai"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public NCC GetNCCById(string maNCC)
        {
            string query = "SELECT MaNCC, TenNCC, DiaChi, DienThoai FROM NhaCungCap WHERE MaNCC = @MaNCC";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaNCC", maNCC);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new NCC
                        {
                            MaNCC = reader["MaNCC"].ToString(),
                            TenNCC = reader["TenNCC"].ToString(),
                            DiaChi = reader["DiaChi"].ToString(),
                            DienThoai = reader["DienThoai"].ToString()
                        };
                    }
                }
            }
            return null;
        }

        public bool InsertNCC(NCC ncc)
        {
            string query = "INSERT INTO NhaCungCap (MaNCC, TenNCC, DiaChi, DienThoai) VALUES (@MaNCC, @TenNCC, @DiaChi, @DienThoai)";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaNCC", ncc.MaNCC);
                cmd.Parameters.AddWithValue("@TenNCC", ncc.TenNCC);
                cmd.Parameters.AddWithValue("@DiaChi", ncc.DiaChi);
                cmd.Parameters.AddWithValue("@DienThoai", ncc.DienThoai);

                try
                {
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi thêm nhà cung cấp: " + ex.Message);
                }
            }
        }

        public bool UpdateNCC(NCC ncc)
        {
            string query = "UPDATE NhaCungCap SET TenNCC = @TenNCC, DiaChi = @DiaChi, DienThoai = @DienThoai WHERE MaNCC = @MaNCC";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaNCC", ncc.MaNCC);
                cmd.Parameters.AddWithValue("@TenNCC", ncc.TenNCC);
                cmd.Parameters.AddWithValue("@DiaChi", ncc.DiaChi);
                cmd.Parameters.AddWithValue("@DienThoai", ncc.DienThoai);

                try
                {
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi cập nhật nhà cung cấp: " + ex.Message);
                }
            }
        }

        //public bool Delete(string maNCC)
        //{
        //    string query = "DELETE FROM NhaCungCap WHERE MaNCC = @MaNCC";

        //    using (SqlConnection conn = DBHelper.GetConnection())
        //    using (SqlCommand cmd = new SqlCommand(query, conn))
        //    {
        //        cmd.Parameters.AddWithValue("@MaNCC", maNCC);

        //        try
        //        {
        //            conn.Open();
        //            int rows = cmd.ExecuteNonQuery();
        //            return rows > 0;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception("Lỗi khi xóa nhà cung cấp: " + ex.Message);
        //        }
        //    }
        //}

        public List<NCC> TimKiemNCC(string tuKhoa)
        {
            List<NCC> list = new List<NCC>();
            string query = @"
                SELECT MaNCC, TenNCC, DiaChi, DienThoai 
                FROM NhaCungCap
                WHERE MaNCC LIKE @TuKhoa OR TenNCC LIKE @TuKhoa OR DiaChi LIKE @TuKhoa OR DienThoai LIKE @TuKhoa";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new NCC
                        {
                            MaNCC = reader["MaNCC"].ToString(),
                            TenNCC = reader["TenNCC"].ToString(),
                            DiaChi = reader["DiaChi"].ToString(),
                            DienThoai = reader["DienThoai"].ToString()
                        });
                    }
                }
            }
            return list;
        }
    }
}
