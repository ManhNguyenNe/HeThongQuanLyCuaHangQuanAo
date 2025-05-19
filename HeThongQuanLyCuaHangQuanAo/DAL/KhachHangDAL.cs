using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeThongQuanLyCuaHangQuanAo.Models;

namespace HeThongQuanLyCuaHangQuanAo.DAL
{
    internal class KhachHangDAL
    {
        public List<KhachHang> GetAllKhachHang()
        {
            List<KhachHang> list = new List<KhachHang>();
            string query = "SELECT MaKhach, TenKhach, DiaChi, DienThoai FROM KhachHang";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new KhachHang
                        {
                            MaKhach = reader["MaKhach"].ToString(),
                            TenKhach = reader["TenKhach"].ToString(),
                            DiaChi = reader["DiaChi"].ToString(),
                            DienThoai = reader["DienThoai"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public KhachHang GetKhachHangById(string maKhach)
        {
            string query = "SELECT MaKhach, TenKhach, DiaChi, DienThoai FROM KhachHang WHERE MaKhach = @MaKhach";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaKhach", maKhach);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new KhachHang
                        {
                            MaKhach = reader["MaKhach"].ToString(),
                            TenKhach = reader["TenKhach"].ToString(),
                            DiaChi = reader["DiaChi"].ToString(),
                            DienThoai = reader["DienThoai"].ToString()
                        };
                    }
                }
            }
            return null;
        }

        public bool InsertKhachHang(KhachHang khachHang)
        {
            string query = "INSERT INTO KhachHang (MaKhach, TenKhach, DiaChi, DienThoai) VALUES (@MaKhach, @TenKhach, @DiaChi, @DienThoai)";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaKhach", khachHang.MaKhach);
                cmd.Parameters.AddWithValue("@TenKhach", khachHang.TenKhach);
                cmd.Parameters.AddWithValue("@DiaChi", khachHang.DiaChi);
                cmd.Parameters.AddWithValue("@DienThoai", khachHang.DienThoai);

                try
                {
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi thêm khách hàng: " + ex.Message);
                }
            }
        }

        public bool UpdateKhachHang(KhachHang khachHang)
        {
            string query = "UPDATE KhachHang SET TenKhach = @TenKhach, DiaChi = @DiaChi, DienThoai = @DienThoai WHERE MaKhach = @MaKhach";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaKhach", khachHang.MaKhach);
                cmd.Parameters.AddWithValue("@TenKhach", khachHang.TenKhach);
                cmd.Parameters.AddWithValue("@DiaChi", khachHang.DiaChi);
                cmd.Parameters.AddWithValue("@DienThoai", khachHang.DienThoai);

                try
                {
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi cập nhật khách hàng: " + ex.Message);
                }
            }
        }

        public List<KhachHang> TimKiemKhachHang(string tuKhoa)
        {
            List<KhachHang> list = new List<KhachHang>();
            string query = @"
                SELECT MaKhach, TenKhach, DiaChi, DienThoai 
                FROM KhachHang
                WHERE MaKhach LIKE @TuKhoa OR TenKhach LIKE @TuKhoa OR DiaChi LIKE @TuKhoa OR DienThoai LIKE @TuKhoa";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new KhachHang
                        {
                            MaKhach = reader["MaKhach"].ToString(),
                            TenKhach = reader["TenKhach"].ToString(),
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
