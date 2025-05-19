using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyCuaHangQuanAo.Models
{
    internal class HoaDonBan
    {
        public string SoHDB { get; set; }
        public string MaNV { get; set; }
        public DateTime NgayBan { get; set; }
        public string MaKhach { get; set; }
        public decimal GiamGia { get; set; }
        public decimal TongTien { get; set; }
    }
}
