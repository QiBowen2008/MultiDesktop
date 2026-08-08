using I18N.DotNet;
using System.Data;
using PostQuantum.FileEncryption;
using static I18N.DotNet.Localizer;

namespace MultiDesktop
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            if (File.Exists(AppPaths.DesktopList))
            {
                DesktopManager.DesktopList.ReadXml(AppPaths.DesktopList);
                DesktopManager.EnsureDesktopListColumns(DesktopManager.DesktopList);
            }
            else
            {
                DesktopManager.DesktopList.TableName = ("DesktopList");
                DesktopManager.DesktopList.Columns.Add("桌面名称", typeof(string));
                DesktopManager.DesktopList.Columns.Add("桌面路径", typeof(string));
                DesktopManager.DesktopList.Columns.Add("是否开启自定义壁纸", typeof(bool));
                DesktopManager.DesktopList.Columns.Add("自定义壁纸地址", typeof(string));
                DesktopManager.DesktopList.Columns.Add("壁纸显示方式", typeof(string));
                DesktopManager.DesktopList.Columns.Add("是否加密", typeof(bool));
            }
            tblDesktopList.DataSource = DesktopManager.DesktopList;
        }

        private void btnAddDesktop_Click(object sender, EventArgs e)
        {
            frmAddDesktop frmAddDesktop = new();
            frmAddDesktop.ShowDialog();
            tblDesktopList.Refresh();
            DesktopManager.IndexToChange = DesktopManager.DesktopList.Rows.Count;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // I18N 国际化
            this.Text = GlobalLocalizer.Localize(this.Text);
            label1.Text = GlobalLocalizer.Localize(label1.Text);
            btnAddDesktop.Text = GlobalLocalizer.Localize(btnAddDesktop.Text);
            btnDeleteDesktop.Text = GlobalLocalizer.Localize(btnDeleteDesktop.Text);
            btnChangeDesktop.Text = GlobalLocalizer.Localize(btnChangeDesktop.Text);
            btnEditDesktop.Text = GlobalLocalizer.Localize(btnEditDesktop.Text);
            btnSet.Text = GlobalLocalizer.Localize(btnSet.Text);
            btnAbout.Text = GlobalLocalizer.Localize(btnAbout.Text);
            notifyIcon1.Text = GlobalLocalizer.Localize(notifyIcon1.Text);
            itmDesktopList.Text = GlobalLocalizer.Localize(itmDesktopList.Text);
            itmSettingsMenu.Text = GlobalLocalizer.Localize(itmSettingsMenu.Text);
            itmAboutMenu.Text = GlobalLocalizer.Localize(itmAboutMenu.Text);
            itmExit.Text = GlobalLocalizer.Localize(itmExit.Text);

            tblDesktopList.DataSource = DesktopManager.DesktopList;
            tblDesktopList.Refresh();
            notifyIcon1.Visible = true;

            // 记录当前正在使用的桌面（用于离开加密桌面时自动重新加密）
            string currentDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            foreach (DataRow r in DesktopManager.DesktopList.Rows)
            {
                string? p = DesktopManager.GetString(r, 1);
                if (!string.IsNullOrEmpty(p) &&
                    string.Equals(Path.GetFullPath(p).TrimEnd('\\'), Path.GetFullPath(currentDesktop).TrimEnd('\\'), StringComparison.OrdinalIgnoreCase))
                {
                    DesktopManager.SetCurrentDesktop(DesktopManager.GetString(r, 0), p, DesktopManager.GetBool(r, 5));
                    break;
                }
            }

            int DesktopIndex = 0;
            foreach (DataRow desktopnames in DesktopManager.DesktopList.Rows)
            {
                string? desktopname = desktopnames[0].ToString();
                ToolStripMenuItem menuItem = new ToolStripMenuItem(desktopname);
                menuItem.Tag = DesktopIndex;
                itmDesktopList.DropDownItems.Add(menuItem);
                DesktopIndex++;// 存储索引
            }
        }

        private void btnDeleteDesktop_Click(object sender, EventArgs e)
        {
            if (tblDesktopList.SelectedIndexs.Length != 0)
            {
                foreach (int i in tblDesktopList.SelectedIndexs.OrderByDescending(x => x))
                {
                    DesktopManager.DesktopList.Rows[i - 1].Delete();
                }
                DesktopManager.DesktopList.AcceptChanges();
                tblDesktopList.Refresh();
                DesktopManager.DesktopList.WriteXml(AppPaths.DesktopList, XmlWriteMode.WriteSchema);
            }


        }

        private void btnEditDesktop_Click(object sender, EventArgs e)
        {
            int idx = tblDesktopList.SelectedIndex - 1;
            if (idx < 0 || idx >= DesktopManager.DesktopList.Rows.Count) return;
            var row = DesktopManager.DesktopList.Rows[idx];
            DesktopManager.t_DesktopName = DesktopManager.GetString(row, 0);
            DesktopManager.t_DesktopPath = DesktopManager.GetString(row, 1);
            DesktopManager.IsEdit = true;
            DesktopManager.IndexToChange = idx;
            EncryptManager.IsEncrypted = DesktopManager.GetBool(row, 5);
            frmAddDesktop frmAddDesktop = new();
            frmAddDesktop.ShowDialog();
            tblDesktopList.Refresh();
        }

        private void tblDesktopList_CellClick(object sender, AntdUI.TableClickEventArgs e)
        {
            if (tblDesktopList.SelectedIndexs.Length > 0)
            {
                btnDeleteDesktop.Enabled = true;
            }
            else
            {
                btnDeleteDesktop.Enabled = false;

            }
            if (tblDesktopList.SelectedIndexs.Length == 1)
            {
                btnChangeDesktop.Enabled = true;
                btnEditDesktop.Enabled = true;
            }
            else
            {
                btnChangeDesktop.Enabled = false;
                btnEditDesktop.Enabled = false;
            }
        }

        private async void btnChangeDesktop_Click(object sender, EventArgs e)
        {
            int idx = tblDesktopList.SelectedIndex - 1;
            if (idx < 0 || idx >= DesktopManager.DesktopList.Rows.Count) return;
            await SwitchToDesktopAsync(DesktopManager.DesktopList.Rows[idx]);
        }

        /// <summary>
        /// 切换桌面：目标为加密桌面时先弹窗校验密码并解锁；
        /// 正在离开的加密桌面（已解密）在切换完成后自动重新加密。
        /// </summary>
        private async Task SwitchToDesktopAsync(DataRow row)
        {
            string name = DesktopManager.GetString(row, 0) ?? "";
            string path = DesktopManager.GetString(row, 1) ?? "";
            if (string.IsNullOrEmpty(path)) return;
            bool targetEncrypted = DesktopManager.GetBool(row, 5);
            bool enableWallpaper = DesktopManager.GetBool(row, 2);
            string? wallpaperPath = DesktopManager.GetString(row, 3);
            string? wallpaperStyle = DesktopManager.GetString(row, 4);
            string? wallpaper = enableWallpaper && !string.IsNullOrEmpty(wallpaperPath) ? wallpaperPath : null;

            // 1. 正在离开的加密桌面若已解密（存在明文文件夹），先取得其密码（切换前询问，避免切换后困惑）
            string? leavingPw = null;
            bool leavingNeedsReEncrypt = DesktopManager.CurrentDesktopEncrypted
                && !string.IsNullOrEmpty(DesktopManager.CurrentDesktopName)
                && !string.IsNullOrEmpty(DesktopManager.CurrentDesktopPath)
                && Directory.Exists(DesktopManager.CurrentDesktopPath);
            if (leavingNeedsReEncrypt)
            {
                leavingPw = EncryptManager.GetSessionPassword(DesktopManager.CurrentDesktopName);
                if (leavingPw == null)
                {
                    // 会话内无缓存密码：弹窗输入，并通过实际解密验证（密码错误会重新弹窗）
                    EncryptManager.DesktopName = DesktopManager.CurrentDesktopName;
                    EncryptManager.DesktopFolder = DesktopManager.CurrentDesktopPath;
                    EncryptManager.DesktopID = EncryptManager.GetZipId(DesktopManager.CurrentDesktopName!);
                    while (true)
                    {
                        using var frm = new frmInputPassword { PromptText = $"请输入桌面“{DesktopManager.CurrentDesktopName}”的密码以重新加密" };
                        if (frm.ShowDialog() != DialogResult.OK)
                            return; // 用户取消，不切换
                        leavingPw = EncryptManager.Password;
                        try
                        {
                            await EncryptManager.VerifyPasswordByDecryptAsync(EncryptManager.DesktopID, leavingPw!);
                            EncryptManager.SetSessionPassword(DesktopManager.CurrentDesktopName, leavingPw!);
                            break;
                        }
                        catch (PqDecryptionException)
                        {
                            MessageBox.Show("密码错误，请重试", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

            // 2. 执行切换：目标加密时弹窗输入密码，并通过实际解密来校验（密码错误会重新弹窗）
            try
            {
                if (targetEncrypted)
                {
                    EncryptManager.DesktopName = name;
                    EncryptManager.DesktopFolder = path;
                    EncryptManager.DesktopID = EncryptManager.GetZipId(name);
                    while (true)
                    {
                        using var frm = new frmInputPassword { PromptText = $"请输入桌面“{name}”的密码" };
                        if (frm.ShowDialog() != DialogResult.OK)
                            return; // 用户取消
                        string pw = EncryptManager.Password!;
                        try
                        {
                            if (Directory.Exists(path))
                            {
                                // 文件夹已存在（此前已解锁为明文）：先验证密码，再直接切换，
                                // 避免用可能过期的压缩包覆盖桌面上的新文件
                                await EncryptManager.VerifyPasswordByDecryptAsync(EncryptManager.DesktopID, pw);
                                DesktopManager.ChangeDesktopPath(path, wallpaper, wallpaperStyle);
                            }
                            else
                            {
                                // 文件夹不存在：真实解密还原后切换（密码错误会在这里抛 PqDecryptionException）
                                await DesktopManager.ChangeDesktopPathWithPassword(path, wallpaper, wallpaperStyle, EncryptManager.DesktopID, pw);
                            }
                            EncryptManager.SetSessionPassword(name, pw);
                            break;
                        }
                        catch (PqDecryptionException)
                        {
                            MessageBox.Show("密码错误，请重试", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    DesktopManager.ChangeDesktopPath(path, wallpaper, wallpaperStyle);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"切换失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. 切换完成后，重新加密离开的桌面（此时 explorer 已释放旧桌面文件夹）
            if (leavingNeedsReEncrypt
                && !string.IsNullOrEmpty(DesktopManager.CurrentDesktopPath)
                && Directory.Exists(DesktopManager.CurrentDesktopPath))
            {
                string oldName = DesktopManager.CurrentDesktopName!;
                string oldPath = DesktopManager.CurrentDesktopPath;
                await Task.Delay(800); // 等待 explorer 释放旧桌面文件夹
                try
                {
                    await EncryptManager.GetZipFile(oldPath, EncryptManager.GetZipId(oldName), leavingPw!);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"警告：桌面“{oldName}”重新加密失败（文件暂为明文）：{ex.Message}",
                        "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            // 4. 记录当前桌面
            DesktopManager.SetCurrentDesktop(name, path, targetEncrypted);
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            frmSet set = new frmSet();
            set.ShowDialog();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (Convert.ToInt16(AppSettingsManager.AppSettings.Rows.Find("ExitMode")?["Value"]) == 0)
            {
                frmClose close = new frmClose();
                close.ShowDialog();
            }
            if (Program.IsMinWindow || Convert.ToInt16(AppSettingsManager.AppSettings.Rows.Find("ExitMode")?["Value"]) == 1)
            {
                Hide();
            }
            else
            {
                Environment.Exit(0);
            }

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
        }

        private void itmExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private async void itmDesktopList_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var clickedItem = e.ClickedItem as ToolStripMenuItem;

            if (clickedItem is not null && clickedItem.Tag is int index)
            {
                if (index < 0 || index >= DesktopManager.DesktopList.Rows.Count) return;
                await SwitchToDesktopAsync(DesktopManager.DesktopList.Rows[index]);
            }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            frmAbout about = new frmAbout();
            about.Show();
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (itmDesktopList.DropDownItems.Count == 0) { itmDesktopList.Enabled = false; }
            else { itmDesktopList.Enabled = true;}
            itmDesktopList.DropDownItems.Clear();
            int DesktopIndex = 0;
            foreach (DataRow desktopnames in DesktopManager.DesktopList.Rows)
            {
                string? desktopname = desktopnames[0].ToString();
                ToolStripMenuItem menuItem = new ToolStripMenuItem(desktopname);
                menuItem.Tag = DesktopIndex;
                itmDesktopList.DropDownItems.Add(menuItem);
                DesktopIndex++;// 存储索引
            }
        }
    }
}
