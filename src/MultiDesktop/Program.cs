using Microsoft.Win32;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices;
using PostQuantum.FileEncryption;

namespace MultiDesktop
{
    internal static class Program
    {
        [DllImport("kernel32.dll")]
        private static extern bool FreeConsole();
        [DllImport("kernel32.dll")]
        private static extern bool AttachConsole(int dwProcessId);
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // NativeAOT 下任何未处理异常都会以 0xC0000409（STATUS_STACK_BUFFER_OVERRUN）fail-fast，
            // 这里兜底：写 error.log 并弹窗提示，而不是直接崩溃。
            try
            {
                Run(args);
            }
            catch (Exception ex)
            {
                try
                {
                    File.WriteAllText(Path.Combine(AppPaths.ConfigDir, "error.log"),
                        $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}]\r\n{ex}\r\n");
                }
                catch { }
                MessageBox.Show($"MultiDesktop 启动失败：\n{ex.Message}\n\n详细信息已写入配置目录下的 error.log",
                    "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void Run(string[] args)
        {
            // ========== CLI 模式 ==========
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "--version")
                {
                    AttachConsole(-1);
                    Console.WriteLine("MultiDesktop v1.1.2.0");
                    return;
                }
                if (args[i] == "--help" || args[i] == "-h")
                {
                    AttachConsole(-1);
                    ShowHelp();
                    return;
                }
                if (args[i] == "--AddDesktop")
                {
                    AttachConsole(-1);
                    if (i + 2 >= args.Length)
                    {
                        Console.WriteLine("错误: --AddDesktop 缺少参数。需要: <桌面名称> <桌面路径>");
                        Console.WriteLine("示例: MultiDesktop --AddDesktop \"工作\" \"D:\\WorkDesktop\"");
                        return;
                    }

                    // 可选参数：--SetBack <壁纸路径> 启用自定义壁纸，--SetStyle <显示方式> 指定显示方式
                    bool enableWallpaper = false;
                    string wallpaperPath = "";
                    string wallpaperStyle = "填充";
                    bool Encrypt = false;
                    int j = i + 3;
                    while (j < args.Length)
                    {
                        if (args[j] == "--SetBack")
                        {
                            if (j + 1 >= args.Length)
                            {
                                Console.WriteLine("错误: --SetBack 缺少参数。需要: <壁纸路径>");
                                Console.WriteLine("示例: MultiDesktop --AddDesktop \"工作\" \"D:\\WorkDesktop\" --SetBack \"D:\\wallpaper.jpg\"");
                                return;
                            }
                            enableWallpaper = true;
                            wallpaperPath = args[j + 1];
                            j += 2;
                        }
                        else if (args[j] == "--SetStyle")
                        {
                            if (j + 1 >= args.Length)
                            {
                                Console.WriteLine("错误: --SetStyle 缺少参数。需要: <显示方式>");
                                Console.WriteLine("提示: 显示方式可选 填充/适应/拉伸/平铺/居中/跨屏");
                                return;
                            }
                            wallpaperStyle = args[j + 1];
                            j += 2;
                        }
                        else if (args[j] == "--SetPassword")
                        {
                            if(j + 1 >= args.Length)
                            {
                                Console.WriteLine("错误: --SetPassword 缺少参数。需要: <密码>");
                                return;
                            }
                            Encrypt = true;
                        }
                        else
                        {
                            j++;
                        }
                    }

                    if (enableWallpaper && !File.Exists(wallpaperPath))
                    {
                        Console.WriteLine($"错误: 壁纸文件不存在: {wallpaperPath}");
                        return;
                    }

                    InitDesktopListForCli();
                    try
                    {
                        DesktopManager.AddDesktop(args[i + 1], args[i + 2], enableWallpaper, wallpaperPath??"", wallpaperStyle,Encrypt);
                        Console.WriteLine($"成功添加桌面: {args[i + 1]} -> {args[i + 2]}");
                        if (enableWallpaper)
                            Console.WriteLine($"已设置壁纸: {wallpaperPath} (显示方式: {wallpaperStyle})");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"添加失败: {ex.Message}");
                    }
                    return;
                }
                if (args[i] == "--DeleteDesktop")
                {
                    AttachConsole(-1);
                    if (i + 1 >= args.Length)
                    {
                        Console.WriteLine("错误: --DeleteDesktop 缺少参数。需要: <桌面名称>");
                        Console.WriteLine("示例: MultiDesktop --DeleteDesktop \"工作\"");
                        return;
                    }
                    InitDesktopListForCli();
                    var row = DesktopManager.DesktopList.Rows.Find(args[i + 1]);
                    if (row != null)
                    {
                        row.Delete();
                        DesktopManager.DesktopList.WriteXml(AppPaths.DesktopList, System.Data.XmlWriteMode.WriteSchema);
                        Console.WriteLine($"已删除桌面: {args[i + 1]}");
                    }
                    else
                    {
                        Console.WriteLine($"错误: 未找到名为 \"{args[i + 1]}\" 的桌面");
                        Console.WriteLine("提示: 使用 --ListDesktop 查看所有已配置的桌面");
                    }
                    return;
                }
                if (args[i] == "--ListDesktop")
                {
                    AttachConsole(-1);
                    if (File.Exists(AppPaths.DesktopList))
                    {
                        Console.Write(File.ReadAllText(AppPaths.DesktopList));
                    }
                    else
                    {
                        Console.WriteLine("当前没有配置任何桌面。");
                        Console.WriteLine("提示: 使用 --AddDesktop <名称> <路径> 添加桌面");
                    }
                    return;
                }
            }

