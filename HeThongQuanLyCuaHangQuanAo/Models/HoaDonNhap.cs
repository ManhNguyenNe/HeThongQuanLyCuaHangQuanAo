using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyCuaHangQuanAo.Models
{
    internal class HoaDonNhap
    {
        public string SoHDN { get; set; }
        public string MaNV { get; set; }
        public DateTime NgayNhap { get; set; }
        public string MaNCC { get; set; }
        public decimal GiamGia { get; set; }
        public decimal TongTien { get; set; }
    }
}
