using HeThongQuanLyCuaHangQuanAo.BUS;
using HeThongQuanLyCuaHangQuanAo.DAL;
using HeThongQuanLyCuaHangQuanAo.Models;
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
    public partial class ucNhanVien : UserControl
    {
        private NhanVienBUS nhanVienBUS = new NhanVienBUS();
        public ucNhanVien()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            var danhSach = nhanVienBUS.GetAll();
            materialListView1.Items.Clear();
            foreach (var nv in danhSach)
            {
                var item = new ListViewItem(nv.MaNV);
                item.SubItems.Add(nv.TenNV);
                item.SubItems.Add(nv.GioiTinh);
                item.SubItems.Add(nv.NgaySinh.ToString("dd/MM/yyyy"));
                item.SubItems.Add(nv.DienThoai);
                item.SubItems.Add(nv.DiaChi);
                item.SubItems.Add(nv.TenCV);
                item.SubItems.Add(nv.TinhTrang);
                materialListView1.Items.Add(item);
            }
        }

        private void ucNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();
            var danhSach = nhanVienBUS.TimKiem(tuKhoa);

            materialListView1.Items.Clear();
            foreach (var nv in danhSach)
            {
                var item = new ListViewItem(nv.MaNV);
                item.SubItems.Add(nv.TenNV);
                item.SubItems.Add(nv.GioiTinh);
                item.SubItems.Add(nv.NgaySinh.ToString("dd/MM/yyyy"));
                item.SubItems.Add(nv.DienThoai);
                item.SubItems.Add(nv.DiaChi);
                item.SubItems.Add(nv.TenCV);
                item.SubItems.Add(nv.TinhTrang);
                materialListView1.Items.Add(item);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (materialListView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string maNV = materialListView1.SelectedItems[0].Text;
            var formCapNhatNV = new formNhanVien(maNV);
            if (formCapNhatNV.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var formThemNV = new formNhanVien();
            if (formThemNV.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }
        private void btnXuatThongTinNV_Click(object sender, EventArgs e)
        {
            XuatDanhSachNhanVienRaPDF();
        }
        private void XuatDanhSachNhanVienRaPDF()
        {
            var nhanVienDAL = new NhanVienDAL();
            List<NhanVien> danhSachNV = nhanVienDAL.GetAllNhanVien();

            if (danhSachNV.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu nhân viên để xuất.");
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF file (*.pdf)|*.pdf",
                FileName = "DanhSachNhanVien.pdf"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                
                string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "tahoma.ttf");

                BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

               
                var titleFont = new iTextSharp.text.Font(baseFont, 16, iTextSharp.text.Font.BOLD);
                var headerFont = new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.BOLD);
                var normalFont = new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL);

                Document doc = new Document(PageSize.A4, 25, 25, 30, 30);
                PdfWriter.GetInstance(doc, new FileStream(saveFileDialog.FileName, FileMode.Create));
                doc.Open();

              
                Paragraph title = new Paragraph("DANH SÁCH NHÂN VIÊN", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                title.SpacingAfter = 20;
                doc.Add(title);

                
                PdfPTable table = new PdfPTable(8);
                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 8, 15, 10, 12, 12, 20, 15, 10 });

                
                string[] headers = { "Mã NV", "Tên NV", "Giới tính", "Ngày Sinh", "Điện Thoại", "Địa Chỉ", "Công Việc", "Tình Trạng" };
                foreach (string header in headers)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(header, headerFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.BackgroundColor = new BaseColor(230, 230, 250);
                    table.AddCell(cell);
                }

                
                foreach (var nv in danhSachNV)
                {
                    table.AddCell(new PdfPCell(new Phrase(nv.MaNV, normalFont)));
                    table.AddCell(new PdfPCell(new Phrase(nv.TenNV, normalFont)));
                    table.AddCell(new PdfPCell(new Phrase(nv.GioiTinh, normalFont)));
                    table.AddCell(new PdfPCell(new Phrase(nv.NgaySinh.ToString("dd/MM/yyyy"), normalFont)));
                    table.AddCell(new PdfPCell(new Phrase(nv.DienThoai, normalFont)));
                    table.AddCell(new PdfPCell(new Phrase(nv.DiaChi, normalFont)));
                    table.AddCell(new PdfPCell(new Phrase(nv.TenCV, normalFont)));
                    table.AddCell(new PdfPCell(new Phrase(nv.TinhTrang, normalFont)));
                }

                doc.Add(table);
                doc.Close();

                MessageBox.Show("Xuất danh sách nhân viên ra PDF thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            LoadData();
        }
    }
}
        
    

