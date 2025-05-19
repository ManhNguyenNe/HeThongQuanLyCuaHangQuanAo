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
    internal class CongViecBUS
    {
        private CongViecDAL dal = new CongViecDAL();

        public List<CongViec> GetAll()
        {
            return dal.GetAllCongViec();
        }

        public bool Add(string tenCV)
        {
            if (string.IsNullOrEmpty(tenCV))
            {
                MessageBox.Show("Tên công việc không được để trống!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra xem tên công việc đã tồn tại chưa
            var danhSachCongViec = GetAll();
            if (danhSachCongViec.Any(cv => cv.TenCV.Equals(tenCV, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Tên công việc đã tồn tại!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Tạo mã công việc mới
            string maCV = GenerateNewID();

            // Thêm công việc mới
            return dal.Add(new CongViec { MaCV = maCV, TenCV = tenCV });
        }

        private string GenerateNewID()
        {
            // Lấy danh sách công việc hiện có
            var danhSachCongViec = GetAll();

            if (danhSachCongViec.Count == 0)
                return "CV001";

            // Tìm mã lớn nhất
            int maxID = 0;
            foreach (var congViec in danhSachCongViec)
            {
                if (congViec.MaCV.StartsWith("CV"))
                {
                    if (int.TryParse(congViec.MaCV.Substring(2), out int id))
                    {
                        if (id > maxID)
                            maxID = id;
                    }
                }
            }

            // Tạo mã mới
            return $"CV{(maxID + 1):D3}";
        }
    }
}
