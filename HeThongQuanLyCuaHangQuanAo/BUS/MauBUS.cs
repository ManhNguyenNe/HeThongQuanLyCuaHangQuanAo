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
    internal class MauBUS
    {
        private MauDAL dal = new MauDAL();

        public List<Mau> GetAll()
        {
            return dal.GetAllMau();
        }

        public bool Add(string tenMau)
        {
            if (string.IsNullOrEmpty(tenMau))
                return false;

            // Kiểm tra xem tên màu đã tồn tại chưa
            var danhSachMau = GetAll();
            if (danhSachMau.Any(m => m.TenMau.Equals(tenMau, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Tên màu đã tồn tại!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Tạo mã màu mới
            string maMau = GenerateNewID();

            // Thêm màu mới
            return dal.Add(new Models.Mau { MaMau = maMau, TenMau = tenMau });
        }

        private string GenerateNewID()
        {
            // Lấy danh sách màu hiện có
            var danhSachMau = GetAll();

            if (danhSachMau.Count == 0)
                return "M001";

            // Tìm mã lớn nhất
            int maxID = 0;
            foreach (var mau in danhSachMau)
            {
                if (mau.MaMau.StartsWith("M"))
                {
                    if (int.TryParse(mau.MaMau.Substring(1), out int id))
                    {
                        if (id > maxID)
                            maxID = id;
                    }
                }
            }

            // Tạo mã mới
            return $"M{(maxID + 1):D3}";
        }

    }
}
