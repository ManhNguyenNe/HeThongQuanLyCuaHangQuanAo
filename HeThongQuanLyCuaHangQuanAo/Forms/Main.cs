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
            //var ucTrangChu = new ucTrangChu();
            //ucTrangChu.Dock = DockStyle.Fill;
            //tpTrangChu.Controls.Add(ucTrangChu);

            var ucSanPham = new ucSanPham();
            ucSanPham.Dock = DockStyle.Fill;
            tpSanPham.Controls.Add(ucSanPham);

            var ucKhachHang = new ucKhachHang();
            ucKhachHang.Dock = DockStyle.Fill;
            tpKhachHang.Controls.Add(ucKhachHang);

            var ucNCC = new ucNCC();
            ucNCC.Dock = DockStyle.Fill;
            tpNhaCungCap.Controls.Add(ucNCC);

            var ucNV = new ucNhanVien();
            ucNV.Dock = DockStyle.Fill;
            tpNhanVien.Controls.Add(ucNV);

            var ucHoaDonNhap = new ucHoaDonNhap();
            ucHoaDonNhap.Dock = DockStyle.Fill;
            tpNhapHang.Controls.Add(ucHoaDonNhap);


            var ucHoaDonBan = new ucHoaDonBan();
            ucHoaDonBan.Dock = DockStyle.Fill;
            tpXuatHang.Controls.Add(ucHoaDonBan);

            var ucTaiKhoan = new ucTaiKhoan();
            ucTaiKhoan.Dock = DockStyle.Fill;
            tpTaiKhoan.Controls.Add(ucTaiKhoan);

            var ucThongKe = new ucThongKe();
            ucThongKe.Dock = DockStyle.Fill;
            tpThongKe.Controls.Add(ucThongKe);

            switch (UserSession.VaiTro)
            {
                case 0: // Admin
                    break;
                case 1: // Nhân viên bán hàng
                    materialTabControl1.TabPages.Remove(tpNhaCungCap);
                    materialTabControl1.TabPages.Remove(tpNhapHang);
                    materialTabControl1.TabPages.Remove(tpNhanVien);
                    materialTabControl1.TabPages.Remove(tpTaiKhoan);
                    materialTabControl1.TabPages.Remove(tpThongKe);
                    break;
                case 2: // Nhân viên kho
                    materialTabControl1.TabPages.Remove(tpKhachHang);
                    materialTabControl1.TabPages.Remove(tpXuatHang);
                    materialTabControl1.TabPages.Remove(tpNhanVien);
                    materialTabControl1.TabPages.Remove(tpTaiKhoan);
                    materialTabControl1.TabPages.Remove(tpThongKe);
                    break;
            }

            materialTabControl1.SelectedIndexChanged += MaterialTabControl1_SelectedIndexChanged;
        }

        private void MaterialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(materialTabControl1.SelectedTab == tpDoiMatKhau)
            {
                var formDoiMatKhau = new formDoiMatKhau(UserSession.MaTK);
                formDoiMatKhau.ShowDialog();
                materialTabControl1.SelectedTab = tpSanPham;
            }
            else if(materialTabControl1.SelectedTab == tpDangXuat)
            {
                // Hủy việc chọn tab đăng xuất
                materialTabControl1.SelectedTab = tpSanPham;
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

            switch (materialTabControl1.SelectedTab.Name)
            {
                case "tpTrangChu":
                    this.Text = "Trang chủ";
                    break;
                case "tpSanPham":
                    this.Text = "Quản lý sản phẩm";
                    break;
                case "tpKhachHang":
                    this.Text = "Quản lý khách hàng";
                    break;
                case "tpNhaCungCap":
                    this.Text = "Quản lý nhà cung cấp";
                    break;
                case "tpNhanVien":
                    this.Text = "Quản lý nhân viên";
                    break;
                case "tpNhapHang":
                    this.Text = "Quản lý nhập hàng";
                    break;
                case "tpXuatHang":
                    this.Text = "Quản lý xuất hàng";
                    break;
                case "tpTaiKhoan":
                    this.Text = "Quản lý tài khoản";
                    break;
                case "tpThongKe":
                    this.Text = "Thống kê";
                    break;
            }
        }

      
    }
}
