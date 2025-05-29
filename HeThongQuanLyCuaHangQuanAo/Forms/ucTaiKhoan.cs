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
    public partial class ucTaiKhoan : UserControl
    {
        private TaiKhoanBUS _taiKhoanBUS = new TaiKhoanBUS();
        public ucTaiKhoan()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            var danhSach = _taiKhoanBUS.GetAllTaiKhoan();
            materialListView1.Items.Clear();
            foreach (var tk in danhSach)
            {
                var item = new ListViewItem(tk.MaTK);
                item.SubItems.Add(tk.MaNV);
                item.SubItems.Add(tk.TenNV);
                item.SubItems.Add(tk.TenDangNhap);

                // Hiển thị vai trò
                string vaiTro = "";
                switch (tk.VaiTro)
                {
                    case 0:
                        vaiTro = "Quản trị viên";
                        break;
                    case 1:
                        vaiTro = "Nhân viên bán hàng";
                        break;
                    case 2:
                        vaiTro = "Nhân viên kho";
                        break;
                    default:
                        vaiTro = "Khác";
                        break;
                }
                item.SubItems.Add(vaiTro);

                materialListView1.Items.Add(item);
            }
        }

        private void ucTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();
            var danhSach = _taiKhoanBUS.TimKiemTaiKhoan(tuKhoa);

            materialListView1.Items.Clear();

            foreach (var tk in danhSach)
            {
                var item = new ListViewItem(tk.MaTK);
                item.SubItems.Add(tk.MaNV);
                item.SubItems.Add(tk.TenNV);
                item.SubItems.Add(tk.TenDangNhap);

                // Hiển thị vai trò
                string vaiTro = "";
                switch (tk.VaiTro)
                {
                    case 0:
                        vaiTro = "Quản trị viên";
                        break;
                    case 1:
                        vaiTro = "Nhân viên bán hàng";
                        break;
                    case 2:
                        vaiTro = "Nhân viên kho";
                        break;
                    default:
                        vaiTro = "Khác";
                        break;
                }
                item.SubItems.Add(vaiTro);

                materialListView1.Items.Add(item);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var formThem = new formTaiKhoan();
            if (formThem.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn tài khoản chưa
            if (materialListView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xóa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string QuyenHan = materialListView1.SelectedItems[0].SubItems[4].Text;
            if (QuyenHan == "Quản trị viên")
            {
                MessageBox.Show("Không thể xóa tài khoản quản trị viên.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Lấy mã tài khoản từ dòng được chọn
            string maTK = materialListView1.SelectedItems[0].Text;

            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản này không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Thực hiện xóa tài khoản
                bool success = _taiKhoanBUS.XoaTaiKhoan(maTK);
                if (success)
                {
                    MessageBox.Show("Xóa tài khoản thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn tài khoản chưa
            if (materialListView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần reset mật khẩu.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Lấy mã tài khoản từ dòng được chọn
            string maTK = materialListView1.SelectedItems[0].Text;

            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn reset mật khẩu về mặc định (12345678) không?",
                "Xác nhận reset mật khẩu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Thực hiện reset mật khẩu
                bool success = _taiKhoanBUS.DatLaiMatKhau(maTK, "12345678");
                if (success)
                {
                    MessageBox.Show("Reset mật khẩu thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            LoadData();
        }
    }
}
