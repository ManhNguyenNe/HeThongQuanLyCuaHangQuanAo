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
                var font = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 12, BaseColor.BLACK);

                doc.Add(new Paragraph("HOA DON BAN", FontFactory.GetFont(BaseFont.TIMES_BOLD, 16, BaseColor.BLUE)));
                doc.Add(new Paragraph($"So HD: {hd.SoHDB}"));
                doc.Add(new Paragraph($"Ngay ban: {hd.NgayBan:dd/MM/yyyy}"));
                doc.Add(new Paragraph($"Nhan vien: {hd.TenNV}"));
                doc.Add(new Paragraph($"Khach hang: {hd.TenKhach}"));
                doc.Add(new Paragraph(" "));

                PdfPTable table = new PdfPTable(5);
                table.WidthPercentage = 100;
                table.AddCell("Ten san pham");
                table.AddCell("Don gia");
                table.AddCell("So luong");
                table.AddCell("Giam gia");
                table.AddCell("Thanh tien");

                decimal tongTien = 0;
                foreach (var ct in chiTietList)
                {
                    table.AddCell(ct.TenQuanAo);
                    table.AddCell($"{ct.DonGiaBan:N0} VNĐ");
                    table.AddCell(ct.SoLuong.ToString());
                    table.AddCell($"{ct.GiamGia:N0} VNĐ");
                    decimal thanhTien = ct.ThanhTien - ct.GiamGia;
                    table.AddCell($"{thanhTien:N0} VNĐ");
                    tongTien += thanhTien;
                }

                doc.Add(table);
                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph($"Tong cong: {tongTien:N0} VND", FontFactory.GetFont(BaseFont.TIMES_BOLD, 12)));
                doc.Close();
            }

            MessageBox.Show($"Xuất hóa đơn thành công tại:\n{filePath}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
    

