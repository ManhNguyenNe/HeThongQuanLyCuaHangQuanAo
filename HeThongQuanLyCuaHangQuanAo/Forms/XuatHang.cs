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
    public partial class XuatHang : MaterialForm
    {
        private MaterialListBox listBoxSuggestions;
        private List<KhachHang> _danhSachKH; // lưu danh sách Khách hàng gốc

        private SanPhamBUS _sanPhamBUS = new SanPhamBUS();
        private HDBanBUS _hdbBUS = new HDBanBUS();
        private ChiTietHDBanBUS _chiTietHDBanBUS = new ChiTietHDBanBUS();
        private KhachHangBUS _khachHangBUS = new KhachHangBUS();
        private List<tempChiTietHoaDonBan> _gioHang = new List<tempChiTietHoaDonBan>();
        private decimal _tongTien = 0;
        private string _maNhanVien = UserSession.MaNV;

        public XuatHang()
        {
            InitializeComponent();

            listBoxSuggestions = new MaterialListBox
            {
                Width = txtKH.Width,
                Height = 200,
                Visible = false
            };

            this.Controls.Add(listBoxSuggestions);
            listBoxSuggestions.BringToFront();

            // Sự kiện hiển thị khi focus vào TextBox
            txtKH.GotFocus += (s, e) =>
            {
                listBoxSuggestions.Visible = true;
            };

            // Ẩn listBoxSuggestions khi txtSDTNCC hoặc listBoxSuggestions mất focus
            txtKH.LostFocus += (s, e) => HideListBoxIfFocusLost();
            listBoxSuggestions.LostFocus += (s, e) => HideListBoxIfFocusLost();

            listBoxSuggestions.SelectedIndexChanged += ListBoxSuggestions_SelectedIndexChanged;


            // Bắt sự kiện gõ trong textbox để lọc listbox
            txtKH.TextChanged += (s, e) =>
            {
                UpdateSuggestionList(txtKH.Text);
            };
        }

        private void XuatHang_Load(object sender, EventArgs e)
        {
            Point screenPos = txtKH.PointToScreen(Point.Empty);
            Point posInForm = this.PointToClient(screenPos);
            listBoxSuggestions.Location = new Point(posInForm.X, posInForm.Y + txtKH.Height);

            LoadSanPham();
            LoadKhachHang();
            UpdateTongTien();
            numGiamGia.Value = 0;
        }

        private void HideListBoxIfFocusLost()
        {
            this.BeginInvoke(new Action(() =>
            {
                if (!txtKH.Focused && !listBoxSuggestions.Focused)
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
                item.SubItems.Add(sp.DonGiaBan.ToString("N0") + " VNĐ");
                materialListView1.Items.Add(item);
            }
        }

        private void LoadKhachHang()
        {
            _danhSachKH = _khachHangBUS.GetAll();

            UpdateSuggestionList("");
            listBoxSuggestions.Visible = false; // Ẩn listBox lúc form mới load
        }

        private void UpdateSuggestionList(string filter)
        {
            var filtered = _danhSachKH
                .Where(kh => kh.TenKhach.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0
                           || kh.DienThoai.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            listBoxSuggestions.Items.Clear();

            foreach (var kh in filtered)
            {
                var item = new MaterialListBoxItem($"{kh.TenKhach} - {kh.DienThoai}");
                item.Tag = kh.MaKhach;
                listBoxSuggestions.Items.Add(item);
            }

            listBoxSuggestions.Visible = filtered.Any();
        }

        private void ListBoxSuggestions_SelectedIndexChanged(object sender, MaterialListBoxItem selectedItem)
        {
            if (selectedItem != null)
            {
                // Lấy mã KH từ Tag để gán lên textbox
                string maKH = selectedItem.Tag?.ToString() ?? "";

                txtKH.Text = maKH;

                listBoxSuggestions.Visible = false;

                txtKH.Focus();
                txtKH.SelectionStart = txtKH.Text.Length;
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

            if (sanPham.SoLuong < soLuong)
            {
                MessageBox.Show($"Số lượng sản phẩm trong kho không đủ. Hiện chỉ còn {sanPham.SoLuong}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra xem sản phẩm đã có trong giỏ hàng chưa
            var existingItem = _gioHang.FirstOrDefault(x => x.MaQuanAo == maSP);
            if (existingItem != null)
            {
                // Cập nhật số lượng nếu sản phẩm đã tồn tại
                existingItem.SoLuong += soLuong;
                existingItem.ThanhTien = existingItem.SoLuong * sanPham.DonGiaBan;
            }
            else
            {
                // Thêm sản phẩm mới vào giỏ hàng
                var chiTiet = new tempChiTietHoaDonBan
                {
                    MaQuanAo = maSP,
                    TenQuanAo = materialListView1.SelectedItems[0].SubItems[1].Text,
                    Co = materialListView1.SelectedItems[0].SubItems[2].Text,
                    Mau = materialListView1.SelectedItems[0].SubItems[3].Text,
                    DonGiaBan = sanPham.DonGiaBan,
                    SoLuong = soLuong,
                    ThanhTien = soLuong * sanPham.DonGiaBan
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
                lvItem.SubItems.Add(item.DonGiaBan.ToString("N0") + " VNĐ");
                lvItem.SubItems.Add(item.SoLuong.ToString());
                materialListView2.Items.Add(lvItem);
            }
        }

        private void UpdateTongTien()
        {
            decimal tongTienGoc = _gioHang.Sum(x => x.ThanhTien);
            decimal giamGia = numGiamGia.Value;

            // Nếu có giảm giá, tính lại tổng tiền
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
                if (string.IsNullOrEmpty(txtKH.Text.Trim()))
                {
                    MessageBox.Show("Vui lòng chọn khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string maKH = txtKH.Text.Trim();

                var ncc = _khachHangBUS.GetById(maKH);
                if (ncc == null)
                {
                    MessageBox.Show("Không tìm thấy khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtKH.Clear();
                    listBoxSuggestions.Visible = false;
                    return;
                }

                // Lấy thông tin giảm giá
                decimal giamGia = numGiamGia.Value;
                if (giamGia < 0 || giamGia > 100)
                {
                    MessageBox.Show("Giảm giá phải từ 0 đến 100%", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo danh sách ChiTietHDBan
                List<HeThongQuanLyCuaHangQuanAo.Models.ChiTietHDBan> chiTietList = new List<HeThongQuanLyCuaHangQuanAo.Models.ChiTietHDBan>();
                foreach (var item in _gioHang)
                {
                    var chiTiet = new HeThongQuanLyCuaHangQuanAo.Models.ChiTietHDBan
                    {
                        SoHDB = "", // Để trống, sẽ được tạo tự động trong TaoHoaDonBan
                        MaQuanAo = item.MaQuanAo,
                        SoLuong = item.SoLuong
                    };
                    chiTietList.Add(chiTiet);
                }

                // Lưu hóa đơn và chi tiết hóa đơn
                bool success = _hdbBUS.TaoHoaDonBan(_maNhanVien, maKH, giamGia, chiTietList);

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
    public class tempChiTietHoaDonBan
    {
        public string MaQuanAo { get; set; }
        public string TenQuanAo { get; set; }
        public string Co { get; set; }
        public string Mau { get; set; }
        public decimal DonGiaBan { get; set; }
        public int SoLuong { get; set; }
        public decimal ThanhTien { get; set; }
    }
}
