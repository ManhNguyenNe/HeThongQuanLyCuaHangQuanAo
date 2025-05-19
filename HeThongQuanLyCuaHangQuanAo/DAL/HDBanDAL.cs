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
    internal class HDBanDAL
    {
        // Lấy tất cả hóa đơn bán kèm thông tin khách hàng và nhân viên
        public List<HDBanView> GetAllHDBan()
        {
            List<HDBanView> list = new List<HDBanView>();
            string query = @"
        SELECT hdb.SoHDB, hdb.MaNV, nv.TenNV, hdb.NgayBan, hdb.MaKhach, kh.TenKhach, hdb.TongTien
        FROM HoaDonBan hdb
        JOIN NhanVien nv ON hdb.MaNV = nv.MaNV
        JOIN KhachHang kh ON hdb.MaKhach = kh.MaKhach
        ORDER BY hdb.NgayBan DESC";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        HDBanView hdbView = new HDBanView
                        {
                            SoHDB = reader["SoHDB"].ToString(),
                            MaNV = reader["MaNV"].ToString(),
                            TenNV = reader["TenNV"].ToString(),
                            NgayBan = Convert.ToDateTime(reader["NgayBan"]),
                            MaKhach = reader["MaKhach"].ToString(),
                            TenKhach = reader["TenKhach"].ToString(),
                            //GiamGia = Convert.ToDecimal(reader["GiamGia"]),
                            TongTien = Convert.ToDecimal(reader["TongTien"])
                        };
                        list.Add(hdbView);
                    }
                }
            }
            return list;
        }

        // Thêm hóa đơn bán mới
        public bool InsertHoaDonBan(HoaDonBan hoaDon)
        {
            string query = @"
        INSERT INTO HoaDonBan (SoHDB, MaNV, NgayBan, MaKhach, GiamGia, TongTien)
        VALUES (@SoHDB, @MaNV, @NgayBan, @MaKhach, @GiamGia, @TongTien)";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@SoHDB", hoaDon.SoHDB);
                cmd.Parameters.AddWithValue("@MaNV", hoaDon.MaNV);
                cmd.Parameters.AddWithValue("@NgayBan", hoaDon.NgayBan);
                cmd.Parameters.AddWithValue("@MaKhach", hoaDon.MaKhach);
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

        // Lấy mã hóa đơn bán mới nhất
        public string GetLatestHDBanID()
        {
            string latestID = null;
            string query = "SELECT TOP 1 SoHDB FROM HoaDonBan ORDER BY SoHDB DESC";

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

        // Tìm kiếm hóa đơn bán
        public List<HDBanView> SearchHDBan(string tuKhoa)
        {
            List<HDBanView> list = new List<HDBanView>();
            string query = @"
                SELECT hdb.SoHDB, hdb.MaNV, nv.TenNV, hdb.NgayBan, hdb.MaKhach, kh.TenKhach, hdb.TongTien
                FROM HoaDonBan hdb
                JOIN NhanVien nv ON hdb.MaNV = nv.MaNV
                JOIN KhachHang kh ON hdb.MaKhach = kh.MaKhach
                WHERE hdb.SoHDB LIKE @TuKhoa
                   OR nv.TenNV LIKE @TuKhoa
                   OR kh.TenKhach LIKE @TuKhoa
                   OR hdb.MaNV LIKE @TuKhoa
                   OR hdb.MaKhach LIKE @TuKhoa
                ORDER BY hdb.NgayBan DESC";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        HDBanView hdbView = new HDBanView
                        {
                            SoHDB = reader["SoHDB"].ToString(),
                            MaNV = reader["MaNV"].ToString(),
                            TenNV = reader["TenNV"].ToString(),
                            NgayBan = Convert.ToDateTime(reader["NgayBan"]),
                            MaKhach = reader["MaKhach"].ToString(),
                            TenKhach = reader["TenKhach"].ToString(),
                            TongTien = Convert.ToDecimal(reader["TongTien"])
                        };
                        list.Add(hdbView);
                    }
                }
            }
            return list;
        }

        // Cập nhật tổng tiền hóa đơn
        public bool UpdateTongTien(string soHDB, decimal tongTien)
        {
            string query = @"
                UPDATE HoaDonBan
                SET TongTien = @TongTien
                WHERE SoHDB = @SoHDB";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@SoHDB", soHDB);
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
