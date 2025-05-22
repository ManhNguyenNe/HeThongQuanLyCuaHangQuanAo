using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyCuaHangQuanAo.ViewModels
{
    internal class ChiTietHDNhapView
    {
        public string SoHDN { get; set; }
        public string TenNV { get; set; }
        public string TenNCC { get; set; }
        public DateTime NgayNhap { get; set; }
        public string MaQuanAo { get; set; }
        public string TenQuanAo { get; set; }
        public decimal DonGiaNhap { get; set; }
        public int SoLuong { get; set; }
        public decimal GiamGia { get; set; }
        public decimal ThanhTien => DonGiaNhap * SoLuong;
    }
}
