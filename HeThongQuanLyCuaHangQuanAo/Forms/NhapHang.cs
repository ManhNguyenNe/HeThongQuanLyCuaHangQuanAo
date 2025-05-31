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
using MaterialSkin;
using MaterialSkin.Controls;

namespace HeThongQuanLyCuaHangQuanAo.Forms
{
    public partial class NhapHang : MaterialForm
    {
        private MaterialListBox listBoxSuggestions;
        private List<NCC> _danhSachNCC; // lưu danh sách NCC gốc

        private SanPhamBUS _sanPhamBUS = new SanPhamBUS();
        private HDNhapBUS _hdnBUS = new HDNhapBUS();
        // private ChiTietHDNhapBUS _chiTietHDNhapBUS = new ChiTietHDNhapBUS();
        private NCCBUS _nccBUS = new NCCBUS();
        private List<tempChiTietHoaDonNhap> _gioHang = new List<tempChiTietHoaDonNhap>();
        private decimal _tongTien = 0;
        private string _maNhanVien = UserSession.MaNV;

        public NhapHang()
        {
            InitializeComponent();

            listBoxSuggestions = new MaterialListBox
            {
                Width = txtNCC.Width,
                Height = 200,
                Visible = false
            };

            this.Controls.Add(listBoxSuggestions);
            listBoxSuggestions.BringToFront();

            // Sự kiện hiển thị khi focus vào TextBox
            txtNCC.GotFocus += (s, e) =>
            {
                listBoxSuggestions.Visible = true;
            };

            // Ẩn listBoxSuggestions khi txtSDTNCC hoặc listBoxSuggestions mất focus
            txtNCC.LostFocus += (s, e) => HideListBoxIfFocusLost();
            listBoxSuggestions.LostFocus += (s, e) => HideListBoxIfFocusLost();

            listBoxSuggestions.SelectedIndexChanged += ListBoxSuggestions_SelectedIndexChanged;


            // Bắt sự kiện gõ trong textbox để lọc listbox
            txtNCC.TextChanged += (s, e) =>
            {
                UpdateSuggestionList(txtNCC.Text);
            };
        }

        private void NhapHang_Load(object sender, EventArgs e)
        {
            Point screenPos = txtNCC.PointToScreen(Point.Empty);
            Point posInForm = this.PointToClient(screenPos);
            listBoxSuggestions.Location = new Point(posInForm.X, posInForm.Y + txtNCC.Height);

            LoadSanPham();
            LoadNCC();
            UpdateTongTien();
            numGiamGia.Value = 0;
        }

        private void HideListBoxIfFocusLost()
        {
            this.BeginInvoke(new Action(() =>
            {
                if (!txtNCC.Focused && !listBoxSuggestions.Focused)
                {
                    listBoxSuggestions.Visible = false;
                }
            }));
        }

        private void LoadSanPham()
        {
            var danhSachSanPham = _sanPhamBUS.GetSanPhamViews();
            materialListView1.Items.Clear();

            foreach (var sp in danhSachSanPham)
            {
                var item = new ListViewItem(sp.MaQuanAo);
                item.SubItems.Add(sp.TenQuanAo);
                item.SubItems.Add(sp.TenCo);
                item.SubItems.Add(sp.TenMau);
                item.SubItems.Add(sp.DonGiaNhap.ToString("N0") + " VNĐ");
                materialListView1.Items.Add(item);
            }
        }
        private void LoadNCC()
        {
            _danhSachNCC = _nccBUS.GetAll();

            UpdateSuggestionList("");
            listBoxSuggestions.Visible = false; // Ẩn listBox lúc form mới load
        }

