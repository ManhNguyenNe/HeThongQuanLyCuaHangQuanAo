using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HeThongQuanLyCuaHangQuanAo.DAL;
using HeThongQuanLyCuaHangQuanAo.Models;
using Excel = Microsoft.Office.Interop.Excel;
using HeThongQuanLyCuaHangQuanAo.ViewModels;
namespace HeThongQuanLyCuaHangQuanAo.BUS
{
   internal class ThongKeBUS
    {
        private readonly ThongKeDAL _thongKeDAL = new ThongKeDAL();


    // Lấy tổng doanh thu theo ngày
        public decimal LayTongDoanhThuTheoNgay(DateTime ngay)
        {
            var tongBan = _thongKeDAL.GetAllHoaDonBan()
                .Where(hdb => hdb.NgayBan.Date == ngay.Date)
                .Sum(hdb => hdb.TongTien);
            return tongBan;
        }
    // Xuất báo cáo doanh thu theo ngày ra Excel
        public void XuatDoanhThuTheoNgayRaExcel_Interop(DateTime tuNgay, DateTime denNgay, string filePath)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.ActiveSheet;

            // Tiêu đề và địa chỉ ở cột D
            worksheet.Cells[1, 4] = "CỬA HÀNG BÁN QUẦN ÁO";
            worksheet.Cells[2, 4] = "Địa chỉ: 12 Chùa Bộc, phường Quang Trung, Đống Đa, Hà Nội";
            worksheet.Cells[3, 4] = "Điện thoại: 0123 456 789";
            worksheet.Range["C1:F1"].Merge();
            worksheet.Range["C2:G2"].Merge();
            worksheet.Range["D3:E3"].Merge();
            worksheet.Range["C1:F1"].Font.Size = 16;
            worksheet.Range["C1:F1"].Font.Bold = true;
            worksheet.Range["C1:F3"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            // Thời gian báo cáo từ form (dòng 5)
            worksheet.Cells[5, 4] = $"Thời gian: {tuNgay:dd/MM/yyyy} - {denNgay:dd/MM/yyyy}";
            worksheet.Range["D5:E5"].Merge();
            worksheet.Range["D5:E5"].Font.Italic = true;

            // Tiêu đề cột ở cột D và E (dòng 7)
            worksheet.Cells[7, 4] = "Ngày";
            worksheet.Cells[7, 5] = "Doanh thu (VNĐ)";
            worksheet.Range["D7:E7"].Font.Bold = true;

            int row = 8;
            decimal tongTatCaNgay = 0;
            for (DateTime date = tuNgay.Date; date <= denNgay.Date; date = date.AddDays(1))
            {
                decimal doanhThu = LayTongDoanhThuTheoNgay(date);
                worksheet.Cells[row, 4] = date.ToString("dd/MM/yyyy");
                worksheet.Cells[row, 5] = doanhThu;
                tongTatCaNgay += doanhThu;
                row++;
            }

            // Thêm dòng tổng doanh thu các ngày
            worksheet.Cells[row, 4] = "Tổng doanh thu";
            worksheet.Cells[row, 5] = tongTatCaNgay;
            worksheet.Range[$"D{row}:E{row}"].Font.Bold = true;
            row++;

            worksheet.Columns.AutoFit();

            // Ngày xuất báo cáo ở cột F-G
            worksheet.Cells[row + 1, 6] = $"Ngày xuất báo cáo: {DateTime.Now:dd/MM/yyyy}";
            worksheet.Range[$"E{row + 1}:G{row + 1}"].Merge();
            worksheet.Range[$"E{row + 1}:G{row + 1}"].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
            worksheet.Range[$"E{row + 1}:G{row + 1}"].Font.Italic = true;

            workbook.SaveAs(filePath);
            workbook.Close();
            excelApp.Quit();

            Marshal.ReleaseComObject(worksheet);
            Marshal.ReleaseComObject(workbook);
            Marshal.ReleaseComObject(excelApp);
        }


        // Lấy tổng doanh thu theo tuần (tính từ ngày bắt đầu đến ngày kết thúc)
        public decimal LayTongDoanhThuTheoTuan(DateTime batDau, DateTime ketThuc)
        {
            decimal tongDoanhThu = 0;
            for (DateTime d = batDau.Date; d <= ketThuc.Date; d = d.AddDays(1))
            {
                tongDoanhThu += LayTongDoanhThuTheoNgay(d);
            }
            return tongDoanhThu;
        }
        // Xuất báo cáo doanh thu theo tuần ra Excel
        public void XuatDoanhThuTheoTuanRaExcel_Interop(DateTime tuNgay, DateTime denNgay, string filePath)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.ActiveSheet;

