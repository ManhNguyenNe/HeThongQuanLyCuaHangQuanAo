namespace HeThongQuanLyCuaHangQuanAo.Forms
{
    partial class Login
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
            this.lblTenDangNhap = new MaterialSkin.Controls.MaterialLabel();
            this.lblMatKhau = new MaterialSkin.Controls.MaterialLabel();
            this.txtTenDangNhap = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtMatKhau = new MaterialSkin.Controls.MaterialTextBox2();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnDangNhap = new MaterialSkin.Controls.MaterialButton();
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(444, 233);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.Controls.Add(this.lblTenDangNhap, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblMatKhau, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtTenDangNhap, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtMatKhau, 2, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(444, 151);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lblTenDangNhap
            // 
            this.lblTenDangNhap.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTenDangNhap.AutoSize = true;
            this.lblTenDangNhap.Depth = 0;
            this.lblTenDangNhap.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTenDangNhap.Location = new System.Drawing.Point(25, 39);
            this.lblTenDangNhap.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTenDangNhap.Name = "lblTenDangNhap";
            this.lblTenDangNhap.Size = new System.Drawing.Size(113, 19);
            this.lblTenDangNhap.TabIndex = 0;
            this.lblTenDangNhap.Text = "Tên đăng nhập:";
            // 
            // lblMatKhau
            // 
            this.lblMatKhau.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMatKhau.AutoSize = true;
            this.lblMatKhau.Depth = 0;
            this.lblMatKhau.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblMatKhau.Location = new System.Drawing.Point(25, 107);
            this.lblMatKhau.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Size = new System.Drawing.Size(72, 19);
            this.lblMatKhau.TabIndex = 1;
            this.lblMatKhau.Text = "Mật khẩu:";
            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTenDangNhap.AnimateReadOnly = false;
            this.txtTenDangNhap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtTenDangNhap.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtTenDangNhap.Depth = 0;
            this.txtTenDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtTenDangNhap.HideSelection = true;
            this.txtTenDangNhap.LeadingIcon = null;
            this.txtTenDangNhap.Location = new System.Drawing.Point(163, 24);
            this.txtTenDangNhap.MaxLength = 32767;
            this.txtTenDangNhap.MouseState = MaterialSkin.MouseState.OUT;
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.PasswordChar = '\0';
            this.txtTenDangNhap.PrefixSuffixText = null;
            this.txtTenDangNhap.ReadOnly = false;
            this.txtTenDangNhap.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTenDangNhap.SelectedText = "";
            this.txtTenDangNhap.SelectionLength = 0;
            this.txtTenDangNhap.SelectionStart = 0;
            this.txtTenDangNhap.ShortcutsEnabled = true;
            this.txtTenDangNhap.Size = new System.Drawing.Size(250, 48);
            this.txtTenDangNhap.TabIndex = 2;
            this.txtTenDangNhap.TabStop = false;
            this.txtTenDangNhap.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtTenDangNhap.TrailingIcon = null;
            this.txtTenDangNhap.UseSystemPasswordChar = false;
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMatKhau.AnimateReadOnly = false;
            this.txtMatKhau.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtMatKhau.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtMatKhau.Depth = 0;
            this.txtMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtMatKhau.HideSelection = true;
            this.txtMatKhau.LeadingIcon = null;
            this.txtMatKhau.Location = new System.Drawing.Point(163, 92);
            this.txtMatKhau.MaxLength = 32767;
            this.txtMatKhau.MouseState = MaterialSkin.MouseState.OUT;
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '*';
            this.txtMatKhau.PrefixSuffixText = null;
            this.txtMatKhau.ReadOnly = false;
            this.txtMatKhau.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtMatKhau.SelectedText = "";
            this.txtMatKhau.SelectionLength = 0;
            this.txtMatKhau.SelectionStart = 0;
            this.txtMatKhau.ShortcutsEnabled = true;
            this.txtMatKhau.Size = new System.Drawing.Size(250, 48);
            this.txtMatKhau.TabIndex = 3;
            this.txtMatKhau.TabStop = false;
            this.txtMatKhau.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtMatKhau.TrailingIcon = null;
            this.txtMatKhau.UseSystemPasswordChar = false;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.btnDangNhap, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 151);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(444, 82);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDangNhap.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDangNhap.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnDangNhap.Depth = 0;
            this.btnDangNhap.HighEmphasis = true;
            this.btnDangNhap.Icon = null;
            this.btnDangNhap.Location = new System.Drawing.Point(169, 14);
            this.btnDangNhap.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnDangNhap.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnDangNhap.Size = new System.Drawing.Size(105, 36);
            this.btnDangNhap.TabIndex = 0;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnDangNhap.UseAccentColor = false;
            this.btnDangNhap.UseVisualStyleBackColor = true;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 300);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Login";
            this.Text = "Đăng nhập";
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
        private MaterialSkin.Controls.MaterialTextBox2 txtMatKhau;
        private MaterialSkin.Controls.MaterialLabel lblTenDangNhap;
        private MaterialSkin.Controls.MaterialLabel lblMatKhau;
        private MaterialSkin.Controls.MaterialTextBox2 txtTenDangNhap;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private MaterialSkin.Controls.MaterialButton btnDangNhap;
    }
}