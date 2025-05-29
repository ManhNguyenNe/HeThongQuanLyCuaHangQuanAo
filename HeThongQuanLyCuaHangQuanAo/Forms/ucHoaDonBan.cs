using HeThongQuanLyCuaHangQuanAo.BUS;
using HeThongQuanLyCuaHangQuanAo.DAL;
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
    public partial class ucHoaDonBan : UserControl
    {
        private HDBanBUS _hdbBUS = new HDBanBUS();
        public ucHoaDonBan()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            var danhSach = _hdbBUS.GetAllHDBan();
            materialListView1.Items.Clear();
            foreach (var hd in danhSach)
            {
                var item = new ListViewItem(hd.SoHDB);
                item.SubItems.Add(hd.MaNV);
                item.SubItems.Add(hd.TenNV);
                item.SubItems.Add(hd.NgayBan.ToString("dd/MM/yyyy"));
                item.SubItems.Add(hd.MaKhach);
                item.SubItems.Add(hd.TenKhach);
                item.SubItems.Add(string.Format("{0:N0} VNĐ", hd.TongTien));
                materialListView1.Items.Add(item);
            }
        }

        private void ucHoaDonBan_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();
            var danhSach = _hdbBUS.TimKiemHDBan(tuKhoa);

            materialListView1.Items.Clear();

            foreach (var hd in danhSach)
            {
                var item = new ListViewItem(hd.SoHDB);
                item.SubItems.Add(hd.MaNV);
                item.SubItems.Add(hd.TenNV);
                item.SubItems.Add(hd.NgayBan.ToString("dd/MM/yyyy"));
                item.SubItems.Add(hd.MaKhach);
                item.SubItems.Add(hd.TenKhach);
                item.SubItems.Add(string.Format("{0:N0} VNĐ", hd.TongTien));
                materialListView1.Items.Add(item);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var formThem = new XuatHang();
            if (formThem.ShowDialog() == DialogResult.OK)
            {
                LoadData(); // Refresh lại dữ liệu sau khi thêm thành công
            }
        }

        private void materialListView1_DoubleClick(object sender, EventArgs e)
        {
            if (materialListView1.SelectedItems.Count > 0)
            {
                // Lấy dòng đang được double-click
                ListViewItem selectedItem = materialListView1.SelectedItems[0];

                // Lấy mã sản phẩm từ cột đầu tiên
                string maHDBan = selectedItem.SubItems[0].Text;

                // Tạo và hiển thị form chi tiết với mã hóa đơn
                var formChiTiet = new formChiTietHDBan(maHDBan);
                formChiTiet.ShowDialog();

                // Sau khi form chi tiết đóng, refresh lại dữ liệu (nếu cần)
                LoadData();
            }
        }
        private void btnXuatHoaDonBan_Click(object sender, EventArgs e)
        {
            if (materialListView1.SelectedItems.Count > 0)
            {
                string soHDB = materialListView1.SelectedItems[0].SubItems[0].Text;
                XuatHoaDonBanRaPDF(soHDB);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void XuatHoaDonBanRaPDF(string soHDB)
        {
            var chiTietDAL = new ChiTietHDBanDAL();
            var chiTietList = chiTietDAL.GetChiTietByHDBanID(soHDB);

            if (chiTietList == null || chiTietList.Count == 0)
            {
                MessageBox.Show("Không tìm thấy chi tiết hóa đơn để xuất.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var hd = chiTietList.First();

            string folderPath = @"C:\HoaDonBan";
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            string fileName = $"HoaDonBan_{hd.SoHDB}.pdf";
            string filePath = Path.Combine(folderPath, fileName);

            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            using (Document doc = new Document(PageSize.A4))
            using (PdfWriter writer = PdfWriter.GetInstance(doc, fs))
            {
                doc.Open();

                // Load font Unicode để hỗ trợ tiếng Việt
                string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
                BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font titleFont = new iTextSharp.text.Font(baseFont, 16f, iTextSharp.text.Font.BOLD, BaseColor.BLUE);
                iTextSharp.text.Font bodyFont = new iTextSharp.text.Font(baseFont, 12f, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font headerFont = new iTextSharp.text.Font(baseFont, 12f, iTextSharp.text.Font.BOLD);

                doc.Add(new Paragraph("HÓA ĐƠN BÁN", titleFont));
                doc.Add(new Paragraph($"Số HĐ: {hd.SoHDB}", bodyFont));
                doc.Add(new Paragraph($"Ngày bán: {hd.NgayBan:dd/MM/yyyy}", bodyFont));
                doc.Add(new Paragraph($"Nhân viên: {hd.TenNV}", bodyFont));
                doc.Add(new Paragraph($"Khách hàng: {hd.TenKhach}", bodyFont));
                doc.Add(new Paragraph(" "));

                PdfPTable table = new PdfPTable(5);
                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 30, 20, 15, 15, 20 });

                AddCell(table, "Tên sản phẩm", headerFont);
                AddCell(table, "Đơn giá", headerFont);
                AddCell(table, "Số lượng", headerFont);
                AddCell(table, "Giảm giá", headerFont);
                AddCell(table, "Thành tiền", headerFont);

                decimal tongTien = 0;
                foreach (var ct in chiTietList)
                {
                    decimal thanhTien = ct.ThanhTien - ct.GiamGia;
                    tongTien += thanhTien;

                    AddCell(table, ct.TenQuanAo, bodyFont);
                    AddCell(table, $"{ct.DonGiaBan:N0} VNĐ", bodyFont);
                    AddCell(table, ct.SoLuong.ToString(), bodyFont);
                    AddCell(table, $"{ct.GiamGia:N0} VNĐ", bodyFont);
                    AddCell(table, $"{thanhTien:N0} VNĐ", bodyFont);
                }

                doc.Add(table);
                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph($"Tổng cộng: {tongTien:N0} VNĐ", headerFont));

                doc.Close();
            }

            MessageBox.Show($"Xuất hóa đơn thành công tại:\n{filePath}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AddCell(PdfPTable table, string text, iTextSharp.text.Font font)
        {
            PdfPCell cell = new PdfPCell(new Phrase(text, font));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.Padding = 5;
            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
            table.AddCell(cell);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            LoadData();
        }
    }
}
    