            // Tiêu đề và địa chỉ ở cột D
            worksheet.Cells[1, 4] = "CỬA HÀNG BÁN QUẦN ÁO";
            worksheet.Cells[2, 4] = "Địa chỉ: 12 Chùa Bộc, phường Quang Trung, Đống Đa, Hà Nội";
            worksheet.Cells[3, 4] = "Điện thoại: 0123 456 789";
            worksheet.Range["C1:F1"].Merge();
            worksheet.Range["C2:G2"].Merge();
            worksheet.Range["D3:E3"].Merge();
            worksheet.Range["C1:F1"].Font.Size = 16;
            worksheet.Range["C1:F1"].Font.Bold = true;
            worksheet.Range["C1:F3"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            // Thời gian báo cáo từ form (dòng 5)
            worksheet.Cells[5, 4] = $"Thời gian: {tuNgay:dd/MM/yyyy} - {denNgay:dd/MM/yyyy}";
            worksheet.Range["D5:E5"].Merge();
            worksheet.Range["D5:E5"].Font.Italic = true;

            // Tiêu đề cột ở cột D và E (dòng 7)
            worksheet.Cells[7, 4] = "Tuần";
            worksheet.Cells[7, 5] = "Doanh thu (VNĐ)";
            worksheet.Range["D7:E7"].Font.Bold = true;

            int row = 8;
            decimal tongTatCaTuan = 0;
            DateTime start = tuNgay.Date;
            while (start <= denNgay.Date)
            {
                DateTime end = start.AddDays(6);
                if (end > denNgay) end = denNgay;

                decimal tongDoanhThu = 0;
                for (DateTime d = start; d <= end; d = d.AddDays(1))
                {
                    tongDoanhThu += LayTongDoanhThuTheoNgay(d);
                }

                string label = $"{start:dd/MM/yyyy} - {end:dd/MM/yyyy}";
                worksheet.Cells[row, 4] = label;
                worksheet.Cells[row, 5] = tongDoanhThu;
                tongTatCaTuan += tongDoanhThu;
                row++;

                start = end.AddDays(1);
            }

            // Thêm dòng tổng doanh thu các tuần
            worksheet.Cells[row, 4] = "Tổng doanh thu";
            worksheet.Cells[row, 5] = tongTatCaTuan;
            worksheet.Range[$"D{row}:G{row}"].Font.Bold = true;
            row++;

            worksheet.Columns.AutoFit();

            // Ngày xuất báo cáo ở cột F-G
            worksheet.Cells[row + 1, 6] = $"Ngày xuất báo cáo: {DateTime.Now:dd/MM/yyyy}";
            worksheet.Range[$"E{row + 1}:G{row + 1}"].Merge();
            worksheet.Range[$"E{row + 1}:G{row + 1}"].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
            worksheet.Range[$"E{row + 1}:G{row + 1}"].Font.Italic = true;

            workbook.SaveAs(filePath);
            workbook.Close();
            excelApp.Quit();

            Marshal.ReleaseComObject(worksheet);
            Marshal.ReleaseComObject(workbook);
            Marshal.ReleaseComObject(excelApp);
        }

   // Lấy tổng doanh thu theo tháng
        public decimal LayTongDoanhThuTheoThang(int thang, int nam)
        {
            var tongBan = _thongKeDAL.GetAllHoaDonBan()
                .Where(hdb => hdb.NgayBan.Month == thang && hdb.NgayBan.Year == nam)
                .Sum(hdb => hdb.TongTien);
            return tongBan;
        }

        // Xuất báo cáo doanh thu theo tháng ra Excel
        public void XuatDoanhThuTheoThangRaExcel_Interop(DateTime tuNgay, DateTime denNgay, string filePath)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.ActiveSheet;

