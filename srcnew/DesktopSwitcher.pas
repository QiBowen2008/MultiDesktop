unit DesktopSwitcher;

{$mode objfpc}{$H+}

interface

uses
  Windows, Registry, Process, SysUtils, DesktopConfig;

// ===== 全局应用常量 (原 AppCommon) =====
var
  ConfigPath: string;

// ===== 全局状态 (原 AppState) =====
var
  CurrentConfig: TDesktopConfigData;
  SelectedDesktopIndex: Integer;

// ===== 桌面切换核心逻辑 (原 DesktopSwitcher) =====
type
  TDesktopSwitcher = class
  public
    /// 修改注册表切换桌面文件夹
    class procedure ChangeDesktopLocation(const NewPath: string);
    /// 重启 explorer.exe 使变更生效
    class procedure RestartExplorer;
    /// 执行完整的桌面切换操作
    class procedure SwitchToDesktop(const Path: string);
  end;

implementation

class procedure TDesktopSwitcher.ChangeDesktopLocation(const NewPath: string);
var
  Reg: TRegistry;
begin
  Reg := TRegistry.Create;
  try
    Reg.RootKey := HKEY_CURRENT_USER;

    // User Shell Folders
    if Reg.OpenKey(
      'Software\Microsoft\Windows\CurrentVersion\Explorer\User Shell Folders', True) then
    begin
      Reg.WriteExpandString('Desktop', NewPath);
      Reg.CloseKey;
    end;

    // Shell Folders
    if Reg.OpenKey(
      'Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders', True) then
    begin
      Reg.WriteExpandString('Desktop', NewPath);
      Reg.CloseKey;
    end;
  finally
    Reg.Free;
  end;
end;

class procedure TDesktopSwitcher.RestartExplorer;
var
  Proc: TProcess;
begin
  // 终止所有 explorer 进程
  Proc := TProcess.Create(nil);
  try
    Proc.Executable := 'taskkill';
    Proc.Parameters.Add('/f');
    Proc.Parameters.Add('/im');
    Proc.Parameters.Add('explorer.exe');
    Proc.Options := [poWaitOnExit, poNoConsole];
    Proc.Execute;
  finally
    Proc.Free;
  end;

  Sleep(1000);

  // 启动 explorer
  Proc := TProcess.Create(nil);
  try
    Proc.Executable := 'explorer.exe';
    Proc.Execute;
  finally
    Proc.Free;
  end;
end;

class procedure TDesktopSwitcher.SwitchToDesktop(const Path: string);
begin
  if Path <> '' then
    ChangeDesktopLocation(Path);
  RestartExplorer;
end;

initialization
  ConfigPath := ExtractFilePath(ParamStr(0)) + 'DesktopConfig.json';
  CurrentConfig := nil;
  SelectedDesktopIndex := -1;

finalization
  if CurrentConfig <> nil then
    CurrentConfig.Free;

end.
