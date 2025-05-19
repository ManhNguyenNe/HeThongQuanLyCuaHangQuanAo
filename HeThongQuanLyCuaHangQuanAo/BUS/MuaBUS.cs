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
    internal class MuaBUS
    {
        private MuaDAL dal = new MuaDAL();

        public List<Mua> GetAll()
        {
            return dal.GetAllMua();
        }

        public bool Add(string tenMua)
        {
            if (string.IsNullOrEmpty(tenMua))
                return false;

            // Kiểm tra xem tên mùa đã tồn tại chưa
            var danhSachMua = GetAll();
            if (danhSachMua.Any(m => m.TenMua.Equals(tenMua, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Tên mùa đã tồn tại!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Tạo mã mùa mới
            string maMua = GenerateNewID();

            // Thêm mùa mới
            return dal.Add(new Models.Mua { MaMua = maMua, TenMua = tenMua });
        }

        private string GenerateNewID()
        {
            // Lấy danh sách mùa hiện có
            var danhSachMua = GetAll();

            if (danhSachMua.Count == 0)
                return "MU001";

            // Tìm mã lớn nhất
            int maxID = 0;
            foreach (var mua in danhSachMua)
            {
                if (mua.MaMua.StartsWith("MU"))
                {
                    if (int.TryParse(mua.MaMua.Substring(2), out int id))
                    {
                        if (id > maxID)
                            maxID = id;
                    }
                }
            }

            // Tạo mã mới
            return $"MU{(maxID + 1):D3}";
        }

    }
}
