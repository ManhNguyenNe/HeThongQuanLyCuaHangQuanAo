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
    internal class HDBanBUS
    {
        private readonly HDBanDAL _hoaDonBanDAL = new HDBanDAL();
        private readonly ChiTietHDBanDAL _chiTietHDBanDAL = new ChiTietHDBanDAL();

        // Lấy tất cả hóa đơn bán
        public List<HDBanView> GetAllHDBan()
        {
            return _hoaDonBanDAL.GetAllHDBan();
        }

        // Tạo hóa đơn bán mới
        public bool TaoHoaDonBan(string maNV, string maKhach, decimal giamGia, List<ChiTietHDBan> chiTietList)
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(maNV))
                    throw new Exception("Mã nhân viên không được để trống");

                if (string.IsNullOrEmpty(maKhach))
                    throw new Exception("Mã khách hàng không được để trống");

                if (chiTietList == null || chiTietList.Count == 0)
                    throw new Exception("Danh sách chi tiết hóa đơn không được để trống");

                if (giamGia < 0 || giamGia > 100)
                    throw new Exception("Giảm giá phải nằm trong khoảng từ 0 đến 100%");

                // Tạo mã hóa đơn mới nếu chưa có
                string soHDB = chiTietList[0].SoHDB;
                if (string.IsNullOrEmpty(soHDB))
                {
                    soHDB = GenerateNewHDBanID();
                    foreach (var chiTiet in chiTietList)
                    {
                        chiTiet.SoHDB = soHDB;
                    }
                }

                // Tính tổng tiền trước khi giảm giá
                decimal tongTienTruocGiam = 0;
                foreach (var chiTiet in chiTietList)
                {
                    tongTienTruocGiam += chiTiet.ThanhTien;
                }

                // Áp dụng giảm giá cho toàn bộ hóa đơn
                decimal tongTienSauGiam = tongTienTruocGiam * (1 - giamGia / 100);

                // Tạo hóa đơn
                HoaDonBan hoaDon = new HoaDonBan
                {
                    SoHDB = soHDB,
                    MaNV = maNV,
                    NgayBan = DateTime.Now,
                    MaKhach = maKhach,
                    GiamGia = giamGia,
                    TongTien = tongTienSauGiam
                };

                // Lưu hóa đơn
                bool success = _hoaDonBanDAL.InsertHoaDonBan(hoaDon);
                if (!success)
                    return false;

                // Lưu chi tiết hóa đơn
                success = _chiTietHDBanDAL.InsertChiTietHDBanList(chiTietList);

                return success;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Tìm kiếm hóa đơn bán
        public List<HDBanView> TimKiemHDBan(string tuKhoa)
        {
            return _hoaDonBanDAL.SearchHDBan(tuKhoa);
        }

        // Tạo mã hóa đơn bán mới
        public string GenerateNewHDBanID()
        {
            string latestID = _hoaDonBanDAL.GetLatestHDBanID();

            if (string.IsNullOrEmpty(latestID))
            {
                return "HDB0001";
            }

            if (latestID.Length != 7 || !latestID.StartsWith("HDB"))
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
                return $"HDB{(currentNumber + 1):0000}";
            }

            throw new Exception("Mã hóa đơn không hợp lệ");
        }
    }
}
