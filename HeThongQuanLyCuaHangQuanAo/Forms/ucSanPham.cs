using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HeThongQuanLyCuaHangQuanAo.DAL;
using HeThongQuanLyCuaHangQuanAo.Models;
using HeThongQuanLyCuaHangQuanAo.ViewModels;
using HeThongQuanLyCuaHangQuanAo.BUS;
using System.IO;

namespace HeThongQuanLyCuaHangQuanAo.Forms
{
    public partial class ucSanPham : UserControl
    {
        private SanPhamBUS sanPhamBUS = new SanPhamBUS();

        public ucSanPham()
        {
            InitializeComponent();
            if (UserSession.VaiTro == 1 || UserSession.VaiTro == 2)
            {
                btnThem.Visible = false;
                btnSua.Visible = false;
                //btnXoa.Visible = false;
            }
        }

        public void LoadData()
        {
            var danhSach = sanPhamBUS.GetSanPhamViews();
            materialListView1.Items.Clear();

            foreach (var sp in danhSach)
            {
                var item = new ListViewItem(sp.MaQuanAo);
                item.SubItems.Add(sp.TenQuanAo);
                item.SubItems.Add(sp.TenCo);
                item.SubItems.Add(sp.TenChatLieu);
                item.SubItems.Add(sp.TenMau);
                item.SubItems.Add(sp.SoLuong.ToString());
                item.SubItems.Add(sp.TenNSX);
                item.SubItems.Add(sp.DonGiaBan.ToString() + " VNĐ");
                materialListView1.Items.Add(item);
            }
        }

        private void ucSanPham_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void materialListView1_DoubleClick(object sender, EventArgs e)
        {
            if (materialListView1.SelectedItems.Count > 0)
            {
                // Lấy dòng đang được double-click
                ListViewItem selectedItem = materialListView1.SelectedItems[0];

                // Lấy mã sản phẩm từ cột đầu tiên
                string maQuanAo = selectedItem.SubItems[0].Text;

                // Tạo và hiển thị form chi tiết với mã sản phẩm
                var formChiTiet = new ChiTietSanPham(maQuanAo);
                formChiTiet.ShowDialog();

                // Sau khi form chi tiết đóng, refresh lại dữ liệu (nếu cần)
                LoadData();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (materialListView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa.");
                return;
            }

            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes) return;

            // Lấy mã sản phẩm từ dòng được chọn
            string maQuanAo = materialListView1.SelectedItems[0].Text;

            // Gọi BUS để xóa
            bool xoaThanhCong = sanPhamBUS.XoaSanPham(maQuanAo);

            if (xoaThanhCong)
            {
                MessageBox.Show("Xóa thành công!");
                LoadData();
            }
            else
            {
                MessageBox.Show("Xóa thất bại.");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var formThem = new ThemSanPham();
            if (formThem.ShowDialog() == DialogResult.OK)
            {
                LoadData(); // Refresh lại dữ liệu sau khi thêm thành công
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (materialListView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa.");
                return;
            }

            string maQuanAo = materialListView1.SelectedItems[0].Text;

            var formSua = new CapNhatSanPham(maQuanAo);


            if (formSua.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(tuKhoa))
            {
                // Nếu không có từ khóa, hiển thị tất cả sản phẩm
                LoadData();
                return;
            }

            // Tìm kiếm sản phẩm từ database
            var ketQuaTimKiem = sanPhamBUS.TimKiemSanPham(tuKhoa);

            // Hiển thị kết quả tìm kiếm
            materialListView1.Items.Clear();

            if (ketQuaTimKiem.Count == 0)
            {
                MessageBox.Show("Không tìm thấy sản phẩm nào phù hợp.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (var sp in ketQuaTimKiem)
            {
                var item = new ListViewItem(sp.MaQuanAo);
                item.SubItems.Add(sp.TenQuanAo);
                item.SubItems.Add(sp.TenCo);
                item.SubItems.Add(sp.TenChatLieu);
                item.SubItems.Add(sp.TenMau);
                item.SubItems.Add(sp.SoLuong.ToString());
                item.SubItems.Add(sp.Anh.ToString());
                item.SubItems.Add(sp.DonGiaBan.ToString() + " VNĐ");
                materialListView1.Items.Add(item);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            LoadData();
        }
    }
    
}
