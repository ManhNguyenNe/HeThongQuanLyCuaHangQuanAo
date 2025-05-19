using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HeThongQuanLyCuaHangQuanAo.BUS;
using HeThongQuanLyCuaHangQuanAo.Models;
using HeThongQuanLyCuaHangQuanAo.ViewModels;
using MaterialSkin.Controls;

namespace HeThongQuanLyCuaHangQuanAo.Forms
{
    public partial class CapNhatSanPham : MaterialForm
    {
        private readonly string _maQuanAo;

        private readonly SanPhamBUS _sanPhamBUS;
        private readonly TheLoaiBUS _theLoaiBUS;
        private readonly CoBUS _coBUS;
        private readonly ChatLieuBUS _chatLieuBUS;
        private readonly MauBUS _mauBUS;
        private readonly DoiTuongBUS _doiTuongBUS;
        private readonly MuaBUS _muaBUS;
        private readonly NoiSanXuatBUS _nsxBUS;

        private string _selectedImagePath; // Biến để lưu đường dẫn ảnh đã chọn
        private string _newImagePath; // Biến để lưu đường dẫn ảnh mới đã chọn
        public CapNhatSanPham(string maQuanAo)
        {
            InitializeComponent();
            _maQuanAo = maQuanAo;
            // Khởi tạo các BUS
            _sanPhamBUS = new SanPhamBUS();
            _theLoaiBUS = new TheLoaiBUS();
            _coBUS = new CoBUS();
            _chatLieuBUS = new ChatLieuBUS();
            _mauBUS = new MauBUS();
            _doiTuongBUS = new DoiTuongBUS();
            _muaBUS = new MuaBUS();
            _nsxBUS = new NoiSanXuatBUS();

        }

        private void CapNhatSanPham_Load(object sender, EventArgs e)
        {
            // Lấy thông tin sản phẩm từ database
            var sanPham = _sanPhamBUS.GetSanPhamById(_maQuanAo);
            if (sanPham != null)
            {
                // Hiển thị mã sản phẩm
                lblMaQA.Text = "Mã sản phẩm: " + sanPham.MaQuanAo;

                // Đổ dữ liệu vào các controls
                txtTenQA.Text = sanPham.TenQuanAo;
                txtDonGiaNhap.Text = sanPham.DonGiaNhap.ToString();
                txtDonGiaBan.Text = sanPham.DonGiaBan.ToString();

                // Lưu đường dẫn ảnh hiện tại
                _selectedImagePath = sanPham.Anh;

                // Load dữ liệu cho các ComboBox
                LoadComboBoxData();
                SetComboBoxSelectedValues(sanPham);

                // Hiển thị ảnh sản phẩm nếu có
                LoadProductImage(sanPham.Anh);
            }
        }

        private void LoadComboBoxData()
        {
            // Load dữ liệu cho ComboBox Thể loại
            cboLoai.DataSource = _theLoaiBUS.GetAll();
            cboLoai.DisplayMember = "TenLoai";
            cboLoai.ValueMember = "MaLoai";

            // Load dữ liệu cho ComboBox Cỡ
            cboCo.DataSource = _coBUS.GetAll();
            cboCo.DisplayMember = "TenCo";
            cboCo.ValueMember = "MaCo";

            // Load dữ liệu cho ComboBox Chất liệu
            cboChatLieu.DataSource = _chatLieuBUS.GetAll();
            cboChatLieu.DisplayMember = "TenChatLieu";
            cboChatLieu.ValueMember = "MaChatLieu";

            // Load dữ liệu cho ComboBox Màu
            cboMau.DataSource = _mauBUS.GetAll();
            cboMau.DisplayMember = "TenMau";
            cboMau.ValueMember = "MaMau";

            // Load dữ liệu cho ComboBox Đối tượng
            cboDoiTuong.DataSource = _doiTuongBUS.GetAll();
            cboDoiTuong.DisplayMember = "TenDoiTuong";
            cboDoiTuong.ValueMember = "MaDoiTuong";

            // Load dữ liệu cho ComboBox Mùa
            cboMua.DataSource = _muaBUS.GetAll();
            cboMua.DisplayMember = "TenMua";
            cboMua.ValueMember = "MaMua";

            // Load dữ liệu cho ComboBox Nơi sản xuất
            cboNSX.DataSource = _nsxBUS.GetAll();
            cboNSX.DisplayMember = "TenNSX";
            cboNSX.ValueMember = "MaNSX";
        }

