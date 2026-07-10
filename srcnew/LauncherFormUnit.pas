unit LauncherFormUnit;

{$mode objfpc}{$H+}

interface

uses
  Windows, SysUtils, Forms, Controls, StdCtrls, ComCtrls, Dialogs,
  DesktopConfig, JsonConfigManager, DesktopSwitcher;

type
  TfrmLauncher = class(TForm)
    lvDesktops: TListView;
    btnSwitch: TButton;
    btnManage: TButton;
    lblTitle: TLabel;
    procedure FormCreate(Sender: TObject);
    procedure lvDesktopsDblClick(Sender: TObject);
    procedure btnSwitchClick(Sender: TObject);
    procedure btnManageClick(Sender: TObject);
  private
    procedure LoadConfig;
    procedure RefreshDesktopList;
    procedure SwitchToSelectedDesktop;
  end;

var
  frmLauncher: TfrmLauncher;

implementation

uses MainFormUnit;

{$R *.lfm}

procedure TfrmLauncher.FormCreate(Sender: TObject);
begin
  // 在 LoadConfig 之前配置全局状态
  LoadConfig;
  RefreshDesktopList;
end;

procedure TfrmLauncher.LoadConfig;
begin
  if CurrentConfig <> nil then
    CurrentConfig.Free;
  CurrentConfig := TJsonConfigManager.Load(ConfigPath);
end;

procedure TfrmLauncher.RefreshDesktopList;
var
  i: Integer;
  Desktop: TDesktopInfo;
  Item: TListItem;
begin
  lvDesktops.Items.Clear;

  if (CurrentConfig = nil) or (CurrentConfig.Desktops.Count = 0) then
    Exit;

  for i := 0 to CurrentConfig.Desktops.Count - 1 do
  begin
    Desktop := CurrentConfig.Desktops[i];
    Item := lvDesktops.Items.Add;
    Item.Caption := Desktop.Name;
    Item.SubItems.Add(Desktop.GetEffectivePath);
    Item.Data := Desktop;
  end;

  if lvDesktops.Items.Count > 0 then
    lvDesktops.Items[0].Selected := True;
end;

procedure TfrmLauncher.lvDesktopsDblClick(Sender: TObject);
begin
  SwitchToSelectedDesktop;
end;

procedure TfrmLauncher.btnSwitchClick(Sender: TObject);
begin
  SwitchToSelectedDesktop;
end;

procedure TfrmLauncher.SwitchToSelectedDesktop;
var
  Desktop: TDesktopInfo;
begin
  if lvDesktops.Selected = nil then
  begin
    MessageDlg('请先选择一个桌面。', mtInformation, [mbOK], 0);
    Exit;
  end;

  Desktop := TDesktopInfo(lvDesktops.Selected.Data);
  if Desktop = nil then Exit;

  try
    TDesktopSwitcher.SwitchToDesktop(Desktop.GetEffectivePath);
    Application.Terminate;
  except
    on E: Exception do
      MessageDlg('切换桌面失败：' + E.Message, mtError, [mbOK], 0);
  end;
end;

procedure TfrmLauncher.btnManageClick(Sender: TObject);
var
  Frm: TfrmMain;
begin
  Self.Hide;
  Frm := TfrmMain.Create(Self);
  try
    Frm.ShowModal;
  finally
    Frm.Free;
  end;
  Self.Show;

  // 重新加载配置
  LoadConfig;
  RefreshDesktopList;
end;

end.
