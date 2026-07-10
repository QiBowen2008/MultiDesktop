using System;
using System.Collections.Generic;

namespace MultiDesktop.Models
{
    /// <summary>
    /// 单个桌面的配置信息
    /// </summary>
    public class DesktopInfo
    {
        /// <summary>唯一标识</summary>
        public int Id { get; set; }

        /// <summary>桌面名称</summary>
        public string Name { get; set; }

        /// <summary>桌面文件夹路径</summary>
        public string Path { get; set; }

        /// <summary>是否为当前桌面（不可删除）</summary>
        public bool IsDefault { get; set; }

        /// <summary>获取实际桌面路径：当前桌面始终返回系统当前桌面路径</summary>
        public string GetEffectivePath()
        {
            if (IsDefault)
                return Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            return Path;
        }

        public DesktopInfo()
        {
            Id = 0;
            Name = "";
            Path = "";
            IsDefault = false;
        }

        /// <summary>创建当前桌面实例（路径不存 JSON，运行时动态读取）</summary>
        public static DesktopInfo CreateDefault()
        {
            return new DesktopInfo
            {
                Id = 0,
                Name = "当前桌面",
                Path = "",
                IsDefault = true
            };
        }

        /// <summary>创建新桌面实例</summary>
        public static DesktopInfo CreateNew(int id, string baseName = "新桌面")
        {
            return new DesktopInfo
            {
                Id = id,
                Name = baseName + id,
                Path = "",
                IsDefault = false
            };
        }

        public override string ToString()
        {
            return Name;
        }
    }

    /// <summary>
    /// 桌面配置文件根对象
    /// </summary>
    public class DesktopConfigData
    {
        /// <summary>是否首次运行</summary>
        public bool FirstRun { get; set; }

        /// <summary>所有桌面列表</summary>
        public List<DesktopInfo> Desktops { get; set; }

        public DesktopConfigData()
        {
            FirstRun = true;
            Desktops = new List<DesktopInfo>();
        }

        /// <summary>创建当前配置（首次运行）</summary>
        public static DesktopConfigData CreateDefault()
        {
            var config = new DesktopConfigData
            {
                FirstRun = true
            };
            config.Desktops.Add(DesktopInfo.CreateDefault());
            return config;
        }
    }
}