            // Tiêu đề và địa chỉ ở cột D
            worksheet.Cells[1, 4] = "CỬA HÀNG BÁN QUẦN ÁO";
            worksheet.Cells[2, 4] = "Địa chỉ: 12 Chùa Bộc, phường Quang Trung, Đống Đa, Hà Nội";
            worksheet.Cells[3, 4] = "Điện thoại: 0123 456 789";
            worksheet.Range["C1:F1"].Merge();
            worksheet.Range["C2:G2"].Merge();
            worksheet.Range["D3:E3"].Merge();
            worksheet.Range["C1:F1"].Font.Size = 16;
            worksheet.Range["C1:F1"].Font.Bold = true;
            worksheet.Range["C1:F3"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            // Thời gian báo cáo từ form (dòng 5)
            worksheet.Cells[5, 4] = $"Thời gian: {tuNgay:dd/MM/yyyy} - {denNgay:dd/MM/yyyy}";
            worksheet.Range["D5:E5"].Merge();
            worksheet.Range["D5:E5"].Font.Italic = true;

            // Tiêu đề cột ở cột D và E
            worksheet.Cells[7, 4] = "Tháng/Năm";
            worksheet.Cells[7, 5] = "Doanh thu (VNĐ)";
            worksheet.Range["D7:E7"].Font.Bold = true;

            int row = 8;
            decimal tongTatCaThang = 0;
            DateTime start = new DateTime(tuNgay.Year, tuNgay.Month, 1);
            DateTime end = new DateTime(denNgay.Year, denNgay.Month, 1);

            for (DateTime date = start; date <= end; date = date.AddMonths(1))
            {
                int thang = date.Month;
                int nam = date.Year;
                decimal doanhThu = LayTongDoanhThuTheoThang(thang, nam);

                worksheet.Cells[row, 4] = $"Tháng {thang:00}/{nam}";
                worksheet.Cells[row, 5] = doanhThu;
                tongTatCaThang += doanhThu;
                row++;
            }

            // Thêm dòng tổng doanh thu các tháng
            worksheet.Cells[row, 4] = "Tổng doanh thu";
            worksheet.Cells[row, 5] = tongTatCaThang;
            worksheet.Range[$"D{row}:E{row}"].Font.Bold = true;
            row++;

            worksheet.Columns.AutoFit();

            // Ngày xuất báo cáo ở cột F-G
            worksheet.Cells[row + 1, 6] = $"Ngày xuất báo cáo: {DateTime.Now:dd/MM/yyyy}";
            worksheet.Range[$"E{row + 1}:G{row + 1}"].Merge();
            worksheet.Range[$"E{row + 1}:G{row + 1}"].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
            worksheet.Range[$"E{row + 1}:G{row + 1}"].Font.Italic = true;

            workbook.SaveAs(filePath);
            workbook.Close();
            excelApp.Quit();

            Marshal.ReleaseComObject(worksheet);
            Marshal.ReleaseComObject(workbook);
            Marshal.ReleaseComObject(excelApp);
        }


    // Thống kê top 10 sản phẩm bán chạy nhất từ ngày này đến ngày kia (lấy tên sản phẩm và số lượng bán)
        public List<(string TenQuanAo, int SoLuongBan)> LayTopSanPhamBanChayTheoNgay(DateTime tuNgay, DateTime denNgay, int top)
        {
            var hoaDonBan = _thongKeDAL.GetAllHoaDonBan()
                .Where(hdb => hdb.NgayBan.Date >= tuNgay.Date && hdb.NgayBan.Date <= denNgay.Date)
                .ToList();

            var chiTietAll = new List<ChiTietHDBan>();
            foreach (var hdb in hoaDonBan)
            {
                chiTietAll.AddRange(_thongKeDAL.GetChiTietHDBan(hdb.SoHDB));
            }

            var sanPhamDict = _thongKeDAL.GetAllSanPham().ToDictionary(sp => sp.MaQuanAo, sp => sp.TenQuanAo);

            var topSP = chiTietAll
                .GroupBy(ct => ct.MaQuanAo)
                .Select(g => new
                {
                    MaQuanAo = g.Key,
                    SoLuongBan = g.Sum(x => x.SoLuong),
                    TenQuanAo = sanPhamDict.ContainsKey(g.Key) ? sanPhamDict[g.Key] : g.Key
                })
                .OrderByDescending(x => x.SoLuongBan)
                .Take(top)
                .Select(x => (x.TenQuanAo, x.SoLuongBan))
                .ToList();

            return topSP;
        }

    // Xuất báo cáo sản phẩm bán chạy ra Excel
        public void XuatSanPhamBanChayRaExcel_Interop(DateTime tuNgay, DateTime denNgay, int top, string filePath)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.ActiveSheet;

