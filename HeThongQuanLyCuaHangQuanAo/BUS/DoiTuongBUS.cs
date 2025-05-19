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
    internal class DoiTuongBUS
    {
        private DoiTuongDAL dal = new DoiTuongDAL();

        public List<DoiTuong> GetAll()
        {
            return dal.GetAllDoiTuong();
        }

        public bool Add(string tenDoiTuong)
        {
            if (string.IsNullOrEmpty(tenDoiTuong))
                return false;

            // Kiểm tra xem tên đối tượng đã tồn tại chưa
            var danhSachDoiTuong = GetAll();
            if (danhSachDoiTuong.Any(dt => dt.TenDoiTuong.Equals(tenDoiTuong, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Tên đối tượng đã tồn tại!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Tạo mã đối tượng mới
            string maDoiTuong = GenerateNewID();

            // Thêm đối tượng mới
            return dal.Add(new Models.DoiTuong { MaDoiTuong = maDoiTuong, TenDoiTuong = tenDoiTuong });
        }

        private string GenerateNewID()
        {
            // Lấy danh sách đối tượng hiện có
            var danhSachDoiTuong = GetAll();

            if (danhSachDoiTuong.Count == 0)
                return "DT001";

            // Tìm mã lớn nhất
            int maxID = 0;
            foreach (var doiTuong in danhSachDoiTuong)
            {
                if (doiTuong.MaDoiTuong.StartsWith("DT"))
                {
                    if (int.TryParse(doiTuong.MaDoiTuong.Substring(2), out int id))
                    {
                        if (id > maxID)
                            maxID = id;
                    }
                }
            }

            // Tạo mã mới
            return $"DT{(maxID + 1):D3}";
        }

    }
}
