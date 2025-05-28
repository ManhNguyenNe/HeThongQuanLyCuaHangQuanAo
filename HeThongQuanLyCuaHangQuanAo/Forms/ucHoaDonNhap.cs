using HeThongQuanLyCuaHangQuanAo.BUS;
using HeThongQuanLyCuaHangQuanAo.DAL;
using HeThongQuanLyCuaHangQuanAo.Models;
using HeThongQuanLyCuaHangQuanAo.ViewModels;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThongQuanLyCuaHangQuanAo.Forms
{
    public partial class ucHoaDonNhap : UserControl
    {
        private HDNhapBUS _hdnBUS = new HDNhapBUS();
        public ucHoaDonNhap()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            var danhSach = _hdnBUS.GetAllHDNhap();
            materialListView1.Items.Clear();
            foreach (var hd in danhSach)
            {
                var item = new ListViewItem(hd.SoHDN);
                item.SubItems.Add(hd.MaNV);
                item.SubItems.Add(hd.TenNV);
                item.SubItems.Add(hd.NgayNhap.ToString("dd/MM/yyyy"));
                item.SubItems.Add(hd.MaNCC);
                item.SubItems.Add(hd.TenNCC);
                item.SubItems.Add(string.Format("{0:N0} VNĐ", hd.TongTien));
                materialListView1.Items.Add(item);
            }
        }

        private void ucHoaDonNhap_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();
            var danhSach = _hdnBUS.TimKiemHDNhap(tuKhoa);

            materialListView1.Items.Clear();

            foreach (var hd in danhSach)
            {
                var item = new ListViewItem(hd.SoHDN);
                item.SubItems.Add(hd.MaNV);
                item.SubItems.Add(hd.TenNV);
                item.SubItems.Add(hd.NgayNhap.ToString("dd/MM/yyyy"));
                item.SubItems.Add(hd.MaNCC);
                item.SubItems.Add(hd.TenNCC);
                item.SubItems.Add(string.Format("{0:N0} VNĐ", hd.TongTien));
                materialListView1.Items.Add(item);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var formThem = new NhapHang();
            if (formThem.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void materialListView1_DoubleClick(object sender, EventArgs e)
        {
            if (materialListView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = materialListView1.SelectedItems[0];

                string maHDNhap = selectedItem.SubItems[0].Text;

                var formChiTiet = new formChiTietHDNhap(maHDNhap);
                formChiTiet.ShowDialog();

                LoadData();
            }
        }
                        private void btnXuatHoaDon_Click(object sender, EventArgs e)
        {
            if (materialListView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string folderPath = @"C:\HoaDonNhap\";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            ListViewItem selectedItem = materialListView1.SelectedItems[0];
            string soHD = selectedItem.SubItems[0].Text;

            var chiTietDAL = new ChiTietHDNhapDAL();
            var chiTiets = chiTietDAL.GetChiTietByHDNhapID(soHD);

            if (chiTiets.Count == 0)
            {
                MessageBox.Show("Không tìm thấy chi tiết hóa đơn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var first = chiTiets[0];
            Document doc = new Document(PageSize.A4);
            string fileName = Path.Combine(folderPath, $"HoaDonNhap_{soHD}.pdf");

            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                PdfWriter.GetInstance(doc, fs);
                doc.Open();

                // Load font Unicode hỗ trợ tiếng Việt
                string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
                BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font titleFont = new iTextSharp.text.Font(baseFont, 16, iTextSharp.text.Font.BOLD);

                iTextSharp.text.Font bodyFont = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.NORMAL);


                doc.Add(new Paragraph("HÓA ĐƠN NHẬP HÀNG", titleFont));
                doc.Add(new Paragraph(" "));

                doc.Add(new Paragraph($"Số HĐ: {first.SoHDN}", bodyFont));
                doc.Add(new Paragraph($"Ngày nhập: {first.NgayNhap:dd/MM/yyyy}", bodyFont));
                doc.Add(new Paragraph($"Nhân viên: {first.TenNV}", bodyFont));
                doc.Add(new Paragraph($"Nhà cung cấp: {first.TenNCC}", bodyFont));
                doc.Add(new Paragraph(" "));

                PdfPTable table = new PdfPTable(5);
                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 20, 35, 15, 15, 15 });

                AddCell(table, "Mã quần áo", true);
                AddCell(table, "Tên quần áo", true);
                AddCell(table, "Đơn giá", true);
                AddCell(table, "Số lượng", true);
                AddCell(table, "Thành tiền", true);

                decimal tongTien = 0;

                foreach (var ct in chiTiets)
                {
                    decimal thanhTien = ct.DonGiaNhap * ct.SoLuong;
                    tongTien += thanhTien;

                    AddCell(table, ct.MaQuanAo);
                    AddCell(table, ct.TenQuanAo);
                    AddCell(table, ct.DonGiaNhap.ToString("N0") + " VNĐ");
                    AddCell(table, ct.SoLuong.ToString());
                    AddCell(table, thanhTien.ToString("N0") + " VNĐ");
                }

                doc.Add(table);
                doc.Add(new Paragraph(" "));

                decimal giamGia = first.GiamGia;
                decimal thanhToan = tongTien - giamGia;

                doc.Add(new Paragraph($"Tổng tiền: {tongTien:N0} VNĐ", bodyFont));
                doc.Add(new Paragraph($"Giảm giá: {giamGia:N0} VNĐ", bodyFont));
                doc.Add(new Paragraph($"Thành tiền: {thanhToan:N0} VNĐ", bodyFont));

                doc.Close();
            }

            MessageBox.Show($"Xuất PDF thành công tại:\n{fileName}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void AddCell(PdfPTable table, string text, bool isHeader = false)
        {
            string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
            BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(
    baseFont,
    isHeader ? 12f : 11f,
    isHeader ? iTextSharp.text.Font.BOLD : iTextSharp.text.Font.NORMAL
);

            PdfPCell cell = new PdfPCell(new Phrase(text, font));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.Padding = 5;
            if (isHeader) cell.BackgroundColor = BaseColor.LIGHT_GRAY;
            table.AddCell(cell);
        }
    }
}
    

