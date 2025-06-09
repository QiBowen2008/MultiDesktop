using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace MultiDesktop
{
    public partial class frmMain : Sunny.UI.UIForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnAddDesktop_Click(object sender, EventArgs e)
        {
            IniManager.writeString(cobDesktopList.SelectedIndex.ToString(), "DesktopPath", txtDesktopLocation.Text, AppCommon.IniPath);
            IniManager.writeString(cobDesktopList.SelectedIndex.ToString(), "DesktopName", txtDesktopName.Text, AppCommon.IniPath);
            IniManager.writeString(cobDesktopList.SelectedIndex.ToString(), "DesktopBack", txtDesktopBackground.Text, AppCommon.IniPath);
            IniManager.writeString("0", "FirstRun", "False", AppCommon.IniPath);
            IniManager.writeString("0", "DesktopCount", cobDesktopList.Items.Count.ToString(), AppCommon.IniPath);
            cobDesktopList.Items.Add("新桌面"+cobDesktopList .Items .Count .ToString ());
            cobDesktopList.SelectedIndex = cobDesktopList.Items.Count - 1;
            txtDesktopBackground.Text = "";
            txtDesktopLocation.Text = "";
            txtDesktopName.Text = "新桌面" + cobDesktopList.Items.Count.ToString();
        }

        private void btnSetDesktopLocation_Click(object sender, EventArgs e)
        {
            if( folderBrowserDialog1.ShowDialog()==DialogResult.OK)
            {
                txtDesktopLocation.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(openFileDialog1 .ShowDialog ()==DialogResult.OK)
            {

            }
        }

        private void cobDesktopList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (cobDesktopList.Text == "默认桌面")
            {
                btnDeleteDesktop.Enabled = false;
                txtDesktopName.Enabled = false;
            }
            else
            {
                btnDeleteDesktop.Enabled = true;
                txtDesktopName.Enabled = true;
            }
            txtDesktopName.Text  = cobDesktopList.Text;
            txtDesktopLocation.Text = IniManager.getString(cobDesktopList .SelectedIndex .ToString (), "DesktopPath", desktopPath, AppCommon.IniPath);
            txtDesktopBackground.Text = IniManager.getString(cobDesktopList.SelectedIndex.ToString(), "DesktopBack", WallpaperHelper.GetWallpaperPath(), AppCommon.IniPath);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            IniManager.writeString(cobDesktopList.SelectedIndex.ToString(), "DesktopPath", txtDesktopLocation.Text, AppCommon.IniPath);
            IniManager.writeString(cobDesktopList.SelectedIndex.ToString(), "DesktopName", txtDesktopName.Text, AppCommon.IniPath);
            IniManager.writeString(cobDesktopList.SelectedIndex.ToString(), "DesktopBack", txtDesktopBackground.Text, AppCommon.IniPath);
            IniManager.writeString("0", "FirstRun", "False", AppCommon.IniPath);
            IniManager.writeString("0", "DesktopCount", cobDesktopList .Items .Count .ToString (), AppCommon.IniPath);

        }

        private void btnDeleteDesktop_Click(object sender, EventArgs e)
        {
            cobDesktopList.Items.RemoveAt(cobDesktopList.SelectedIndex);
            int deletenumber = cobDesktopList .SelectedIndex;
            IniManager.DeleteSection(AppCommon.IniPath,deletenumber.ToString ());
            for (int i=deletenumber+1; i < cobDesktopList .Items .Count+1 ; i++)
            {
                IniFileHelper.RenameSection(AppCommon.IniPath, i.ToString (), i.ToString());
            }
            cobDesktopList .Items .Remove (cobDesktopList.SelectedIndex);
            txtDesktopBackground.Text = "";
            txtDesktopLocation.Text = "";
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // 获取当前DPI比例
            float dpiX, dpiY;
            using (Graphics g = CreateGraphics())
            {
                dpiX = g.DpiX;
                dpiY = g.DpiY;
            }
            // 根据DPI比例调整控件尺寸
            float scaleFactor = dpiX / 96f; // 96 DPI 是标准DPI

            foreach (Control control in Controls)
            {
                control.Width = (int)(control.Width * scaleFactor);
                control.Height = (int)(control.Height * scaleFactor);
                control.Left = (int)(control.Left * scaleFactor);
                control.Top = (int)(control.Top * scaleFactor);
            }
            Height = (int)(342 * scaleFactor);
            Width = (int)(656 * scaleFactor);
            titleHeight = Convert.ToInt32(titleHeight * scaleFactor);
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (IniManager.getString("0", "FirstRun", "True", AppCommon.IniPath) == "True")
            {
                txtDesktopLocation.Text = desktopPath;
            }
            else
            {
                txtDesktopLocation.Text = IniManager.getString("0", "DesktopPath", desktopPath, AppCommon.IniPath);
                txtDesktopBackground .Text = IniManager.getString("0", "DesktopBack", WallpaperHelper .GetWallpaperPath (), AppCommon.IniPath);
            }
            int DesktopCount = Convert .ToInt16 ( IniManager.getString("0", "DesktopCount", "0", AppCommon.IniPath));
            for (int i =1; i <= DesktopCount; i++) {
                if(!string .IsNullOrEmpty ( IniManager.getString(i.ToString(), "DesktopName", "", AppCommon.IniPath))){
                    cobDesktopList.Items.Add(IniManager.getString(i.ToString(), "DesktopName", "", AppCommon.IniPath));
                }
            }
        }

        private void btnChangeDesktop_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDesktopLocation .Text))
            {
                try
                {
                    // 修改注册表中的桌面位置
                    ChangeDesktopLocation(txtDesktopLocation.Text);
                    // 重启 explorer.exe 使更改生效
                    RestartExplorer();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if(!string.IsNullOrEmpty(txtDesktopBackground .Text))
            {
                if(txtDesktopBackground .Text != "默认壁纸")
                {
                    try
                    {
                        WallpaperChanger .SetWallpaper (txtDesktopBackground .Text);
                    }
                    catch {
                        MessageBox.Show("无效的壁纸文件");
                    }
                }
            }
        }
        static void RestartExplorer()
        {
            // 结束现有的 explorer.exe 进程
            foreach (Process process in Process.GetProcessesByName("explorer"))
            {
                process.Kill();
            }

            // 稍等片刻确保进程完全结束
            System.Threading.Thread.Sleep(1000);

            // 启动新的 explorer.exe
            Process.Start("explorer.exe");
        }
        static void ChangeDesktopLocation(string newPath)
        {
            // 获取当前用户的注册表项
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(
                @"Software\Microsoft\Windows\CurrentVersion\Explorer\User Shell Folders", true))
            {
                if (key == null)
                {
                    throw new Exception("Unable to open registry key.");
                }

                // 修改 Desktop 的值
                key.SetValue("Desktop", newPath, RegistryValueKind.ExpandString);
            }

            // 同时更新 Shell Folders 中的值以确保兼容性
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(
                @"Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders", true))
            {
                if (key != null)
                {
                    key.SetValue("Desktop", newPath, RegistryValueKind.ExpandString);
                }
            }
        }

        private void txtDesktopName_TextChanged(object sender, EventArgs e)
        {
            cobDesktopList .Items[cobDesktopList .SelectedIndex] = txtDesktopName.Text;
        }
    }
}
