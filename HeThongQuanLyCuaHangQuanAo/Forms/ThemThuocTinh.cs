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
    public partial class ThemThuocTinh : MaterialForm
    {
        public enum LoaiThuocTinh
        {
            TheLoai,
            Co,
            ChatLieu,
            Mau,
            DoiTuong,
            Mua,
            NoiSanXuat,
            CongViec
        }

        private readonly LoaiThuocTinh _loaiThuocTinh;
        private readonly TheLoaiBUS _theLoaiBUS;
        private readonly CoBUS _coBUS;
        private readonly ChatLieuBUS _chatLieuBUS;
        private readonly MauBUS _mauBUS;
        private readonly DoiTuongBUS _doiTuongBUS;
        private readonly MuaBUS _muaBUS;
        private readonly NoiSanXuatBUS _nsxBUS;
        private readonly CongViecBUS _congViecBUS;

        public ThemThuocTinh(LoaiThuocTinh loaiThuocTinh)
        {
            InitializeComponent();
            _loaiThuocTinh = loaiThuocTinh;

            // Khởi tạo các BUS tùy theo loại thuộc tính
            switch (_loaiThuocTinh)
            {
                case LoaiThuocTinh.TheLoai:
                    _theLoaiBUS = new TheLoaiBUS();
                    this.Text = "Thêm Loại";
                    lblThuocTinh.Text = "Tên Loại:";
                    break;
                case LoaiThuocTinh.Co:
                    _coBUS = new CoBUS();
                    this.Text = "Thêm Cỡ";
                    lblThuocTinh.Text = "Tên Cỡ:";
                    break;
                case LoaiThuocTinh.ChatLieu:
                    _chatLieuBUS = new ChatLieuBUS();
                    this.Text = "Thêm Chất Liệu";
                    lblThuocTinh.Text = "Tên Chất Liệu:";
                    break;
                case LoaiThuocTinh.Mau:
                    _mauBUS = new MauBUS();
                    this.Text = "Thêm Màu";
                    lblThuocTinh.Text = "Tên Màu:";
                    break;
                case LoaiThuocTinh.DoiTuong:
                    _doiTuongBUS = new DoiTuongBUS();
                    this.Text = "Thêm Đối Tượng";
                    lblThuocTinh.Text = "Tên Đối Tượng:";
                    break;
                case LoaiThuocTinh.Mua:
                    _muaBUS = new MuaBUS();
                    this.Text = "Thêm Mùa";
                    lblThuocTinh.Text = "Tên Mùa:";
                    break;
                case LoaiThuocTinh.NoiSanXuat:
                    _nsxBUS = new NoiSanXuatBUS();
                    this.Text = "Thêm Nơi Sản Xuất";
                    lblThuocTinh.Text = "Tên Nơi Sản Xuất:";
                    break;
                case LoaiThuocTinh.CongViec:
                    _congViecBUS = new CongViecBUS();
                    this.Text = "Thêm Công Việc";
                    lblThuocTinh.Text = "Tên Công Việc:";
                    break;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string tenThuocTinh = txtThuocTinh.Text.Trim();

            if (string.IsNullOrEmpty(tenThuocTinh))
            {
                MessageBox.Show("Vui lòng nhập tên thuộc tính!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool result = false;

            try
            {
                // Thêm thuộc tính tùy theo loại
                switch (_loaiThuocTinh)
                {
                    case LoaiThuocTinh.TheLoai:
                        result = _theLoaiBUS.Add(tenThuocTinh);
                        break;
                    case LoaiThuocTinh.Co:
                        result = _coBUS.Add(tenThuocTinh);
                        break;
                    case LoaiThuocTinh.ChatLieu:
                        result = _chatLieuBUS.Add(tenThuocTinh);
                        break;
                    case LoaiThuocTinh.Mau:
                        result = _mauBUS.Add(tenThuocTinh);
                        break;
                    case LoaiThuocTinh.DoiTuong:
                        result = _doiTuongBUS.Add(tenThuocTinh);
                        break;
                    case LoaiThuocTinh.Mua:
                        result = _muaBUS.Add(tenThuocTinh);
                        break;
                    case LoaiThuocTinh.NoiSanXuat:
                        result = _nsxBUS.Add(tenThuocTinh);
                        break;
                    case LoaiThuocTinh.CongViec:
                        result = _congViecBUS.Add(tenThuocTinh);
                        break;
                }

                if (result)
                {
                    MessageBox.Show("Thêm thuộc tính thành công!", "Thông báo",
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
    }
}
