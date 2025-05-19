using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HeThongQuanLyCuaHangQuanAo.DAL;
using HeThongQuanLyCuaHangQuanAo.Models;
using HeThongQuanLyCuaHangQuanAo.ViewModels;

namespace HeThongQuanLyCuaHangQuanAo.BUS
{
    internal class TaiKhoanBUS
    {
        private readonly TaiKhoanDAL _taiKhoanDAL = new TaiKhoanDAL();
        private readonly NhanVienDAL _nhanVienDAL = new NhanVienDAL();

        // Lấy tất cả tài khoản
        public List<TaiKhoanView> GetAllTaiKhoan()
        {
            return _taiKhoanDAL.GetAllTaiKhoan();
        }

        // Lấy tài khoản theo mã
        public TaiKhoan GetTaiKhoanById(string maTK)
        {
            return _taiKhoanDAL.GetTaiKhoanById(maTK);
        }

        // Lấy tài khoản theo tên đăng nhập
        public TaiKhoan GetTaiKhoanByUsername(string tenDangNhap)
        {
            return _taiKhoanDAL.GetTaiKhoanByUsername(tenDangNhap);
        }

        // Lấy tài khoản theo mã nhân viên
        public TaiKhoan GetTaiKhoanByMaNV(string maNV)
        {
            return _taiKhoanDAL.GetTaiKhoanByMaNV(maNV);
        }

