using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeThongQuanLyCuaHangQuanAo.Models;
using System.Windows.Forms;
using HeThongQuanLyCuaHangQuanAo.DAL;
using HeThongQuanLyCuaHangQuanAo.ViewModels;

namespace HeThongQuanLyCuaHangQuanAo.BUS
{
    internal class SanPhamBUS
    {
        private SanPhamDAL dal = new SanPhamDAL();

        public List<SanPhamView> GetSanPhamViews()
        {
            return dal.GetSanPhamViews();
        }

        public SanPhamView GetSanPhamViewById(string maQuanAo)
        {
            return dal.GetSanPhamViewById(maQuanAo);
        }

        // Dùng trước khi thêm hoặc cập nhật
        public bool ValidateSanPham(SanPham sp, bool check)
        {
            // Kiểm tra dữ liệu
            if (string.IsNullOrWhiteSpace(sp.MaQuanAo))
                throw new Exception("Mã sản phẩm không được để trống");

            if (string.IsNullOrWhiteSpace(sp.TenQuanAo))
                throw new Exception("Tên sản phẩm không được để trống");

            // Cắt khoảng trắng trước và sau tên sản phẩm
            sp.TenQuanAo = sp.TenQuanAo.Trim();

            if (sp.TenQuanAo.Length > 100)
                throw new Exception("Tên sản phẩm không được vượt quá 100 ký tự");

            if (string.IsNullOrWhiteSpace(sp.DonGiaNhapStr))
                throw new Exception("Đơn giá nhập không được để trống");

            if (string.IsNullOrWhiteSpace(sp.DonGiaBanStr))
                throw new Exception("Đơn giá bán không được để trống");

            // Parse và validate đơn giá nhập
            if (!decimal.TryParse(sp.DonGiaNhapStr, out decimal donGiaNhap))
                throw new Exception("Đơn giá nhập không hợp lệ");

            if (donGiaNhap <= 0)
                throw new Exception("Đơn giá nhập phải lớn hơn 0");

            // Parse và validate đơn giá bán
            if (!decimal.TryParse(sp.DonGiaBanStr, out decimal donGiaBan))
                throw new Exception("Đơn giá bán không hợp lệ");

            if (donGiaBan <= 0)
                throw new Exception("Đơn giá bán phải lớn hơn 0");

            if (donGiaBan <= donGiaNhap)
                throw new Exception("Đơn giá bán phải lớn đơn giá nhập");

            // Gán giá trị đã parse
            sp.DonGiaNhap = donGiaNhap;
            sp.DonGiaBan = donGiaBan;

            if (check)
            {
                // Thêm sản phẩm
                return dal.InsertSanPham(sp);
            }
            else
            {
                // Cập nhật sản phẩm
                return dal.UpdateSanPham(sp);
            }

        }

        public string GenerateNewSanPhamID()
        {
            string latestCode = dal.GetLatestSanPhamID();

            if (string.IsNullOrEmpty(latestCode))
            {
                return "SP0001";
            }

            if (latestCode.Length != 6 || !latestCode.StartsWith("SP"))
            {
                throw new Exception("Cấu trúc mã sản phẩm trong database không hợp lệ");
            }

            string numberPart = latestCode.Substring(2);
            if (int.TryParse(numberPart, out int currentNumber))
            {
                if (currentNumber >= 9999)
                {
                    throw new Exception("Đạt giới hạn mã sản phẩm");
                }
                return $"SP{(currentNumber + 1):0000}";
            }

            throw new Exception("Hẹ hẹ hẹ");
        }

        public SanPham GetSanPhamById(string maQuanAo)
        {
            return dal.GetSanPhamById(maQuanAo);
        }

        public List<SanPhamView> TimKiemSanPham(string tuKhoa)
        {
            return dal.TimKiemSanPham(tuKhoa);
        }
    }
}
