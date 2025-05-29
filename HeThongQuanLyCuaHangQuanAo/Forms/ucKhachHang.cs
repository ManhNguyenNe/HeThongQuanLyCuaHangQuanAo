using HeThongQuanLyCuaHangQuanAo.BUS;
using HeThongQuanLyCuaHangQuanAo.DAL;
using HeThongQuanLyCuaHangQuanAo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace HeThongQuanLyCuaHangQuanAo.Forms
{
    public partial class ucKhachHang : UserControl
    {
        private List<KhachHang> LayDanhSachTuListView()
{
    List<KhachHang> ds = new List<KhachHang>();
    foreach (ListViewItem item in materialListView1.Items)
    {
        ds.Add(new KhachHang
        {
            MaKhach = item.SubItems[0].Text,
            TenKhach = item.SubItems[1].Text,
            DiaChi = item.SubItems[2].Text,
            DienThoai = item.SubItems[3].Text
        });
    }
    return ds;
}
        private KhachHangBUS khachHangBUS = new KhachHangBUS();
        public ucKhachHang()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            var danhSach = khachHangBUS.GetAll();
            materialListView1.Items.Clear();
            foreach (var kh in danhSach)
            {
                var item = new ListViewItem(kh.MaKhach);
                item.SubItems.Add(kh.TenKhach);
                item.SubItems.Add(kh.DiaChi);
                item.SubItems.Add(kh.DienThoai);
                materialListView1.Items.Add(item);
            }
        }

        private void ucKhachHang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var formThemKhachHang = new formKhachHang();
            if (formThemKhachHang.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn khách hàng chưa
            if (materialListView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Lấy mã khách hàng từ dòng được chọn
            string maKhach = materialListView1.SelectedItems[0].Text;

            // Mở form khách hàng ở chế độ cập nhật
            var formCapNhatKhachHang = new formKhachHang(maKhach);
            if (formCapNhatKhachHang.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();
            var danhSach = khachHangBUS.TimKiem(tuKhoa);

            materialListView1.Items.Clear();
            foreach (var kh in danhSach)
            {
                var item = new ListViewItem(kh.MaKhach);
                item.SubItems.Add(kh.TenKhach);
                item.SubItems.Add(kh.DiaChi);
                item.SubItems.Add(kh.DienThoai);
                materialListView1.Items.Add(item);
            }
        }
                private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

                private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
           
        }


        private void btnXuatPDF_Click(object sender, EventArgs e)
        {
            List<KhachHang> danhSach = LayDanhSachTuListView();

            string folderPath = @"C:\Dulieukhachhang";
            Directory.CreateDirectory(folderPath);

           
            string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
            BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            iTextSharp.text.Font titleFont = new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.BOLD, BaseColor.BLUE);
            iTextSharp.text.Font cellFont = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.NORMAL);

            foreach (var kh in danhSach)
            {
                string filePath = Path.Combine(folderPath, $"{kh.MaKhach}_{kh.TenKhach}.pdf");
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 20, 20, 20, 20);
                    PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                  
                    Paragraph title = new Paragraph("THÔNG TIN KHÁCH HÀNG", titleFont);
                    title.Alignment = Element.ALIGN_CENTER;
                    title.SpacingAfter = 20;
                    pdfDoc.Add(title);

                  
                    PdfPTable table = new PdfPTable(2);
                    table.WidthPercentage = 100;
                    table.SpacingBefore = 10;
                    table.SpacingAfter = 10;
                    table.SetWidths(new float[] { 30, 70 });

                    AddCell(table, "Mã khách:", cellFont, true);
                    AddCell(table, kh.MaKhach, cellFont);

                    AddCell(table, "Tên khách:", cellFont, true);
                    AddCell(table, kh.TenKhach, cellFont);

                    AddCell(table, "Địa chỉ:", cellFont, true);
                    AddCell(table, kh.DiaChi, cellFont);

                    AddCell(table, "SĐT:", cellFont, true);
                    AddCell(table, kh.DienThoai, cellFont);

                    pdfDoc.Add(table);
                    pdfDoc.Close();
                }
            }

            MessageBox.Show("Đã xuất thông tin khách hàng ra file PDF!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

      
        private void AddCell(PdfPTable table, string text, iTextSharp.text.Font font, bool isHeader = false)
        {
            PdfPCell cell = new PdfPCell(new Phrase(text, font));
            cell.Padding = 5;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.HorizontalAlignment = isHeader ? Element.ALIGN_RIGHT : Element.ALIGN_LEFT;
            if (isHeader) cell.BackgroundColor = BaseColor.LIGHT_GRAY;
            table.AddCell(cell);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            LoadData();
        }
    }
}
    

