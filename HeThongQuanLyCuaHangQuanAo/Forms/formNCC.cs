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
    public partial class formNCC : MaterialForm
    {
        private NCCBUS _nccBUS;
        private string _maNCC; // Sẽ có giá trị nếu đang ở chế độ cập nhật
        private bool _isUpdateMode; // Cờ để xác định chế độ thêm mới hay cập nhật

        public formNCC()
        {
            InitializeComponent();
            _nccBUS = new NCCBUS();
            _isUpdateMode = false;
            this.Text = "Thêm Nhà Cung Cấp";
            btnLuu.Text = "Thêm";
        }

        // Constructor cho chế độ cập nhật
        public formNCC(string maNCC)
        {
            InitializeComponent();
            _nccBUS = new NCCBUS();
            _maNCC = maNCC;
            _isUpdateMode = true;
            this.Text = "Cập Nhật Nhà Cung Cấp";
            btnLuu.Text = "Cập Nhật";
            LoadNCCData();
        }

        private void LoadNCCData()
        {
            if (_isUpdateMode && !string.IsNullOrEmpty(_maNCC))
            {
                var ncc = _nccBUS.GetById(_maNCC);
                if (ncc != null)
                {
                    txtTenNCC.Text = ncc.TenNCC;
                    txtDiaChi.Text = ncc.DiaChi;
                    txtSDT.Text = ncc.DienThoai;
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string tenNCC = txtTenNCC.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string dienThoai = txtSDT.Text.Trim();

            bool success;
            if (_isUpdateMode)
            {
                // Chế độ cập nhật
                success = _nccBUS.Update(_maNCC, tenNCC, diaChi, dienThoai);
                if (success)
                {
                    MessageBox.Show("Cập nhật nhà cung cấp thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            else
            {
                // Chế độ thêm mới
                success = _nccBUS.Add(tenNCC, diaChi, dienThoai);
                if (success)
                {
                    MessageBox.Show("Thêm nhà cung cấp thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }

    }
}
