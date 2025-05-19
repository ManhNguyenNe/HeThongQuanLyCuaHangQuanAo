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
    internal class NoiSanXuatBUS
    {
        private NoiSanXuatDAL dal = new NoiSanXuatDAL();

        public List<NoiSanXuat> GetAll()
        {
            return dal.GetAllNSX();
        }

        public bool Add(string tenNSX)
        {
            if (string.IsNullOrEmpty(tenNSX))
                return false;

            // Kiểm tra xem tên nơi sản xuất đã tồn tại chưa
            var danhSachNSX = GetAll();
            if (danhSachNSX.Any(nsx => nsx.TenNSX.Equals(tenNSX, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Tên nơi sản xuất đã tồn tại!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Tạo mã nơi sản xuất mới
            string maNSX = GenerateNewID();

            // Thêm nơi sản xuất mới
            return dal.Add(new Models.NoiSanXuat { MaNSX = maNSX, TenNSX = tenNSX });
        }

        private string GenerateNewID()
        {
            // Lấy danh sách nơi sản xuất hiện có
            var danhSachNSX = GetAll();

            if (danhSachNSX.Count == 0)
                return "NSX001";

            // Tìm mã lớn nhất
            int maxID = 0;
            foreach (var nsx in danhSachNSX)
            {
                if (nsx.MaNSX.StartsWith("NSX"))
                {
                    if (int.TryParse(nsx.MaNSX.Substring(3), out int id))
                    {
                        if (id > maxID)
                            maxID = id;
                    }
                }
            }

            // Tạo mã mới
            return $"NSX{(maxID + 1):D3}";
        }

    }
}