            // ========== GUI 模式：立刻断开控制台 ==========
            FreeConsole();
            // 检测非交互式会话（WinGet 验证、Session 0、无桌面环境）
            if (!Environment.UserInteractive)
            {
                // 非交互式环境，直接退出，不启动 GUI
                // 返回 0 让 WinGet 验证通过
                return;
            }
            // ========== 初始化（只执行一次） ==========
            if (!File.Exists(AppPaths.AppSettings))
            {
                var dt = AppSettingsManager.AppSettings;
                dt.Columns.Add("Key", typeof(string));
                dt.Columns.Add("Value", typeof(int));
                dt.TableName = "AppSettings";
                dt.Rows.Add("Color", 0);
                dt.Rows.Add("ExitMode", 0);
                dt.WriteXml(AppPaths.AppSettings, XmlWriteMode.WriteSchema);
            }
            else
            {
                AppSettingsManager.AppSettings.ReadXml(AppPaths.AppSettings);
            }

            AppSettingsManager.AppSettings.PrimaryKey = new DataColumn[]
            {
                AppSettingsManager.AppSettings.Columns["Key"]
            };

            AppSettingsManager.ColorMode.TryGetValue(AppSettingsManager.GetColor(Convert.ToInt16(AppSettingsManager.AppSettings.Rows.Find("Color")?["Value"])), out var colorMode);
            Application.SetColorMode(colorMode);
            ApplicationConfiguration.Initialize();
            Application.Run(new frmMain());
        }

        public static bool IsMinWindow = false;

        private static void ShowHelp()
        {
            Console.WriteLine(@"MultiDesktop — Windows 多桌面管理工具  v1.1.2.0

通过修改 Windows 注册表中的桌面路径，实现在多个虚拟桌面文件夹之间
一键切换。程序可最小化到系统托盘，右键即可快速切换已配置的桌面。

用法:
  MultiDesktop [选项]

  不带任何参数运行将启动图形界面。

选项:
  --help, -h               显示此帮助信息

  --version                显示版本号

  --AddDesktop <名称> <路径> [--SetBack <壁纸路径>] [--SetStyle <显示方式>]
                           添加一个新的桌面配置。
                           名称和路径均需提供，路径必须存在。
                           --SetBack 可选，为桌面设置自定义壁纸（切换到此桌面时自动应用）。
                           --SetStyle 可选，指定壁纸显示方式（默认""填充""），
                           可用值: 填充/适应/拉伸/平铺/居中/跨屏。
                           示例:
                             MultiDesktop --AddDesktop ""工作"" ""D:\WorkDesktop""
                             MultiDesktop --AddDesktop ""娱乐"" ""E:\GameDesktop"" --SetBack ""D:\pics\game.jpg"" --SetStyle 拉伸

  --DeleteDesktop <名称>
                           删除指定名称的桌面配置。
                           示例:
                             MultiDesktop --DeleteDesktop ""工作""

  --ListDesktop            列出所有已配置的桌面。

提示:
  - 桌面切换即时生效，无需重启资源管理器。
  - 配置文件保存在程序同目录下的 DesktopList.xml 中。
  - 程序首次运行会自动创建必要的配置文件。

项目主页: https://github.com/Qibowen2008/MultiDesktop
许可证: MIT");
        }

        private static void InitDesktopListForCli()
        {
            if (File.Exists(AppPaths.DesktopList))
            {
                DesktopManager.DesktopList.ReadXml(AppPaths.DesktopList);
                DesktopManager.EnsureDesktopListColumns(DesktopManager.DesktopList);
            }
            else
            {
                DesktopManager.DesktopList.TableName = "DesktopList";
                DesktopManager.DesktopList.Columns.Add("桌面名称", typeof(string));
                DesktopManager.DesktopList.Columns.Add("桌面路径", typeof(string));
                DesktopManager.DesktopList.Columns.Add("是否开启自定义壁纸", typeof(bool));
                DesktopManager.DesktopList.Columns.Add("自定义壁纸地址", typeof(string));
                DesktopManager.DesktopList.Columns.Add("壁纸显示方式", typeof(string));
                DesktopManager.DesktopList.Columns.Add("是否加密", typeof(bool));
            }
            if (File.Exists(AppPaths.PasswordList))
            {
                EncryptManager.PasswordList.ReadXml(AppPaths.PasswordList);
            }
            else
            {
                EncryptManager.PasswordList.TableName = "PasswordList";
                EncryptManager.PasswordList.Columns.Add("id",typeof(int));
                EncryptManager.PasswordList.Columns.Add("hash",typeof(string));
            }
            DesktopManager.DesktopList.PrimaryKey = new DataColumn[]
            {
                DesktopManager.DesktopList.Columns["桌面名称"]!
            };
        }
    }
    /// <summary>
    /// 配置文件路径解析。winget 等场景下工作目录(CWD)可能不可写，
    /// 因此配置文件统一放在 exe 所在目录；该目录不可写时回退到 %AppData%\MultiDesktop。
    /// </summary>
    public static class AppPaths
    {
        public static readonly string ConfigDir = ResolveConfigDir();
        public static readonly string AppSettings = Path.Combine(ConfigDir, "AppSettings.xml");
        public static readonly string DesktopList = Path.Combine(ConfigDir, "DesktopList.xml");
        public static readonly string PasswordList = Path.Combine(ConfigDir, "PasswordList.xml");

        private static string ResolveConfigDir()
        {
            try
            {
                // 探测 exe 目录是否可写（winget portable 安装在用户目录下，可写）
                var probe = Path.Combine(AppContext.BaseDirectory, ".write_probe");
                File.WriteAllText(probe, "");
                File.Delete(probe);
                return AppContext.BaseDirectory;
            }
            catch
            {
                var dir = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "MultiDesktop");
                Directory.CreateDirectory(dir);
                return dir;
            }
        }
    }

    public static class DesktopManager
    {
        // ========== Win32 Shell API ==========

        // 桌面文件夹的 Known Folder GUID
        private static readonly Guid FOLDERID_Desktop =
            new("{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}");

        // SHSetKnownFolderPath 标志
        private const uint KF_FLAG_NO_FLAGS = 0x00000000;  // 写注册表 + 立即通知 Shell 刷新

        // SHChangeNotify 事件
        private const uint SHCNE_ASSOCCHANGED = 0x08000000;
        private const uint SHCNF_FLUSH = 0x1000;

        /// <summary>
        /// 修改已知文件夹位置（写注册表 + 立即通知 Shell 刷新，无需重启 explorer）。
        /// </summary>
        [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
        private static extern int SHSetKnownFolderPath(
            ref Guid rfid, uint dwFlags, IntPtr hToken, string pszPath);

        /// <summary>
        /// 通知 Shell 发生了变更（双重保险）。
        /// </summary>
        [DllImport("shell32.dll")]
        private static extern void SHChangeNotify(
            uint wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);

        // ========== 壁纸 API ==========

        // SystemParametersInfo 常量
        private const uint SPI_SETDESKWALLPAPER = 0x0014;
        private const uint SPIF_UPDATEINIFILE   = 0x01;  // 写入注册表（user profile）
        private const uint SPIF_SENDCHANGE      = 0x02;  // 广播 WM_SETTINGCHANGE

        /// <summary>
        /// 设置系统参数（此处用于壁纸）。
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SystemParametersInfo(
            uint uAction, uint uParam, string lpvParam, uint fuWinInfo);

        // ========== 数据 ==========

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

        /// <summary>
        /// 确保 DataTable 包含所有列（兼容旧版 DesktopList.xml 缺少新列的情况）。
        /// </summary>
        public static void EnsureDesktopListColumns(DataTable dt)
        {
            if (!dt.Columns.Contains("是否开启自定义壁纸"))
                dt.Columns.Add("是否开启自定义壁纸", typeof(bool));
            if (!dt.Columns.Contains("自定义壁纸地址"))
                dt.Columns.Add("自定义壁纸地址", typeof(string));
            if (!dt.Columns.Contains("壁纸显示方式"))
                dt.Columns.Add("壁纸显示方式", typeof(string));
        }

        /// <summary>
        /// 将壁纸显示方式名称映射为注册表 WallpaperStyle / TileWallpaper 值。
        /// </summary>
        private static (string style, string tile) GetWallpaperStyleValues(string? styleName)
        {
            return styleName switch
            {
                "居中" => ("0",  "0"),
                "平铺" => ("0",  "1"),
                "拉伸" => ("2",  "0"),
                "适应" => ("6",  "0"),
                "填充" => ("10", "0"),
                "跨屏" => ("22", "0"),
                _      => ("10", "0"),  // 默认填充
            };
        }

        // ========== 壁纸设置 ==========

        /// <summary>
        /// 将指定图片设为桌面壁纸（通过 SystemParametersInfo 立即生效）。
        /// SPIF_UPDATEINIFILE 会自动写入注册表，无需手动操作。
        /// </summary>
        private static void SetWallpaper(string wallpaperPath, string? wallpaperStyle)
        {
            var (styleVal, tileVal) = GetWallpaperStyleValues(wallpaperStyle);

            using (var deskKey = Registry.CurrentUser.OpenSubKey(
                @"Control Panel\Desktop", writable: true))
            {
                deskKey?.SetValue("WallpaperStyle", styleVal, RegistryValueKind.String);
                deskKey?.SetValue("TileWallpaper",  tileVal,  RegistryValueKind.String);
            }

            // 调用 SystemParametersInfo 立即应用壁纸并广播变更通知
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, wallpaperPath,
                SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
        }

        // ========== 桌面切换 ==========

        /// <summary>
        /// 切换桌面文件夹路径。
        /// 优先使用 SHSetKnownFolderPath（无感切换，不重启 explorer）；
        /// 若失败则回退到旧方案（改注册表 + 重启 explorer）。
        /// </summary>
        public static void ChangeDesktopPath(string newPath)
        {
            ChangeDesktopPath(newPath, null, null);
        }

        /// <summary>
        /// 切换桌面文件夹路径，并可选设置壁纸及显示方式。
        /// wallpaperPath 为 null 时仅切换目录，不修改壁纸。
        /// </summary>
        public static void ChangeDesktopPath(string newPath, string? wallpaperPath, string? wallpaperStyle)
        {
            // 确保目标目录存在
            if (!Directory.Exists(newPath))
                Directory.CreateDirectory(newPath);

            // 设置了壁纸路径则立即应用
            if (!string.IsNullOrEmpty(wallpaperPath) && File.Exists(wallpaperPath))
                SetWallpaper(wallpaperPath, wallpaperStyle);

            // 方案一（优先）：SHSetKnownFolderPath —— 无感切换
            var guid = FOLDERID_Desktop;
            int hr = SHSetKnownFolderPath(
                ref guid,
                KF_FLAG_NO_FLAGS,
                IntPtr.Zero,
                newPath);

            if (hr == 0) // S_OK
            {
                // 双重保险：再发一次 Shell 刷新通知
                SHChangeNotify(SHCNE_ASSOCCHANGED, SHCNF_FLUSH, IntPtr.Zero, IntPtr.Zero);
                return;
            }

            // 方案二（回退）：改注册表 + 重启 explorer
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
        public static bool AddDesktop(string DesktopName, string DesktopPath, bool enableWallpaper, string wallpaperPath, string wallpaperStyle,bool IsEncrypt)
        {
            if (!string.IsNullOrWhiteSpace(DesktopName) && !string.IsNullOrWhiteSpace(DesktopPath))
            {
                if (Directory.Exists(DesktopPath))
                {
                    // 壁纸存在性检查：开启自定义壁纸时文件必须存在
                    if (enableWallpaper && !File.Exists(wallpaperPath))
                    {
                        MessageBox.Show("壁纸文件不存在，请检查路径");
                        return false;
                    }

                    if (DesktopManager.IsEdit == false)
                    {
                        DesktopManager.DesktopList.Rows.Add(DesktopName, DesktopPath, enableWallpaper, wallpaperPath ?? "", wallpaperStyle ?? "填充",IsEncrypt);
                    }
                    else
                    {
                        DesktopManager.DesktopList.Rows[DesktopManager.IndexToChange][0] = DesktopName;
                        DesktopManager.DesktopList.Rows[DesktopManager.IndexToChange][1] = DesktopPath;
                        DesktopManager.DesktopList.Rows[DesktopManager.IndexToChange][2] = enableWallpaper;
                        DesktopManager.DesktopList.Rows[DesktopManager.IndexToChange][3] = wallpaperPath ?? "";
                        DesktopManager.DesktopList.Rows[DesktopManager.IndexToChange][4] = wallpaperStyle ?? "填充";
                    }
                    DesktopManager.DesktopList.WriteXml(AppPaths.DesktopList, System.Data.XmlWriteMode.WriteSchema);
                    return true;
                }
                else
                {
                    MessageBox.Show("你输入的桌面路径不存在");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("请完整填写信息");
                return false;
            }
        }
    }
    public static class AppSettingsManager
    {
        public static Dictionary<string, SystemColorMode> ColorMode = new Dictionary<string, SystemColorMode>
            {{ "浅色", SystemColorMode.Classic },
             { "跟随系统", SystemColorMode.System },
             { "深色", SystemColorMode.Dark }
        };
        public static DataTable AppSettings = new();
        public static string GetColor(int ColorNumber)
        {
            return ColorNumber switch
            {
                0 => "跟随系统",
                1 => "浅色",
                2 => "深色",
                _ => "跟随系统"
            };
        }
        public static int GetColorNum(string ColorStr)
        {
            return ColorStr switch
            {
               "跟随系统" => 0,
                "浅色" => 1,
                "深色" => 2,
                _ => 0
            };
        }
        public static string GetExitMode(int ExitModeNumber)
        {
            return ExitModeNumber switch
            {
                0 => "询问",
                1 => "最小化到后台",
                2 => "退出程序",
                _ => "询问"
            };
        }
        public static int GetExitModeNum(string ExitModeStr)
        {
            return ExitModeStr switch
            {
                "询问" => 0,
                "最小化到后台" => 1,
                "退出程序" => 2,
                _ => 0
            };
        }
    }
    public static class EncryptManager
    {
        public static bool IsEncrypted = false;
        public static DataTable PasswordList = new();
        public static string DesktopFolder;
        public static int DesktopID;
        public  static void GetZipFile(string folder,int id,string password)
        {
            string zipfile = AppPaths.ConfigDir + "/Zips/" + id.ToString() + ".zip";
            string zipDirectory = Path.GetDirectoryName(zipfile);

            // 2. 创建该目录（如果已存在则不会做任何事）
            if (!string.IsNullOrEmpty(zipDirectory))
            {
                Directory.CreateDirectory(zipDirectory);
            }
            System.IO.Compression.ZipFile.CreateFromDirectory(folder, zipfile, System.IO.Compression.CompressionLevel.NoCompression, false);
            Directory.Delete(folder, true);
            new PqFileEncryptor().EncryptFileAsync(zipfile, zipfile + ".encrypted", password);
        }
        public static void UnZipFile(string folder, int id, string password)
        {
            string zipfile = AppPaths.ConfigDir + "/Zips/" + id.ToString() + ".zip";
            string encryptedfile = zipfile + ".encrypted";
            new PqFileDecryptor().DecryptFileAsync(encryptedfile, zipfile, password);
            System.IO.Compression.ZipFile.ExtractToDirectory(zipfile, folder, true);
            File.Delete(zipfile);
            File.Delete(encryptedfile);
        }
    }
}