            // Tiêu đề và địa chỉ ở cột D
            worksheet.Cells[1, 4] = "CỬA HÀNG BÁN QUẦN ÁO";
            worksheet.Cells[2, 4] = "Địa chỉ: 12 Chùa Bộc, phường Quang Trung, Đống Đa, Hà Nội";
            worksheet.Cells[3, 4] = "Điện thoại: 0123 456 789";
            worksheet.Range["C1:F1"].Merge();
            worksheet.Range["C2:G2"].Merge();
            worksheet.Range["D3:E3"].Merge();
            worksheet.Range["C1:F1"].Font.Size = 16;
            worksheet.Range["C1:F1"].Font.Bold = true;
            worksheet.Range["C1:F3"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            // Thời gian báo cáo từ form (dòng 5)
            worksheet.Cells[5, 4] = $"Thời gian: {tuNgay:dd/MM/yyyy} - {denNgay:dd/MM/yyyy}";
            worksheet.Range["D5:F5"].Merge();
            worksheet.Range["D5:F5"].Font.Italic = true;

            // Tiêu đề cột ở cột D và E
            worksheet.Cells[7, 4] = "Tên sản phẩm";
            worksheet.Cells[7, 5] = "Số lượng bán";
            worksheet.Range["D7:E7"].Font.Bold = true;

            int row = 8;
            int tongSoLuong = 0;
            var list = LayTopSanPhamBanChayTheoNgay(tuNgay, denNgay, top);
            foreach (var item in list)
            {
                worksheet.Cells[row, 4] = item.TenQuanAo;
                worksheet.Cells[row, 5] = item.SoLuongBan;
                tongSoLuong += item.SoLuongBan;
                row++;
            }

            // Thêm dòng tổng số lượng bán
            worksheet.Cells[row, 4] = "Tổng số lượng bán";
            worksheet.Cells[row, 5] = tongSoLuong;
            worksheet.Range[$"D{row}:E{row}"].Font.Bold = true;
            row++;

            worksheet.Columns.AutoFit();

            // Ngày xuất báo cáo ở cột F-G
            worksheet.Cells[row + 1, 6] = $"Ngày xuất báo cáo: {DateTime.Now:dd/MM/yyyy}";
            worksheet.Range[$"E{row + 1}:G{row + 1}"].Merge();
            worksheet.Range[$"E{row + 1}:G{row + 1}"].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
            worksheet.Range[$"E{row + 1}:G{row + 1}"].Font.Italic = true;

            workbook.SaveAs(filePath);
            workbook.Close();
            excelApp.Quit();

            Marshal.ReleaseComObject(worksheet);
            Marshal.ReleaseComObject(workbook);
            Marshal.ReleaseComObject(excelApp);
        }

    // Lấy báo cáo tồn kho hiện tại (tên sản phẩm và số lượng tồn kho)
        public List<(string TenQuanAo, int TonKho)> BaoCaoTonKhoHienTai()
        {
            // Lấy tất cả sản phẩm đã từng nhập
            var dsSanPham = _thongKeDAL.GetAllSanPham();

            // Lấy tất cả hóa đơn nhập và bán
            var hoaDonNhap = _thongKeDAL.GetAllHoaDonNhap();
            var hoaDonBan = _thongKeDAL.GetAllHoaDonBan();

            // Tính tổng nhập cho từng sản phẩm
            var dictNhap = new Dictionary<string, int>();
            foreach (var hdn in hoaDonNhap)
            {
                var chiTietNhap = _thongKeDAL.GetChiTietHDNhap(hdn.SoHDN);
                foreach (var ct in chiTietNhap)
                {
                    if (dictNhap.ContainsKey(ct.MaQuanAo))
                        dictNhap[ct.MaQuanAo] += ct.SoLuong;
                    else
                        dictNhap[ct.MaQuanAo] = ct.SoLuong;
                }
            }

            // Tính tổng bán cho từng sản phẩm
            var dictBan = new Dictionary<string, int>();
            foreach (var hdb in hoaDonBan)
            {
                var chiTietBan = _thongKeDAL.GetChiTietHDBan(hdb.SoHDB);
                foreach (var ct in chiTietBan)
                {
                    if (dictBan.ContainsKey(ct.MaQuanAo))
                        dictBan[ct.MaQuanAo] += ct.SoLuong;
                    else
                        dictBan[ct.MaQuanAo] = ct.SoLuong;
                }
            }

            // Tính tồn kho = tổng nhập - tổng bán cho từng sản phẩm (hiện cả tồn kho = 0)
            var result = dsSanPham.Select(sp =>
            {
                int nhap = dictNhap.ContainsKey(sp.MaQuanAo) ? dictNhap[sp.MaQuanAo] : 0;
                int ban = dictBan.ContainsKey(sp.MaQuanAo) ? dictBan[sp.MaQuanAo] : 0;
                int ton = nhap - ban;
                return (sp.TenQuanAo, TonKho: ton);
            }).ToList();

            return result;
        }
        // Xuất báo cáo tồn kho theo tên sản phẩm ra Excel
        public void XuatTonKhoHienTaiRaExcel_Interop(string filePath)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.ActiveSheet;

