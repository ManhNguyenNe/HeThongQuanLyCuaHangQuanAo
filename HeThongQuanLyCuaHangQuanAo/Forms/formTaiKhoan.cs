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
    public partial class formTaiKhoan : MaterialForm
    {
        private TaiKhoanBUS _taiKhoanBUS = new TaiKhoanBUS();
        private NhanVienBUS _nhanVienBUS = new NhanVienBUS();
        private string _maTK; // Sẽ có giá trị nếu đang ở chế độ cập nhật
        private bool _isUpdateMode; // Cờ để xác định chế độ thêm mới hay cập nhật
        public formTaiKhoan()
        {
            InitializeComponent();
            _isUpdateMode = false;
            this.Text = "Thêm Tài Khoản";
            btnLuu.Text = "Thêm";

            // Load danh sách nhân viên
            LoadNhanVien();

            // Thiết lập combobox vai trò
            materialComboBox1.Items.Add("Admin");
            materialComboBox1.Items.Add("Nhân viên bán hàng");
            materialComboBox1.Items.Add("Nhân viên kho");
            materialComboBox1.SelectedIndex = 1; // Mặc định là nhân viên bán hàng

            // Thiết lập combobox tình trạng
            materialComboBox2.Items.Add("Hoạt động");
            materialComboBox2.Items.Add("Khóa");
            materialComboBox2.SelectedIndex = 0; // Mặc định là hoạt động
        }
        // Constructor cho chế độ cập nhật
        public formTaiKhoan(string maTK)
        {
            InitializeComponent();
            _maTK = maTK;
            _isUpdateMode = true;
            this.Text = "Cập Nhật Tài Khoản";
            btnLuu.Text = "Cập Nhật";

            // Load danh sách nhân viên
            LoadNhanVien();

            // Thiết lập combobox vai trò
            materialComboBox1.Items.Add("Admin");
            materialComboBox1.Items.Add("Nhân viên bán hàng");
            materialComboBox1.Items.Add("Nhân viên kho");

            // Thiết lập combobox tình trạng
            materialComboBox2.Items.Add("Hoạt động");
            materialComboBox2.Items.Add("Khóa");

            // Load dữ liệu tài khoản
            LoadTaiKhoanData();
        }

        private void LoadNhanVien()
        {
            var danhSachNV = _nhanVienBUS.GetAll();
            cbNhanVien.DataSource = danhSachNV;
            cbNhanVien.DisplayMember = "TenNV";
            cbNhanVien.ValueMember = "MaNV";
        }

        private void LoadTaiKhoanData()
        {
            var taiKhoan = _taiKhoanBUS.GetTaiKhoanById(_maTK);
            if (taiKhoan != null)
            {
                // Thiết lập giá trị cho các control
                materialTextBox1.Text = taiKhoan.TenDangNhap;

                // Chọn nhân viên
                for (int i = 0; i < cbNhanVien.Items.Count; i++)
                {
                    var nv = cbNhanVien.Items[i] as dynamic;
                    if (nv != null && nv.MaNV == taiKhoan.MaNV)
                    {
                        cbNhanVien.SelectedIndex = i;
                        break;
                    }
                }

                // Chọn vai trò
                materialComboBox1.SelectedIndex = taiKhoan.VaiTro;

                // Thiết lập trạng thái
                materialComboBox2.SelectedIndex = taiKhoan.TinhTrang ? 0 : 1;

                // Ẩn trường mật khẩu nếu đang ở chế độ cập nhật
                lblMatKhau.Text = "Mật khẩu";
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ form
            string tenDangNhap = materialTextBox1.Text.Trim();
            string matKhau = materialTextBox2.Text.Trim();
            string maNV = cbNhanVien.SelectedValue.ToString();
            int vaiTro = materialComboBox1.SelectedIndex;
            bool tinhTrang = materialComboBox2.SelectedIndex == 0; // 0 là Hoạt động, 1 là Khóa

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(tenDangNhap))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                materialTextBox1.Focus();
                return;
            }

            if (!_isUpdateMode && string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                materialTextBox2.Focus();
                return;
            }

            bool success;
            if (_isUpdateMode)
            {
                // Chế độ cập nhật
                success = _taiKhoanBUS.CapNhatTaiKhoan(_maTK, maNV, tenDangNhap, vaiTro, tinhTrang);

                // Nếu có nhập mật khẩu mới thì cập nhật mật khẩu
                if (!string.IsNullOrEmpty(matKhau))
                {
                    _taiKhoanBUS.DatLaiMatKhau(_maTK, matKhau);
                }

                if (success)
                {
                    MessageBox.Show("Cập nhật tài khoản thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            else
            {
                // Chế độ thêm mới
                success = _taiKhoanBUS.ThemTaiKhoan(maNV, tenDangNhap, matKhau, vaiTro);
                if (success)
                {
                    MessageBox.Show("Thêm tài khoản thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
    }
}
