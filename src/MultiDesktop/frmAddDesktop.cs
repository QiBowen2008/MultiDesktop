using I18N.DotNet;

namespace MultiDesktop
{
    public partial class frmAddDesktop : Form
    {
        public frmAddDesktop()
        {
            InitializeComponent();
        }

        private void btnAddDesktop_Click(object sender, EventArgs e)
        {
            string wallpaperStyle = cboWallpaperStyle.SelectedItem?.ToString() ?? "填充";
            bool Encrypt = EncryptManager.IsEncrypted;
            if (DesktopManager.AddDesktop(txtDesktopName.Text, txtDesktopPath.Text,
                                           chkEnableWallpaper.Checked, txtWallpaperPath.Text,
                                           wallpaperStyle, Encrypt))
            {
                if (Encrypt)
                {

                }
            }
        }

        private void btnShowFolderBrowseDialog_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtDesktopPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnBrowseWallpaper_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtWallpaperPath.Text = openFileDialog1.FileName;
            }
        }

        private void chkEnableWallpaper_CheckedChanged(object sender, EventArgs e)
        {
            bool enabled = chkEnableWallpaper.Checked;
            txtWallpaperPath.Enabled = enabled;
            btnBrowseWallpaper.Enabled = enabled;
            cboWallpaperStyle.Enabled = enabled;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmAddDesktop_Load(object sender, EventArgs e)
        {
            // I18N 国际化
            this.Text = GlobalLocalizer.Localize(this.Text);
            label1.Text = GlobalLocalizer.Localize(label1.Text);
            label2.Text = GlobalLocalizer.Localize(label2.Text);
            label3.Text = GlobalLocalizer.Localize(label3.Text);
            label4.Text = GlobalLocalizer.Localize(label4.Text);
            chkEnableWallpaper.Text = GlobalLocalizer.Localize(chkEnableWallpaper.Text);
            btnAddDesktop.Text = GlobalLocalizer.Localize(btnAddDesktop.Text);
            btnClose.Text = GlobalLocalizer.Localize(btnClose.Text);

            txtDesktopName.Text = DesktopManager.t_DesktopName;
            txtDesktopPath.Text = DesktopManager.t_DesktopPath;

            // 默认选中"填充"
            cboWallpaperStyle.SelectedIndex = 0;

            // 编辑模式：加载已有壁纸设置
            if (DesktopManager.IsEdit)
            {
                var row = DesktopManager.DesktopList.Rows[DesktopManager.IndexToChange];
                if (row.ItemArray.Length > 2)
                {
                    chkEnableWallpaper.Checked = Convert.ToBoolean(row[2]);
                    txtWallpaperPath.Text = row[3]?.ToString() ?? "";
                }
                if (row.ItemArray.Length > 4)
                {
                    string savedStyle = row[4]?.ToString() ?? "填充";
                    int idx = cboWallpaperStyle.Items.IndexOf(savedStyle);
                    cboWallpaperStyle.SelectedIndex = idx >= 0 ? idx : 0;
                }
            }

            // 初始化控件启用状态
            txtWallpaperPath.Enabled = chkEnableWallpaper.Checked;
            btnBrowseWallpaper.Enabled = chkEnableWallpaper.Checked;
            cboWallpaperStyle.Enabled = chkEnableWallpaper.Checked;
        }

        private void frmAddDesktop_FormClosing(object sender, FormClosingEventArgs e)
        {
            DesktopManager.ReSetDesktopManager();
        }

        private void btnSetPassword_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtDesktopPath.Text))
            {
                MessageBox.Show("请先设置桌面路径");
            }
            else
            {
                EncryptManager.DesktopFolder = txtDesktopPath.Text;
                frmPassword frmPassword = new frmPassword();
                frmPassword.ShowDialog();
            }
        }
    }
}
