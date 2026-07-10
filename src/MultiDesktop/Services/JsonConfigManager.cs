using System;
using System.IO;
using System.Text;
using System.Web.Script.Serialization;
using MultiDesktop.Models;

namespace MultiDesktop.Services
{
    /// <summary>
    /// JSON 配置文件管理器
    /// </summary>
    public static class JsonConfigManager
    {
        private static readonly JavaScriptSerializer Serializer = new JavaScriptSerializer();
        private static readonly object LockObj = new object();

        /// <summary>从文件加载配置，不存在则返回初始配置</summary>
        public static DesktopConfigData Load(string filePath)
        {
            lock (LockObj)
            {
                try
                {
                    if (!File.Exists(filePath))
                        return DesktopConfigData.CreateDefault();

                    string json = File.ReadAllText(filePath, Encoding.UTF8);
                    if (string.IsNullOrWhiteSpace(json))
                        return DesktopConfigData.CreateDefault();

                    return Serializer.Deserialize<DesktopConfigData>(json)
                           ?? DesktopConfigData.CreateDefault();
                }
                catch
                {
                    return DesktopConfigData.CreateDefault();
                }
            }
        }

        /// <summary>保存配置到文件</summary>
        public static bool Save(string filePath, DesktopConfigData config)
        {
            lock (LockObj)
            {
                try
                {
                    string dir = Path.GetDirectoryName(filePath);
                    if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                        Directory.CreateDirectory(dir);

                    string json = Serializer.Serialize(config);
                    File.WriteAllText(filePath, json, Encoding.UTF8);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
