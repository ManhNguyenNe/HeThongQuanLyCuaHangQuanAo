using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyCuaHangQuanAo.ViewModels
{
    internal class HDBanView
    {
        public string SoHDB { get; set; }
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public DateTime NgayBan { get; set; }
        public string MaKhach { get; set; }
        public string TenKhach { get; set; }
        public decimal TongTien { get; set; }
    }
}
