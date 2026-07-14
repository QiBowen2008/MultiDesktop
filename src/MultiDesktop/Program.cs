using Microsoft.Win32;
//using MultiLangDll;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MultiDesktop
{
    internal static class Program
    {
        [DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        [DllImport("kernel32.dll")]
        private static extern bool FreeConsole();
        /// <summary>
        ///  The main entry point for the application.
        ///  程序主入口点
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                //QtLang.SetShowLang("en");
                // To customize application configuration such as set high DPI settings or default font,
                // see https://aka.ms/applicationconfiguration.
                Console.WriteLine("程序正在启动");
                FreeConsole();

                AppSettingsManager.ColorMode.TryGetValue(Properties.Settings.Default.ColorMode, out var colorMode);
                Application.SetColorMode(colorMode);
                ApplicationConfiguration.Initialize();
                Application.Run(new frmMain());
            }
            else
            {
                for (int i = 0; i < args.Length; i++) {
                    if (args[i] == "--version")
                    {
                        Console.WriteLine("1.1.2.0");
                    }
                    if (args[i] == "--help")
                    {
                        
                    }
                }
            }
        }
        public static bool IsMinWindow = false;
    }
    public static class DesktopManager
    {
        public static DataTable DesktopList = new();
        public static string? t_DesktopName = "";
        public static string? t_DesktopPath = "";
        public static bool IsEdit = false;
        public static int IndexToChange;
        public static void ReSetDesktopManager()
        {
            t_DesktopName = "";
            t_DesktopPath = "";
            IsEdit = false;
        }
        public static void ChangeDesktopPath(string newPath)
        {
            using (RegistryKey? key = Registry.CurrentUser.OpenSubKey(
                @"Software\Microsoft\Windows\CurrentVersion\Explorer\User Shell Folders", true))
            {
                if (key == null)
                    throw new Exception("无法打开注册表项");
                key.SetValue("Desktop", newPath, RegistryValueKind.ExpandString);
            }

            using (RegistryKey? key = Registry.CurrentUser.OpenSubKey(
                @"Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders", true))
            {
                if (key != null)
                    key.SetValue("Desktop", newPath, RegistryValueKind.ExpandString);
            }
            foreach (Process process in Process.GetProcessesByName("explorer"))
            {
                process.Kill();
            }
            System.Threading.Thread.Sleep(1000);
            Process.Start("explorer.exe");
        }
    }
    public static class AppSettingsManager
    {
        public static Dictionary<string, SystemColorMode> ColorMode = new Dictionary<string, SystemColorMode>
            {{ "浅色", SystemColorMode.Classic },
             { "跟随系统",SystemColorMode.System },
             { "深色",SystemColorMode.Dark }
        };

    }
}