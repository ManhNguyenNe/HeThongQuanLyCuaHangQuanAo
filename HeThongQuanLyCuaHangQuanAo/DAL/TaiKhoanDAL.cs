using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeThongQuanLyCuaHangQuanAo.Models;
using HeThongQuanLyCuaHangQuanAo.ViewModels;

namespace HeThongQuanLyCuaHangQuanAo.DAL
{
    internal class TaiKhoanDAL
    {
        // Lấy tất cả tài khoản kèm thông tin nhân viên
        public List<TaiKhoanView> GetAllTaiKhoan()
        {
            List<TaiKhoanView> list = new List<TaiKhoanView>();
            string query = @"
                SELECT tk.MaTK, tk.MaNV, nv.TenNV, tk.TenDangNhap, tk.MatKhau, tk.VaiTro
                FROM TaiKhoan tk
                JOIN NhanVien nv ON tk.MaNV = nv.MaNV
                ORDER BY tk.MaTK";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new TaiKhoanView
                        {
                            MaTK = reader["MaTK"].ToString(),
                            MaNV = reader["MaNV"].ToString(),
                            TenNV = reader["TenNV"].ToString(),
                            TenDangNhap = reader["TenDangNhap"].ToString(),
                            MatKhau = reader["MatKhau"].ToString(),
                            VaiTro = Convert.ToInt32(reader["VaiTro"]),
                            //TinhTrang = Convert.ToBoolean(reader["TinhTrang"])
                        });
                    }
                }
            }
            return list;
        }

        // Lấy tài khoản theo mã tài khoản
        public TaiKhoan GetTaiKhoanById(string maTK)
        {
            TaiKhoan taiKhoan = null;
            string query = "SELECT * FROM TaiKhoan WHERE MaTK = @MaTK";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaTK", maTK);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        taiKhoan = new TaiKhoan
                        {
                            MaTK = reader["MaTK"].ToString(),
                            MaNV = reader["MaNV"].ToString(),
                            TenDangNhap = reader["TenDangNhap"].ToString(),
                            MatKhau = reader["MatKhau"].ToString(),
                            VaiTro = Convert.ToInt32(reader["VaiTro"]),
                            //TinhTrang = Convert.ToBoolean(reader["TinhTrang"])
                        };
                    }
                }
            }
            return taiKhoan;
        }

        // Lấy tài khoản theo tên đăng nhập
        public TaiKhoan GetTaiKhoanByUsername(string tenDangNhap)
        {
            string query = @"
        SELECT TK.*, NV.TenNV
        FROM TaiKhoan TK
        INNER JOIN NhanVien NV ON TK.MaNV = NV.MaNV
        WHERE TK.TenDangNhap = @TenDangNhap";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new TaiKhoan
                        {
                            MaTK = reader["MaTK"].ToString(),
                            MaNV = reader["MaNV"].ToString(),
                            TenDangNhap = reader["TenDangNhap"].ToString(),
                            MatKhau = reader["MatKhau"].ToString(),
                            VaiTro = Convert.ToInt32(reader["VaiTro"])
                            //TinhTrang = Convert.ToBoolean(reader["TinhTrang"])
                        };
                    }
                }
            }

            return null;
        }

        // Lấy tài khoản theo mã nhân viên
        public TaiKhoan GetTaiKhoanByMaNV(string maNV)
        {
            TaiKhoan taiKhoan = null;
            string query = "SELECT * FROM TaiKhoan WHERE MaNV = @MaNV";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaNV", maNV);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        taiKhoan = new TaiKhoan
                        {
                            MaTK = reader["MaTK"].ToString(),
                            MaNV = reader["MaNV"].ToString(),
                            TenDangNhap = reader["TenDangNhap"].ToString(),
                            MatKhau = reader["MatKhau"].ToString(),
                            VaiTro = Convert.ToInt32(reader["VaiTro"])
                            //TinhTrang = Convert.ToBoolean(reader["TinhTrang"])
                        };
                    }
                }
            }
            return taiKhoan;
        }

        // Thêm tài khoản mới
        public bool InsertTaiKhoan(TaiKhoan taiKhoan)
        {
            string query = @"
                INSERT INTO TaiKhoan (MaTK, MaNV, TenDangNhap, MatKhau, VaiTro)
                VALUES (@MaTK, @MaNV, @TenDangNhap, @MatKhau, @VaiTro)";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaTK", taiKhoan.MaTK);
                cmd.Parameters.AddWithValue("@MaNV", taiKhoan.MaNV);
                cmd.Parameters.AddWithValue("@TenDangNhap", taiKhoan.TenDangNhap);
                cmd.Parameters.AddWithValue("@MatKhau", taiKhoan.MatKhau);
                cmd.Parameters.AddWithValue("@VaiTro", taiKhoan.VaiTro);
                //cmd.Parameters.AddWithValue("@TinhTrang", taiKhoan.TinhTrang);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        // Cập nhật tài khoản
        public bool UpdateTaiKhoan(TaiKhoan taiKhoan)
        {
            string query = @"
                UPDATE TaiKhoan
                SET MaNV = @MaNV,
                    TenDangNhap = @TenDangNhap,
                    MatKhau = @MatKhau,
                    VaiTro = @VaiTro
                WHERE MaTK = @MaTK";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaTK", taiKhoan.MaTK);
                cmd.Parameters.AddWithValue("@MaNV", taiKhoan.MaNV);
                cmd.Parameters.AddWithValue("@TenDangNhap", taiKhoan.TenDangNhap);
                cmd.Parameters.AddWithValue("@MatKhau", taiKhoan.MatKhau);
                cmd.Parameters.AddWithValue("@VaiTro", taiKhoan.VaiTro);
                //cmd.Parameters.AddWithValue("@TinhTrang", taiKhoan.TinhTrang);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        // Cập nhật mật khẩu
        public bool UpdatePassword(string maTK, string matKhauMoi)
        {
            string query = @"
        UPDATE TaiKhoan
        SET MatKhau = @MatKhau
        WHERE MaTK = @MaTK";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaTK", maTK);
                cmd.Parameters.AddWithValue("@MatKhau", matKhauMoi);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        // Xóa tài khoản
        public bool DeleteTaiKhoan(string maTK)
        {
            string query = "DELETE FROM TaiKhoan WHERE MaTK = @MaTK";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaTK", maTK);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        // Tìm kiếm tài khoản
        public List<TaiKhoanView> SearchTaiKhoan(string tuKhoa)
        {
            List<TaiKhoanView> list = new List<TaiKhoanView>();
            string query = @"
                SELECT tk.MaTK, tk.MaNV, nv.TenNV, tk.TenDangNhap, tk.MatKhau, tk.VaiTro
                FROM TaiKhoan tk
                JOIN NhanVien nv ON tk.MaNV = nv.MaNV
                WHERE tk.MaTK LIKE @TuKhoa
                   OR tk.MaNV LIKE @TuKhoa
                   OR nv.TenNV LIKE @TuKhoa
                   OR tk.TenDangNhap LIKE @TuKhoa
                ORDER BY tk.MaTK";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new TaiKhoanView
                        {
                            MaTK = reader["MaTK"].ToString(),
                            MaNV = reader["MaNV"].ToString(),
                            TenNV = reader["TenNV"].ToString(),
                            TenDangNhap = reader["TenDangNhap"].ToString(),
                            MatKhau = reader["MatKhau"].ToString(),
                            VaiTro = Convert.ToInt32(reader["VaiTro"]),
                            //TinhTrang = Convert.ToBoolean(reader["TinhTrang"])
                        });
                    }
                }
            }
            return list;
        }

        // Lấy mã tài khoản mới nhất
        public string GetLatestTaiKhoanID()
        {
            string latestID = null;
            string query = "SELECT TOP 1 MaTK FROM TaiKhoan ORDER BY MaTK DESC";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    latestID = result.ToString();
                }
            }
            return latestID;
        }
    }
}
