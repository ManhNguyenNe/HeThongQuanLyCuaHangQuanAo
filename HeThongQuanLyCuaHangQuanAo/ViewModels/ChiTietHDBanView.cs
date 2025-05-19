using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyCuaHangQuanAo.ViewModels
{
    internal class ChiTietHDBanView
    {
        public string SoHDB { get; set; }
        public string TenNV { get; set; }
        public string TenKhach { get; set; }
        public DateTime NgayBan { get; set; }
        public string MaQuanAo { get; set; }
        public string TenQuanAo { get; set; }
        public decimal DonGiaBan { get; set; }
        public int SoLuong { get; set; }
        public decimal GiamGia { get; set; }
        public decimal ThanhTien { get; set; }
    }
}