        private void UpdateSuggestionList(string filter)
        {
            var filtered = _danhSachNCC
                .Where(ncc => ncc.TenNCC.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0
                           || ncc.DienThoai.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            listBoxSuggestions.Items.Clear();

            foreach (var ncc in filtered)
            {
                var item = new MaterialListBoxItem($"{ncc.TenNCC} - {ncc.DienThoai}");
                item.Tag = ncc.MaNCC;
                listBoxSuggestions.Items.Add(item);
            }

            listBoxSuggestions.Visible = filtered.Any();
        }

        private void ListBoxSuggestions_SelectedIndexChanged(object sender, MaterialListBoxItem selectedItem)
        {
            if (selectedItem != null)
            {
                // Lấy mã NCC từ Tag để gán lên textbox
                string maNCC = selectedItem.Tag?.ToString() ?? "";

                txtNCC.Text = maNCC;

                listBoxSuggestions.Visible = false;

                txtNCC.Focus();
                txtNCC.SelectionStart = txtNCC.Text.Length;
            }
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            if (materialListView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần thêm vào hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int soLuong = (int)numSoLuong.Value;
            if (soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maSP = materialListView1.SelectedItems[0].Text;
            var sanPham = _sanPhamBUS.GetSanPhamById(maSP);

            if (sanPham == null)
            {
                MessageBox.Show("Không tìm thấy thông tin sản phẩm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var existingItem = _gioHang.FirstOrDefault(x => x.MaQuanAo == maSP);
            if (existingItem != null)
            {
                existingItem.SoLuong += soLuong;
                existingItem.ThanhTien = existingItem.SoLuong * sanPham.DonGiaNhap;
            }
            else
            {
                // Thêm sản phẩm mới vào giỏ hàng
                var chiTiet = new tempChiTietHoaDonNhap
                {
                    MaQuanAo = maSP,
                    TenQuanAo = materialListView1.SelectedItems[0].SubItems[1].Text,
                    Co = materialListView1.SelectedItems[0].SubItems[2].Text,
                    Mau = materialListView1.SelectedItems[0].SubItems[3].Text,
                    DonGiaNhap = sanPham.DonGiaNhap,
                    SoLuong = soLuong,
                    ThanhTien = soLuong * sanPham.DonGiaNhap
                };
                _gioHang.Add(chiTiet);
            }

            // Cập nhật hiển thị giỏ hàng
            HienThiGioHang();
            UpdateTongTien();
            numSoLuong.Value = 1;
        }

        private void HienThiGioHang()
        {
            materialListView2.Items.Clear();
            foreach (var item in _gioHang)
            {
                var lvItem = new ListViewItem(item.MaQuanAo);
                lvItem.SubItems.Add(item.TenQuanAo);
                lvItem.SubItems.Add(item.Co);
                lvItem.SubItems.Add(item.Mau);
                lvItem.SubItems.Add(item.DonGiaNhap.ToString("N0") + " VNĐ");
                lvItem.SubItems.Add(item.SoLuong.ToString());
                materialListView2.Items.Add(lvItem);
            }
        }

        private void UpdateTongTien()
        {
            decimal tongTienGoc = _gioHang.Sum(x => x.ThanhTien);
            decimal giamGia = numGiamGia.Value;

            if (giamGia > 0)
            {
                _tongTien = tongTienGoc * (1 - giamGia / 100);
            }
            else
            {
                _tongTien = tongTienGoc;
            }

            lblTongTien.Text = "Tổng tiền: " + _tongTien.ToString("N0") + " VNĐ";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (materialListView2.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa khỏi hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maSP = materialListView2.SelectedItems[0].Text;
            var item = _gioHang.FirstOrDefault(x => x.MaQuanAo == maSP);
            if (item != null)
            {
                _gioHang.Remove(item);
                HienThiGioHang();
                UpdateTongTien();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = rtxtTimKiem.Text.Trim();
            var ketQuaTimKiem = _sanPhamBUS.TimKiemSanPham(tuKhoa);

            materialListView1.Items.Clear();

            foreach (var sp in ketQuaTimKiem)
            {
                var item = new ListViewItem(sp.MaQuanAo);
                item.SubItems.Add(sp.TenQuanAo);
                item.SubItems.Add(sp.TenCo);
                item.SubItems.Add(sp.TenMau);
                item.SubItems.Add(sp.DonGiaBan.ToString("N0") + " VNĐ");
                materialListView1.Items.Add(item);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            rtxtTimKiem.Clear();
            LoadSanPham();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_gioHang.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm sản phẩm vào hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (string.IsNullOrEmpty(txtNCC.Text.Trim()))
                {
                    MessageBox.Show("Vui lòng chọn nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string maNCC = txtNCC.Text.Trim();

                var ncc = _nccBUS.GetById(maNCC);
                if (ncc == null)
                {
                    MessageBox.Show("Không tìm thấy nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNCC.Clear();
                    listBoxSuggestions.Visible = false;
                    return;
                }

                decimal giamGia = numGiamGia.Value;
                if (giamGia < 0 || giamGia > 100)
                {
                    MessageBox.Show("Giảm giá phải từ 0 đến 100%", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                List<HeThongQuanLyCuaHangQuanAo.Models.ChiTietHDNhap> chiTietList = new List<HeThongQuanLyCuaHangQuanAo.Models.ChiTietHDNhap>();
                foreach (var item in _gioHang)
                {
                    var chiTiet = new HeThongQuanLyCuaHangQuanAo.Models.ChiTietHDNhap
                    {
                        SoHDN = "", // Để trống, sẽ được tạo tự động trong TaoHoaDonBan
                        MaQuanAo = item.MaQuanAo,
                        SoLuong = item.SoLuong,
                    };
                    chiTietList.Add(chiTiet);
                }

                bool success = _hdnBUS.TaoHoaDonNhap(_maNhanVien, maNCC, giamGia, chiTietList);

                if (success)
                {
                    MessageBox.Show("Đã lưu hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Lưu hóa đơn thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTinhGiamGia_Click(object sender, EventArgs e)
        {
            decimal giamGia = numGiamGia.Value;
            if (giamGia < 0 || giamGia > 100)
            {
                MessageBox.Show("Giảm giá phải từ 0 đến 100%", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tính lại tổng tiền sau khi giảm giá
            decimal tongTienGoc = _gioHang.Sum(x => x.ThanhTien);
            decimal tongTienSauGiam = tongTienGoc * (1 - giamGia / 100);

            // Cập nhật hiển thị
            lblTongTien.Text = "Tổng tiền: " + tongTienSauGiam.ToString("N0") + " VNĐ";
            _tongTien = tongTienSauGiam;
        }
    }

    // Class để lưu thông tin chi tiết hóa đơn tạm thời
    public class tempChiTietHoaDonNhap
    {
        public string MaQuanAo { get; set; }
        public string TenQuanAo { get; set; }
        public string Co { get; set; }
        public string Mau { get; set; }
        public decimal DonGiaNhap { get; set; }
        public int SoLuong { get; set; }
        public decimal ThanhTien { get; set; }
    }
}
