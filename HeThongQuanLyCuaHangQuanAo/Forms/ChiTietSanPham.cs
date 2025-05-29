using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using HeThongQuanLyCuaHangQuanAo.BUS;
using HeThongQuanLyCuaHangQuanAo.Models;
using HeThongQuanLyCuaHangQuanAo.ViewModels;
using System.IO;

namespace HeThongQuanLyCuaHangQuanAo.Forms
{
    public partial class ChiTietSanPham : MaterialForm
    {
        private readonly string _maQuanAo;
        private readonly SanPhamBUS _sanPhamBUS;

        public ChiTietSanPham(string maQuanAo)
        {
            InitializeComponent();
            _maQuanAo = maQuanAo;
            _sanPhamBUS = new SanPhamBUS();
        }

        private void ChiTietSanPham_Load(object sender, EventArgs e)
        {
            var sanPham = _sanPhamBUS.GetSanPhamViewById(_maQuanAo);
            if (sanPham != null)
            {
                lblMaQA.Text = "Mã sản phẩm: " + sanPham.MaQuanAo;
                txtTenQA.Text = sanPham.TenQuanAo;
                txtLoai.Text = sanPham.TenLoai;
                txtCo.Text = sanPham.TenCo;
                txtChatLieu.Text = sanPham.TenChatLieu;
                txtMauSac.Text = sanPham.TenMau;
                txtDoiTuong.Text = sanPham.TenDoiTuong;
                txtMua.Text = sanPham.TenMua;
                txtNSX.Text = sanPham.TenNSX;
                if (UserSession.VaiTro == 1)
                {
                    txtDonGiaNhap.Text = "**********";
                }
                else
                {
                    txtDonGiaNhap.Text = sanPham.DonGiaNhap.ToString();
                }
                txtDonGiaBan.Text = sanPham.DonGiaBan.ToString();

                if (!string.IsNullOrEmpty(sanPham.Anh))
                {
                    try
                    {
                        // Lấy đường dẫn thư mục project
                        string projectPath = Application.StartupPath;
                        projectPath = Directory.GetParent(Directory.GetParent(projectPath).FullName).FullName;

                        // Tạo đường dẫn đầy đủ đến ảnh
                        string imagePath = Path.Combine(projectPath, sanPham.Anh);

                        if (File.Exists(imagePath))
                        {
                            pictureBox1.Image = Image.FromFile(imagePath);
                            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                        else
                        {
                            MessageBox.Show($"Không tìm thấy file ảnh tại đường dẫn: {imagePath}");
                            pictureBox1.Image = null;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi load ảnh: {ex.Message}");
                        pictureBox1.Image = null;
                    }
                }
                //else
                //{
                //    MessageBox.Show("Không có đường dẫn ảnh trong DB");
                //}
            }
        }

    }
}
