# MultiDesktop 项目长期备忘

## 项目约定
- 所有配置文件（AppSettings.xml / DesktopList.xml）必须通过 `AppPaths` 类访问（exe 目录，失败回退 %AppData%\MultiDesktop）。**禁止 CWD 相对路径**——winget/快捷方式场景 CWD 不可控。
- 资源文件（如图标）用 `AppContext.BaseDirectory` 定位。
- 退出用 `Environment.Exit(0)`，不要用 `Process.Kill()`（退出码 -1 会被 winget 验证判失败）。
- 发布：`dotnet publish src/MultiDesktop/MultiDesktop.AOT.csproj -c Release -r win-x86`（NativeAOT）。

## 关键经验
- NativeAOT 程序崩溃码 0xC0000409 ≠ 栈溢出，是**未处理托管异常 fail-fast**。复现方法：换 CWD/降权限运行。
- winget 云端验证（Windows Sandbox）会运行 portable exe，CWD 不可写；验证环境触发过的崩溃可用只读目录本地复现。
- winget 包标识：Buger.MultiDesktop；重新构建后必须更新清单 InstallerSha256。
