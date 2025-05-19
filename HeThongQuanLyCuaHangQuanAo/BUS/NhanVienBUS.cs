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
    internal class NhanVienBUS
    {
        private NhanVienDAL dal = new NhanVienDAL();

        public List<NhanVien> GetAll()
        {
            return dal.GetAllNhanVien();
        }

        public NhanVien GetById(string maNV)
        {
            return dal.GetNhanVienById(maNV);
        }

        public bool ValidateNhanVien(NhanVien nv, bool isAdd)
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào
                if (!isAdd && string.IsNullOrEmpty(nv.MaNV))
                    throw new Exception("Mã nhân viên không được để trống!");

                if (string.IsNullOrEmpty(nv.TenNV))
                    throw new Exception("Tên nhân viên không được để trống!");

                // Cắt khoảng trắng trước và sau tên nhân viên
                nv.TenNV = nv.TenNV.Trim();

                if (nv.TenNV.Length > 100)
                    throw new Exception("Tên nhân viên không được vượt quá 100 ký tự!");

                if (string.IsNullOrEmpty(nv.GioiTinh))
                    throw new Exception("Giới tính không được để trống!");

                if (nv.NgaySinh == DateTime.MinValue)
                    throw new Exception("Ngày sinh không hợp lệ!");

                // Kiểm tra tuổi (ví dụ: phải từ 18 tuổi trở lên)
                int tuoi = DateTime.Now.Year - nv.NgaySinh.Year;
                if (DateTime.Now.DayOfYear < nv.NgaySinh.DayOfYear)
                    tuoi--;

                if (tuoi < 18)
                    throw new Exception("Nhân viên phải đủ 18 tuổi trở lên!");

                if (string.IsNullOrEmpty(nv.DienThoai))
                    throw new Exception("Số điện thoại không được để trống!");

                // Kiểm tra số điện thoại hợp lệ
                if (!IsValidPhoneNumber(nv.DienThoai))
                    throw new Exception("Số điện thoại phải có đúng 10 chữ số!");

                if (string.IsNullOrEmpty(nv.MaCV))
                    throw new Exception("Vui lòng chọn công việc cho nhân viên!");

                //if (!isAdd && string.IsNullOrEmpty(nv.TinhTrang))
                //    throw new Exception("Tình trạng không được để trống!");

                // Kiểm tra xem số điện thoại đã tồn tại chưa
                var danhSachNhanVien = GetAll();
                if (isAdd)
                {
                    if (danhSachNhanVien.Any(x => x.DienThoai == nv.DienThoai))
                        throw new Exception("Số điện thoại đã tồn tại trong hệ thống!");

                    // Tạo mã nhân viên mới nếu là thêm mới
                    nv.MaNV = GenerateNewID();

                    // Đặt tình trạng mặc định là "Đang làm" nếu là thêm mới
                    nv.TinhTrang = "Đang làm";

                    // Thêm nhân viên mới
                    return dal.InsertNhanVien(nv);
                }
                else
                {
                    if (danhSachNhanVien.Any(x => x.DienThoai == nv.DienThoai && x.MaNV != nv.MaNV))
                        throw new Exception("Số điện thoại đã tồn tại trong hệ thống!");

                    // Cập nhật nhân viên
                    return dal.UpdateNhanVien(nv);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        // Phương thức Add mới sử dụng ValidateNhanVien
        public bool Add(string tenNV, string gioiTinh, DateTime ngaySinh, string dienThoai, string diaChi, string maCV)
        {
            var nhanVien = new NhanVien
            {
                TenNV = tenNV,
                GioiTinh = gioiTinh,
                NgaySinh = ngaySinh,
                DienThoai = dienThoai,
                DiaChi = diaChi,
                MaCV = maCV
            };

            return ValidateNhanVien(nhanVien, true);
        }

        // Phương thức Update mới sử dụng ValidateNhanVien
        public bool Update(string maNV, string tenNV, string gioiTinh, DateTime ngaySinh, string dienThoai, string diaChi, string maCV, string tinhTrang)
        {
            var nhanVien = new NhanVien
            {
                MaNV = maNV,
                TenNV = tenNV,
                GioiTinh = gioiTinh,
                NgaySinh = ngaySinh,
                DienThoai = dienThoai,
                DiaChi = diaChi,
                MaCV = maCV,
                TinhTrang = tinhTrang
            };

            return ValidateNhanVien(nhanVien, false);
        }

        //public bool UpdateTinhTrang(string maNV, string tinhTrang)
        //{
        //    if (string.IsNullOrEmpty(maNV))
        //    {
        //        MessageBox.Show("Mã nhân viên không được để trống!", "Lỗi",
        //            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return false;
        //    }

        //    if (string.IsNullOrEmpty(tinhTrang))
        //    {
        //        MessageBox.Show("Tình trạng không được để trống!", "Lỗi",
        //            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return false;
        //    }

        //    return dal.UpdateTinhTrangNhanVien(maNV, tinhTrang);
        //}

        public List<NhanVien> TimKiem(string tuKhoa)
        {
            if (string.IsNullOrEmpty(tuKhoa))
                return GetAll();

            return dal.TimKiemNhanVien(tuKhoa);
        }

        private string GenerateNewID()
        {
            // Lấy danh sách nhân viên hiện có
            var danhSachNhanVien = GetAll();

            if (danhSachNhanVien.Count == 0)
                return "NV001";

            // Tìm mã lớn nhất
            int maxID = 0;
            foreach (var nhanVien in danhSachNhanVien)
            {
                if (nhanVien.MaNV.StartsWith("NV"))
                {
                    if (int.TryParse(nhanVien.MaNV.Substring(2), out int id))
                    {
                        if (id > maxID)
                            maxID = id;
                    }
                }
            }

            // Tạo mã mới
            return $"NV{(maxID + 1):D3}";
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, @"^\d{10}$");
        }



    }
}
