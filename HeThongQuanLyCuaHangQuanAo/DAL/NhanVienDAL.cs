using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeThongQuanLyCuaHangQuanAo.Models;

namespace HeThongQuanLyCuaHangQuanAo.DAL
{
    internal class NhanVienDAL
    {
        public List<NhanVien> GetAllNhanVien()
        {
            List<NhanVien> list = new List<NhanVien>();
            string query = @"SELECT nv.MaNV, nv.TenNV, nv.GioiTinh, nv.NgaySinh, nv.DienThoai, 
                           nv.DiaChi, nv.MaCV, cv.TenCV, nv.TinhTrang 
                           FROM NhanVien nv 
                           LEFT JOIN CongViec cv ON nv.MaCV = cv.MaCV";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new NhanVien
                        {
                            MaNV = reader["MaNV"].ToString(),
                            TenNV = reader["TenNV"].ToString(),
                            GioiTinh = reader["GioiTinh"].ToString(),
                            NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                            DienThoai = reader["DienThoai"].ToString(),
                            DiaChi = reader["DiaChi"].ToString(),
                            MaCV = reader["MaCV"].ToString(),
                            TenCV = reader["TenCV"] != DBNull.Value ? reader["TenCV"].ToString() : "",
                            TinhTrang = reader["TinhTrang"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public NhanVien GetNhanVienById(string maNV)
        {
            string query = @"SELECT nv.MaNV, nv.TenNV, nv.GioiTinh, nv.NgaySinh, nv.DienThoai, 
                           nv.DiaChi, nv.MaCV, cv.TenCV, nv.TinhTrang 
                           FROM NhanVien nv 
                           LEFT JOIN CongViec cv ON nv.MaCV = cv.MaCV 
                           WHERE nv.MaNV = @MaNV";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaNV", maNV);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new NhanVien
                        {
                            MaNV = reader["MaNV"].ToString(),
                            TenNV = reader["TenNV"].ToString(),
                            GioiTinh = reader["GioiTinh"].ToString(),
                            NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                            DienThoai = reader["DienThoai"].ToString(),
                            DiaChi = reader["DiaChi"].ToString(),
                            MaCV = reader["MaCV"].ToString(),
                            TenCV = reader["TenCV"] != DBNull.Value ? reader["TenCV"].ToString() : "",
                            TinhTrang = reader["TinhTrang"].ToString()
                        };
                    }
                }
            }
            return null;
        }

        public bool InsertNhanVien(NhanVien nhanVien)
        {
            string query = @"INSERT INTO NhanVien (MaNV, TenNV, GioiTinh, NgaySinh, DienThoai, DiaChi, MaCV, TinhTrang) 
                           VALUES (@MaNV, @TenNV, @GioiTinh, @NgaySinh, @DienThoai, @DiaChi, @MaCV, @TinhTrang)";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaNV", nhanVien.MaNV);
                cmd.Parameters.AddWithValue("@TenNV", nhanVien.TenNV);
                cmd.Parameters.AddWithValue("@GioiTinh", nhanVien.GioiTinh);
                cmd.Parameters.AddWithValue("@NgaySinh", nhanVien.NgaySinh);
                cmd.Parameters.AddWithValue("@DienThoai", nhanVien.DienThoai);
                cmd.Parameters.AddWithValue("@DiaChi", nhanVien.DiaChi);
                cmd.Parameters.AddWithValue("@MaCV", nhanVien.MaCV);
                cmd.Parameters.AddWithValue("@TinhTrang", string.IsNullOrEmpty(nhanVien.TinhTrang) ? "Đang làm" : nhanVien.TinhTrang);

                try
                {
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi thêm nhân viên: " + ex.Message);
                }
            }
        }

        public bool UpdateNhanVien(NhanVien nhanVien)
        {
            string query = @"UPDATE NhanVien 
                           SET TenNV = @TenNV, 
                               GioiTinh = @GioiTinh, 
                               NgaySinh = @NgaySinh, 
                               DienThoai = @DienThoai, 
                               DiaChi = @DiaChi, 
                               MaCV = @MaCV,
                               TinhTrang = @TinhTrang
                           WHERE MaNV = @MaNV";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaNV", nhanVien.MaNV);
                cmd.Parameters.AddWithValue("@TenNV", nhanVien.TenNV);
                cmd.Parameters.AddWithValue("@GioiTinh", nhanVien.GioiTinh);
                cmd.Parameters.AddWithValue("@NgaySinh", nhanVien.NgaySinh);
                cmd.Parameters.AddWithValue("@DienThoai", nhanVien.DienThoai);
                cmd.Parameters.AddWithValue("@DiaChi", nhanVien.DiaChi);
                cmd.Parameters.AddWithValue("@MaCV", nhanVien.MaCV);
                cmd.Parameters.AddWithValue("@TinhTrang", nhanVien.TinhTrang);

                try
                {
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi cập nhật nhân viên: " + ex.Message);
                }
            }
        }

        public bool UpdateTinhTrangNhanVien(string maNV, string tinhTrang)
        {
            string query = "UPDATE NhanVien SET TinhTrang = @TinhTrang WHERE MaNV = @MaNV";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaNV", maNV);
                cmd.Parameters.AddWithValue("@TinhTrang", tinhTrang);

                try
                {
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi cập nhật tình trạng nhân viên: " + ex.Message);
                }
            }
        }

        public List<NhanVien> TimKiemNhanVien(string tuKhoa)
        {
            List<NhanVien> list = new List<NhanVien>();
            string query = @"SELECT nv.MaNV, nv.TenNV, nv.GioiTinh, nv.NgaySinh, nv.DienThoai, 
                           nv.DiaChi, nv.MaCV, cv.TenCV, nv.TinhTrang 
                           FROM NhanVien nv 
                           LEFT JOIN CongViec cv ON nv.MaCV = cv.MaCV 
                           WHERE nv.MaNV LIKE @TuKhoa 
                           OR nv.TenNV LIKE @TuKhoa 
                           OR nv.DienThoai LIKE @TuKhoa 
                           OR cv.TenCV LIKE @TuKhoa";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new NhanVien
                        {
                            MaNV = reader["MaNV"].ToString(),
                            TenNV = reader["TenNV"].ToString(),
                            GioiTinh = reader["GioiTinh"].ToString(),
                            NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                            DienThoai = reader["DienThoai"].ToString(),
                            DiaChi = reader["DiaChi"].ToString(),
                            MaCV = reader["MaCV"].ToString(),
                            TenCV = reader["TenCV"] != DBNull.Value ? reader["TenCV"].ToString() : "",
                            TinhTrang = reader["TinhTrang"].ToString()
                        });
                    }
                }
            }
            return list;
        }
    }
}
