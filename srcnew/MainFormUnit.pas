unit MainFormUnit;

{$mode objfpc}{$H+}

interface

uses
  SysUtils, Forms, Controls, StdCtrls, ComCtrls, Dialogs, ExtCtrls,
  DesktopConfig, JsonConfigManager, DesktopSwitcher, Math, Classes;

type

  { TfrmMain }

  TfrmMain = class(TForm)
    pnlBottom: TPanel;
    btnAddDesktop: TButton;
    btnDeleteCurrent: TButton;
    btnClose: TButton;
    pnlLeft: TPanel;
    lvDesktops: TListView;
    Splitter1: TSplitter;
    pnlRight: TPanel;
    grpDetail: TGroupBox;
    lblName: TLabel;
    txtName: TEdit;
    lblPath: TLabel;
    txtPath: TEdit;
    btnBrowsePath: TButton;
    btnSaveDetail: TButton;
    btnDelete: TButton;
    SelectDirectoryDialog1: TSelectDirectoryDialog;
    procedure FormCreate(Sender: TObject);
    procedure lvDesktopsResize(Sender: TObject);
    procedure lvDesktopsSelectItem(Sender: TObject; Item: TListItem; Selected: Boolean);
    procedure grpDetailResize(Sender: TObject);
    procedure pnlBottomClick(Sender: TObject);
    procedure txtNameChange(Sender: TObject);
    procedure btnBrowsePathClick(Sender: TObject);
    procedure btnSaveDetailClick(Sender: TObject);
    procedure btnDeleteClick(Sender: TObject);
    procedure btnAddDesktopClick(Sender: TObject);
    procedure btnDeleteCurrentClick(Sender: TObject);
    procedure btnCloseClick(Sender: TObject);
  private
    FConfig: TDesktopConfigData;
    FSelectedDesktop: TDesktopInfo;
    FIsUpdating: Boolean;

    procedure RefreshDesktopList;
    procedure AutoFitListViewColumns;
    procedure PopulateDetailPanel;
    procedure ClearDetailPanel;
    procedure SyncSelectedItem;
    function ValidateInput: Boolean;
  end;

var
  frmMain: TfrmMain;

implementation

{$R *.lfm}

// ===== 初始化 =====

procedure TfrmMain.FormCreate(Sender: TObject);
begin
  // 使用已有的全局配置，否则加载
  if CurrentConfig <> nil then
    FConfig := CurrentConfig
  else
    FConfig := TJsonConfigManager.Load(ConfigPath);

  RefreshDesktopList;
end;

// ===== 列表管理 =====

procedure TfrmMain.RefreshDesktopList;
var
  i: Integer;
  Desktop: TDesktopInfo;
  Item: TListItem;
begin
  FIsUpdating := True;
  lvDesktops.Items.Clear;

  if (FConfig = nil) or (FConfig.Desktops.Count = 0) then
  begin
    FIsUpdating := False;
    Exit;
  end;

  for i := 0 to FConfig.Desktops.Count - 1 do
  begin
    Desktop := FConfig.Desktops[i];
    Item := lvDesktops.Items.Add;
    Item.Caption := Desktop.Name;
    Item.SubItems.Add(Desktop.GetEffectivePath);
    Item.Data := Desktop;
  end;

  if lvDesktops.Items.Count > 0 then
    lvDesktops.Items[0].Selected := True;

  FIsUpdating := False;
  AutoFitListViewColumns;
end;

procedure TfrmMain.lvDesktopsResize(Sender: TObject);
begin
  AutoFitListViewColumns;
end;

procedure TfrmMain.AutoFitListViewColumns;
var
  w: Integer;
begin
  if lvDesktops.Columns.Count < 2 then Exit;
  w := lvDesktops.ClientWidth - 4;
  if w < 100 then Exit;
  lvDesktops.Columns[0].Width := (w * 40) div 100;
  lvDesktops.Columns[1].Width := (w * 60) div 100;
end;

