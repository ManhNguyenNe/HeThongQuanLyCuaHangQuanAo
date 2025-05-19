using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyCuaHangQuanAo.Models
{
    internal class NhanVien
    {
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DienThoai { get; set; }
        public string DiaChi { get; set; }
        public string MaCV { get; set; }
        public string TenCV { get; set; } // Thêm để hiển thị tên công việc
        public string TinhTrang { get; set; } // Thêm để hiển thị tình trạng làm việc
    }
}
