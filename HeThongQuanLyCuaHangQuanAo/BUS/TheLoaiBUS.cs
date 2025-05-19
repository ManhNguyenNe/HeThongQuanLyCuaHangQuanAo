using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HeThongQuanLyCuaHangQuanAo.DAL;
using HeThongQuanLyCuaHangQuanAo.Models;

namespace HeThongQuanLyCuaHangQuanAo.BUS
{
    internal class TheLoaiBUS
    {
        private TheLoaiDAL dal = new TheLoaiDAL();

        public List<TheLoai> GetAll()
        {
            return dal.GetAllTheLoai();
        }

        public bool Add(string tenLoai)
        {
            if (string.IsNullOrEmpty(tenLoai))
                return false;

            // Kiểm tra xem tên loại đã tồn tại chưa
            var danhSachLoai = GetAll();
            if (danhSachLoai.Any(l => l.TenLoai.Equals(tenLoai, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Tên loại đã tồn tại!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Tạo mã loại mới
            string maLoai = GenerateNewID();

            // Thêm loại mới
            return dal.Add(new Models.TheLoai { MaLoai = maLoai, TenLoai = tenLoai });
        }

        private string GenerateNewID()
        {
            // Lấy danh sách loại hiện có
            var danhSachLoai = GetAll();

            if (danhSachLoai.Count == 0)
                return "L001";

            // Tìm mã lớn nhất
            int maxID = 0;
            foreach (var loai in danhSachLoai)
            {
                if (loai.MaLoai.StartsWith("L"))
                {
                    if (int.TryParse(loai.MaLoai.Substring(1), out int id))
                    {
                        if (id > maxID)
                            maxID = id;
                    }
                }
            }

            // Tạo mã mới
            return $"L{(maxID + 1):D3}";
        }
    }
}
