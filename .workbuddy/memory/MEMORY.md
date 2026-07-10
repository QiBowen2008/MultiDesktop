# MultiDesktop 项目约定

## 技术栈
- C# / .NET Framework 4.0 / WinForms
- JSON 配置存储（DesktopConfig.json）
- 管理窗口使用标准 WinForms 控件（不再依赖 SunnyUI）

## 窗口架构
- **frmLauncher**：启动窗口，桌面选择 + 快速切换
- **frmMain**：管理窗口，ListView + 属性面板的 CRUD 界面

## 核心类
- `DesktopSwitcher`：注册表修改 + explorer 重启，两个窗口共用
- `JsonConfigManager`：JSON 读写 + 旧 INI 自动迁移
- `AppState.Config`：跨窗口共享配置
