using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeThongQuanLyCuaHangQuanAo.DAL;
using HeThongQuanLyCuaHangQuanAo.Models;
using System.Windows.Forms;

namespace HeThongQuanLyCuaHangQuanAo.BUS
{
    internal class KhachHangBUS
    {
        private KhachHangDAL dal = new KhachHangDAL();

        public List<KhachHang> GetAll()
        {
            return dal.GetAllKhachHang();
        }

        public KhachHang GetById(string maKhach)
        {
            return dal.GetKhachHangById(maKhach);
        }

        public bool Add(string tenKhach, string diaChi, string dienThoai)
        {
            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(tenKhach))
            {
                MessageBox.Show("Tên khách hàng không được để trống!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //if (string.IsNullOrEmpty(diaChi))
            //{
            //    MessageBox.Show("Địa chỉ không được để trống!", "Lỗi",
            //        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}

            if (string.IsNullOrEmpty(dienThoai))
            {
                MessageBox.Show("Số điện thoại không được để trống!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra số điện thoại hợp lệ
            if (!IsValidPhoneNumber(dienThoai))
            {
                MessageBox.Show("Số điện thoại không hợp lệ!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra xem số điện thoại đã tồn tại chưa
            var danhSachKhachHang = GetAll();
            if (danhSachKhachHang.Any(kh => kh.DienThoai == dienThoai))
            {
                MessageBox.Show("Số điện thoại đã tồn tại trong hệ thống!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Tạo mã khách hàng mới
            string maKhach = GenerateNewID();

            // Thêm khách hàng mới
            return dal.InsertKhachHang(new KhachHang
            {
                MaKhach = maKhach,
                TenKhach = tenKhach,
                DiaChi = diaChi,
                DienThoai = dienThoai
            });
        }

        public bool Update(string maKhach, string tenKhach, string diaChi, string dienThoai)
        {
            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(maKhach))
            {
                MessageBox.Show("Mã khách hàng không được để trống!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(tenKhach))
            {
                MessageBox.Show("Tên khách hàng không được để trống!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(dienThoai))
            {
                MessageBox.Show("Số điện thoại không được để trống!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra số điện thoại hợp lệ
            if (!IsValidPhoneNumber(dienThoai))
            {
                MessageBox.Show("Số điện thoại không hợp lệ!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra xem số điện thoại đã tồn tại chưa (trừ khách hàng hiện tại)
            var danhSachKhachHang = GetAll();
            if (danhSachKhachHang.Any(kh => kh.DienThoai == dienThoai && kh.MaKhach != maKhach))
            {
                MessageBox.Show("Số điện thoại đã tồn tại trong hệ thống!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Cập nhật khách hàng
            return dal.UpdateKhachHang(new KhachHang
            {
                MaKhach = maKhach,
                TenKhach = tenKhach,
                DiaChi = diaChi,
                DienThoai = dienThoai
            });
        }

        public List<KhachHang> TimKiem(string tuKhoa)
        {
            if (string.IsNullOrEmpty(tuKhoa))
                return GetAll();

            return dal.TimKiemKhachHang(tuKhoa);
        }

        private string GenerateNewID()
        {
            // Lấy danh sách khách hàng hiện có
            var danhSachKhachHang = GetAll();

            if (danhSachKhachHang.Count == 0)
                return "KH001";

            // Tìm mã lớn nhất
            int maxID = 0;
            foreach (var khachHang in danhSachKhachHang)
            {
                if (khachHang.MaKhach.StartsWith("KH"))
                {
                    if (int.TryParse(khachHang.MaKhach.Substring(2), out int id))
                    {
                        if (id > maxID)
                            maxID = id;
                    }
                }
            }

            // Tạo mã mới
            return $"KH{(maxID + 1):D3}";
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // Kiểm tra số điện thoại chỉ chứa số và có độ dài hợp lệ (10-11 số)
            return System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, @"^\d{10}$");
        }
    }
}
