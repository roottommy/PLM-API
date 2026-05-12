# PLM_API

專案概述
- PLM_API 為以 .NET 9 建置的後端 API，目標是從 PLM（Aras Innovator）擷取文件、品號等資料，轉換為檢驗基礎資料並寫入 MongoDB，供 SPC/檢驗系統或前端查詢使用。
- 核心範例：Services/InspectionBaseService.cs（處理 PLM 登入、解析工作流程與文件，組成檢查項目 JSON 並寫入 MongoDB）。

關鍵技術
- 平台：.NET 9
- PLM：Aras Innovator (Aras.IOM)
- 資料庫：MongoDB（MongoDB.Driver、MongoDB.Bson）、MSSQL（System.Data.SqlClient）
- 序列化 / 解析：Newtonsoft.Json、System.Xml
- DI / Options：Microsoft.Extensions.DependencyInjection、Microsoft.Extensions.Options
- 日誌：ILogger（建議結構化日誌）
- 測試：xUnit / Moq（建議加入）

專案結構（樹狀圖）
- 下面樹狀圖以專案主要資料夾與範例檔案為主，方便快速導覽實體位置與責任範圍。

PLM_API.sln
├── ApiServer/                      ← .NET 9 Web API（Controllers、Program.cs）
│   ├── Controllers/
│   │   └── InspectionController.cs
│   ├── Program.cs
│   ├── appsettings.json
│   └── SwaggerConfig.cs
├── Services/                       ← 業務邏輯（InspectionBaseService 等）
│   ├── InspectionBaseService.cs
│   ├── IInspectionService.cs
│   └── Mappers/
│       └── InspectionMapper.cs
├── Repositories/                   ← MSSql 與 Mongo 的資料存取封裝
│   ├── IPlmRepository.cs
│   ├── PlmRepository.cs
│   ├── IMongoRepository.cs
│   └── MongoRepository.cs
├── Infrastructure/                 ← Mongo 初始化、共用擴充
│   ├── MongoClientFactory.cs
│   └── Extensions/
│       └── ServiceCollectionExtensions.cs
├── PLM/Models/                     ← 與 PLM 互動的 DTO / Model
│   ├── PlmDocument.cs
│   └── PlmWorkflow.cs
├── Utilities/                      ← 共用工具、擴充方法
│   ├── XmlHelper.cs
│   └── JsonHelper.cs
├── Tests/                          ← 單元測試專案（xUnit）
│   └── PLM_API.Tests.csproj
├── docs/                           ← 文件（可選）
│   └── architecture.md
└── README.md

主要功能
- 透過 Aras Innovator（PLM）物件實作讀寫PLM等資料。
- 將 PLM XML 與屬性解析成檢查項目（checkItems），並組成 BSON Document 寫入 MongoDB（包含 createdAt/updatedAt 處理）、MSSQL。
- 提供 API 端點（Controllers）以觸發同步或查詢（視專案實作）。

環境需求
- .NET 9 SDK
- Visual Studio 2022 或等效 IDE
- MongoDB server（本機或遠端）
- 可存取的 Aras Innovator 帳號與權限

建置與執行
- Visual Studio
  1. 開啟 solution。
  2. 設定啟動專案，執行 __Build > Rebuild Solution__。
  3. 啟動除錯或執行（F5）。
- dotnet CLI
  - 還原：dotnet restore
  - 建置：dotnet build
  - 執行：dotnet run --project <PathToProject>.csproj

安全與密碼管理
- 開發建議使用 __dotnet user-secrets__ 管理開發時的敏感設定，生產環境請使用環境變數或金鑰庫（例如 Azure Key Vault）。
- PLM 密碼範例程式會做 MD5 雜湊（Innovator.ScalcMD5），實際部署仍應避免在 repo 中放置明文密碼。

故障排查（常見問題）
- PLM 連線失敗：確認 PLMServer、PLMDB、PLMUser 與密碼正確，且主機能存取 PLM 伺服器。
- Mongo 寫入失敗：檢查 ConnectionString、Database 權限、網路連線與防火牆。
- 欄位或 XML 解析錯誤：檢查 PLM 回傳 XML 結構與服務中解析邏輯（Services/InspectionBaseService.cs）。


開發建議
- 使用 Repository + Service pattern 保持關心分離。
- 在 Service 中加強例外與日誌紀錄，避免吞掉錯誤（方便除錯）。
- 測試環境建議建立 mock 的 Aras / Mongo 測試資料，或使用相容測試替代。
- 使用非同步 API 與 CancellationToken。
- 統一錯誤格式：加入 ExceptionHandlingMiddleware 回傳結構化 JSON。
- 明確 DI 生命週期（Singleton / Scoped / Transient）。
- 使用 DTO / record 回傳，避免直接回傳資料庫實體。
- 開啟 nullable reference types 與 __Analyze > Run Code Analysis__，提升穩定度。

版本
- v1.0.0 - 初始版本（生成於 README）
