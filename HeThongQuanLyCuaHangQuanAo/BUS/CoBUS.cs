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
    internal class CoBUS
    {
        private CoDAL dal = new CoDAL();

        public List<Co> GetAll()
        {
            return dal.GetAllCo();
        }

        public bool Add(string tenCo)
        {
            if (string.IsNullOrEmpty(tenCo))
                return false;

            // Kiểm tra xem tên cỡ đã tồn tại chưa
            var danhSachCo = GetAll();
            if (danhSachCo.Any(c => c.TenCo.Equals(tenCo, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Tên cỡ đã tồn tại!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Tạo mã cỡ mới
            string maCo = GenerateNewID();

            // Thêm cỡ mới
            return dal.Add(new Models.Co { MaCo = maCo, TenCo = tenCo });
        }

        private string GenerateNewID()
        {
            // Lấy danh sách cỡ hiện có
            var danhSachCo = GetAll();

            if (danhSachCo.Count == 0)
                return "C001";

            // Tìm mã lớn nhất
            int maxID = 0;
            foreach (var co in danhSachCo)
            {
                if (co.MaCo.StartsWith("C"))
                {
                    if (int.TryParse(co.MaCo.Substring(1), out int id))
                    {
                        if (id > maxID)
                            maxID = id;
                    }
                }
            }

            // Tạo mã mới
            return $"C{(maxID + 1):D3}";
        }

    }
}
