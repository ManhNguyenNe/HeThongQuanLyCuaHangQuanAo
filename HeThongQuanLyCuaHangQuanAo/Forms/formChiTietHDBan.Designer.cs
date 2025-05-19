namespace HeThongQuanLyCuaHangQuanAo.Forms
{
    partial class formChiTietHDBan
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMaHDBan = new MaterialSkin.Controls.MaterialLabel();
            this.lblTenNhanVien = new MaterialSkin.Controls.MaterialLabel();
            this.lblTenKhachHang = new MaterialSkin.Controls.MaterialLabel();
            this.lblNgayBan = new MaterialSkin.Controls.MaterialLabel();
            this.materialListView1 = new MaterialSkin.Controls.MaterialListView();
            this.clnMaSP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnTenSP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnDonGia = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnSoLuong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblGiamGia = new MaterialSkin.Controls.MaterialLabel();
            this.lblThanhTien = new MaterialSkin.Controls.MaterialLabel();
            this.btnInPDF = new MaterialSkin.Controls.MaterialButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.materialListView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 123);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1588, 833);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.44444F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.44444F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.Controls.Add(this.lblMaHDBan, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblTenNhanVien, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblTenKhachHang, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblNgayBan, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnInPDF, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1576, 154);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // lblMaHDBan
            // 
            this.lblMaHDBan.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMaHDBan.AutoSize = true;
            this.lblMaHDBan.Depth = 0;
            this.lblMaHDBan.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblMaHDBan.Location = new System.Drawing.Point(6, 29);
            this.lblMaHDBan.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblMaHDBan.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblMaHDBan.Name = "lblMaHDBan";
            this.lblMaHDBan.Size = new System.Drawing.Size(91, 19);
            this.lblMaHDBan.TabIndex = 0;
            this.lblMaHDBan.Text = "Mã hóa đơn:";
            // 
            // lblTenNhanVien
            // 
            this.lblTenNhanVien.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTenNhanVien.AutoSize = true;
            this.lblTenNhanVien.Depth = 0;
            this.lblTenNhanVien.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTenNhanVien.Location = new System.Drawing.Point(6, 106);
            this.lblTenNhanVien.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTenNhanVien.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTenNhanVien.Name = "lblTenNhanVien";
            this.lblTenNhanVien.Size = new System.Drawing.Size(76, 19);
            this.lblTenNhanVien.TabIndex = 4;
            this.lblTenNhanVien.Text = "Nhân viên:";
            // 
            // lblTenKhachHang
            // 
            this.lblTenKhachHang.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTenKhachHang.AutoSize = true;
            this.lblTenKhachHang.Depth = 0;
            this.lblTenKhachHang.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTenKhachHang.Location = new System.Drawing.Point(706, 106);
            this.lblTenKhachHang.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTenKhachHang.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTenKhachHang.Name = "lblTenKhachHang";
            this.lblTenKhachHang.Size = new System.Drawing.Size(90, 19);
            this.lblTenKhachHang.TabIndex = 3;
            this.lblTenKhachHang.Text = "Khách hàng:";
            // 
            // lblNgayBan
            // 
            this.lblNgayBan.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNgayBan.AutoSize = true;
            this.lblNgayBan.Depth = 0;
            this.lblNgayBan.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblNgayBan.Location = new System.Drawing.Point(706, 29);
            this.lblNgayBan.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblNgayBan.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblNgayBan.Name = "lblNgayBan";
            this.lblNgayBan.Size = new System.Drawing.Size(73, 19);
            this.lblNgayBan.TabIndex = 5;
            this.lblNgayBan.Text = "Ngày bán:";
            // 
            // materialListView1
            // 
            this.materialListView1.AutoSizeTable = false;
            this.materialListView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialListView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.materialListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnMaSP,
            this.clnTenSP,
            this.clnDonGia,
            this.clnSoLuong});
            this.materialListView1.Depth = 0;
            this.materialListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialListView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialListView1.FullRowSelect = true;
            this.materialListView1.HideSelection = false;
            this.materialListView1.Location = new System.Drawing.Point(6, 172);
            this.materialListView1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.materialListView1.MinimumSize = new System.Drawing.Size(400, 192);
            this.materialListView1.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialListView1.MouseState = MaterialSkin.MouseState.OUT;
            this.materialListView1.Name = "materialListView1";
            this.materialListView1.OwnerDraw = true;
            this.materialListView1.Size = new System.Drawing.Size(1576, 571);
            this.materialListView1.TabIndex = 2;
            this.materialListView1.UseCompatibleStateImageBehavior = false;
            this.materialListView1.View = System.Windows.Forms.View.Details;
            // 
            // clnMaSP
            // 
            this.clnMaSP.Text = "Mã sản phẩm";
            this.clnMaSP.Width = 200;
            // 
            // clnTenSP
            // 
            this.clnTenSP.Text = "Tên sản phẩm";
            this.clnTenSP.Width = 200;
            // 
            // clnDonGia
            // 
            this.clnDonGia.Text = "Đơn giá";
            this.clnDonGia.Width = 200;
            // 
            // clnSoLuong
            // 
            this.clnSoLuong.Text = "Số lượng";
            this.clnSoLuong.Width = 200;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.lblGiamGia, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblThanhTien, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(6, 755);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1576, 72);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // lblGiamGia
            // 
            this.lblGiamGia.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblGiamGia.AutoSize = true;
            this.lblGiamGia.Depth = 0;
            this.lblGiamGia.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblGiamGia.Location = new System.Drawing.Point(6, 26);
            this.lblGiamGia.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblGiamGia.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblGiamGia.Name = "lblGiamGia";
            this.lblGiamGia.Size = new System.Drawing.Size(69, 19);
            this.lblGiamGia.TabIndex = 0;
            this.lblGiamGia.Text = "Giảm giá:";
            // 
            // lblThanhTien
            // 
            this.lblThanhTien.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblThanhTien.AutoSize = true;
            this.lblThanhTien.Depth = 0;
            this.lblThanhTien.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblThanhTien.Location = new System.Drawing.Point(794, 26);
            this.lblThanhTien.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblThanhTien.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblThanhTien.Name = "lblThanhTien";
            this.lblThanhTien.Size = new System.Drawing.Size(81, 19);
            this.lblThanhTien.TabIndex = 1;
            this.lblThanhTien.Text = "Thành tiền:";
            // 
            // btnInPDF
            // 
            this.btnInPDF.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnInPDF.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnInPDF.Depth = 0;
            this.btnInPDF.HighEmphasis = true;
            this.btnInPDF.Icon = null;
            this.btnInPDF.Location = new System.Drawing.Point(1404, 6);
            this.btnInPDF.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnInPDF.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnInPDF.Name = "btnInPDF";
            this.btnInPDF.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnInPDF.Size = new System.Drawing.Size(64, 36);
            this.btnInPDF.TabIndex = 6;
            this.btnInPDF.Text = "In";
            this.btnInPDF.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnInPDF.UseAccentColor = false;
            this.btnInPDF.UseVisualStyleBackColor = true;
            // 
            // formChiTietHDBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 962);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "formChiTietHDBan";
            this.Padding = new System.Windows.Forms.Padding(6, 123, 6, 6);
            this.Text = "Chi Tiết Hóa Đơn";
            this.Load += new System.EventHandler(this.ChiTietHDBan_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private MaterialSkin.Controls.MaterialListView materialListView1;
        private System.Windows.Forms.ColumnHeader clnMaSP;
        private System.Windows.Forms.ColumnHeader clnTenSP;
        private System.Windows.Forms.ColumnHeader clnDonGia;
        private System.Windows.Forms.ColumnHeader clnSoLuong;
        private MaterialSkin.Controls.MaterialLabel lblMaHDBan;
        private MaterialSkin.Controls.MaterialLabel lblTenKhachHang;
        private MaterialSkin.Controls.MaterialLabel lblTenNhanVien;
        private MaterialSkin.Controls.MaterialLabel lblNgayBan;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private MaterialSkin.Controls.MaterialLabel lblGiamGia;
        private MaterialSkin.Controls.MaterialLabel lblThanhTien;
        private MaterialSkin.Controls.MaterialButton btnInPDF;
    }
}