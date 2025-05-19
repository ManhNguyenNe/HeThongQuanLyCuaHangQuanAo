using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyCuaHangQuanAo.Models
{
    internal class SanPham
    {
        public string MaQuanAo { get; set; }
        public string TenQuanAo { get; set; }
        public string MaLoai { get; set; }
        public string MaCo { get; set; }
        public string MaChatLieu { get; set; }
        public string MaMau { get; set; }
        public string MaDoiTuong { get; set; }
        public string MaMua { get; set; }
        public string MaNSX { get; set; }
        public int SoLuong { get; set; }
        public string Anh { get; set; }
        public string DonGiaNhapStr { get; set; }
        public string DonGiaBanStr { get; set; }
        public decimal DonGiaNhap { get; set; }
        public decimal DonGiaBan { get; set; }
        public bool TinhTrang { get; set; }
    }
}
