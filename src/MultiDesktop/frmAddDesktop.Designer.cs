namespace MultiDesktop
{
    partial class frmAddDesktop
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
            btnAddDesktop = new AntdUI.Button();
            btnClose = new AntdUI.Button();
            label1 = new Label();
            label2 = new Label();
            txtDesktopName = new AntdUI.Input();
            txtDesktopPath = new AntdUI.Input();
            btnShowFolderBrowseDialog = new AntdUI.Button();
            folderBrowserDialog1 = new FolderBrowserDialog();
            chkEnableWallpaper = new AntdUI.Checkbox();
            label3 = new Label();
            txtWallpaperPath = new AntdUI.Input();
            btnBrowseWallpaper = new AntdUI.Button();
            openFileDialog1 = new OpenFileDialog();
            label4 = new Label();
            cboWallpaperStyle = new ComboBox();
            btnSetPassword = new AntdUI.Button();
            SuspendLayout();
            // 
            // btnAddDesktop
            // 
            btnAddDesktop.DefaultBack = Color.Green;
            btnAddDesktop.Font = new Font("Microsoft YaHei UI", 15F);
            btnAddDesktop.Location = new Point(172, 560);
            btnAddDesktop.Name = "btnAddDesktop";
            btnAddDesktop.Size = new Size(166, 79);
            btnAddDesktop.TabIndex = 0;
            btnAddDesktop.Text = "确定";
            btnAddDesktop.Click += btnAddDesktop_Click;
            // 
            // btnClose
            // 
            btnClose.DefaultBack = Color.Red;
            btnClose.Font = new Font("Microsoft YaHei UI", 15F);
            btnClose.Location = new Point(453, 560);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(166, 79);
            btnClose.TabIndex = 1;
            btnClose.Text = "取消";
            btnClose.Click += btnClose_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 15F);
            label1.Location = new Point(64, 93);
            label1.Name = "label1";
            label1.Size = new Size(137, 39);
            label1.TabIndex = 2;
            label1.Text = "桌面名称";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 15F);
            label2.Location = new Point(64, 197);
            label2.Name = "label2";
            label2.Size = new Size(137, 39);
            label2.TabIndex = 3;
            label2.Text = "桌面路径";
            // 
            // txtDesktopName
            // 
            txtDesktopName.Font = new Font("Microsoft YaHei UI", 15F);
            txtDesktopName.Location = new Point(231, 77);
            txtDesktopName.Name = "txtDesktopName";
            txtDesktopName.Size = new Size(442, 84);
            txtDesktopName.TabIndex = 4;
            // 
            // txtDesktopPath
            // 
            txtDesktopPath.Font = new Font("Microsoft YaHei UI", 15F);
            txtDesktopPath.Location = new Point(231, 176);
            txtDesktopPath.Name = "txtDesktopPath";
            txtDesktopPath.Size = new Size(442, 79);
            txtDesktopPath.TabIndex = 5;
            // 
            // btnShowFolderBrowseDialog
            // 
            btnShowFolderBrowseDialog.Font = new Font("Microsoft YaHei UI", 15F);
            btnShowFolderBrowseDialog.Location = new Point(679, 176);
            btnShowFolderBrowseDialog.Name = "btnShowFolderBrowseDialog";
            btnShowFolderBrowseDialog.Size = new Size(78, 79);
            btnShowFolderBrowseDialog.TabIndex = 6;
            btnShowFolderBrowseDialog.Text = "...";
            btnShowFolderBrowseDialog.Click += btnShowFolderBrowseDialog_Click;
            // 
            // chkEnableWallpaper
            // 
            chkEnableWallpaper.Font = new Font("Microsoft YaHei UI", 13F);
            chkEnableWallpaper.Location = new Point(231, 261);
            chkEnableWallpaper.Name = "chkEnableWallpaper";
            chkEnableWallpaper.Size = new Size(250, 40);
            chkEnableWallpaper.TabIndex = 7;
            chkEnableWallpaper.Text = "启用自定义壁纸";
            chkEnableWallpaper.CheckedChanged += chkEnableWallpaper_CheckedChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft YaHei UI", 15F);
            label3.Location = new Point(64, 332);
            label3.Name = "label3";
            label3.Size = new Size(137, 39);
            label3.TabIndex = 8;
            label3.Text = "壁纸路径";
            // 
            // txtWallpaperPath
            // 
            txtWallpaperPath.Font = new Font("Microsoft YaHei UI", 15F);
            txtWallpaperPath.Location = new Point(231, 312);
            txtWallpaperPath.Name = "txtWallpaperPath";
            txtWallpaperPath.PlaceholderText = "选择壁纸图片文件";
            txtWallpaperPath.Size = new Size(442, 79);
            txtWallpaperPath.TabIndex = 9;
            // 
            // btnBrowseWallpaper
            // 
            btnBrowseWallpaper.Font = new Font("Microsoft YaHei UI", 15F);
            btnBrowseWallpaper.Location = new Point(679, 312);
            btnBrowseWallpaper.Name = "btnBrowseWallpaper";
            btnBrowseWallpaper.Size = new Size(78, 79);
            btnBrowseWallpaper.TabIndex = 10;
            btnBrowseWallpaper.Text = "...";
            btnBrowseWallpaper.Click += btnBrowseWallpaper_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.Filter = "图片文件|*.jpg;*.jpeg;*.png;*.bmp;*.gif|所有文件|*.*";
            openFileDialog1.Title = "选择壁纸图片";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft YaHei UI", 15F);
            label4.Location = new Point(64, 420);
            label4.Name = "label4";
            label4.Size = new Size(137, 39);
            label4.TabIndex = 11;
            label4.Text = "显示方式";
            // 
            // cboWallpaperStyle
            // 
            cboWallpaperStyle.DropDownStyle = ComboBoxStyle.DropDownList;
            cboWallpaperStyle.Font = new Font("Microsoft YaHei UI", 13F);
            cboWallpaperStyle.Items.AddRange(new object[] { "填充", "适应", "拉伸", "平铺", "居中", "跨屏" });
            cboWallpaperStyle.Location = new Point(231, 420);
            cboWallpaperStyle.Name = "cboWallpaperStyle";
            cboWallpaperStyle.Size = new Size(526, 43);
            cboWallpaperStyle.TabIndex = 12;
            // 
            // btnSetPassword
            // 
            btnSetPassword.Font = new Font("Microsoft YaHei UI", 15F);
            btnSetPassword.Location = new Point(305, 484);
            btnSetPassword.Name = "btnSetPassword";
            btnSetPassword.Size = new Size(212, 60);
            btnSetPassword.TabIndex = 13;
            btnSetPassword.Text = "桌面加密设置";
            btnSetPassword.Click += btnSetPassword_Click;
            // 
            // frmAddDesktop
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(806, 660);
            Controls.Add(btnSetPassword);
            Controls.Add(cboWallpaperStyle);
            Controls.Add(label4);
            Controls.Add(btnBrowseWallpaper);
            Controls.Add(txtWallpaperPath);
            Controls.Add(label3);
            Controls.Add(chkEnableWallpaper);
            Controls.Add(btnShowFolderBrowseDialog);
            Controls.Add(txtDesktopPath);
            Controls.Add(txtDesktopName);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnClose);
            Controls.Add(btnAddDesktop);
            Name = "frmAddDesktop";
            Text = "添加桌面";
            FormClosing += frmAddDesktop_FormClosing;
            Load += frmAddDesktop_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private AntdUI.Button btnAddDesktop;
        private AntdUI.Button btnClose;
        private Label label1;
        private Label label2;
        private AntdUI.Input txtDesktopName;
        private AntdUI.Input txtDesktopPath;
        private AntdUI.Button btnShowFolderBrowseDialog;
        private FolderBrowserDialog folderBrowserDialog1;
        private AntdUI.Checkbox chkEnableWallpaper;
        private Label label3;
        private AntdUI.Input txtWallpaperPath;
        private AntdUI.Button btnBrowseWallpaper;
        private OpenFileDialog openFileDialog1;
        private Label label4;
        private ComboBox cboWallpaperStyle;
        private AntdUI.Button btnSetPassword;
    }
}