procedure TfrmMain.lvDesktopsSelectItem(Sender: TObject; Item: TListItem; Selected: Boolean);
begin
  if FIsUpdating then Exit;
  if not Selected then
  begin
    FSelectedDesktop := nil;
    ClearDetailPanel;
    Exit;
  end;

  FSelectedDesktop := TDesktopInfo(Item.Data);
  PopulateDetailPanel;
end;

// ===== 详情面板 =====

procedure TfrmMain.grpDetailResize(Sender: TObject);
const
  Margin = 27;    // 18 at 144 PPI (150% scaling)
  BtnWidth = 63;  // 42 at 144 PPI
  Gap = 12;       //  8 at 144 PPI
var
  w: Integer;
begin
  w := grpDetail.ClientWidth;
  if w < 100 then Exit;

  txtName.Width := w - Margin * 2;
  btnBrowsePath.Left := w - Margin - BtnWidth;
  txtPath.Width := btnBrowsePath.Left - txtPath.Left - Gap;
end;

procedure TfrmMain.pnlBottomClick(Sender: TObject);
begin

end;

procedure TfrmMain.PopulateDetailPanel;
begin
  if FSelectedDesktop = nil then Exit;

  FIsUpdating := True;
  txtName.Text := FSelectedDesktop.Name;
  txtPath.Text := FSelectedDesktop.GetEffectivePath;

  txtName.Enabled := not FSelectedDesktop.IsDefault;
  txtPath.Enabled := not FSelectedDesktop.IsDefault;
  btnBrowsePath.Enabled := not FSelectedDesktop.IsDefault;
  btnDelete.Enabled := not FSelectedDesktop.IsDefault;
  FIsUpdating := False;
end;

procedure TfrmMain.ClearDetailPanel;
begin
  FIsUpdating := True;
  txtName.Text := '';
  txtPath.Text := '';
  txtName.Enabled := False;
  txtPath.Enabled := False;
  btnBrowsePath.Enabled := False;
  btnDelete.Enabled := False;
  FIsUpdating := False;
end;

procedure TfrmMain.txtNameChange(Sender: TObject);
begin
  if FIsUpdating or (FSelectedDesktop = nil) then Exit;
  if lvDesktops.Selected <> nil then
    lvDesktops.Selected.Caption := txtName.Text;
end;

procedure TfrmMain.btnBrowsePathClick(Sender: TObject);
begin
  if SelectDirectoryDialog1.Execute then
  begin
    txtPath.Text := SelectDirectoryDialog1.FileName;
    if (FSelectedDesktop <> nil) and (lvDesktops.Selected <> nil) then
      lvDesktops.Selected.SubItems[0] := txtPath.Text;
  end;
end;

// ===== 验证 =====

function TfrmMain.ValidateInput: Boolean;
var
  Path: string;
begin
  if FSelectedDesktop = nil then
  begin
    MessageDlg('请先选择一个桌面。', mtInformation, [mbOK], 0);
    Exit(False);
  end;

  if Trim(txtName.Text) = '' then
  begin
    MessageDlg('桌面名称不能为空。', mtWarning, [mbOK], 0);
    if txtName.CanFocus then
      txtName.SetFocus;
    Exit(False);
  end;

  if not FSelectedDesktop.IsDefault then
  begin
    Path := Trim(txtPath.Text);
    if Path = '' then
    begin
      MessageDlg('桌面路径不能为空，请选择桌面文件夹。', mtWarning, [mbOK], 0);
      if txtPath.CanFocus then
        txtPath.SetFocus;
      Exit(False);
    end;
    if not DirectoryExists(Path) then
    begin
      MessageDlg('桌面路径 "' + Path + '" 不存在，请重新选择。', mtWarning, [mbOK], 0);
      if txtPath.CanFocus then
        txtPath.SetFocus;
      Exit(False);
    end;
  end;

  Result := True;
end;

// ===== 操作按钮 =====

