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
    internal class ChiTietHDNhapDAL
    {
        public List<ChiTietHDNhapView> GetChiTietByHDNhapID(string soHDN)
        {
            List<ChiTietHDNhapView> list = new List<ChiTietHDNhapView>();
            string query = @"
        SELECT ct.SoHDN, hdn.NgayNhap, nv.TenNV, ncc.TenNCC, 
               ct.MaQuanAo, sp.TenQuanAo, sp.DonGiaNhap, ct.SoLuong, 
               hdn.GiamGia
        FROM ChiTietHDNhap ct
        JOIN SanPham sp ON ct.MaQuanAo = sp.MaQuanAo
        JOIN HoaDonNhap hdn ON ct.SoHDN = hdn.SoHDN
        JOIN NhanVien nv ON hdn.MaNV = nv.MaNV
        JOIN NhaCungCap ncc ON hdn.MaNCC = ncc.MaNCC
        WHERE ct.SoHDN = @SoHDN";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@SoHDN", soHDN);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ChiTietHDNhapView ctView = new ChiTietHDNhapView
                        {
                            SoHDN = reader["SoHDN"].ToString(),
                            NgayNhap = Convert.ToDateTime(reader["NgayNhap"]),
                            TenNV = reader["TenNV"].ToString(),
                            TenNCC = reader["TenNCC"].ToString(),
                            MaQuanAo = reader["MaQuanAo"].ToString(),
                            TenQuanAo = reader["TenQuanAo"].ToString(),
                            DonGiaNhap = Convert.ToDecimal(reader["DonGiaNhap"]),
                            SoLuong = Convert.ToInt32(reader["SoLuong"]),
                            GiamGia = Convert.ToDecimal(reader["GiamGia"]),
                        };
                        list.Add(ctView);
                    }
                }
            }
            return list;
        }

        public bool InsertChiTietHDNhap(ChiTietHDNhap chiTiet)
        {
            string query = @"
        INSERT INTO ChiTietHDNhap (SoHDN, MaQuanAo, SoLuong)
        VALUES (@SoHDN, @MaQuanAo, @SoLuong)";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@SoHDN", chiTiet.SoHDN);
                cmd.Parameters.AddWithValue("@MaQuanAo", chiTiet.MaQuanAo);
                cmd.Parameters.AddWithValue("@SoLuong", chiTiet.SoLuong);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool InsertChiTietHDNhapList(List<ChiTietHDNhap> chiTietList)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string insertChiTietQuery = @"
                    INSERT INTO ChiTietHDNhap (SoHDN, MaQuanAo, SoLuong)
                    VALUES (@SoHDN, @MaQuanAo, @SoLuong)";

                        foreach (var chiTiet in chiTietList)
                        {
                            using (SqlCommand cmd = new SqlCommand(insertChiTietQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@SoHDN", chiTiet.SoHDN);
                                cmd.Parameters.AddWithValue("@MaQuanAo", chiTiet.MaQuanAo);
                                cmd.Parameters.AddWithValue("@SoLuong", chiTiet.SoLuong);
                                cmd.ExecuteNonQuery();
                            }

                            string updateSanPhamQuery = @"
                        UPDATE SanPham
                        SET SoLuong = SoLuong + @SoLuong
                        WHERE MaQuanAo = @MaQuanAo";

                            using (SqlCommand cmd = new SqlCommand(updateSanPhamQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@SoLuong", chiTiet.SoLuong);
                                cmd.Parameters.AddWithValue("@MaQuanAo", chiTiet.MaQuanAo);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }

        public bool UpdateSanPhamSoLuong(string maQuanAo, int soLuong)
        {
            string query = @"
                UPDATE SanPham
                SET SoLuong = SoLuong + @SoLuong
                WHERE MaQuanAo = @MaQuanAo";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                cmd.Parameters.AddWithValue("@MaQuanAo", maQuanAo);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        public decimal TinhTongTien(string soHDN)
        {
            decimal tongTien = 0;
            string query = @"
                SELECT SUM(sp.DonGiaNhap * ct.SoLuong) AS TongTien
                FROM ChiTietHDNhap ct
                JOIN SanPham sp ON ct.MaQuanAo = sp.MaQuanAo
                WHERE ct.SoHDN = @SoHDN";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@SoHDN", soHDN);
                conn.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    tongTien = Convert.ToDecimal(result);
                }
            }
            return tongTien;
        }
    }
}
