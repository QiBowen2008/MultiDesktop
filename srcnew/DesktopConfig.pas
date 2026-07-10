unit DesktopConfig;

{$mode objfpc}{$H+}

interface

uses
  SysUtils, fgl;

type
  TDesktopInfo = class
  private
    FId: Integer;
    FName: string;
    FPath: string;
    FIsDefault: Boolean;
  public
    constructor Create; overload;
    /// 创建"当前桌面"实例（不可删除，路径运行时动态获取）
    constructor CreateDefault;
    /// 创建新桌面实例
    constructor CreateNew(AId: Integer; const ABaseName: string = '新桌面');
    /// 获取实际桌面路径：默认桌面返回系统桌面路径
    function GetEffectivePath: string;
    function ToString: string; override;
    property Id: Integer read FId write FId;
    property Name: string read FName write FName;
    property Path: string read FPath write FPath;
    property IsDefault: Boolean read FIsDefault write FIsDefault;
  end;

  TDesktopInfoList = specialize TFPGObjectList<TDesktopInfo>;

  TDesktopConfigData = class
  private
    FFirstRun: Boolean;
    FDesktops: TDesktopInfoList;
  public
    constructor Create; overload;
    /// 创建初始配置（含一个"当前桌面"）
    constructor CreateDefault;
    destructor Destroy; override;
    property FirstRun: Boolean read FFirstRun write FFirstRun;
    property Desktops: TDesktopInfoList read FDesktops;
  end;

implementation

// ===== TDesktopInfo =====

constructor TDesktopInfo.Create;
begin
  inherited;
  FId := 0;
  FName := '';
  FPath := '';
  FIsDefault := False;
end;

constructor TDesktopInfo.CreateDefault;
begin
  Create;
  FId := 0;
  FName := '当前桌面';
  FPath := '';
  FIsDefault := True;
end;

constructor TDesktopInfo.CreateNew(AId: Integer; const ABaseName: string);
begin
  Create;
  FId := AId;
  FName := ABaseName + IntToStr(AId);
  FPath := '';
  FIsDefault := False;
end;

function TDesktopInfo.GetEffectivePath: string;
begin
  if FIsDefault then
    Result := GetEnvironmentVariable('USERPROFILE') + '\Desktop'
  else
    Result := FPath;
end;

function TDesktopInfo.ToString: string;
begin
  Result := FName;
end;

// ===== TDesktopConfigData =====

constructor TDesktopConfigData.Create;
begin
  inherited;
  FFirstRun := True;
  FDesktops := TDesktopInfoList.Create(True);  // OwnsObjects = True
end;

constructor TDesktopConfigData.CreateDefault;
begin
  Create;
  FFirstRun := True;
  FDesktops.Add(TDesktopInfo.CreateDefault);
end;

destructor TDesktopConfigData.Destroy;
begin
  FDesktops.Free;
  inherited;
end;

end.
