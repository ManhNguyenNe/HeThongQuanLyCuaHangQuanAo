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
   internal class ThongKeDAL
    {
        // Lấy tất cả hóa đơn nhập
        public List<HoaDonNhap> GetAllHoaDonNhap()
        {
            List<HoaDonNhap> list = new List<HoaDonNhap>();
            string query = @"
        SELECT SoHDN, MaNV, NgayNhap, MaNCC, GiamGia, TongTien
        FROM HoaDonNhap
        ORDER BY NgayNhap DESC";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        HoaDonNhap hdn = new HoaDonNhap
                        {
                            SoHDN = reader["SoHDN"].ToString(),
                            MaNV = reader["MaNV"].ToString(),
                            NgayNhap = Convert.ToDateTime(reader["NgayNhap"]),
                            MaNCC = reader["MaNCC"].ToString(),
                            GiamGia = Convert.ToDecimal(reader["GiamGia"]),
                            TongTien = Convert.ToDecimal(reader["TongTien"])
                        };
                        list.Add(hdn);
                    }
                }
            }
            return list;
        }

        // Lấy chi tiết hóa đơn bán theo số hóa đơn bán
        public List<ChiTietHDBan> GetChiTietHDBan(string soHDB)
        {
            List<ChiTietHDBan> list = new List<ChiTietHDBan>();
            string query = @"
        SELECT SoHDB, MaQuanAo, SoLuong
        FROM ChiTietHDBan
        WHERE SoHDB = @SoHDB";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@SoHDB", soHDB);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ChiTietHDBan ct = new ChiTietHDBan
                        {
                            SoHDB = reader["SoHDB"].ToString(),
                            MaQuanAo = reader["MaQuanAo"].ToString(),
                            SoLuong = Convert.ToInt32(reader["SoLuong"])
                        };
                        list.Add(ct);
                    }
                }
            }
            return list;
        }


        // Lấy tất cả hóa đơn bán
        public List<HoaDonBan> GetAllHoaDonBan()
        {
            List<HoaDonBan> list = new List<HoaDonBan>();
            string query = @"
        SELECT SoHDB, MaNV, NgayBan, MaKhach, GiamGia, TongTien
        FROM HoaDonBan
        ORDER BY NgayBan DESC";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        HoaDonBan hdb = new HoaDonBan
                        {
                            SoHDB = reader["SoHDB"].ToString(),
                            MaNV = reader["MaNV"].ToString(),
                            NgayBan = Convert.ToDateTime(reader["NgayBan"]),
                            MaKhach = reader["MaKhach"].ToString(),
                            GiamGia = Convert.ToDecimal(reader["GiamGia"]),
                            TongTien = Convert.ToDecimal(reader["TongTien"])
                        };
                        list.Add(hdb);
                    }
                }
            }
            return list;
        }


        // Lấy tất cả sản phẩm
        public List<SanPham> GetAllSanPham()
        {
            List<SanPham> list = new List<SanPham>();
            string query = @"
        SELECT MaQuanAo, TenQuanAo, MaLoai, MaCo, MaChatLieu, MaMau, MaDoiTuong, MaMua, MaNSX, SoLuong, Anh, DonGiaNhap, DonGiaBan
        FROM SanPham
        ORDER BY TenQuanAo";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        SanPham sp = new SanPham
                        {
                            MaQuanAo = reader["MaQuanAo"].ToString(),
                            TenQuanAo = reader["TenQuanAo"].ToString(),
                            MaLoai = reader["MaLoai"].ToString(),
                            MaCo = reader["MaCo"].ToString(),
                            MaChatLieu = reader["MaChatLieu"].ToString(),
                            MaMau = reader["MaMau"].ToString(),
                            MaDoiTuong = reader["MaDoiTuong"].ToString(),
                            MaMua = reader["MaMua"].ToString(),
                            MaNSX = reader["MaNSX"].ToString(),
                            SoLuong = Convert.ToInt32(reader["SoLuong"]),
                            Anh = reader["Anh"].ToString(),
                            DonGiaNhap = Convert.ToDecimal(reader["DonGiaNhap"]),
                            DonGiaBan = Convert.ToDecimal(reader["DonGiaBan"]),
                        };
                        list.Add(sp);
                    }
                }
            }
            return list;
        }

        // Lấy chi tiết hóa đơn nhập theo số hóa đơn nhập
        public List<ChiTietHDNhap> GetChiTietHDNhap(string soHDN)
        {
            List<ChiTietHDNhap> list = new List<ChiTietHDNhap>();
            string query = @"
                SELECT SoHDN, MaQuanAo, SoLuong
                FROM ChiTietHDNhap
                WHERE SoHDN = @SoHDN";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@SoHDN", soHDN);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ChiTietHDNhap ct = new ChiTietHDNhap
                        {
                            SoHDN = reader["SoHDN"].ToString(),
                            MaQuanAo = reader["MaQuanAo"].ToString(),
                            SoLuong = Convert.ToInt32(reader["SoLuong"])
                        };
                        list.Add(ct);
                    }
                }
            }
            return list;
        }


        // Lấy tất cả khách hàng
        public List<KhachHang> GetAllKhachHang()
        {
            List<KhachHang> list = new List<KhachHang>();
            string query = @"
        SELECT MaKhach, TenKhach, DiaChi, DienThoai
        FROM KhachHang";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        KhachHang kh = new KhachHang
                        {
                            MaKhach = reader["MaKhach"].ToString(),
                            TenKhach = reader["TenKhach"].ToString(),
                            DiaChi = reader["DiaChi"].ToString(),
                            DienThoai = reader["DienThoai"].ToString()
                        };
                        list.Add(kh);
                    }
                }
            }
            return list;

        }
    }
}
