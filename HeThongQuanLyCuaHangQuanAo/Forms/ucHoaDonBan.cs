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
    }
}