        // Thêm tài khoản mới
        public bool ThemTaiKhoan(string maNV, string tenDangNhap, string matKhau, int vaiTro)
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(maNV))
                {
                    MessageBox.Show("Mã nhân viên không được để trống!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (string.IsNullOrEmpty(tenDangNhap))
                {
                    MessageBox.Show("Tên đăng nhập không được để trống!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (string.IsNullOrEmpty(matKhau))
                {
                    MessageBox.Show("Mật khẩu không được để trống!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Kiểm tra nhân viên tồn tại
                var nhanVien = _nhanVienDAL.GetNhanVienById(maNV);
                if (nhanVien == null)
                {
                    MessageBox.Show("Nhân viên không tồn tại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Kiểm tra nhân viên đã có tài khoản chưa
                var taiKhoanNV = _taiKhoanDAL.GetTaiKhoanByMaNV(maNV);
                if (taiKhoanNV != null)
                {
                    MessageBox.Show("Nhân viên này đã có tài khoản!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Kiểm tra tên đăng nhập đã tồn tại chưa
                var taiKhoanTDN = _taiKhoanDAL.GetTaiKhoanByUsername(tenDangNhap);
                if (taiKhoanTDN != null)
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Tạo mã tài khoản mới
                string maTK = GenerateNewTaiKhoanID();

                // Tạo tài khoản mới
                TaiKhoan taiKhoan = new TaiKhoan
                {
                    MaTK = maTK,
                    MaNV = maNV,
                    TenDangNhap = tenDangNhap,
                    MatKhau = matKhau, // Lưu mật khẩu không mã hóa
                    VaiTro = vaiTro,
                    TinhTrang = true // Mặc định tài khoản mới là hoạt động
                };

                // Thêm tài khoản vào CSDL
                return _taiKhoanDAL.InsertTaiKhoan(taiKhoan);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Cập nhật tài khoản
        public bool CapNhatTaiKhoan(string maTK, string maNV, string tenDangNhap, int vaiTro, bool tinhTrang)
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(maTK))
                {
                    MessageBox.Show("Mã tài khoản không được để trống!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (string.IsNullOrEmpty(maNV))
                {
                    MessageBox.Show("Mã nhân viên không được để trống!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (string.IsNullOrEmpty(tenDangNhap))
                {
                    MessageBox.Show("Tên đăng nhập không được để trống!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Kiểm tra tài khoản tồn tại
                var taiKhoan = _taiKhoanDAL.GetTaiKhoanById(maTK);
                if (taiKhoan == null)
                {
                    MessageBox.Show("Tài khoản không tồn tại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Kiểm tra nhân viên tồn tại
                var nhanVien = _nhanVienDAL.GetNhanVienById(maNV);
                if (nhanVien == null)
                {
                    MessageBox.Show("Nhân viên không tồn tại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Kiểm tra tên đăng nhập đã tồn tại chưa (trừ tài khoản hiện tại)
                var taiKhoanTDN = _taiKhoanDAL.GetTaiKhoanByUsername(tenDangNhap);
                if (taiKhoanTDN != null && taiKhoanTDN.MaTK != maTK)
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Cập nhật thông tin tài khoản
                taiKhoan.MaNV = maNV;
                taiKhoan.TenDangNhap = tenDangNhap;
                taiKhoan.VaiTro = vaiTro;
                taiKhoan.TinhTrang = tinhTrang;

                // Cập nhật tài khoản trong CSDL
                return _taiKhoanDAL.UpdateTaiKhoan(taiKhoan);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Đổi mật khẩu
        public bool DoiMatKhau(string maTK, string matKhauCu, string matKhauMoi)
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(maTK))
                {
                    MessageBox.Show("Mã tài khoản không được để trống!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (string.IsNullOrEmpty(matKhauCu) || string.IsNullOrEmpty(matKhauMoi))
                {
                    MessageBox.Show("Mật khẩu không được để trống!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Kiểm tra tài khoản tồn tại
                var taiKhoan = _taiKhoanDAL.GetTaiKhoanById(maTK);
                if (taiKhoan == null)
                {
                    MessageBox.Show("Tài khoản không tồn tại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Kiểm tra mật khẩu cũ
                if (taiKhoan.MatKhau != matKhauCu)
                {
                    MessageBox.Show("Mật khẩu cũ không đúng!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Cập nhật mật khẩu mới
                return _taiKhoanDAL.UpdatePassword(maTK, matKhauMoi);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Đặt lại mật khẩu (dành cho admin)
        public bool DatLaiMatKhau(string maTK, string matKhauMoi)
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(maTK))
                {
                    MessageBox.Show("Mã tài khoản không được để trống!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (string.IsNullOrEmpty(matKhauMoi))
                {
                    MessageBox.Show("Mật khẩu mới không được để trống!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Kiểm tra tài khoản tồn tại
                var taiKhoan = _taiKhoanDAL.GetTaiKhoanById(maTK);
                if (taiKhoan == null)
                {
                    MessageBox.Show("Tài khoản không tồn tại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Cập nhật mật khẩu
                taiKhoan.MatKhau = matKhauMoi;

                // Cập nhật tài khoản trong CSDL
                return _taiKhoanDAL.UpdateTaiKhoan(taiKhoan);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Xóa tài khoản
        public bool XoaTaiKhoan(string maTK)
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(maTK))
                {
                    MessageBox.Show("Mã tài khoản không được để trống!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Kiểm tra tài khoản tồn tại
                var taiKhoan = _taiKhoanDAL.GetTaiKhoanById(maTK);
                if (taiKhoan == null)
                {
                    MessageBox.Show("Tài khoản không tồn tại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Xóa tài khoản
                return _taiKhoanDAL.DeleteTaiKhoan(maTK);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Tìm kiếm tài khoản
        public List<TaiKhoanView> TimKiemTaiKhoan(string tuKhoa)
        {
            return _taiKhoanDAL.SearchTaiKhoan(tuKhoa);
        }

        // Tạo mã tài khoản mới
        public string GenerateNewTaiKhoanID()
        {
            string latestID = _taiKhoanDAL.GetLatestTaiKhoanID();

            if (string.IsNullOrEmpty(latestID))
            {
                return "TK0001";
            }

            if (latestID.Length != 6 || !latestID.StartsWith("TK"))
            {
                throw new Exception("Cấu trúc mã tài khoản trong database không hợp lệ");
            }

            string numberPart = latestID.Substring(2);
            if (int.TryParse(numberPart, out int currentNumber))
            {
                if (currentNumber >= 9999)
                {
                    throw new Exception("Đạt giới hạn mã tài khoản");
                }
                return $"TK{(currentNumber + 1):0000}";
            }

            throw new Exception("Mã tài khoản không hợp lệ");
        }

        // Kiểm tra mật khẩu
        public bool KiemTraMatKhau(string maTK, string matKhau)
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(maTK) || string.IsNullOrEmpty(matKhau))
                {
                    return false;
                }

                // Lấy tài khoản theo mã
                var taiKhoan = _taiKhoanDAL.GetTaiKhoanById(maTK);
                if (taiKhoan == null)
                {
                    return false;
                }

                // So sánh với mật khẩu trong CSDL
                return taiKhoan.MatKhau == matKhau;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public TaiKhoanView DangNhap(string tenDangNhap, string matKhau)
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(matKhau))
                {
                    return null;
                }

                // Kiểm tra tài khoản
                var taiKhoan = _taiKhoanDAL.GetTaiKhoanByUsername(tenDangNhap);
                if (taiKhoan != null && taiKhoan.MatKhau == matKhau)
                {
                    // Lấy thông tin nhân viên
                    var nhanVien = _nhanVienDAL.GetNhanVienById(taiKhoan.MaNV);

                    // Trả về thông tin tài khoản
                    return new ViewModels.TaiKhoanView
                    {
                        MaTK = taiKhoan.MaTK,
                        MaNV = taiKhoan.MaNV,
                        TenNV = nhanVien?.TenNV,
                        TenDangNhap = taiKhoan.TenDangNhap,
                        MatKhau = taiKhoan.MatKhau,
                        VaiTro = taiKhoan.VaiTro,
                        TinhTrang = taiKhoan.TinhTrang
                    };
                }

                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
