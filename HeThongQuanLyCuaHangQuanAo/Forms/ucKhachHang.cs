using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HeThongQuanLyCuaHangQuanAo.Models;
using HeThongQuanLyCuaHangQuanAo.BUS;

namespace HeThongQuanLyCuaHangQuanAo.Forms
{
    public partial class ucKhachHang : UserControl
    {
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
    }
}
