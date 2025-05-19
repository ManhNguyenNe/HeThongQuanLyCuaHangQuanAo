namespace HeThongQuanLyCuaHangQuanAo.Forms
{
    partial class formKhachHang
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
            this.lblTenKhach = new MaterialSkin.Controls.MaterialLabel();
            this.lblDiaChi = new MaterialSkin.Controls.MaterialLabel();
            this.lblSDT = new MaterialSkin.Controls.MaterialLabel();
            this.txtDiaChi = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            this.txtTenKhachHang = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtSDT = new MaterialSkin.Controls.MaterialTextBox2();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnLuu = new MaterialSkin.Controls.MaterialButton();
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
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 64);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(594, 333);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.Controls.Add(this.lblTenKhach, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblDiaChi, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblSDT, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtDiaChi, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtTenKhachHang, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtSDT, 2, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(588, 260);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lblTenKhach
            // 
            this.lblTenKhach.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTenKhach.AutoSize = true;
            this.lblTenKhach.Depth = 0;
            this.lblTenKhach.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTenKhach.Location = new System.Drawing.Point(91, 23);
            this.lblTenKhach.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTenKhach.Name = "lblTenKhach";
            this.lblTenKhach.Size = new System.Drawing.Size(115, 19);
            this.lblTenKhach.TabIndex = 0;
            this.lblTenKhach.Text = "Tên khách hàng";
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Depth = 0;
            this.lblDiaChi.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblDiaChi.Location = new System.Drawing.Point(91, 120);
            this.lblDiaChi.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(54, 19);
            this.lblDiaChi.TabIndex = 1;
            this.lblDiaChi.Text = "Địa chỉ:";
            // 
            // lblSDT
            // 
            this.lblSDT.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSDT.AutoSize = true;
            this.lblSDT.Depth = 0;
            this.lblSDT.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblSDT.Location = new System.Drawing.Point(91, 218);
            this.lblSDT.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(99, 19);
            this.lblSDT.TabIndex = 2;
            this.lblSDT.Text = "Số điện thoại:";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtDiaChi.AnimateReadOnly = false;
            this.txtDiaChi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtDiaChi.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDiaChi.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDiaChi.Depth = 0;
            this.txtDiaChi.HideSelection = true;
            this.txtDiaChi.Location = new System.Drawing.Point(238, 76);
            this.txtDiaChi.MaxLength = 32767;
            this.txtDiaChi.MouseState = MaterialSkin.MouseState.OUT;
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.PasswordChar = '\0';
            this.txtDiaChi.ReadOnly = false;
            this.txtDiaChi.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDiaChi.SelectedText = "";
            this.txtDiaChi.SelectionLength = 0;
            this.txtDiaChi.SelectionStart = 0;
            this.txtDiaChi.ShortcutsEnabled = true;
            this.txtDiaChi.Size = new System.Drawing.Size(250, 107);
            this.txtDiaChi.TabIndex = 3;
            this.txtDiaChi.TabStop = false;
            this.txtDiaChi.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDiaChi.UseSystemPasswordChar = false;
            // 
            // txtTenKhachHang
            // 
            this.txtTenKhachHang.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTenKhachHang.AnimateReadOnly = false;
            this.txtTenKhachHang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtTenKhachHang.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtTenKhachHang.Depth = 0;
            this.txtTenKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtTenKhachHang.HideSelection = true;
            this.txtTenKhachHang.LeadingIcon = null;
            this.txtTenKhachHang.Location = new System.Drawing.Point(238, 8);
            this.txtTenKhachHang.MaxLength = 32767;
            this.txtTenKhachHang.MouseState = MaterialSkin.MouseState.OUT;
            this.txtTenKhachHang.Name = "txtTenKhachHang";
            this.txtTenKhachHang.PasswordChar = '\0';
            this.txtTenKhachHang.PrefixSuffixText = null;
            this.txtTenKhachHang.ReadOnly = false;
            this.txtTenKhachHang.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTenKhachHang.SelectedText = "";
            this.txtTenKhachHang.SelectionLength = 0;
            this.txtTenKhachHang.SelectionStart = 0;
            this.txtTenKhachHang.ShortcutsEnabled = true;
            this.txtTenKhachHang.Size = new System.Drawing.Size(250, 48);
            this.txtTenKhachHang.TabIndex = 4;
            this.txtTenKhachHang.TabStop = false;
            this.txtTenKhachHang.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtTenKhachHang.TrailingIcon = null;
            this.txtTenKhachHang.UseSystemPasswordChar = false;
            // 
            // txtSDT
            // 
            this.txtSDT.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtSDT.AnimateReadOnly = false;
            this.txtSDT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtSDT.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtSDT.Depth = 0;
            this.txtSDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtSDT.HideSelection = true;
            this.txtSDT.LeadingIcon = null;
            this.txtSDT.Location = new System.Drawing.Point(238, 203);
            this.txtSDT.MaxLength = 32767;
            this.txtSDT.MouseState = MaterialSkin.MouseState.OUT;
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.PasswordChar = '\0';
            this.txtSDT.PrefixSuffixText = null;
            this.txtSDT.ReadOnly = false;
            this.txtSDT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSDT.SelectedText = "";
            this.txtSDT.SelectionLength = 0;
            this.txtSDT.SelectionStart = 0;
            this.txtSDT.ShortcutsEnabled = true;
            this.txtSDT.Size = new System.Drawing.Size(250, 48);
            this.txtSDT.TabIndex = 5;
            this.txtSDT.TabStop = false;
            this.txtSDT.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSDT.TrailingIcon = null;
            this.txtSDT.UseSystemPasswordChar = false;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.Controls.Add(this.btnLuu, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 269);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(588, 61);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLuu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLuu.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnLuu.Depth = 0;
            this.btnLuu.HighEmphasis = true;
            this.btnLuu.Icon = null;
            this.btnLuu.Location = new System.Drawing.Point(261, 12);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnLuu.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnLuu.Size = new System.Drawing.Size(64, 36);
            this.btnLuu.TabIndex = 0;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnLuu.UseAccentColor = false;
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // formKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "formKhachHang";
            this.Text = "Thêm khách hàng";
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
        private MaterialSkin.Controls.MaterialLabel lblTenKhach;
        private MaterialSkin.Controls.MaterialLabel lblDiaChi;
        private MaterialSkin.Controls.MaterialLabel lblSDT;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 txtDiaChi;
        private MaterialSkin.Controls.MaterialTextBox2 txtTenKhachHang;
        private MaterialSkin.Controls.MaterialTextBox2 txtSDT;
        private MaterialSkin.Controls.MaterialButton btnLuu;
    }
}