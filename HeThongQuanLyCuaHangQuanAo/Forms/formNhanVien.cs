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
using HeThongQuanLyCuaHangQuanAo.Models;
using MaterialSkin.Controls;

namespace HeThongQuanLyCuaHangQuanAo.Forms
{
    public partial class formNhanVien : MaterialForm
    {
        private readonly CongViecBUS _congViecBUS;

        private readonly NhanVienBUS _nhanVienBUS;
        private string _maNhanVien; // Sẽ có giá trị nếu đang ở chế độ cập nhật
        private bool _isUpdateMode; // Cờ để xác định chế độ thêm mới hay cập nhật
        public formNhanVien()
        {
            InitializeComponent();
            
            _nhanVienBUS = new NhanVienBUS();
            _congViecBUS = new CongViecBUS();
            _isUpdateMode = false;
            this.Text = "Thêm Nhân Viên";
            btnLuu.Text = "Thêm";
            LoadComboboxData();
        }

        public formNhanVien(string maNhanVien)
        {
            InitializeComponent();

            _nhanVienBUS = new NhanVienBUS();
            _congViecBUS = new CongViecBUS();
            _maNhanVien = maNhanVien;
            _isUpdateMode = true;
            this.Text = "Cập Nhật Nhân Viên";
            btnLuu.Text = "Cập Nhật";
            LoadComboboxData();
            LoadNhanVienData();
        }

        private void LoadComboboxData()
        {
            cboCongViec.DataSource = _congViecBUS.GetAll();
            cboCongViec.DisplayMember = "TenCV";
            cboCongViec.ValueMember = "MaCV";
        }

        private void LoadNhanVienData()
        {
            if (_isUpdateMode && !string.IsNullOrEmpty(_maNhanVien))
            {
                var nhanVien = _nhanVienBUS.GetById(_maNhanVien);
                if (nhanVien != null)
                {
                    txtTenNhanVien.Text = nhanVien.TenNV;
                    cboGioiTinh.SelectedItem = nhanVien.GioiTinh;
                    dateTimePicker1.Value = nhanVien.NgaySinh;
                    txtSDT.Text = nhanVien.DienThoai;
                    txtDiaChi.Text = nhanVien.DiaChi;

                    // Chọn công việc bằng cách sử dụng SelectedValue
                    cboCongViec.SelectedValue = nhanVien.MaCV;

                    // Chọn tình trạng
                    cboTinhTrang.SelectedItem = nhanVien.TinhTrang;
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string tenNV = txtTenNhanVien.Text.Trim();
            string gioiTinh = cboGioiTinh.SelectedItem?.ToString();
            DateTime ngaySinh = dateTimePicker1.Value;
            string dienThoai = txtSDT.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string maCV = cboCongViec.SelectedValue?.ToString();
            string tinhTrang = cboTinhTrang.SelectedItem?.ToString();

            bool success;
            if (_isUpdateMode)
            {
                // Chế độ cập nhật
                success = _nhanVienBUS.Update(_maNhanVien, tenNV, gioiTinh, ngaySinh, dienThoai, diaChi, maCV, tinhTrang);
                if (success)
                {
                    MessageBox.Show("Cập nhật nhân viên thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            else
            {
                // Chế độ thêm mới
                success = _nhanVienBUS.Add(tenNV, gioiTinh, ngaySinh, dienThoai, diaChi, maCV);
                if (success)
                {
                    MessageBox.Show("Thêm nhân viên thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var formThemCongViec = new ThemThuocTinh(ThemThuocTinh.LoaiThuocTinh.CongViec);
            if (formThemCongViec.ShowDialog() == DialogResult.OK)
            {
                cboCongViec.DataSource = _congViecBUS.GetAll();
                cboCongViec.DisplayMember = "TenCV";
                cboCongViec.ValueMember = "MaCV";
            }
        }
    }
}
