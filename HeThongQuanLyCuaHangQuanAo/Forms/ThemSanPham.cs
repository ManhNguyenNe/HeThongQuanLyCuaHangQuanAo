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
using MaterialSkin.Controls;

namespace HeThongQuanLyCuaHangQuanAo.Forms
{
    public partial class ThemSanPham : MaterialForm
    {
        private readonly SanPhamBUS _sanPhamBUS;
        private readonly TheLoaiBUS _theLoaiBUS;
        private readonly CoBUS _coBUS;
        private readonly ChatLieuBUS _chatLieuBUS;
        private readonly MauBUS _mauBUS;
        private readonly DoiTuongBUS _doiTuongBUS;
        private readonly MuaBUS _muaBUS;
        private readonly NoiSanXuatBUS _nsxBUS;
        private string _selectedImagePath; // Biến để lưu đường dẫn ảnh đã chọn
        public ThemSanPham()
        {
            InitializeComponent();

            // Khởi tạo các BUS
            _sanPhamBUS = new SanPhamBUS();
            _theLoaiBUS = new TheLoaiBUS();
            _coBUS = new CoBUS();
            _chatLieuBUS = new ChatLieuBUS();
            _mauBUS = new MauBUS();
            _doiTuongBUS = new DoiTuongBUS();
            _muaBUS = new MuaBUS();
            _nsxBUS = new NoiSanXuatBUS();

            // Load dữ liệu cho ComboBox khi form được tạo
            LoadComboBoxData();
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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo đối tượng sản phẩm mới
                var sanPham = new SanPham
                {
                    MaQuanAo = _sanPhamBUS.GenerateNewSanPhamID(),
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
                    Anh = _selectedImagePath ?? "", // Sử dụng đường dẫn ảnh đã chọn
                    TinhTrang = true
                };

                // Lưu sản phẩm
                if (_sanPhamBUS.ValidateSanPham(sanPham, true))
                {
                    MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo",
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

                        // Tạo thư mục Images trong thư mục gốc project
                        string imagesFolder = Path.Combine(projectPath, "Images");
                        if (!Directory.Exists(imagesFolder))
                        {
                            Directory.CreateDirectory(imagesFolder);
                        }

                        // Lấy mã sản phẩm mới để đặt tên file
                        string maSanPham = _sanPhamBUS.GenerateNewSanPhamID();

                        // Lấy extension của file ảnh gốc
                        string extension = Path.GetExtension(selectedFile);

                        // Tạo tên file mới sử dụng mã sản phẩm và timestamp để tránh trùng
                        string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                        string newFileName = $"{maSanPham}_{timestamp}{extension}";
                        string destinationPath = Path.Combine(projectPath, "Images", newFileName);

                        // Copy file ảnh vào thư mục Images
                        File.Copy(selectedFile, destinationPath, true);

                        // Lưu đường dẫn tương đối
                        _selectedImagePath = Path.Combine("Images", newFileName);

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

                // Chọn item cuối cùng (item vừa thêm)
                //cboLoai.SelectedIndex = cboLoai.Items.Count - 1;
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

                // Chọn item cuối cùng (item vừa thêm)
                //cboNSX.SelectedIndex = cboNSX.Items.Count - 1;
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

                // Chọn item cuối cùng (item vừa thêm)
                //cboCo.SelectedIndex = cboCo.Items.Count - 1;
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

                // Chọn item cuối cùng (item vừa thêm)
                //cboChatLieu.SelectedIndex = cboChatLieu.Items.Count - 1;
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

                // Chọn item cuối cùng (item vừa thêm)
                //cboMau.SelectedIndex = cboMau.Items.Count - 1;
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

                // Chọn item cuối cùng (item vừa thêm)
                //cboDoiTuong.SelectedIndex = cboDoiTuong.Items.Count - 1;
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

                // Chọn item cuối cùng (item vừa thêm)
                //cboMua.SelectedIndex = cboMua.Items.Count - 1;
            }
        }
    }
}
