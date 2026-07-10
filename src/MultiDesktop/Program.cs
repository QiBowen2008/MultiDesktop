using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MultiDesktop
{
    internal static class Program
    {
        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Environment.OSVersion.Version.Major >= 6)
                SetProcessDPIAware();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLauncher());
        }
    }

    /// <summary>
    /// 全局应用常量
    /// </summary>
    public static class AppCommon
    {
        /// <summary>JSON 配置文件完整路径</summary>
        public static string ConfigPath = Path.Combine(Application.StartupPath, "DesktopConfig.json");
    }

    /// <summary>
    /// 全局状态（跨窗口共享）
    /// </summary>
    public static class AppState
    {
        /// <summary>当前加载的桌面配置</summary>
        public static Models.DesktopConfigData Config { get; set; }

        /// <summary>在启动窗口中选择的桌面索引</summary>
        public static int SelectedDesktopIndex { get; set; }
    }

    /// <summary>
    /// 密码功能预留（开发计划）
    /// </summary>
    public static class PasswordHelper
    {
        public static int DesktopIndex;
    }

    /// <summary>
    /// 桌面切换核心逻辑（供所有窗口复用）
    /// </summary>
    public static class DesktopSwitcher
    {
        /// <summary>修改注册表切换桌面文件夹</summary>
        public static void ChangeDesktopLocation(string newPath)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(
                @"Software\Microsoft\Windows\CurrentVersion\Explorer\User Shell Folders", true))
            {
                if (key == null)
                    throw new Exception("无法打开注册表项。");
                key.SetValue("Desktop", newPath, RegistryValueKind.ExpandString);
            }

            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(
                @"Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders", true))
            {
                if (key != null)
                    key.SetValue("Desktop", newPath, RegistryValueKind.ExpandString);
            }
        }

        /// <summary>重启 explorer.exe 使变更生效</summary>
        public static void RestartExplorer()
        {
            foreach (Process process in Process.GetProcessesByName("explorer"))
            {
                process.Kill();
            }
            System.Threading.Thread.Sleep(1000);
            Process.Start("explorer.exe");
        }

        /// <summary>执行完整的桌面切换操作</summary>
        public static void SwitchToDesktop(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                ChangeDesktopLocation(path);
            }
            RestartExplorer();
        }
    }
}
