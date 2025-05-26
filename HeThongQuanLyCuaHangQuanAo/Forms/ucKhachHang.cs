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

        private void btnXuatPDF_Click(object sender, EventArgs e)
        {
            List<KhachHang> danhSach = LayDanhSachTuListView();

            string folderPath = @"C:\Dulieukhachhang";
            Directory.CreateDirectory(folderPath);

            foreach (var kh in danhSach)
            {
                string filePath = Path.Combine(folderPath, $"{kh.MaKhach}_{kh.TenKhach}.pdf");
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 10, 10, 10, 10);
                    PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    pdfDoc.Add(new Paragraph($"MaKhach: {kh.MaKhach}"));
                    pdfDoc.Add(new Paragraph($"TenKhach: {kh.TenKhach}"));
                    pdfDoc.Add(new Paragraph($"DiaChi: {kh.DiaChi}"));
                    pdfDoc.Add(new Paragraph($"SDT: {kh.DienThoai}"));
                    pdfDoc.Close();
                    stream.Close();
                }
            }

            MessageBox.Show("Đã xuất thông tin khách hàng ra file PDF!");

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        
        public static void ExportCustomerToPDF(string tenKhachHang, string diaChi, string soDienThoai, string path)
        {
            Document document = new Document();
            PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));
            document.Open();

            document.Add(new Paragraph("Thông tin khách hàng"));
            document.Add(new Paragraph("Tên: " + tenKhachHang));
            document.Add(new Paragraph("Địa chỉ: " + diaChi));
            document.Add(new Paragraph("SĐT: " + soDienThoai));

            document.Close();
        }


        public static void ExportAllCustomersToPDFs(List<KhachHang> danhSachKhachHang, string thuMucXuat)
        {

            if (!Directory.Exists(thuMucXuat))
                Directory.CreateDirectory(thuMucXuat);

            foreach (var kh in danhSachKhachHang)
            {
                string fileName = $"KhachHang_{kh.MaKhach}.pdf";
                string filePath = Path.Combine(thuMucXuat, fileName);

                ExportCustomerToPDF(kh.TenKhach, kh.DiaChi, kh.DienThoai, filePath);
            }
        }
    }
}
    