            // Tiêu đề và địa chỉ ở cột D
            worksheet.Cells[1, 4] = "CỬA HÀNG BÁN QUẦN ÁO";
            worksheet.Cells[2, 4] = "Địa chỉ: 12 Chùa Bộc, phường Quang Trung, Đống Đa, Hà Nội";
            worksheet.Cells[3, 4] = "Điện thoại: 0123 456 789";
            worksheet.Range["C1:F1"].Merge();
            worksheet.Range["C2:G2"].Merge();
            worksheet.Range["D3:E3"].Merge();
            worksheet.Range["C1:F1"].Font.Size = 16;
            worksheet.Range["C1:F1"].Font.Bold = true;
            worksheet.Range["C1:F3"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            // Tiêu đề cột ở cột D và E
            worksheet.Cells[5, 4] = "Tên sản phẩm";
            worksheet.Cells[5, 5] = "Tồn kho";
            worksheet.Range["D5:E5"].Font.Bold = true;

            int row = 6;
            int tongTonKho = 0;
            var list = BaoCaoTonKhoHienTai();
            foreach (var item in list)
            {
                worksheet.Cells[row, 4] = item.TenQuanAo;
                worksheet.Cells[row, 5] = item.TonKho;
                tongTonKho += item.TonKho;
                row++;
            }

            // Thêm dòng tổng tồn kho
            worksheet.Cells[row, 4] = "Tổng tồn kho";
            worksheet.Cells[row, 5] = tongTonKho;
            worksheet.Range[$"D{row}:E{row}"].Font.Bold = true;
            row++;

            worksheet.Columns.AutoFit();

            // Ngày xuất báo cáo ở cột F-G
            worksheet.Cells[row + 1, 6] = $"Ngày xuất báo cáo: {DateTime.Now:dd/MM/yyyy}";
            worksheet.Range[$"E{row + 1}:G{row + 1}"].Merge();
            worksheet.Range[$"E{row + 1}:G{row + 1}"].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
            worksheet.Range[$"E{row + 1}:G{row + 1}"].Font.Italic = true;

            workbook.SaveAs(filePath);
            workbook.Close();
            excelApp.Quit();

            Marshal.ReleaseComObject(worksheet);
            Marshal.ReleaseComObject(workbook);
            Marshal.ReleaseComObject(excelApp);
        }


        // Lấy top khách hàng mua nhiều nhất trong khoảng thời gian từ ngày này đến ngày kia
        public List<(string TenKhach, decimal TongTienMua)> LayTopKhachHangMuaNhieuNhatTheoNgay(DateTime tuNgay, DateTime denNgay, int top)
        {
            // Lấy tất cả hóa đơn bán trong khoảng ngày
            var hoaDonBan = _thongKeDAL.GetAllHoaDonBan()
                .Where(hdb => hdb.NgayBan.Date >= tuNgay.Date && hdb.NgayBan.Date <= denNgay.Date)
                .ToList();

            // Lấy tất cả khách hàng
            var khachDict = _thongKeDAL.GetAllKhachHang().ToDictionary(kh => kh.MaKhach, kh => kh.TenKhach);

            // Gom nhóm theo khách hàng, tính tổng số tiền mua
            var dictTongTien = new Dictionary<string, decimal>();
            foreach (var hdb in hoaDonBan)
            {
                if (dictTongTien.ContainsKey(hdb.MaKhach))
                    dictTongTien[hdb.MaKhach] += hdb.TongTien;
                else
                    dictTongTien[hdb.MaKhach] = hdb.TongTien;
            }

            // Lấy top khách hàng
            var topKH = dictTongTien
                .OrderByDescending(x => x.Value)
                .Take(top)
                .Select(x => (
                    TenKhach: khachDict.ContainsKey(x.Key) ? khachDict[x.Key] : x.Key,
                    TongTienMua: x.Value
                ))
                .ToList();

            return topKH;
        }

