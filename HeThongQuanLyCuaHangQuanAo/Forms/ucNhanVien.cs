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
                Document doc = new Document(PageSize.A4, 25, 25, 30, 30);
                PdfWriter.GetInstance(doc, new FileStream(saveFileDialog.FileName, FileMode.Create));
                doc.Open();

        
                var titleFont = FontFactory.GetFont("Arial", "16", Font.Bold);
                Paragraph title = new Paragraph("DANH SACH NHAN VIEN", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                title.SpacingAfter = 20;
                doc.Add(title);

            
                PdfPTable table = new PdfPTable(8);
                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 8, 15, 10, 12, 12, 20, 15, 10 });

               
                string[] headers = { "Ma NV", "Ten NV", "Gioi Tinh", "Ngay Sinh", "Dien Thoai", "Dia Chi", "Cong Viec", "Tinh Trang" };
                foreach (string header in headers)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(header, FontFactory.GetFont("Arial", "10", Font.Bold)));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.BackgroundColor = new BaseColor(230, 230, 250);
                    table.AddCell(cell);
                }

               
                foreach (var nv in danhSachNV)
                {
                    table.AddCell(nv.MaNV);
                    table.AddCell(nv.TenNV);
                    table.AddCell(nv.GioiTinh);
                    table.AddCell(nv.NgaySinh.ToString("dd/MM/yyyy"));
                    table.AddCell(nv.DienThoai);
                    table.AddCell(nv.DiaChi);
                    table.AddCell(nv.TenCV);
                    table.AddCell(nv.TinhTrang);
                }

                doc.Add(table);
                doc.Close();

                MessageBox.Show("Xuất danh sách nhân viên ra PDF thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


    }
}

        
    

