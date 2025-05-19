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
    public partial class formChiTietHDBan : MaterialForm
    {

        private readonly string _soHDB;
        private readonly ChiTietHDBanBUS _chiTietHDBanBUS;

        public formChiTietHDBan(string soHDB)
        {
            InitializeComponent();
            _soHDB = soHDB;
            _chiTietHDBanBUS = new ChiTietHDBanBUS();
        }

        private void ChiTietHDBan_Load(object sender, EventArgs e)
        {
            LoadChiTietHoaDon();
        }

        private void LoadChiTietHoaDon()
        {
            var chiTietList = _chiTietHDBanBUS.GetChiTietByHDBanID(_soHDB);

            if (chiTietList.Count > 0)
            {
                // Hiển thị thông tin hóa đơn
                var firstItem = chiTietList[0];
                lblMaHDBan.Text = "Mã hóa đơn: " + firstItem.SoHDB;
                lblTenNhanVien.Text = "Nhân viên: " + firstItem.TenNV;
                lblTenKhachHang.Text = "Khách hàng: " + firstItem.TenKhach;
                lblNgayBan.Text = "Ngày bán: " + firstItem.NgayBan.ToString("dd/MM/yyyy");
                lblGiamGia.Text = "Giảm giá: " + firstItem.GiamGia.ToString("0.##") + "%";

                // Hiển thị chi tiết sản phẩm
                materialListView1.Items.Clear();
                decimal tongTien = 0;

                foreach (var chiTiet in chiTietList)
                {
                    var item = new ListViewItem(chiTiet.MaQuanAo);
                    item.SubItems.Add(chiTiet.TenQuanAo);
                    item.SubItems.Add(string.Format("{0:N0} VNĐ", chiTiet.DonGiaBan));
                    item.SubItems.Add(chiTiet.SoLuong.ToString());
                    materialListView1.Items.Add(item);

                    tongTien += chiTiet.ThanhTien;
                }

                // Hiển thị tổng tiền sau khi giảm giá
                decimal giamGia = firstItem.GiamGia;
                decimal tongTienSauGiam = tongTien * (1 - giamGia / 100);
                lblThanhTien.Text = "Thành tiền: " + string.Format("{0:N0} VNĐ", tongTienSauGiam);
            }
        }
    }
}
