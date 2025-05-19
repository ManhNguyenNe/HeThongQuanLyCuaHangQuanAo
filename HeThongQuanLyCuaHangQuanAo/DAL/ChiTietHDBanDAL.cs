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
    internal class ChiTietHDBanDAL
    {
        // Lấy chi tiết hóa đơn bán theo số hóa đơn
        public List<ChiTietHDBanView> GetChiTietByHDBanID(string soHDB)
        {
            List<ChiTietHDBanView> list = new List<ChiTietHDBanView>();
            string query = @"
        SELECT ct.SoHDB, hdb.NgayBan, nv.TenNV, kh.TenKhach, 
               ct.MaQuanAo, sp.TenQuanAo, sp.DonGiaBan, ct.SoLuong, 
               hdb.GiamGia, ct.ThanhTien
        FROM ChiTietHDBan ct
        JOIN SanPham sp ON ct.MaQuanAo = sp.MaQuanAo
        JOIN HoaDonBan hdb ON ct.SoHDB = hdb.SoHDB
        JOIN NhanVien nv ON hdb.MaNV = nv.MaNV
        JOIN KhachHang kh ON hdb.MaKhach = kh.MaKhach
        WHERE ct.SoHDB = @SoHDB";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@SoHDB", soHDB);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ChiTietHDBanView ctView = new ChiTietHDBanView
                        {
                            SoHDB = reader["SoHDB"].ToString(),
                            NgayBan = Convert.ToDateTime(reader["NgayBan"]),
                            TenNV = reader["TenNV"].ToString(),
                            TenKhach = reader["TenKhach"].ToString(),
                            MaQuanAo = reader["MaQuanAo"].ToString(),
                            TenQuanAo = reader["TenQuanAo"].ToString(),
                            DonGiaBan = Convert.ToDecimal(reader["DonGiaBan"]),
                            SoLuong = Convert.ToInt32(reader["SoLuong"]),
                            GiamGia = Convert.ToDecimal(reader["GiamGia"]),
                            ThanhTien = Convert.ToDecimal(reader["ThanhTien"])
                        };
                        list.Add(ctView);
                    }
                }
            }
            return list;
        }

        // Thêm chi tiết hóa đơn bán
        public bool InsertChiTietHDBan(ChiTietHDBan chiTiet)
        {
            string query = @"
        INSERT INTO ChiTietHDBan (SoHDB, MaQuanAo, SoLuong, ThanhTien)
        VALUES (@SoHDB, @MaQuanAo, @SoLuong, @ThanhTien)";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@SoHDB", chiTiet.SoHDB);
                cmd.Parameters.AddWithValue("@MaQuanAo", chiTiet.MaQuanAo);
                cmd.Parameters.AddWithValue("@SoLuong", chiTiet.SoLuong);
                cmd.Parameters.AddWithValue("@ThanhTien", chiTiet.ThanhTien);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        // Thêm nhiều chi tiết hóa đơn bán trong một transaction
        public bool InsertChiTietHDBanList(List<ChiTietHDBan> chiTietList)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string insertChiTietQuery = @"
                    INSERT INTO ChiTietHDBan (SoHDB, MaQuanAo, SoLuong, ThanhTien)
                    VALUES (@SoHDB, @MaQuanAo, @SoLuong, @ThanhTien)";

                        foreach (var chiTiet in chiTietList)
                        {
                            using (SqlCommand cmd = new SqlCommand(insertChiTietQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@SoHDB", chiTiet.SoHDB);
                                cmd.Parameters.AddWithValue("@MaQuanAo", chiTiet.MaQuanAo);
                                cmd.Parameters.AddWithValue("@SoLuong", chiTiet.SoLuong);
                                cmd.Parameters.AddWithValue("@ThanhTien", chiTiet.ThanhTien);
                                cmd.ExecuteNonQuery();
                            }

                            // Cập nhật số lượng sản phẩm
                            string updateSanPhamQuery = @"
                        UPDATE SanPham
                        SET SoLuong = SoLuong - @SoLuong
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

        // Cập nhật số lượng sản phẩm sau khi bán
        public bool UpdateSanPhamSoLuong(string maQuanAo, int soLuong)
        {
            string query = @"
                UPDATE SanPham
                SET SoLuong = SoLuong - @SoLuong
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

        // Tính tổng tiền của một hóa đơn
        public decimal TinhTongTien(string soHDB)
        {
            decimal tongTien = 0;
            string query = @"
                SELECT SUM(ThanhTien) AS TongTien
                FROM ChiTietHDBan
                WHERE SoHDB = @SoHDB";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@SoHDB", soHDB);
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
