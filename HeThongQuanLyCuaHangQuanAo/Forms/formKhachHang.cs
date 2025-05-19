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
    public partial class formKhachHang : MaterialForm
    {
        private KhachHangBUS _khachHangBUS;
        private string _maKhach; // Sẽ có giá trị nếu đang ở chế độ cập nhật
        private bool _isUpdateMode; // Cờ để xác định chế độ thêm mới hay cập nhật

        // Constructor cho chế độ thêm mới
        public formKhachHang()
        {
            InitializeComponent();
            _khachHangBUS = new KhachHangBUS();
            _isUpdateMode = false;
            this.Text = "Thêm Khách Hàng";
            btnLuu.Text = "Thêm";
        }

        // Constructor cho chế độ cập nhật
        public formKhachHang(string maKhach)
        {
            InitializeComponent();
            _khachHangBUS = new KhachHangBUS();
            _maKhach = maKhach;
            _isUpdateMode = true;
            this.Text = "Cập Nhật Khách Hàng";
            btnLuu.Text = "Cập Nhật";
            LoadKhachHangData();
        }

        private void LoadKhachHangData()
        {
            if (_isUpdateMode && !string.IsNullOrEmpty(_maKhach))
            {
                var khachHang = _khachHangBUS.GetById(_maKhach);
                if (khachHang != null)
                {
                    txtTenKhachHang.Text = khachHang.TenKhach;
                    txtDiaChi.Text = khachHang.DiaChi;
                    txtSDT.Text = khachHang.DienThoai;
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string tenKhach = txtTenKhachHang.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string dienThoai = txtSDT.Text.Trim();

            bool success;
            if (_isUpdateMode)
            {
                // Chế độ cập nhật
                success = _khachHangBUS.Update(_maKhach, tenKhach, diaChi, dienThoai);
                if (success)
                {
                    MessageBox.Show("Cập nhật khách hàng thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            else
            {
                // Chế độ thêm mới
                success = _khachHangBUS.Add(tenKhach, diaChi, dienThoai);
                if (success)
                {
                    MessageBox.Show("Thêm khách hàng thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
    }
}
