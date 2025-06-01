using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeThongQuanLyCuaHangQuanAo.BUS;
using System.Windows.Forms;
using HeThongQuanLyCuaHangQuanAo.Models;
using HeThongQuanLyCuaHangQuanAo.ViewModels;
using MaterialSkin.Controls;

namespace HeThongQuanLyCuaHangQuanAo.DAL
{
    internal class SanPhamDAL
    {
        public List<SanPhamView> GetSanPhamViews()
        {
            List<SanPhamView> list = new List<SanPhamView>();

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = @"
            SELECT sp.MaQuanAo, sp.TenQuanAo, sp.SoLuong, sp.Anh, sp.DonGiaBan, sp.DonGiaNhap,
                   tl.TenLoai, c.TenCo, cl.TenChatLieu, m.TenMau, dt.TenDoiTuong, mu.TenMua, nsx.TenNSX
            FROM SanPham sp
            JOIN TheLoai tl ON sp.MaLoai = tl.MaLoai
            JOIN Co c ON sp.MaCo = c.MaCo
            JOIN ChatLieu cl ON sp.MaChatLieu = cl.MaChatLieu
            JOIN Mau m ON sp.MaMau = m.MaMau
            JOIN DoiTuong dt ON sp.MaDoiTuong = dt.MaDoiTuong
            JOIN Mua mu ON sp.MaMua = mu.MaMua
            JOIN NoiSanXuat nsx ON sp.MaNSX = nsx.MaNSX";

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        SanPhamView spv = new SanPhamView
                        {
                            MaQuanAo = reader["MaQuanAo"].ToString(),
                            TenQuanAo = reader["TenQuanAo"].ToString(),
                            TenLoai = reader["TenLoai"].ToString(),
                            TenCo = reader["TenCo"].ToString(),
                            TenChatLieu = reader["TenChatLieu"].ToString(),
                            TenMau = reader["TenMau"].ToString(),
                            TenDoiTuong = reader["TenDoiTuong"].ToString(),
                            TenMua = reader["TenMua"].ToString(),
                            TenNSX = reader["TenNSX"].ToString(),
                            SoLuong = Convert.ToInt32(reader["SoLuong"]),
                            Anh = reader["Anh"].ToString(),
                            DonGiaBan = Convert.ToDecimal(reader["DonGiaBan"]),
                            DonGiaNhap = Convert.ToDecimal(reader["DonGiaNhap"]),
                        };

                        list.Add(spv);
                    }
                }
            }

            return list;
        }

        public SanPhamView GetSanPhamViewById(string maQuanAo)
        {
            SanPhamView spView = null;
            string query = @"
        SELECT 
            sp.MaQuanAo,
            sp.TenQuanAo,
            l.TenLoai,
            c.TenCo,
            cl.TenChatLieu,
            m.TenMau,
            dt.TenDoiTuong,
            mu.TenMua,
            nsx.TenNSX,
            sp.SoLuong,
            sp.Anh,
            sp.DonGiaBan,
            sp.DonGiaNhap
        FROM SanPham sp
        JOIN TheLoai l ON sp.MaLoai = l.MaLoai
        JOIN Co c ON sp.MaCo = c.MaCo
        JOIN ChatLieu cl ON sp.MaChatLieu = cl.MaChatLieu
        JOIN Mau m ON sp.MaMau = m.MaMau
        JOIN DoiTuong dt ON sp.MaDoiTuong = dt.MaDoiTuong
        JOIN Mua mu ON sp.MaMua = mu.MaMua
        JOIN NoiSanXuat nsx ON sp.MaNSX = nsx.MaNSX
        WHERE sp.MaQuanAo = @MaQuanAo";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaQuanAo", maQuanAo);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        spView = new SanPhamView
                        {
                            MaQuanAo = reader["MaQuanAo"].ToString(),
                            TenQuanAo = reader["TenQuanAo"].ToString(),
                            TenLoai = reader["TenLoai"].ToString(),
                            TenCo = reader["TenCo"].ToString(),
                            TenChatLieu = reader["TenChatLieu"].ToString(),
                            TenMau = reader["TenMau"].ToString(),
                            TenDoiTuong = reader["TenDoiTuong"].ToString(),
                            TenMua = reader["TenMua"].ToString(),
                            TenNSX = reader["TenNSX"].ToString(),
                            SoLuong = Convert.ToInt32(reader["SoLuong"]),
                            Anh = reader["Anh"].ToString(),
                            DonGiaBan = Convert.ToDecimal(reader["DonGiaBan"]),
                            DonGiaNhap = Convert.ToDecimal(reader["DonGiaNhap"])
                        };
                    }
                }
            }

            return spView;
        }

        public bool InsertSanPham(SanPham sp)
        {
            string query = @"
                INSERT INTO SanPham (
                    MaQuanAo, TenQuanAo, MaLoai, MaCo, MaChatLieu, 
                    MaMau, MaDoiTuong, MaMua, MaNSX, SoLuong, 
                    Anh, DonGiaNhap, DonGiaBan
                ) VALUES (
                    @MaQuanAo, @TenQuanAo, @MaLoai, @MaCo, @MaChatLieu,
                    @MaMau, @MaDoiTuong, @MaMua, @MaNSX, 0,
                    @Anh, @DonGiaNhap, @DonGiaBan
                )";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaQuanAo", sp.MaQuanAo);
                cmd.Parameters.AddWithValue("@TenQuanAo", sp.TenQuanAo);
                cmd.Parameters.AddWithValue("@MaLoai", sp.MaLoai);
                cmd.Parameters.AddWithValue("@MaCo", sp.MaCo);
                cmd.Parameters.AddWithValue("@MaChatLieu", sp.MaChatLieu);
                cmd.Parameters.AddWithValue("@MaMau", sp.MaMau);
                cmd.Parameters.AddWithValue("@MaDoiTuong", sp.MaDoiTuong);
                cmd.Parameters.AddWithValue("@MaMua", sp.MaMua);
                cmd.Parameters.AddWithValue("@MaNSX", sp.MaNSX);
                cmd.Parameters.AddWithValue("@Anh", sp.Anh);
                cmd.Parameters.AddWithValue("@DonGiaNhap", sp.DonGiaNhap);
                cmd.Parameters.AddWithValue("@DonGiaBan", sp.DonGiaBan);

                try
                {
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi thêm sản phẩm: " + ex.Message);
                }
            }
        }

        public string GetLatestSanPhamID()
        {
            string query = "SELECT TOP 1 MaQuanAo FROM SanPham WHERE MaQuanAo LIKE 'SP%' ORDER BY MaQuanAo DESC";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                object result = cmd.ExecuteScalar();
                return result?.ToString();
            }
        }

        public SanPham GetSanPhamById(string maQuanAo)
        {
            SanPham sanPham = null;
            string query = @"
        SELECT 
            MaQuanAo, TenQuanAo, MaLoai, MaCo, MaChatLieu, 
            MaMau, MaDoiTuong, MaMua, MaNSX, SoLuong, 
            Anh, DonGiaNhap, DonGiaBan
        FROM SanPham
        WHERE MaQuanAo = @MaQuanAo";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaQuanAo", maQuanAo);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        sanPham = new SanPham
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
                    }
                }
            }

            return sanPham;
        }

        public bool UpdateSanPham(SanPham sp)
        {
            string query = @"
        UPDATE SanPham 
        SET TenQuanAo = @TenQuanAo,
            MaLoai = @MaLoai,
            MaCo = @MaCo,
            MaChatLieu = @MaChatLieu,
            MaMau = @MaMau,
            MaDoiTuong = @MaDoiTuong,
            MaMua = @MaMua,
            MaNSX = @MaNSX,
            Anh = @Anh,
            DonGiaNhap = @DonGiaNhap,
            DonGiaBan = @DonGiaBan
        WHERE MaQuanAo = @MaQuanAo";

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaQuanAo", sp.MaQuanAo);
                cmd.Parameters.AddWithValue("@TenQuanAo", sp.TenQuanAo);
                cmd.Parameters.AddWithValue("@MaLoai", sp.MaLoai);
                cmd.Parameters.AddWithValue("@MaCo", sp.MaCo);
                cmd.Parameters.AddWithValue("@MaChatLieu", sp.MaChatLieu);
                cmd.Parameters.AddWithValue("@MaMau", sp.MaMau);
                cmd.Parameters.AddWithValue("@MaDoiTuong", sp.MaDoiTuong);
                cmd.Parameters.AddWithValue("@MaMua", sp.MaMua);
                cmd.Parameters.AddWithValue("@MaNSX", sp.MaNSX);
                cmd.Parameters.AddWithValue("@Anh", sp.Anh);
                cmd.Parameters.AddWithValue("@DonGiaNhap", sp.DonGiaNhap);
                cmd.Parameters.AddWithValue("@DonGiaBan", sp.DonGiaBan);

                try
                {
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi cập nhật sản phẩm: " + ex.Message);
                }
            }
        }


        public List<SanPhamView> TimKiemSanPham(string tuKhoa)
        {
            List<SanPhamView> list = new List<SanPhamView>();

            using (SqlConnection conn = DBHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = @"
            SELECT sp.MaQuanAo, sp.TenQuanAo, sp.SoLuong, sp.Anh, sp.DonGiaBan,
                   tl.TenLoai, c.TenCo, cl.TenChatLieu, m.TenMau, dt.TenDoiTuong, mu.TenMua, nsx.TenNSX
            FROM SanPham sp
            JOIN TheLoai tl ON sp.MaLoai = tl.MaLoai
            JOIN Co c ON sp.MaCo = c.MaCo
            JOIN ChatLieu cl ON sp.MaChatLieu = cl.MaChatLieu
            JOIN Mau m ON sp.MaMau = m.MaMau
            JOIN DoiTuong dt ON sp.MaDoiTuong = dt.MaDoiTuong
            JOIN Mua mu ON sp.MaMua = mu.MaMua
            JOIN NoiSanXuat nsx ON sp.MaNSX = nsx.MaNSX
            WHERE
                sp.MaQuanAo LIKE @TuKhoa OR
                sp.TenQuanAo LIKE @TuKhoa OR
                tl.TenLoai LIKE @TuKhoa OR
                c.TenCo LIKE @TuKhoa OR
                cl.TenChatLieu LIKE @TuKhoa OR
                m.TenMau LIKE @TuKhoa";

                cmd.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        SanPhamView spv = new SanPhamView
                        {
                            MaQuanAo = reader["MaQuanAo"].ToString(),
                            TenQuanAo = reader["TenQuanAo"].ToString(),
                            TenLoai = reader["TenLoai"].ToString(),
                            TenCo = reader["TenCo"].ToString(),
                            TenChatLieu = reader["TenChatLieu"].ToString(),
                            TenMau = reader["TenMau"].ToString(),
                            TenDoiTuong = reader["TenDoiTuong"].ToString(),
                            TenMua = reader["TenMua"].ToString(),
                            TenNSX = reader["TenNSX"].ToString(),
                            SoLuong = Convert.ToInt32(reader["SoLuong"]),
                            Anh = reader["Anh"].ToString(),
                            DonGiaBan = Convert.ToDecimal(reader["DonGiaBan"]),
                        };

                        list.Add(spv);
                    }
                }
            }
            return list;
        }

    }
}

