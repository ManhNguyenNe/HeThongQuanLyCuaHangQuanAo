namespace HeThongQuanLyCuaHangQuanAo.Forms
{
    partial class ThemThuocTinh
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
            this.btnThem = new MaterialSkin.Controls.MaterialButton();
            this.txtThuocTinh = new MaterialSkin.Controls.MaterialTextBox2();
            this.lblThuocTinh = new MaterialSkin.Controls.MaterialLabel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Controls.Add(this.btnThem, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtThuocTinh, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblThuocTinh, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 64);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(444, 233);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnThem
            // 
            this.btnThem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnThem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnThem.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnThem.Depth = 0;
            this.btnThem.HighEmphasis = true;
            this.btnThem.Icon = null;
            this.btnThem.Location = new System.Drawing.Point(189, 176);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnThem.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnThem.Name = "btnThem";
            this.btnThem.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnThem.Size = new System.Drawing.Size(64, 36);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnThem.UseAccentColor = false;
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtThuocTinh
            // 
            this.txtThuocTinh.AnimateReadOnly = false;
            this.txtThuocTinh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtThuocTinh.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtThuocTinh.Depth = 0;
            this.txtThuocTinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtThuocTinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtThuocTinh.HideSelection = true;
            this.txtThuocTinh.LeadingIcon = null;
            this.txtThuocTinh.Location = new System.Drawing.Point(69, 79);
            this.txtThuocTinh.MaxLength = 32767;
            this.txtThuocTinh.MouseState = MaterialSkin.MouseState.OUT;
            this.txtThuocTinh.Name = "txtThuocTinh";
            this.txtThuocTinh.PasswordChar = '\0';
            this.txtThuocTinh.PrefixSuffixText = null;
            this.txtThuocTinh.ReadOnly = false;
            this.txtThuocTinh.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtThuocTinh.SelectedText = "";
            this.txtThuocTinh.SelectionLength = 0;
            this.txtThuocTinh.SelectionStart = 0;
            this.txtThuocTinh.ShortcutsEnabled = true;
            this.txtThuocTinh.Size = new System.Drawing.Size(304, 48);
            this.txtThuocTinh.TabIndex = 1;
            this.txtThuocTinh.TabStop = false;
            this.txtThuocTinh.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtThuocTinh.TrailingIcon = null;
            this.txtThuocTinh.UseSystemPasswordChar = false;
            // 
            // lblThuocTinh
            // 
            this.lblThuocTinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblThuocTinh.AutoSize = true;
            this.lblThuocTinh.Depth = 0;
            this.lblThuocTinh.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblThuocTinh.Location = new System.Drawing.Point(69, 57);
            this.lblThuocTinh.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblThuocTinh.Name = "lblThuocTinh";
            this.lblThuocTinh.Size = new System.Drawing.Size(107, 19);
            this.lblThuocTinh.TabIndex = 2;
            this.lblThuocTinh.Text = "materialLabel1";
            // 
            // ThemThuocTinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 300);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ThemThuocTinh";
            this.Text = "Thêm thuộc tính";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MaterialSkin.Controls.MaterialButton btnThem;
        private MaterialSkin.Controls.MaterialTextBox2 txtThuocTinh;
        private MaterialSkin.Controls.MaterialLabel lblThuocTinh;
    }
}