using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyCuaHangQuanAo
{
    internal class UserSession
    {
        public static string MaTK { get; set; }
        public static string MaNV { get; set; }
        public static string TenNV { get; set; }
        public static int VaiTro { get; set; }

        public static void ClearSession()
        {
            MaTK = null;
            MaNV = null;
            TenNV = null;
            VaiTro = -1;
        }
    }
}
