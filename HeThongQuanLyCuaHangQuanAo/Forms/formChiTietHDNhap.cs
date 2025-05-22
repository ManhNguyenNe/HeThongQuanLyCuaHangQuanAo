using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HeThongQuanLyCuaHangQuanAo.BUS;
using MaterialSkin.Controls;

namespace HeThongQuanLyCuaHangQuanAo.Forms
{
    public partial class formChiTietHDNhap : MaterialForm
    {
        private readonly string _soHDN;
        private readonly ChiTietHDNhapBUS _chiTietHDNhapBUS;
        public formChiTietHDNhap(string soHDN)
        {
            InitializeComponent();
            _soHDN = soHDN;
            _chiTietHDNhapBUS = new ChiTietHDNhapBUS();
        }

        private void formChiTietHDNhap_Load(object sender, EventArgs e)
        {
            LoadChiTietHoaDon();
        }

        private void LoadChiTietHoaDon()
        {
            var chiTietList = _chiTietHDNhapBUS.GetChiTietByHDNhapID(_soHDN);

            if (chiTietList.Count > 0)
            {
                // Hiển thị thông tin hóa đơn
                var firstItem = chiTietList[0];
                lblMaHDBan.Text = "Mã hóa đơn: " + firstItem.SoHDN;
                lblTenNhanVien.Text = "Nhân viên: " + firstItem.TenNV;
                lblTenNCC.Text = "Nhà cung cấp: " + firstItem.TenNCC;
                lblNgayNhap.Text = "Ngày nhập: " + firstItem.NgayNhap.ToString("dd/MM/yyyy");
                lblGiamGia.Text = "Giảm giá: " + firstItem.GiamGia.ToString("0.##") + "%";

                materialListView1.Items.Clear();
                decimal tongTien = 0;

                foreach (var chiTiet in chiTietList)
                {
                    var item = new ListViewItem(chiTiet.MaQuanAo);
                    item.SubItems.Add(chiTiet.TenQuanAo);
                    item.SubItems.Add(string.Format("{0:N0} VNĐ", chiTiet.DonGiaNhap));
                    item.SubItems.Add(chiTiet.SoLuong.ToString());
                    materialListView1.Items.Add(item);

                    tongTien += chiTiet.ThanhTien;
                }

                decimal giamGia = firstItem.GiamGia;
                decimal tongTienSauGiam = tongTien * (1 - giamGia / 100);
                lblThanhTien.Text = "Thành tiền: " + string.Format("{0:N0} VNĐ", tongTienSauGiam);
            }
        }
    }
}
