# C-PinballDemo

## プロジェクトの作成

- dotnet new wpf -n MyWpfApp
- dotnet build
- dotnet run

## ビルド

- dotnet publish -c Release -r win-x64 --self-contained true
  | オプション | 意味 |
  | ----------------------- | ----------------- |
  | `-c Release` | 本番用ビルド |
  | `-r win-x64` | Windows 64bit |
  | `--self-contained true` | .NET 未インストール PC でも動く |

ProjectName/bin/Release/net10.0-windows/win-x64/publish/ProjectName.exe で作成される。
