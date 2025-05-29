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
    public partial class formDoiMatKhau : MaterialForm
    {
        private readonly TaiKhoanBUS _taiKhoanBUS = new TaiKhoanBUS();
        private readonly string _maTK;
        public formDoiMatKhau(string maTK)
        {
            InitializeComponent();
            _maTK = maTK;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string matKhauCu = txtMatKhauCu.Text.Trim();
            string matKhauMoi = txtMatKhauMoi.Text.Trim();
            string xacNhanMatKhauMoi = txtXacNhanMatKhauMoi.Text.Trim();
            if(string.IsNullOrEmpty(matKhauCu) || string.IsNullOrEmpty(matKhauMoi) || string.IsNullOrEmpty(xacNhanMatKhauMoi))
            {
                MessageBox.Show("Vui lòng điền đầy đủ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (matKhauMoi != xacNhanMatKhauMoi)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bool success = _taiKhoanBUS.DoiMatKhau(_maTK, matKhauCu, matKhauMoi);
            if (success)
            {
                MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