        // Xuất báo cáo top khách hàng mua nhiều nhất ra Excel
        public void XuatTopKhachHangMuaNhieuNhatRaExcel_Interop(DateTime tuNgay, DateTime denNgay, int top, string filePath)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.ActiveSheet;

            // Tiêu đề và địa chỉ ở cột D
            worksheet.Cells[1, 4] = "CỬA HÀNG BÁN QUẦN ÁO";
            worksheet.Cells[2, 4] = "Địa chỉ: 12 Chùa Bộc, phường Quang Trung, Đống Đa, Hà Nội";
            worksheet.Cells[3, 4] = "Điện thoại: 0123 456 789";
            worksheet.Range["C1:F1"].Merge();
            worksheet.Range["C2:G2"].Merge();
            worksheet.Range["D3:E3"].Merge();
            worksheet.Range["C1:F1"].Font.Size = 16;
            worksheet.Range["C1:F1"].Font.Bold = true;
            worksheet.Range["C1:F3"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            // Thời gian báo cáo từ form (dòng 5)
            worksheet.Cells[5, 4] = $"Thời gian: {tuNgay:dd/MM/yyyy} - {denNgay:dd/MM/yyyy}";
            worksheet.Range["D5:F5"].Merge();
            worksheet.Range["D5:F5"].Font.Italic = true;

            // Tiêu đề cột ở cột D, E, F
            worksheet.Cells[7, 4] = "Mã khách hàng";
            worksheet.Cells[7, 5] = "Tên khách hàng";
            worksheet.Cells[7, 6] = "Tổng tiền mua (VNĐ)";
            worksheet.Range["D7:F7"].Font.Bold = true;

            int row = 8;
            decimal tongTien = 0;

            // Lấy danh sách khách hàng
            var khachDict = _thongKeDAL.GetAllKhachHang().ToDictionary(kh => kh.MaKhach, kh => kh.TenKhach);

            // Gom nhóm theo khách hàng, tính tổng số tiền mua
            var hoaDonBan = _thongKeDAL.GetAllHoaDonBan()
                .Where(hdb => hdb.NgayBan.Date >= tuNgay.Date && hdb.NgayBan.Date <= denNgay.Date)
                .ToList();

            var dictTongTien = new Dictionary<string, decimal>();
            foreach (var hdb in hoaDonBan)
            {
                if (dictTongTien.ContainsKey(hdb.MaKhach))
                    dictTongTien[hdb.MaKhach] += hdb.TongTien;
                else
                    dictTongTien[hdb.MaKhach] = hdb.TongTien;
            }

            var topKH = dictTongTien
                .OrderByDescending(x => x.Value)
                .Take(top)
                .Select(x => new
                {
                    MaKhach = x.Key,
                    TenKhach = khachDict.ContainsKey(x.Key) ? khachDict[x.Key] : x.Key,
                    TongTienMua = x.Value
                })
                .ToList();

            foreach (var item in topKH)
            {
                worksheet.Cells[row, 4] = item.MaKhach;
                worksheet.Cells[row, 5] = item.TenKhach;
                worksheet.Cells[row, 6] = item.TongTienMua;
                tongTien += item.TongTienMua;
                row++;
            }

            // Thêm dòng tổng tiền
            worksheet.Cells[row, 4] = "";
            worksheet.Cells[row, 5] = "Tổng tiền";
            worksheet.Cells[row, 6] = tongTien;
            worksheet.Range[$"E{row}:F{row}"].Font.Bold = true;
            row++;

            worksheet.Columns.AutoFit();

            // Ngày xuất báo cáo ở cột G-H
            worksheet.Cells[row + 1, 7] = $"Ngày xuất báo cáo: {DateTime.Now:dd/MM/yyyy}";
            worksheet.Range[$"F{row + 1}:H{row + 1}"].Merge();
            worksheet.Range[$"F{row + 1}:H{row + 1}"].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
            worksheet.Range[$"F{row + 1}:H{row + 1}"].Font.Italic = true;

            workbook.SaveAs(filePath);
            workbook.Close();
            excelApp.Quit();

            Marshal.ReleaseComObject(worksheet);
            Marshal.ReleaseComObject(workbook);
            Marshal.ReleaseComObject(excelApp);
        }
    }
}
