using Microsoft.Win32;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
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
            Application.Run(new frmMain());
        }
    }
    public static class IniManager
    {
        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="section">段落名</param>
        /// <param name="key">键名</param>
        /// <param name="defval">读取异常是的缺省值</param>
        /// <param name="retval">键名所对应的的值，没有找到返回空值</param>
        /// <param name="size">返回值允许的大小</param>
        /// <param name="filepath">ini文件的完整路径</param>
        /// <returns></returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern int GetPrivateProfileSectionNames(
            byte[] lpszReturnBuffer,
            int nSize,
            string lpFileName
        );
        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileString(
            string section,
            string key,
            string defval,
            StringBuilder retval,
            int size,
            string filepath);

        /// <summary>
        /// 写入
        /// </summary>
        /// <param name="section">需要写入的段落名</param>
        /// <param name="key">需要写入的键名</param>
        /// <param name="val">写入值</param>
        /// <param name="filepath">ini文件的完整路径</param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        private static extern int WritePrivateProfileString(
            string section,
            string key,
            string val,
            string filepath);


        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="section">段落名</param>
        /// <param name="key">键名</param>
        /// <param name="def">没有找到时返回的默认值</param>
        /// <param name="filename">ini文件完整路径</param>
        /// <returns></returns>
        public static string getString(string section, string key, string def, string filename)
        {
            StringBuilder sb = new StringBuilder(1024);
            GetPrivateProfileString(section, key, def, sb, 1024, filename);
            return sb.ToString();
        }

        /// <summary>
        /// 写入数据
        /// </summary>
        /// <param name="section">段落名</param>
        /// <param name="key">键名</param>
        /// <param name="val">写入值</param>
        /// <param name="filename">ini文件完整路径</param>
        public static void writeString(string section, string key, string val, string filename)
        {
            WritePrivateProfileString(section, key, val, filename);
        }
        public static void DeleteSection(string filePath, string section)
        {
            // 通过写入null来删除整个节
            WritePrivateProfileString(section, null, null, filePath);
        }
    }
    public class IniFileHelper
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        private static extern int GetPrivateProfileString(
            string lpAppName,
            string lpKeyName,
            string lpDefault,
            StringBuilder lpReturnedString,
            int nSize,
            string lpFileName);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        private static extern bool WritePrivateProfileString(
            string lpAppName,
            string lpKeyName,
            string lpString,
            string lpFileName);

        public static void RenameSection(string filePath, string oldSection, string newSection)
        {
            // 1. 读取原节的所有键值对
            var keys = GetAllKeys(filePath, oldSection);
            var keyValuePairs = new Dictionary<string, string>();

            foreach (var key in keys)
            {
                var value = new StringBuilder(255);
                GetPrivateProfileString(oldSection, key, "", value, 255, filePath);
                keyValuePairs[key] = value.ToString();
            }

            // 2. 删除原节
            WritePrivateProfileString(oldSection, null, null, filePath);

            // 3. 使用新节名写入所有键值对
            foreach (var kvp in keyValuePairs)
            {
                WritePrivateProfileString(newSection, kvp.Key, kvp.Value, filePath);
            }
        }

        private static List<string> GetAllKeys(string filePath, string section)
        {
            // 获取节的所有键
            var keys = new StringBuilder(65535);
            GetPrivateProfileString(section, null, "", keys, 65535, filePath);
            return keys.ToString().Split('\0')
                .Where(k => !string.IsNullOrEmpty(k))
                .ToList();
        }
    }
    public static class PasswordHelper
    {
        public static int DesktopIndex;
    }
    public static class AppCommon
    {
        public static string IniPath = Application.StartupPath + "\\" + "DesktopConfig.ini";
    }
    class WallpaperChanger
    {
        // 导入Windows API
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        // 常量定义
        private const int SPI_SETDESKWALLPAPER = 0x0014;
        private const int SPIF_UPDATEINIFILE = 0x01;
        private const int SPIF_SENDWININICHANGE = 0x02;

        public static void SetWallpaper(string path)
        {
            // 设置桌面背景
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, path,
                                SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        }
    }
    public class WallpaperHelper
    {
        // Windows API常量
        private const int SPI_GETDESKWALLPAPER = 0x0073;
        private const int MAX_PATH = 260;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        /// <summary>
        /// 获取当前桌面壁纸路径
        /// </summary>
        /// <returns>壁纸路径，如果是纯色/幻灯片则返回"不支持的文件"</returns>
        public static string GetWallpaperPath()
        {
            try
            {
                string wallpaperPath = new string('\0', MAX_PATH);
                SystemParametersInfo(SPI_GETDESKWALLPAPER, MAX_PATH, wallpaperPath, 0);

                // 去除字符串中的空字符
                wallpaperPath = wallpaperPath.Substring(0, wallpaperPath.IndexOf('\0')).Trim();

                // 检查是否是有效文件路径
                if (string.IsNullOrEmpty(wallpaperPath) ||
                    !File.Exists(wallpaperPath) ||
                    IsSolidColorOrSlideshow(wallpaperPath))
                {
                    return "不支持的文件";
                }

                return wallpaperPath;
            }
            catch
            {
                return "不支持的文件";
            }
        }

        /// <summary>
        /// 检查是否是纯色背景或幻灯片
        /// </summary>
        private static bool IsSolidColorOrSlideshow(string wallpaperPath)
        {
            // 纯色背景的路径通常是空或特定值
            if (string.IsNullOrEmpty(wallpaperPath))
            {
                return true;
            }

            // 检查是否是幻灯片（通过注册表）
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Personalization\Desktop Slideshow"))
            {
                if (key != null)
                {
                    // 如果有幻灯片相关设置，则认为是幻灯片
                    var attributes = key.GetValue("Attributes");
                    if (attributes != null)
                    {
                        return true;
                    }
                }
            }

            // Windows 10/11纯色背景的特殊处理
            if (wallpaperPath.StartsWith("TranscodedWallpaper") ||
                wallpaperPath.StartsWith("C:\\Windows\\Web\\Wallpaper\\Windows\\img0.jpg"))
            {
                return true;
            }

            return false;
        }
    }

}
