namespace HeThongQuanLyCuaHangQuanAo.Forms
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.tpTrangChu = new System.Windows.Forms.TabPage();
            this.tpSanPham = new System.Windows.Forms.TabPage();
            this.tpKhachHang = new System.Windows.Forms.TabPage();
            this.tpNhaCungCap = new System.Windows.Forms.TabPage();
            this.tpNhanVien = new System.Windows.Forms.TabPage();
            this.tpNhapHang = new System.Windows.Forms.TabPage();
            this.tpXuatHang = new System.Windows.Forms.TabPage();
            this.tpTaiKhoan = new System.Windows.Forms.TabPage();
            this.tpDangXuat = new System.Windows.Forms.TabPage();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.materialTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.tpTrangChu);
            this.materialTabControl1.Controls.Add(this.tpSanPham);
            this.materialTabControl1.Controls.Add(this.tpKhachHang);
            this.materialTabControl1.Controls.Add(this.tpNhaCungCap);
            this.materialTabControl1.Controls.Add(this.tpNhanVien);
            this.materialTabControl1.Controls.Add(this.tpNhapHang);
            this.materialTabControl1.Controls.Add(this.tpXuatHang);
            this.materialTabControl1.Controls.Add(this.tpTaiKhoan);
            this.materialTabControl1.Controls.Add(this.tpDangXuat);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialTabControl1.ImageList = this.imageList1;
            this.materialTabControl1.Location = new System.Drawing.Point(3, 64);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Multiline = true;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(1194, 733);
            this.materialTabControl1.TabIndex = 0;
            this.materialTabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.materialTabControl1_Selected);
            // 
            // tpTrangChu
            // 
            this.tpTrangChu.ImageKey = "icons8-analytics-32.png";
            this.tpTrangChu.Location = new System.Drawing.Point(4, 39);
            this.tpTrangChu.Name = "tpTrangChu";
            this.tpTrangChu.Padding = new System.Windows.Forms.Padding(3);
            this.tpTrangChu.Size = new System.Drawing.Size(1186, 690);
            this.tpTrangChu.TabIndex = 0;
            this.tpTrangChu.Text = "Trang chủ";
            this.tpTrangChu.UseVisualStyleBackColor = true;
            // 
            // tpSanPham
            // 
            this.tpSanPham.ImageKey = "icons8-product-32.png";
            this.tpSanPham.Location = new System.Drawing.Point(4, 39);
            this.tpSanPham.Name = "tpSanPham";
            this.tpSanPham.Padding = new System.Windows.Forms.Padding(3);
            this.tpSanPham.Size = new System.Drawing.Size(1186, 690);
            this.tpSanPham.TabIndex = 1;
            this.tpSanPham.Text = "Sản phẩm";
            this.tpSanPham.UseVisualStyleBackColor = true;
            // 
            // tpKhachHang
            // 
            this.tpKhachHang.ImageKey = "icons8-customer-32.png";
            this.tpKhachHang.Location = new System.Drawing.Point(4, 39);
            this.tpKhachHang.Name = "tpKhachHang";
            this.tpKhachHang.Padding = new System.Windows.Forms.Padding(3);
            this.tpKhachHang.Size = new System.Drawing.Size(1186, 690);
            this.tpKhachHang.TabIndex = 2;
            this.tpKhachHang.Text = "Khách hàng";
            this.tpKhachHang.UseVisualStyleBackColor = true;
            // 
            // tpNhaCungCap
            // 
            this.tpNhaCungCap.ImageKey = "icons8-supplier-32.png";
            this.tpNhaCungCap.Location = new System.Drawing.Point(4, 39);
            this.tpNhaCungCap.Name = "tpNhaCungCap";
            this.tpNhaCungCap.Padding = new System.Windows.Forms.Padding(3);
            this.tpNhaCungCap.Size = new System.Drawing.Size(1186, 690);
            this.tpNhaCungCap.TabIndex = 3;
            this.tpNhaCungCap.Text = "Nhà cung cấp";
            this.tpNhaCungCap.UseVisualStyleBackColor = true;
            // 
            // tpNhanVien
            // 
            this.tpNhanVien.ImageKey = "icons8-user-32.png";
            this.tpNhanVien.Location = new System.Drawing.Point(4, 39);
            this.tpNhanVien.Name = "tpNhanVien";
            this.tpNhanVien.Padding = new System.Windows.Forms.Padding(3);
            this.tpNhanVien.Size = new System.Drawing.Size(1186, 690);
            this.tpNhanVien.TabIndex = 4;
            this.tpNhanVien.Text = "Nhân viên";
            this.tpNhanVien.UseVisualStyleBackColor = true;
            // 
            // tpNhapHang
            // 
            this.tpNhapHang.ImageKey = "icons8-input-32.png";
            this.tpNhapHang.Location = new System.Drawing.Point(4, 39);
            this.tpNhapHang.Name = "tpNhapHang";
            this.tpNhapHang.Padding = new System.Windows.Forms.Padding(3);
            this.tpNhapHang.Size = new System.Drawing.Size(1186, 690);
            this.tpNhapHang.TabIndex = 5;
            this.tpNhapHang.Text = "Nhập hàng";
            this.tpNhapHang.UseVisualStyleBackColor = true;
            // 
            // tpXuatHang
            // 
            this.tpXuatHang.ImageKey = "icons8-checkout-32.png";
            this.tpXuatHang.Location = new System.Drawing.Point(4, 39);
            this.tpXuatHang.Name = "tpXuatHang";
            this.tpXuatHang.Padding = new System.Windows.Forms.Padding(3);
            this.tpXuatHang.Size = new System.Drawing.Size(1186, 690);
            this.tpXuatHang.TabIndex = 6;
            this.tpXuatHang.Text = "Xuất hàng";
            this.tpXuatHang.UseVisualStyleBackColor = true;
            // 
            // tpTaiKhoan
            // 
            this.tpTaiKhoan.ImageKey = "icons8-account-32.png";
            this.tpTaiKhoan.Location = new System.Drawing.Point(4, 39);
            this.tpTaiKhoan.Name = "tpTaiKhoan";
            this.tpTaiKhoan.Padding = new System.Windows.Forms.Padding(3);
            this.tpTaiKhoan.Size = new System.Drawing.Size(1186, 690);
            this.tpTaiKhoan.TabIndex = 7;
            this.tpTaiKhoan.Text = "Tài khoản";
            this.tpTaiKhoan.UseVisualStyleBackColor = true;
            // 
            // tpDangXuat
            // 
            this.tpDangXuat.ImageKey = "icons8-logout-32.png";
            this.tpDangXuat.Location = new System.Drawing.Point(4, 39);
            this.tpDangXuat.Name = "tpDangXuat";
            this.tpDangXuat.Padding = new System.Windows.Forms.Padding(3);
            this.tpDangXuat.Size = new System.Drawing.Size(1186, 690);
            this.tpDangXuat.TabIndex = 8;
            this.tpDangXuat.Text = "Đăng xuất";
            this.tpDangXuat.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icons8-account-32.png");
            this.imageList1.Images.SetKeyName(1, "icons8-analytics-32.png");
            this.imageList1.Images.SetKeyName(2, "icons8-customer-32.png");
            this.imageList1.Images.SetKeyName(3, "icons8-product-32.png");
            this.imageList1.Images.SetKeyName(4, "icons8-supplier-32.png");
            this.imageList1.Images.SetKeyName(5, "icons8-user-32.png");
            this.imageList1.Images.SetKeyName(6, "icons8-checkout-32.png");
            this.imageList1.Images.SetKeyName(7, "icons8-input-32.png");
            this.imageList1.Images.SetKeyName(8, "icons8-logout-32.png");
            this.imageList1.Images.SetKeyName(9, "icons8-warehouse-32.png");
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.materialTabControl1);
            this.DrawerShowIconsWhenHidden = true;
            this.DrawerTabControl = this.materialTabControl1;
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.materialTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage tpTrangChu;
        private System.Windows.Forms.TabPage tpSanPham;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TabPage tpKhachHang;
        private System.Windows.Forms.TabPage tpNhaCungCap;
        private System.Windows.Forms.TabPage tpNhanVien;
        private System.Windows.Forms.TabPage tpNhapHang;
        private System.Windows.Forms.TabPage tpXuatHang;
        private System.Windows.Forms.TabPage tpTaiKhoan;
        private System.Windows.Forms.TabPage tpDangXuat;
    }
}