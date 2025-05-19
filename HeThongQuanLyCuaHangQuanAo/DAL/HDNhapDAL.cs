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
    internal class HDNhapDAL
    {
        public List<HDNhapView> GetAllHDNhap()
        {
            List<HDNhapView> list = new List<HDNhapView>();
            string query = @"
        SELECT hdn.SoHDN, hdn.MaNV, nv.TenNV, hdn.NgayNhap, hdn.MaNCC, ncc.TenNCC, hdn.TongTien
        FROM HoaDonNhap hdn
        JOIN NhanVien nv ON hdn.MaNV = nv.MaNV
        JOIN NhaCungCap ncc ON hdn.MaNCC = ncc.MaNCC
        ORDER BY hdn.NgayNhap DESC";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        HDNhapView hdnView = new HDNhapView
                        {
                            SoHDN = reader["SoHDN"].ToString(),
                            MaNV = reader["MaNV"].ToString(),
                            TenNV = reader["TenNV"].ToString(),
                            NgayNhap = Convert.ToDateTime(reader["NgayNhap"]),
                            MaNCC = reader["MaNCC"].ToString(),
                            TenNCC = reader["TenNCC"].ToString(),
                            TongTien = Convert.ToDecimal(reader["TongTien"])
                        };
                        list.Add(hdnView);
                    }
                }
            }
            return list;
        }

        public bool InsertHoaDonNhap(HoaDonNhap hoaDon)
        {
            string query = @"
        INSERT INTO HoaDonNhap (SoHDN, MaNV, NgayNhap, MaNCC, GiamGia, TongTien)
        VALUES (@SoHDN, @MaNV, @NgayNhap, @MaNCC, @GiamGia, @TongTien)";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@SoHDN", hoaDon.SoHDN);
                cmd.Parameters.AddWithValue("@MaNV", hoaDon.MaNV);
                cmd.Parameters.AddWithValue("@NgayNhap", hoaDon.NgayNhap);
                cmd.Parameters.AddWithValue("@MaNCC", hoaDon.MaNCC);
                cmd.Parameters.AddWithValue("@GiamGia", hoaDon.GiamGia);
                cmd.Parameters.AddWithValue("@TongTien", hoaDon.TongTien);

                try
                {
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public string GetLatestHDNhapID()
        {
            string latestID = null;
            string query = "SELECT TOP 1 SoHDN FROM HoaDonNhap ORDER BY SoHDN DESC";

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

        public List<HDNhapView> SearchHDNhap(string tuKhoa)
        {
            List<HDNhapView> list = new List<HDNhapView>();
            string query = @"
                SELECT hdn.SoHDN, hdn.MaNV, nv.TenNV, hdn.NgayNhap, hdn.MaNCC, ncc.TenNCC, hdn.TongTien
                FROM HoaDonNhap hdn
                JOIN NhanVien nv ON hdn.MaNV = nv.MaNV
                JOIN NhaCungCap ncc ON hdn.MaNCC = ncc.MaNCC
                WHERE hdn.SoHDN LIKE @TuKhoa
                   OR nv.TenNV LIKE @TuKhoa
                   OR ncc.TenNCC LIKE @TuKhoa
                   OR hdn.MaNV LIKE @TuKhoa
                   OR hdn.MaNCC LIKE @TuKhoa
                ORDER BY hdn.NgayNhap DESC";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        HDNhapView hdnView = new HDNhapView
                        {
                            SoHDN = reader["SoHDN"].ToString(),
                            MaNV = reader["MaNV"].ToString(),
                            TenNV = reader["TenNV"].ToString(),
                            NgayNhap = Convert.ToDateTime(reader["NgayNhap"]),
                            MaNCC = reader["MaNCC"].ToString(),
                            TenNCC = reader["TenNCC"].ToString(),
                            TongTien = Convert.ToDecimal(reader["TongTien"])
                        };
                        list.Add(hdnView);
                    }
                }
            }
            return list;
        }

        public bool UpdateTongTien(string soHDN, decimal tongTien)
        {
            string query = @"
                UPDATE HoaDonNhap
                SET TongTien = @TongTien
                WHERE SoHDN = @SoHDN";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@SoHDN", soHDN);
                cmd.Parameters.AddWithValue("@TongTien", tongTien);

                try
                {
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
