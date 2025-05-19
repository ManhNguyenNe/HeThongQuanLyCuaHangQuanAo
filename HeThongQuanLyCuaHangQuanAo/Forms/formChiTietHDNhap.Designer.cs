namespace HeThongQuanLyCuaHangQuanAo.Forms
{
    partial class formChiTietHDNhap
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
            this.lblTenNCC = new MaterialSkin.Controls.MaterialLabel();
            this.lblNgayNhap = new MaterialSkin.Controls.MaterialLabel();
            this.materialListView1 = new MaterialSkin.Controls.MaterialListView();
            this.clnMaSP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnTenSP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnDonGia = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnSoLuong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblGiamGia = new MaterialSkin.Controls.MaterialLabel();
            this.lblThanhTien = new MaterialSkin.Controls.MaterialLabel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.materialListView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 64);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(794, 433);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.lblMaHDBan, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblTenNhanVien, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblTenNCC, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblNgayNhap, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(788, 80);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // lblMaHDBan
            // 
            this.lblMaHDBan.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMaHDBan.AutoSize = true;
            this.lblMaHDBan.Depth = 0;
            this.lblMaHDBan.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblMaHDBan.Location = new System.Drawing.Point(3, 10);
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
            this.lblTenNhanVien.Location = new System.Drawing.Point(3, 50);
            this.lblTenNhanVien.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTenNhanVien.Name = "lblTenNhanVien";
            this.lblTenNhanVien.Size = new System.Drawing.Size(76, 19);
            this.lblTenNhanVien.TabIndex = 4;
            this.lblTenNhanVien.Text = "Nhân viên:";
            // 
            // lblTenNCC
            // 
            this.lblTenNCC.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTenNCC.AutoSize = true;
            this.lblTenNCC.Depth = 0;
            this.lblTenNCC.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTenNCC.Location = new System.Drawing.Point(397, 50);
            this.lblTenNCC.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTenNCC.Name = "lblTenNCC";
            this.lblTenNCC.Size = new System.Drawing.Size(103, 19);
            this.lblTenNCC.TabIndex = 3;
            this.lblTenNCC.Text = "Nhà cung cấp:";
            // 
            // lblNgayNhap
            // 
            this.lblNgayNhap.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNgayNhap.AutoSize = true;
            this.lblNgayNhap.Depth = 0;
            this.lblNgayNhap.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblNgayNhap.Location = new System.Drawing.Point(397, 10);
            this.lblNgayNhap.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblNgayNhap.Name = "lblNgayNhap";
            this.lblNgayNhap.Size = new System.Drawing.Size(82, 19);
            this.lblNgayNhap.TabIndex = 5;
            this.lblNgayNhap.Text = "Ngày nhập:";
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
            this.materialListView1.Location = new System.Drawing.Point(3, 89);
            this.materialListView1.MinimumSize = new System.Drawing.Size(200, 100);
            this.materialListView1.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialListView1.MouseState = MaterialSkin.MouseState.OUT;
            this.materialListView1.Name = "materialListView1";
            this.materialListView1.OwnerDraw = true;
            this.materialListView1.Size = new System.Drawing.Size(788, 297);
            this.materialListView1.TabIndex = 3;
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
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 392);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(788, 38);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // lblGiamGia
            // 
            this.lblGiamGia.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblGiamGia.AutoSize = true;
            this.lblGiamGia.Depth = 0;
            this.lblGiamGia.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblGiamGia.Location = new System.Drawing.Point(3, 9);
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
            this.lblThanhTien.Location = new System.Drawing.Point(397, 9);
            this.lblThanhTien.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblThanhTien.Name = "lblThanhTien";
            this.lblThanhTien.Size = new System.Drawing.Size(81, 19);
            this.lblThanhTien.TabIndex = 1;
            this.lblThanhTien.Text = "Thành tiền:";
            // 
            // formChiTietHDNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "formChiTietHDNhap";
            this.Text = "Chi Tiết Hóa Đơn";
            this.Load += new System.EventHandler(this.formChiTietHDNhap_Load);
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
        private MaterialSkin.Controls.MaterialLabel lblMaHDBan;
        private MaterialSkin.Controls.MaterialLabel lblTenNhanVien;
        private MaterialSkin.Controls.MaterialLabel lblTenNCC;
        private MaterialSkin.Controls.MaterialLabel lblNgayNhap;
        private MaterialSkin.Controls.MaterialListView materialListView1;
        private System.Windows.Forms.ColumnHeader clnMaSP;
        private System.Windows.Forms.ColumnHeader clnTenSP;
        private System.Windows.Forms.ColumnHeader clnDonGia;
        private System.Windows.Forms.ColumnHeader clnSoLuong;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private MaterialSkin.Controls.MaterialLabel lblGiamGia;
        private MaterialSkin.Controls.MaterialLabel lblThanhTien;
    }
}