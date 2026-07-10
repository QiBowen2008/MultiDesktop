program MultiDesktop;

{$mode objfpc}{$H+}

uses
  {$IFDEF UNIX}
  cthreads,
  {$ENDIF}
  Interfaces,  // Lazarus 组件接口
  Forms,
  DesktopConfig in 'DesktopConfig.pas',
  JsonConfigManager in 'JsonConfigManager.pas',
  DesktopSwitcher in 'DesktopSwitcher.pas',
  LauncherFormUnit in 'LauncherFormUnit.pas' {frmLauncher},
  MainFormUnit in 'MainFormUnit.pas' {frmMain};

{$R *.res}

begin
  RequireDerivedFormResource := True;
  Application.Scaled := True;
  {$PUSH}{$WARN 5044 OFF}
  Application.MainFormOnTaskbar := True;
  {$POP}
  Application.Title := 'MultiDesktop';
  Application.Initialize;
  Application.CreateForm(TfrmLauncher, frmLauncher);
  Application.Run;
end.
