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
    public partial class ucHoaDonNhap : UserControl
    {
        private HDNhapBUS _hdnBUS = new HDNhapBUS();
        public ucHoaDonNhap()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            var danhSach = _hdnBUS.GetAllHDNhap();
            materialListView1.Items.Clear();
            foreach (var hd in danhSach)
            {
                var item = new ListViewItem(hd.SoHDN);
                item.SubItems.Add(hd.MaNV);
                item.SubItems.Add(hd.TenNV);
                item.SubItems.Add(hd.NgayNhap.ToString("dd/MM/yyyy"));
                item.SubItems.Add(hd.MaNCC);
                item.SubItems.Add(hd.TenNCC);
                item.SubItems.Add(string.Format("{0:N0} VNĐ", hd.TongTien));
                materialListView1.Items.Add(item);
            }
        }

        private void ucHoaDonNhap_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();
            var danhSach = _hdnBUS.TimKiemHDNhap(tuKhoa);

            materialListView1.Items.Clear();

            foreach (var hd in danhSach)
            {
                var item = new ListViewItem(hd.SoHDN);
                item.SubItems.Add(hd.MaNV);
                item.SubItems.Add(hd.TenNV);
                item.SubItems.Add(hd.NgayNhap.ToString("dd/MM/yyyy"));
                item.SubItems.Add(hd.MaNCC);
                item.SubItems.Add(hd.TenNCC);
                item.SubItems.Add(string.Format("{0:N0} VNĐ", hd.TongTien));
                materialListView1.Items.Add(item);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var formThem = new NhapHang();
            if (formThem.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void materialListView1_DoubleClick(object sender, EventArgs e)
        {
            if (materialListView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = materialListView1.SelectedItems[0];

                string maHDNhap = selectedItem.SubItems[0].Text;

                var formChiTiet = new formChiTietHDNhap(maHDNhap);
                formChiTiet.ShowDialog();

                LoadData();
            }
        }
    }
}
