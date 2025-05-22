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
    internal class HDNhapBUS
    {
        private readonly HDNhapDAL _hoaDonNhapDAL = new HDNhapDAL();
        private readonly ChiTietHDNhapDAL _chiTietHDNhapDAL = new ChiTietHDNhapDAL();
        private readonly SanPhamBUS _sanPhamBUS = new SanPhamBUS();

        public List<HDNhapView> GetAllHDNhap()
        {
            return _hoaDonNhapDAL.GetAllHDNhap();
        }

        public bool TaoHoaDonNhap(string maNV, string maNCC, decimal giamGia, List<ChiTietHDNhap> chiTietList)
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(maNV))
                    throw new Exception("Mã nhân viên không được để trống");

                if (string.IsNullOrEmpty(maNCC))
                    throw new Exception("Mã nhà cung cấp không được để trống");

                if (chiTietList == null || chiTietList.Count == 0)
                    throw new Exception("Danh sách chi tiết hóa đơn không được để trống");

                if (giamGia < 0 || giamGia > 100)
                    throw new Exception("Giảm giá phải nằm trong khoảng từ 0 đến 100%");

                // Tạo mã hóa đơn mới nếu chưa có
                string soHDN = chiTietList[0].SoHDN;
                if (string.IsNullOrEmpty(soHDN))
                {
                    soHDN = GenerateNewHDNhapID();
                    foreach (var chiTiet in chiTietList)
                    {
                        chiTiet.SoHDN = soHDN;
                    }
                }

                // Tính tổng tiền trước khi giảm giá
                decimal tongTienTruocGiam = 0;
                foreach (var chiTiet in chiTietList)
                {
                    var sanPham = _sanPhamBUS.GetSanPhamById(chiTiet.MaQuanAo);
                    if (sanPham == null)
                        throw new Exception($"Không tìm thấy thông tin sản phẩm {chiTiet.MaQuanAo}");
                    
                    tongTienTruocGiam += sanPham.DonGiaNhap * chiTiet.SoLuong;
                }

                // Áp dụng giảm giá cho toàn bộ hóa đơn
                decimal tongTienSauGiam = tongTienTruocGiam * (1 - giamGia / 100);

                // Tạo hóa đơn
                HoaDonNhap hoaDon = new HoaDonNhap
                {
                    SoHDN = soHDN,
                    MaNV = maNV,
                    NgayNhap = DateTime.Now,
                    MaNCC = maNCC,
                    GiamGia = giamGia,
                    TongTien = tongTienSauGiam
                };

                // Lưu hóa đơn
                bool success = _hoaDonNhapDAL.InsertHoaDonNhap(hoaDon);
                if (!success)
                    return false;

                // Lưu chi tiết hóa đơn
                success = _chiTietHDNhapDAL.InsertChiTietHDNhapList(chiTietList);

                return success;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<HDNhapView> TimKiemHDNhap(string tuKhoa)
        {
            return _hoaDonNhapDAL.SearchHDNhap(tuKhoa);
        }

        public string GenerateNewHDNhapID()
        {
            string latestID = _hoaDonNhapDAL.GetLatestHDNhapID();

            if (string.IsNullOrEmpty(latestID))
            {
                return "HDN0001";
            }

            if (latestID.Length != 7 || !latestID.StartsWith("HDN"))
            {
                throw new Exception("Cấu trúc mã hóa đơn trong database không hợp lệ");
            }

            string numberPart = latestID.Substring(3);
            if (int.TryParse(numberPart, out int currentNumber))
            {
                if (currentNumber >= 9999)
                {
                    throw new Exception("Đạt giới hạn mã hóa đơn");
                }
                return $"HDN{(currentNumber + 1):0000}";
            }

            throw new Exception("Mã hóa đơn không hợp lệ");
        }
    }
}
