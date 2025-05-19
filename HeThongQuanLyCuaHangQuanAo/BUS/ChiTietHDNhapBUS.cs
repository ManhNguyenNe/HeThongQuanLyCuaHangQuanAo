using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeThongQuanLyCuaHangQuanAo.DAL;
using HeThongQuanLyCuaHangQuanAo.Models;
using HeThongQuanLyCuaHangQuanAo.ViewModels;

namespace HeThongQuanLyCuaHangQuanAo.BUS
{
    internal class ChiTietHDNhapBUS
    {
        private readonly ChiTietHDNhapDAL _dal = new ChiTietHDNhapDAL();
        private readonly SanPhamBUS _sanPhamBUS = new SanPhamBUS();

        public List<ChiTietHDNhapView> GetChiTietByHDNhapID(string soHDN)
        {
            return _dal.GetChiTietByHDNhapID(soHDN);
        }

        public bool ThemChiTietHDNhap(ChiTietHDNhap chiTiet)
        {
            try
            {
                if (string.IsNullOrEmpty(chiTiet.SoHDN))
                    throw new Exception("Số hóa đơn không được để trống");

                if (string.IsNullOrEmpty(chiTiet.MaQuanAo))
                    throw new Exception("Mã sản phẩm không được để trống");

                if (chiTiet.SoLuong <= 0)
                    throw new Exception("Số lượng phải lớn hơn 0");

                // Kiểm tra số lượng tồn
                var sanPham = _sanPhamBUS.GetSanPhamById(chiTiet.MaQuanAo);
                if (sanPham == null)
                    throw new Exception("Sản phẩm không tồn tại");

                //if (sanPham.SoLuong < chiTiet.SoLuong)
                //    throw new Exception($"Số lượng sản phẩm '{sanPham.TenQuanAo}' trong kho không đủ. Hiện chỉ còn {sanPham.SoLuong}");

                chiTiet.ThanhTien = sanPham.DonGiaBan * chiTiet.SoLuong;

                return _dal.InsertChiTietHDNhap(chiTiet);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ThemNhieuChiTietHDNhap(List<ChiTietHDNhap> chiTietList)
        {
            try
            {
                if (chiTietList == null || chiTietList.Count == 0)
                    throw new Exception("Danh sách chi tiết hóa đơn không được để trống");

                foreach (var chiTiet in chiTietList)
                {
                    if (string.IsNullOrEmpty(chiTiet.SoHDN))
                        throw new Exception("Số hóa đơn không được để trống");

                    if (string.IsNullOrEmpty(chiTiet.MaQuanAo))
                        throw new Exception("Mã sản phẩm không được để trống");

                    if (chiTiet.SoLuong <= 0)
                        throw new Exception("Số lượng phải lớn hơn 0");

                    var sanPham = _sanPhamBUS.GetSanPhamById(chiTiet.MaQuanAo);
                    if (sanPham == null)
                        throw new Exception("Sản phẩm không tồn tại");

                    //if (sanPham.SoLuong < chiTiet.SoLuong)
                    //    throw new Exception($"Số lượng sản phẩm '{sanPham.TenQuanAo}' trong kho không đủ. Hiện chỉ còn {sanPham.SoLuong}");

                    chiTiet.ThanhTien = sanPham.DonGiaBan * chiTiet.SoLuong;
                }

                return _dal.InsertChiTietHDNhapList(chiTietList);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public decimal TinhTongTien(string soHDN)
        {
            return _dal.TinhTongTien(soHDN);
        }

        public decimal TinhThanhTien(decimal donGia, int soLuong)
        {
            return donGia * soLuong;
        }
    }
}
