unit JsonConfigManager;

{$mode objfpc}{$H+}

interface

uses
  SysUtils, Classes, fpjson, jsonparser, DesktopConfig;

type
  TJsonConfigManager = class
  private
    class var FLock: TRTLCriticalSection;
    class constructor Create;
    class destructor Destroy;
  public
    /// 从文件加载配置，不存在则返回初始配置
    class function Load(const FilePath: string): TDesktopConfigData;
    /// 保存配置到文件，成功返回 True
    class function Save(const FilePath: string; Config: TDesktopConfigData): Boolean;
  end;

implementation

class constructor TJsonConfigManager.Create;
begin
  InitCriticalSection(FLock);
end;

class destructor TJsonConfigManager.Destroy;
begin
  DoneCriticalSection(FLock);
end;

class function TJsonConfigManager.Load(const FilePath: string): TDesktopConfigData;
var
  JsonText: TStringList;
  JsonData: TJSONData;
  JsonObj: TJSONObject;
  JsonArr: TJSONArray;
  i: Integer;
  ItemObj: TJSONObject;
  Desktop: TDesktopInfo;
begin
  EnterCriticalSection(FLock);
  try
    if not FileExists(FilePath) then
    begin
      Result := TDesktopConfigData.CreateDefault;
      Exit;
    end;

    JsonText := TStringList.Create;
    try
      JsonText.LoadFromFile(FilePath);
      if Trim(JsonText.Text) = '' then
      begin
        Result := TDesktopConfigData.CreateDefault;
        Exit;
      end;

      JsonData := GetJSON(JsonText.Text);
      try
        Result := TDesktopConfigData.Create;
        if JsonData.JSONType = jtObject then
        begin
          JsonObj := TJSONObject(JsonData);
          Result.FirstRun := JsonObj.Get('FirstRun', True);

          if JsonObj.Find('Desktops', JsonArr) and (JsonArr.JSONType = jtArray) then
          begin
            for i := 0 to JsonArr.Count - 1 do
            begin
              if JsonArr.Items[i].JSONType <> jtObject then
                Continue;
              ItemObj := TJSONObject(JsonArr.Items[i]);
              Desktop := TDesktopInfo.Create;
              Desktop.Id       := ItemObj.Get('Id', 0);
              Desktop.Name     := ItemObj.Get('Name', '');
              Desktop.Path     := ItemObj.Get('Path', '');
              Desktop.IsDefault := ItemObj.Get('IsDefault', False);
              Result.Desktops.Add(Desktop);
            end;
          end;
        end;
      finally
        JsonData.Free;
      end;
    finally
      JsonText.Free;
    end;
  finally
    LeaveCriticalSection(FLock);
  end;
end;

class function TJsonConfigManager.Save(const FilePath: string;
  Config: TDesktopConfigData): Boolean;
var
  JsonObj: TJSONObject;
  JsonArr: TJSONArray;
  i: Integer;
  Desktop: TDesktopInfo;
  ItemObj: TJSONObject;
  JsonText: TStringList;
  Dir: string;
begin
  Result := False;
  if Config = nil then Exit;

  EnterCriticalSection(FLock);
  try
    Dir := ExtractFileDir(FilePath);
    if (Dir <> '') and (not DirectoryExists(Dir)) then
      ForceDirectories(Dir);

    JsonObj := TJSONObject.Create;
    try
      JsonObj.Add('FirstRun', Config.FirstRun);

      JsonArr := TJSONArray.Create;
      for i := 0 to Config.Desktops.Count - 1 do
      begin
        Desktop := Config.Desktops[i];
        ItemObj := TJSONObject.Create;
        ItemObj.Add('Id', Desktop.Id);
        ItemObj.Add('Name', Desktop.Name);
        ItemObj.Add('Path', Desktop.Path);
        ItemObj.Add('IsDefault', Desktop.IsDefault);
        JsonArr.Add(ItemObj);
      end;
      JsonObj.Add('Desktops', JsonArr);

      JsonText := TStringList.Create;
      try
        JsonText.Text := JsonObj.FormatJSON();
        JsonText.SaveToFile(FilePath);
        Result := True;
      finally
        JsonText.Free;
      end;
    finally
      JsonObj.Free;
    end;
  finally
    LeaveCriticalSection(FLock);
  end;
end;

end.