procedure TfrmMain.btnSaveDetailClick(Sender: TObject);
begin
  if not ValidateInput then Exit;

  FSelectedDesktop.Name := Trim(txtName.Text);
  if not FSelectedDesktop.IsDefault then
    FSelectedDesktop.Path := Trim(txtPath.Text);

  if TJsonConfigManager.Save(ConfigPath, FConfig) then
  begin
    if lvDesktops.Selected <> nil then
    begin
      lvDesktops.Selected.Caption := FSelectedDesktop.Name;
      lvDesktops.Selected.SubItems[0] := FSelectedDesktop.GetEffectivePath;
    end;
    MessageDlg('保存成功。', mtInformation, [mbOK], 0);
  end
  else
    MessageDlg('保存失败，请检查文件权限。', mtError, [mbOK], 0);
end;

procedure TfrmMain.btnDeleteClick(Sender: TObject);
begin
  if FSelectedDesktop = nil then Exit;

  if FSelectedDesktop.IsDefault then
  begin
    MessageDlg('初始桌面不可删除。', mtWarning, [mbOK], 0);
    Exit;
  end;

  if MessageDlg(
    '确定要删除桌面 "' + FSelectedDesktop.Name + '" 吗？此操作不可恢复。',
    mtWarning, mbYesNo, 0) <> mrYes then
    Exit;

  FConfig.Desktops.Remove(FSelectedDesktop);
  // 重新整理 ID
  SyncSelectedItem;

  TJsonConfigManager.Save(ConfigPath, FConfig);
  FSelectedDesktop := nil;
  RefreshDesktopList;
end;

procedure TfrmMain.SyncSelectedItem;
var
  i: Integer;
begin
  for i := 0 to FConfig.Desktops.Count - 1 do
    FConfig.Desktops[i].Id := i;
end;

procedure TfrmMain.btnAddDesktopClick(Sender: TObject);
var
  NextId, Counter: Integer;
  BaseName, NewName: string;
  i: Integer;
  NewDesktop: TDesktopInfo;
  Item: TListItem;
  Duplicate: Boolean;
begin
  BaseName := '新桌面';
  if FConfig.Desktops.Count > 0 then
    NextId := FConfig.Desktops[FConfig.Desktops.Count - 1].Id + 1
  else
    NextId := 1;

  NewName := BaseName + '_' + IntToStr(NextId);
  Counter := 1;
  repeat
    Duplicate := False;
    for i := 0 to FConfig.Desktops.Count - 1 do
      if FConfig.Desktops[i].Name = NewName then
      begin
        Duplicate := True;
        Inc(Counter);
        NewName := BaseName + '_' + IntToStr(Counter);
        Break;
      end;
  until not Duplicate;

  NewDesktop := TDesktopInfo.Create;
  NewDesktop.Id := NextId;
  NewDesktop.Name := NewName;
  NewDesktop.Path := GetEnvironmentVariable('USERPROFILE') + '\Desktop';
  NewDesktop.IsDefault := False;

  FConfig.Desktops.Add(NewDesktop);
  FConfig.FirstRun := False;
  TJsonConfigManager.Save(ConfigPath, FConfig);

  Item := lvDesktops.Items.Add;
  Item.Caption := NewDesktop.Name;
  Item.SubItems.Add(NewDesktop.Path);
  Item.Data := NewDesktop;

  Item.Selected := True;
  Item.MakeVisible(False);
end;

procedure TfrmMain.btnDeleteCurrentClick(Sender: TObject);
begin
  if FSelectedDesktop = nil then
  begin
    MessageDlg('请先在左侧列表中选择一个桌面。', mtInformation, [mbOK], 0);
    Exit;
  end;

  if FSelectedDesktop.IsDefault then
  begin
    MessageDlg('初始桌面不可删除。', mtWarning, [mbOK], 0);
    Exit;
  end;

  if MessageDlg(
    '确定要删除桌面 "' + FSelectedDesktop.Name + '" 吗？此操作不可恢复。',
    mtWarning, mbYesNo, 0) <> mrYes then
    Exit;

  FConfig.Desktops.Remove(FSelectedDesktop);
  SyncSelectedItem;

  TJsonConfigManager.Save(ConfigPath, FConfig);
  FSelectedDesktop := nil;
  RefreshDesktopList;
end;

procedure TfrmMain.btnCloseClick(Sender: TObject);
begin
  ModalResult := mrOK;
end;

end.
