@echo off
rem ============================================================
rem  MultiDesktop 安装包一键构建脚本
rem  1) dotnet publish AOT (Release / win-x64 / self-contained)
rem  2) makensis 生成 exe 安装包
rem ============================================================
setlocal

set "ROOT=%~dp0.."
set "NSIS=D:\program\Nsis\makensis.exe"
set "RID=win-x64"
set "CONFIG=Release"
set "PUBLISH_DIR=%ROOT%\src\MultiDesktop\bin\Release\net10.0-windows\%RID%\publish"

rem AOT 编译需要 vswhere.exe 定位 VS 工具链，把它所在目录加入 PATH
if exist "%ProgramFiles(x86)%\Microsoft Visual Studio\Installer" (
    set "PATH=%ProgramFiles(x86)%\Microsoft Visual Studio\Installer;%PATH%"
)

echo [1/2] dotnet publish (AOT, %CONFIG%, %RID%) ...
dotnet publish "%ROOT%\src\MultiDesktop\MultiDesktop.AOT.csproj" -c %CONFIG% -r %RID% --self-contained true -o "%PUBLISH_DIR%"
if errorlevel 1 (
    echo 发布失败，请检查 AOT 编译环境（需要 VS C++ 工具链）。
    exit /b 1
)

if not exist "%PUBLISH_DIR%\MultiDesktop.AOT.exe" (
    echo 未找到发布产物: %PUBLISH_DIR%\MultiDesktop.AOT.exe
    exit /b 1
)

echo [2/2] 构建 NSIS 安装包 ...
"%NSIS%" /DPUBLISH_DIR="%PUBLISH_DIR%" "%~dp0build_installer.nsi"
if errorlevel 1 (
    echo NSIS 构建失败。
    exit /b 1
)

echo.
echo 安装包已生成: %~dp0MultiDesktop-Setup-*.exe
endlocal
