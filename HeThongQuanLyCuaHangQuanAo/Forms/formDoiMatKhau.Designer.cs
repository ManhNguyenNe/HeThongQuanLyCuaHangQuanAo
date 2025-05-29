namespace HeThongQuanLyCuaHangQuanAo.Forms
{
    partial class formDoiMatKhau
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
            this.btnHuy = new MaterialSkin.Controls.MaterialButton();
            this.btnLuu = new MaterialSkin.Controls.MaterialButton();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMatKhauCu = new MaterialSkin.Controls.MaterialLabel();
            this.lblMatKhauMoi = new MaterialSkin.Controls.MaterialLabel();
            this.lblXacNhanMatKhauMoi = new MaterialSkin.Controls.MaterialLabel();
            this.txtMatKhauCu = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtMatKhauMoi = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtXacNhanMatKhauMoi = new MaterialSkin.Controls.MaterialTextBox2();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 33);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(596, 365);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.btnHuy, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnLuu, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 294);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(592, 69);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btnHuy
            // 
            this.btnHuy.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnHuy.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnHuy.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnHuy.Depth = 0;
            this.btnHuy.HighEmphasis = true;
            this.btnHuy.Icon = null;
            this.btnHuy.Location = new System.Drawing.Point(174, 16);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnHuy.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnHuy.Size = new System.Drawing.Size(64, 36);
            this.btnHuy.TabIndex = 0;
            this.btnHuy.Text = "hủy";
            this.btnHuy.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnHuy.UseAccentColor = false;
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLuu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLuu.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnLuu.Depth = 0;
            this.btnLuu.HighEmphasis = true;
            this.btnLuu.Icon = null;
            this.btnLuu.Location = new System.Drawing.Point(351, 16);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnLuu.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnLuu.Size = new System.Drawing.Size(64, 36);
            this.btnLuu.TabIndex = 1;
            this.btnLuu.Text = "lưu";
            this.btnLuu.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnLuu.UseAccentColor = false;
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel3.Controls.Add(this.lblMatKhauCu, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblMatKhauMoi, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.lblXacNhanMatKhauMoi, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.txtMatKhauCu, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtMatKhauMoi, 2, 2);
            this.tableLayoutPanel3.Controls.Add(this.txtXacNhanMatKhauMoi, 2, 3);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(592, 288);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // lblMatKhauCu
            // 
            this.lblMatKhauCu.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMatKhauCu.AutoSize = true;
            this.lblMatKhauCu.Depth = 0;
            this.lblMatKhauCu.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblMatKhauCu.Location = new System.Drawing.Point(90, 82);
            this.lblMatKhauCu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMatKhauCu.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblMatKhauCu.Name = "lblMatKhauCu";
            this.lblMatKhauCu.Size = new System.Drawing.Size(93, 19);
            this.lblMatKhauCu.TabIndex = 0;
            this.lblMatKhauCu.Text = "Mật khẩu cũ:";
            // 
            // lblMatKhauMoi
            // 
            this.lblMatKhauMoi.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMatKhauMoi.AutoSize = true;
            this.lblMatKhauMoi.Depth = 0;
            this.lblMatKhauMoi.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblMatKhauMoi.Location = new System.Drawing.Point(90, 151);
            this.lblMatKhauMoi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMatKhauMoi.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblMatKhauMoi.Name = "lblMatKhauMoi";
            this.lblMatKhauMoi.Size = new System.Drawing.Size(103, 19);
            this.lblMatKhauMoi.TabIndex = 1;
            this.lblMatKhauMoi.Text = "Mật khẩu mới:";
            // 
            // lblXacNhanMatKhauMoi
            // 
            this.lblXacNhanMatKhauMoi.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblXacNhanMatKhauMoi.AutoSize = true;
            this.lblXacNhanMatKhauMoi.Depth = 0;
            this.lblXacNhanMatKhauMoi.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblXacNhanMatKhauMoi.Location = new System.Drawing.Point(90, 220);
            this.lblXacNhanMatKhauMoi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblXacNhanMatKhauMoi.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblXacNhanMatKhauMoi.Name = "lblXacNhanMatKhauMoi";
            this.lblXacNhanMatKhauMoi.Size = new System.Drawing.Size(93, 19);
            this.lblXacNhanMatKhauMoi.TabIndex = 2;
            this.lblXacNhanMatKhauMoi.Text = "Xác nhận lại:";
            // 
            // txtMatKhauCu
            // 
            this.txtMatKhauCu.AnimateReadOnly = false;
            this.txtMatKhauCu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtMatKhauCu.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtMatKhauCu.Depth = 0;
            this.txtMatKhauCu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMatKhauCu.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtMatKhauCu.HideSelection = true;
            this.txtMatKhauCu.LeadingIcon = null;
            this.txtMatKhauCu.Location = new System.Drawing.Point(238, 59);
            this.txtMatKhauCu.Margin = new System.Windows.Forms.Padding(2);
            this.txtMatKhauCu.MaxLength = 32767;
            this.txtMatKhauCu.MouseState = MaterialSkin.MouseState.OUT;
            this.txtMatKhauCu.Name = "txtMatKhauCu";
            this.txtMatKhauCu.PasswordChar = '*';
            this.txtMatKhauCu.PrefixSuffixText = null;
            this.txtMatKhauCu.ReadOnly = false;
            this.txtMatKhauCu.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtMatKhauCu.SelectedText = "";
            this.txtMatKhauCu.SelectionLength = 0;
            this.txtMatKhauCu.SelectionStart = 0;
            this.txtMatKhauCu.ShortcutsEnabled = true;
            this.txtMatKhauCu.Size = new System.Drawing.Size(262, 48);
            this.txtMatKhauCu.TabIndex = 3;
            this.txtMatKhauCu.TabStop = false;
            this.txtMatKhauCu.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtMatKhauCu.TrailingIcon = null;
            this.txtMatKhauCu.UseSystemPasswordChar = false;
            // 
            // txtMatKhauMoi
            // 
            this.txtMatKhauMoi.AnimateReadOnly = false;
            this.txtMatKhauMoi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtMatKhauMoi.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtMatKhauMoi.Depth = 0;
            this.txtMatKhauMoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMatKhauMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtMatKhauMoi.HideSelection = true;
            this.txtMatKhauMoi.LeadingIcon = null;
            this.txtMatKhauMoi.Location = new System.Drawing.Point(238, 128);
            this.txtMatKhauMoi.Margin = new System.Windows.Forms.Padding(2);
            this.txtMatKhauMoi.MaxLength = 32767;
            this.txtMatKhauMoi.MouseState = MaterialSkin.MouseState.OUT;
            this.txtMatKhauMoi.Name = "txtMatKhauMoi";
            this.txtMatKhauMoi.PasswordChar = '*';
            this.txtMatKhauMoi.PrefixSuffixText = null;
            this.txtMatKhauMoi.ReadOnly = false;
            this.txtMatKhauMoi.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtMatKhauMoi.SelectedText = "";
            this.txtMatKhauMoi.SelectionLength = 0;
            this.txtMatKhauMoi.SelectionStart = 0;
            this.txtMatKhauMoi.ShortcutsEnabled = true;
            this.txtMatKhauMoi.Size = new System.Drawing.Size(262, 48);
            this.txtMatKhauMoi.TabIndex = 4;
            this.txtMatKhauMoi.TabStop = false;
            this.txtMatKhauMoi.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtMatKhauMoi.TrailingIcon = null;
            this.txtMatKhauMoi.UseSystemPasswordChar = false;
            // 
            // txtXacNhanMatKhauMoi
            // 
            this.txtXacNhanMatKhauMoi.AnimateReadOnly = false;
            this.txtXacNhanMatKhauMoi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtXacNhanMatKhauMoi.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtXacNhanMatKhauMoi.Depth = 0;
            this.txtXacNhanMatKhauMoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtXacNhanMatKhauMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtXacNhanMatKhauMoi.HideSelection = true;
            this.txtXacNhanMatKhauMoi.LeadingIcon = null;
            this.txtXacNhanMatKhauMoi.Location = new System.Drawing.Point(238, 197);
            this.txtXacNhanMatKhauMoi.Margin = new System.Windows.Forms.Padding(2);
            this.txtXacNhanMatKhauMoi.MaxLength = 32767;
            this.txtXacNhanMatKhauMoi.MouseState = MaterialSkin.MouseState.OUT;
            this.txtXacNhanMatKhauMoi.Name = "txtXacNhanMatKhauMoi";
            this.txtXacNhanMatKhauMoi.PasswordChar = '*';
            this.txtXacNhanMatKhauMoi.PrefixSuffixText = null;
            this.txtXacNhanMatKhauMoi.ReadOnly = false;
            this.txtXacNhanMatKhauMoi.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtXacNhanMatKhauMoi.SelectedText = "";
            this.txtXacNhanMatKhauMoi.SelectionLength = 0;
            this.txtXacNhanMatKhauMoi.SelectionStart = 0;
            this.txtXacNhanMatKhauMoi.ShortcutsEnabled = true;
            this.txtXacNhanMatKhauMoi.Size = new System.Drawing.Size(262, 48);
            this.txtXacNhanMatKhauMoi.TabIndex = 5;
            this.txtXacNhanMatKhauMoi.TabStop = false;
            this.txtXacNhanMatKhauMoi.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtXacNhanMatKhauMoi.TrailingIcon = null;
            this.txtXacNhanMatKhauMoi.UseSystemPasswordChar = false;
            // 
            // formDoiMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "formDoiMatKhau";
            this.Padding = new System.Windows.Forms.Padding(2, 33, 2, 2);
            this.Text = "Đổi Mật Khẩu";
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
        private MaterialSkin.Controls.MaterialButton btnHuy;
        private MaterialSkin.Controls.MaterialButton btnLuu;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private MaterialSkin.Controls.MaterialLabel lblMatKhauCu;
        private MaterialSkin.Controls.MaterialLabel lblMatKhauMoi;
        private MaterialSkin.Controls.MaterialLabel lblXacNhanMatKhauMoi;
        private MaterialSkin.Controls.MaterialTextBox2 txtMatKhauCu;
        private MaterialSkin.Controls.MaterialTextBox2 txtMatKhauMoi;
        private MaterialSkin.Controls.MaterialTextBox2 txtXacNhanMatKhauMoi;
    }
}