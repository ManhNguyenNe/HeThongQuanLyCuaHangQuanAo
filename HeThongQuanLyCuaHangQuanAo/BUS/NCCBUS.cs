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
    internal class NCCBUS
    {
        private NCCDAL dal = new NCCDAL();

        public List<NCC> GetAll()
        {
            return dal.GetAllNCC();
        }

        public NCC GetById(string maNCC)
        {
            return dal.GetNCCById(maNCC);
        }

        public bool Add(string tenNCC, string diaChi, string dienThoai)
        {
            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(tenNCC))
            {
                MessageBox.Show("Tên nhà cung cấp không được để trống!", "Lỗi",
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
                MessageBox.Show("Số điện thoại phải có đúng 10 chữ số!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra xem số điện thoại đã tồn tại chưa
            var danhSachNCC = GetAll();
            if (danhSachNCC.Any(ncc => ncc.DienThoai == dienThoai))
            {
                MessageBox.Show("Số điện thoại đã tồn tại trong hệ thống!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Tạo mã nhà cung cấp mới
            string maNCC = GenerateNewID();

            // Thêm nhà cung cấp mới
            return dal.InsertNCC(new NCC
            {
                MaNCC = maNCC,
                TenNCC = tenNCC,
                DiaChi = diaChi,
                DienThoai = dienThoai
            });
        }

        public bool Update(string maNCC, string tenNCC, string diaChi, string dienThoai)
        {
            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(maNCC))
            {
                MessageBox.Show("Mã nhà cung cấp không được để trống!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(tenNCC))
            {
                MessageBox.Show("Tên nhà cung cấp không được để trống!", "Lỗi",
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
                MessageBox.Show("Số điện thoại phải có đúng 10 chữ số!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra xem số điện thoại đã tồn tại chưa (trừ nhà cung cấp hiện tại)
            var danhSachNCC = GetAll();
            if (danhSachNCC.Any(ncc => ncc.DienThoai == dienThoai && ncc.MaNCC != maNCC))
            {
                MessageBox.Show("Số điện thoại đã tồn tại trong hệ thống!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Cập nhật nhà cung cấp
            return dal.UpdateNCC(new NCC
            {
                MaNCC = maNCC,
                TenNCC = tenNCC,
                DiaChi = diaChi,
                DienThoai = dienThoai
            });
        }

        //public bool Delete(string maNCC)
        //{
        //    if (string.IsNullOrEmpty(maNCC))
        //        return false;

        //    // Kiểm tra xem nhà cung cấp có tồn tại không
        //    var ncc = GetById(maNCC);
        //    if (ncc == null)
        //    {
        //        MessageBox.Show("Không tìm thấy nhà cung cấp cần xóa!", "Lỗi",
        //            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return false;
        //    }

        //    // Xác nhận xóa
        //    DialogResult result = MessageBox.Show(
        //        $"Bạn có chắc chắn muốn xóa nhà cung cấp '{ncc.TenNCC}' không?",
        //        "Xác nhận xóa",
        //        MessageBoxButtons.YesNo,
        //        MessageBoxIcon.Question);

        //    if (result == DialogResult.No)
        //        return false;

        //    // Xóa nhà cung cấp
        //    return dal.Delete(maNCC);
        //}

        public List<NCC> TimKiem(string tuKhoa)
        {
            if (string.IsNullOrEmpty(tuKhoa))
                return GetAll();

            return dal.TimKiemNCC(tuKhoa);
        }

        private string GenerateNewID()
        {
            // Lấy danh sách nhà cung cấp hiện có
            var danhSachNCC = GetAll();

            if (danhSachNCC.Count == 0)
                return "NCC001";

            // Tìm mã lớn nhất
            int maxID = 0;
            foreach (var ncc in danhSachNCC)
            {
                if (ncc.MaNCC.StartsWith("NCC"))
                {
                    if (int.TryParse(ncc.MaNCC.Substring(3), out int id))
                    {
                        if (id > maxID)
                            maxID = id;
                    }
                }
            }

            // Tạo mã mới
            return $"NCC{(maxID + 1):D3}";
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // Kiểm tra số điện thoại chỉ chứa số và có độ dài chính xác 10 số
            return System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, @"^\d{10}$");
        }
    }
}
