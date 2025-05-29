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
    public partial class ucNCC : UserControl
    {
        private NCCBUS nccBUS = new NCCBUS();
        public ucNCC()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            var danhSach = nccBUS.GetAll();
            materialListView1.Items.Clear();
            foreach (var ncc in danhSach)
            {
                var item = new ListViewItem(ncc.MaNCC);
                item.SubItems.Add(ncc.TenNCC);
                item.SubItems.Add(ncc.DiaChi);
                item.SubItems.Add(ncc.DienThoai);
                materialListView1.Items.Add(item);
            }
        }

        private void ucNCC_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();
            var danhSach = nccBUS.TimKiem(tuKhoa);

            materialListView1.Items.Clear();
            foreach (var ncc in danhSach)
            {
                var item = new ListViewItem(ncc.MaNCC);
                item.SubItems.Add(ncc.TenNCC);
                item.SubItems.Add(ncc.DiaChi);
                item.SubItems.Add(ncc.DienThoai);
                materialListView1.Items.Add(item);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (materialListView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp cần sửa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string maNCC = materialListView1.SelectedItems[0].Text;
            var formCapNhatNCC = new formNCC(maNCC);
            if (formCapNhatNCC.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var formThemNCC = new formNCC();
            if (formThemNCC.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            LoadData();
        }
    }
}
