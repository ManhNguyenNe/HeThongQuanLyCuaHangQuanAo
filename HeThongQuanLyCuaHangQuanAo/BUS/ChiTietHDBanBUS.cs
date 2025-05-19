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
    internal class ChiTietHDBanBUS
    {
        private readonly ChiTietHDBanDAL _dal = new ChiTietHDBanDAL();
        private readonly SanPhamBUS _sanPhamBUS = new SanPhamBUS();

        // Lấy chi tiết hóa đơn bán theo số hóa đơn
        public List<ChiTietHDBanView> GetChiTietByHDBanID(string soHDB)
        {
            return _dal.GetChiTietByHDBanID(soHDB);
        }

        // Thêm chi tiết hóa đơn bán
        public bool ThemChiTietHDBan(ChiTietHDBan chiTiet)
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(chiTiet.SoHDB))
                    throw new Exception("Số hóa đơn không được để trống");

                if (string.IsNullOrEmpty(chiTiet.MaQuanAo))
                    throw new Exception("Mã sản phẩm không được để trống");

                if (chiTiet.SoLuong <= 0)
                    throw new Exception("Số lượng phải lớn hơn 0");

                // Kiểm tra số lượng tồn
                var sanPham = _sanPhamBUS.GetSanPhamById(chiTiet.MaQuanAo);
                if (sanPham == null)
                    throw new Exception("Sản phẩm không tồn tại");

                if (sanPham.SoLuong < chiTiet.SoLuong)
                    throw new Exception($"Số lượng sản phẩm '{sanPham.TenQuanAo}' trong kho không đủ. Hiện chỉ còn {sanPham.SoLuong}");

                // Tính thành tiền
                chiTiet.ThanhTien = sanPham.DonGiaBan * chiTiet.SoLuong;

                // Thêm chi tiết hóa đơn
                return _dal.InsertChiTietHDBan(chiTiet);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Thêm nhiều chi tiết hóa đơn bán
        public bool ThemNhieuChiTietHDBan(List<ChiTietHDBan> chiTietList)
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào
                if (chiTietList == null || chiTietList.Count == 0)
                    throw new Exception("Danh sách chi tiết hóa đơn không được để trống");

                // Kiểm tra số lượng tồn cho từng sản phẩm
                foreach (var chiTiet in chiTietList)
                {
                    if (string.IsNullOrEmpty(chiTiet.SoHDB))
                        throw new Exception("Số hóa đơn không được để trống");

                    if (string.IsNullOrEmpty(chiTiet.MaQuanAo))
                        throw new Exception("Mã sản phẩm không được để trống");

                    if (chiTiet.SoLuong <= 0)
                        throw new Exception("Số lượng phải lớn hơn 0");

                    var sanPham = _sanPhamBUS.GetSanPhamById(chiTiet.MaQuanAo);
                    if (sanPham == null)
                        throw new Exception("Sản phẩm không tồn tại");

                    if (sanPham.SoLuong < chiTiet.SoLuong)
                        throw new Exception($"Số lượng sản phẩm '{sanPham.TenQuanAo}' trong kho không đủ. Hiện chỉ còn {sanPham.SoLuong}");

                    // Tính thành tiền cho từng chi tiết
                    chiTiet.ThanhTien = sanPham.DonGiaBan * chiTiet.SoLuong;
                }

                // Thêm chi tiết hóa đơn
                return _dal.InsertChiTietHDBanList(chiTietList);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Tính tổng tiền của một hóa đơn
        public decimal TinhTongTien(string soHDB)
        {
            return _dal.TinhTongTien(soHDB);
        }

        // Tính thành tiền cho một chi tiết hóa đơn
        public decimal TinhThanhTien(decimal donGia, int soLuong)
        {
            return donGia * soLuong;
        }
    }
}