        private void SetComboBoxSelectedValues(SanPham sanPham)
        {
            // Chọn giá trị trong các ComboBox dựa trên dữ liệu sản phẩm
            cboLoai.SelectedValue = sanPham.MaLoai;
            cboCo.SelectedValue = sanPham.MaCo;
            cboChatLieu.SelectedValue = sanPham.MaChatLieu;
            cboMau.SelectedValue = sanPham.MaMau;
            cboDoiTuong.SelectedValue = sanPham.MaDoiTuong;
            cboMua.SelectedValue = sanPham.MaMua;
            cboNSX.SelectedValue = sanPham.MaNSX;
        }

        private void LoadProductImage(string imagePath)
        {
            if (!string.IsNullOrEmpty(imagePath))
            {
                try
                {
                    // Lấy đường dẫn thư mục project
                    string projectPath = Application.StartupPath;
                    projectPath = Directory.GetParent(Directory.GetParent(projectPath).FullName).FullName;

                    // Tạo đường dẫn đầy đủ đến ảnh
                    string fullImagePath = Path.Combine(projectPath, imagePath);

                    if (File.Exists(fullImagePath))
                    {
                        pictureBox1.Image = Image.FromFile(fullImagePath);
                        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    else
                    {
                        MessageBox.Show($"Không tìm thấy file ảnh tại đường dẫn: {fullImagePath}");
                        pictureBox1.Image = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi load ảnh: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    pictureBox1.Image = null;
                }
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo đối tượng sản phẩm mới
                var sanPham = new SanPham
                {
                    MaQuanAo = _maQuanAo,
                    TenQuanAo = txtTenQA.Text,
                    MaLoai = cboLoai.SelectedValue.ToString(),
                    MaCo = cboCo.SelectedValue.ToString(),
                    MaChatLieu = cboChatLieu.SelectedValue.ToString(),
                    MaMau = cboMau.SelectedValue.ToString(),
                    MaDoiTuong = cboDoiTuong.SelectedValue.ToString(),
                    MaMua = cboMua.SelectedValue.ToString(),
                    MaNSX = cboNSX.SelectedValue.ToString(),
                    DonGiaNhapStr = txtDonGiaNhap.Text,
                    DonGiaBanStr = txtDonGiaBan.Text,
                    Anh = _newImagePath ?? _selectedImagePath ?? "", // Sử dụng đường dẫn ảnh mới nếu có, nếu không thì dùng ảnh cũ
                    TinhTrang = true
                };

                // Lưu sản phẩm
                if (_sanPhamBUS.ValidateSanPham(sanPham, false))
                {
                    MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo",
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

        private void btnAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                openFileDialog.Title = "Chọn ảnh sản phẩm";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Lấy đường dẫn file ảnh đã chọn
                        string selectedFile = openFileDialog.FileName;

                        // Lấy đường dẫn thư mục project
                        string projectPath = Application.StartupPath;
                        // Đi ngược lại 2 cấp từ thư mục bin/Debug để về thư mục gốc project
                        projectPath = Directory.GetParent(Directory.GetParent(projectPath).FullName).FullName;

                        // Lấy mã sản phẩm mới để đặt tên file
                        string maSanPham = _maQuanAo;

                        // Lấy extension của file ảnh gốc
                        string extension = Path.GetExtension(selectedFile);

                        // Tạo tên file mới sử dụng mã sản phẩm và timestamp để tránh trùng
                        string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                        string newFileName = $"{maSanPham}_{timestamp}{extension}";
                        string destinationPath = Path.Combine(projectPath, "Images", newFileName);

                        // Copy file ảnh vào thư mục Images
                        File.Copy(selectedFile, destinationPath, true);

                        // Lưu đường dẫn tương đối
                        _newImagePath = Path.Combine("Images", newFileName);

                        // Hiển thị ảnh lên PictureBox
                        pictureBox1.Image = Image.FromFile(destinationPath);
                        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xử lý ảnh: {ex.Message}", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void llblLoai_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var formThemLoai = new ThemThuocTinh(ThemThuocTinh.LoaiThuocTinh.TheLoai);
            if (formThemLoai.ShowDialog() == DialogResult.OK)
            {
                // Refresh lại dữ liệu cho ComboBox Loại
                cboLoai.DataSource = _theLoaiBUS.GetAll();
                cboLoai.DisplayMember = "TenLoai";
                cboLoai.ValueMember = "MaLoai";
            }
        }

        private void llblCo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var formThemCo = new ThemThuocTinh(ThemThuocTinh.LoaiThuocTinh.Co);
            if (formThemCo.ShowDialog() == DialogResult.OK)
            {
                // Refresh lại dữ liệu cho ComboBox Cỡ
                cboCo.DataSource = _coBUS.GetAll();
                cboCo.DisplayMember = "TenCo";
                cboCo.ValueMember = "MaCo";
            }
        }

        private void llblChatLieu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var formThemChatLieu = new ThemThuocTinh(ThemThuocTinh.LoaiThuocTinh.ChatLieu);
            if (formThemChatLieu.ShowDialog() == DialogResult.OK)
            {
                // Refresh lại dữ liệu cho ComboBox Chất liệu
                cboChatLieu.DataSource = _chatLieuBUS.GetAll();
                cboChatLieu.DisplayMember = "TenChatLieu";
                cboChatLieu.ValueMember = "MaChatLieu";
            }
        }

        private void llblMau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var formThemMau = new ThemThuocTinh(ThemThuocTinh.LoaiThuocTinh.Mau);
            if (formThemMau.ShowDialog() == DialogResult.OK)
            {
                // Refresh lại dữ liệu cho ComboBox Màu
                cboMau.DataSource = _mauBUS.GetAll();
                cboMau.DisplayMember = "TenMau";
                cboMau.ValueMember = "MaMau";
            }
        }

        private void llblDoiTuong_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var formThemDoiTuong = new ThemThuocTinh(ThemThuocTinh.LoaiThuocTinh.DoiTuong);
            if (formThemDoiTuong.ShowDialog() == DialogResult.OK)
            {
                // Refresh lại dữ liệu cho ComboBox Đối tượng
                cboDoiTuong.DataSource = _doiTuongBUS.GetAll();
                cboDoiTuong.DisplayMember = "TenDoiTuong";
                cboDoiTuong.ValueMember = "MaDoiTuong";
            }
        }

        private void llblMua_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var formThemMua = new ThemThuocTinh(ThemThuocTinh.LoaiThuocTinh.Mua);
            if (formThemMua.ShowDialog() == DialogResult.OK)
            {
                // Refresh lại dữ liệu cho ComboBox Mùa
                cboMua.DataSource = _muaBUS.GetAll();
                cboMua.DisplayMember = "TenMua";
                cboMua.ValueMember = "MaMua";
            }
        }

        private void llblNSX_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var formThemNSX = new ThemThuocTinh(ThemThuocTinh.LoaiThuocTinh.NoiSanXuat);
            if (formThemNSX.ShowDialog() == DialogResult.OK)
            {
                // Refresh lại dữ liệu cho ComboBox NSX
                cboNSX.DataSource = _nsxBUS.GetAll();
                cboNSX.DisplayMember = "TenNSX";
                cboNSX.ValueMember = "MaNSX";
            }
        }
    }
}
