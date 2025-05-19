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

        
    }
}
