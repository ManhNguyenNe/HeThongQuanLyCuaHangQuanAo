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
        public formTaiKhoan()
        {
            InitializeComponent();
            this.Text = "Thêm Tài Khoản";
            btnLuu.Text = "Thêm";

            // Load danh sách nhân viên
            LoadNhanVien();

            // Thiết lập combobox vai trò
            materialComboBox1.Items.Add("Admin");
            materialComboBox1.Items.Add("Nhân viên bán hàng");
            materialComboBox1.Items.Add("Nhân viên kho");
            materialComboBox1.SelectedIndex = 1; // Mặc định là nhân viên bán hàng
        }


        private void LoadNhanVien()
        {
            var danhSachNV = _nhanVienBUS.GetAll();
            cbNhanVien.DataSource = danhSachNV;
            cbNhanVien.DisplayMember = "TenNV";
            cbNhanVien.ValueMember = "MaNV";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ form
                string tenDangNhap = materialTextBox1.Text.Trim();
                string matKhau = materialTextBox2.Text.Trim();
                string maNV = cbNhanVien.SelectedValue.ToString();
                int vaiTro = materialComboBox1.SelectedIndex;

                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(matKhau))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Thực hiện thêm tài khoản nhưng KHÔNG đóng form
                bool success = _taiKhoanBUS.ThemTaiKhoan(maNV, tenDangNhap, matKhau, vaiTro);

                if (success)
                {
                    MessageBox.Show("Thêm tài khoản thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
