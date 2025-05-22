using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace HeThongQuanLyCuaHangQuanAo.Forms
{
    public partial class Main : MaterialForm
    {
        public Main()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // Hiển thị tên người dùng đăng nhập
            this.Text = $"Hệ thống quản lý cửa hàng quần áo - {UserSession.TenNV}";

            // Phân quyền truy cập
            ApplyPermissions();

            // Load các user control
            LoadUserControls();
        }

        private void ApplyPermissions()
        {
            // Lưu danh sách các tab cần giữ lại
            List<TabPage> tabsToKeep = new List<TabPage>();

            // Tab trang chủ luôn được hiển thị cho tất cả người dùng
            tabsToKeep.Add(tpTrangChu);

            // Phân quyền theo vai trò
            switch (UserSession.VaiTro)
            {
                case 0: // Admin - có quyền truy cập tất cả
                        // Thêm tất cả các tab vào danh sách giữ lại
                    foreach (TabPage tab in materialTabControl1.TabPages)
                    {
                        if (!tabsToKeep.Contains(tab))
                        {
                            tabsToKeep.Add(tab);
                        }
                    }
                    break;
                case 1: // Nhân viên bán hàng - chỉ truy cập tab sản phẩm, khách hàng và xuất hàng
                    tabsToKeep.Add(tpSanPham);
                    tabsToKeep.Add(tpXuatHang);
                    tabsToKeep.Add(tpKhachHang);
                    break;
                case 2: // Nhân viên kho - chỉ truy cập tab sản phẩm, nhà cung cấp và nhập hàng
                    tabsToKeep.Add(tpSanPham);
                    tabsToKeep.Add(tpNhapHang);
                    tabsToKeep.Add(tpNhaCungCap);
                    break;
                default:
                    break;
            }

            // Tab đăng xuất luôn được hiển thị
            tabsToKeep.Add(tpDangXuat);

            // Lưu tất cả các tab vào một danh sách tạm
            List<TabPage> allTabs = new List<TabPage>();
            foreach (TabPage tab in materialTabControl1.TabPages)
            {
                allTabs.Add(tab);
            }

            // Xóa các tab không có trong danh sách giữ lại
            foreach (TabPage tab in allTabs)
            {
                if (!tabsToKeep.Contains(tab))
                {
                    materialTabControl1.TabPages.Remove(tab);
                }
            }
        }

        public bool CheckPermission(string featureName)
        {
            switch (UserSession.VaiTro)
            {
                case 0: // Admin có tất cả quyền
                    return true;
                case 1: // Nhân viên bán hàng
                    if (featureName == "SanPham" || featureName == "XuatHang" || featureName == "KhachHang")
                        return true;
                    break;
                case 2: // Nhân viên kho
                    if (featureName == "SanPham" || featureName == "NhapHang" || featureName == "NhaCungCap")
                        return true;
                    break;
            }

            // Hiển thị thông báo không đủ quyền
            MessageBox.Show("Bạn không có quyền truy cập chức năng này!",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        private void LoadUserControls()
        {
            // Chỉ tải các user control cho các tab mà người dùng có quyền truy cập

            // Tab Sản phẩm - Admin, Nhân viên bán hàng, Nhân viên kho đều có quyền
            if (materialTabControl1.TabPages.Contains(tpSanPham))
            {
                var ucSanPham = new ucSanPham();
                ucSanPham.Dock = DockStyle.Fill;
                tpSanPham.Controls.Add(ucSanPham);
            }

            // Tab Khách hàng - Admin và Nhân viên bán hàng có quyền
            if (materialTabControl1.TabPages.Contains(tpKhachHang))
            {
                var ucKhachHang = new ucKhachHang();
                ucKhachHang.Dock = DockStyle.Fill;
                tpKhachHang.Controls.Add(ucKhachHang);
            }

            // Tab Nhà cung cấp - Admin và Nhân viên kho có quyền
            if (materialTabControl1.TabPages.Contains(tpNhaCungCap))
            {
                var ucNCC = new ucNCC();
                ucNCC.Dock = DockStyle.Fill;
                tpNhaCungCap.Controls.Add(ucNCC);
            }

            // Tab Nhân viên - Chỉ Admin có quyền
            if (materialTabControl1.TabPages.Contains(tpNhanVien))
            {
                var ucNV = new ucNhanVien();
                ucNV.Dock = DockStyle.Fill;
                tpNhanVien.Controls.Add(ucNV);
            }

            // Tab Nhập hàng - Admin và Nhân viên kho có quyền
            if (materialTabControl1.TabPages.Contains(tpNhapHang))
            {
                var ucHoaDonNhap = new ucHoaDonNhap();
                ucHoaDonNhap.Dock = DockStyle.Fill;
                tpNhapHang.Controls.Add(ucHoaDonNhap);
            }

            // Tab Xuất hàng - Admin và Nhân viên bán hàng có quyền
            if (materialTabControl1.TabPages.Contains(tpXuatHang))
            {
                var ucHoaDonBan = new ucHoaDonBan();
                ucHoaDonBan.Dock = DockStyle.Fill;
                tpXuatHang.Controls.Add(ucHoaDonBan);
            }

            // Tab Tài khoản - Chỉ Admin có quyền
            if (materialTabControl1.TabPages.Contains(tpTaiKhoan))
            {
                var ucTaiKhoan = new ucTaiKhoan();
                ucTaiKhoan.Dock = DockStyle.Fill;
                tpTaiKhoan.Controls.Add(ucTaiKhoan);
            }

            // Thêm xử lý cho tab đăng xuất
            materialTabControl1.Selecting += materialTabControl1_Selecting;
        }

        private void materialTabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == tpDangXuat)
            {
                // Hủy việc chọn tab đăng xuất
                e.Cancel = true;

                // Xử lý đăng xuất
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?",
                    "Xác nhận đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Xóa thông tin phiên đăng nhập
                    UserSession.ClearSession();

                    // Đóng form hiện tại và mở form đăng nhập
                    this.Hide();
                    var loginForm = new Login();
                    loginForm.FormClosed += (s, args) => this.Close();
                    loginForm.Show();
                }
            }
        }
    }
}
