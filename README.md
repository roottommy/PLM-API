# PLM_API

PLM 系統整合 API，負責 **Aras Innovator PLM 系統**與 **ERP 系統（鼎新）** 之間的資料同步、品號作廢流程自動化，以及將檢驗基準書資料寫入 MongoDB 供 SPC 分析使用。

---

## 目錄

- [系統架構](#系統架構)
- [技術堆疊](#技術堆疊)
- [專案目錄結構](#專案目錄結構)
- [資料庫說明](#資料庫說明)
- [API 端點](#api-端點)
- [資料流說明](#資料流說明)
- [環境設定](#環境設定)
- [本機開發啟動](#本機開發啟動)
- [日誌機制](#日誌機制)

---

## 系統架構

┌─────────────────────┐
│   Aras Innovator    │  PLM 系統（品號維護、工作流程審查）
│   (PLM System)      │
└────────┬────────────┘
         │ HTTP (IOM API)
         ▼
┌─────────────────────┐
│     PLM_API         │  本專案：ASP.NET Core Web API
│  (ASP.NET Core 9)   │
└────┬───────┬────────┘
     │       │
     ▼       ▼
┌─────────┐ ┌──────────────────┐
│  ERP DB │ │    MongoDB       │
│ (鼎新)  │ │  (SPC 檢驗資料)  │
│ MS SQL  │ └──────────────────┘
└─────────┘

### 三層式架構

Controller 層   →   Service 層   →   Repository 層   →   Database
（接收 HTTP 請求）  （業務邏輯）     （資料存取）         （MSSQL / MongoDB）

---

## 技術堆疊

| 類別 | 套件 / 版本 |
|------|------------|
| 框架 | .NET 9 / ASP.NET Core Web API |
| ORM | Entity Framework Core 9.0.10 |
| 資料庫驅動 | Microsoft.EntityFrameworkCore.SqlServer 9.0.10 |
| NoSQL 驅動 | MongoDB.Driver 3.5.0 |
| PLM 整合 | Aras.IOM 15.0.1 |
| 日誌框架 | Serilog 4.3.1 + Serilog.AspNetCore 10.0.0 |
| API 文件 | Swashbuckle.AspNetCore 6.6.2 (Swagger) |

---

## 專案目錄結構

PLM_API/
├── Controllers/                    # API 控制器
│   ├── PartController.cs           # 品號相關 API
│   ├── InspectionBaseController.cs # 檢驗基準書相關 API
│   └── ERPBaseController.cs        # ERP 基礎資料查詢 API
│
├── Services/                       # 業務邏輯層
│   ├── IPartService.cs
│   ├── PartService.cs              # 品號查詢、作廢流程
│   ├── IInspectionBaseService.cs
│   ├── InspectionBaseService.cs    # 檢驗基準書寫入 MongoDB
│   ├── IERPBaseService.cs
│   ├── ERPBaseService.cs           # ERP 品號類別、庫別查詢
│   ├── IAppLogService.cs
│   ├── AppLogService.cs            # DB Log 寫入服務
│   └── CodeService.cs              # 品號狀態代碼解析
│
├── PLM/
│   ├── Models/
│   │   ├── ERP/                    # ERP 資料表 Entity（INVMB、INVTL、INVTM…）
│   │   ├── LogDB/                  # Log 資料表 Entity（PLMApiTrace）
│   │   ├── Mongo/                  # MongoDB 相關 Model
│   │   ├── SPCAn/                  # SPC 分析資料 Model
│   │   ├── DTOs/                   # 資料傳輸物件（ItemChangeOrderDto…）
│   │   ├── ServiceResult.cs        # 統一 API 回傳結果
│   │   └── CommonEnums.cs          # 共用列舉定義
│   └── Repositories/               # 資料存取層
│       ├── IPartRepository.cs
│       ├── PartRepository.cs       # ERP 品號資料存取
│       ├── IInspectionBaseRepository.cs
│       ├── InspectionBaseRepository.cs
│       ├── IERPBaseRepository.cs
│       └── ERPBaseRepository.cs
│
├── Infrastructure/
│   ├── MSSql/                      # EF Core DbContext
│   │   ├── AppERPDbContext.cs       # ERP 主資料庫
│   │   ├── AppERPSysDbContext.cs    # ERP 系統資料庫
│   │   ├── AppSPCDbContext.cs       # SPC 分析資料庫
│   │   ├── AppModelDbContext.cs     # Model 資料庫
│   │   └── AppLogDbContext.cs       # Log 資料庫
│   └── Mongo/                      # MongoDB 基礎設施
│       ├── IMongoDbContext.cs
│       ├── MongoDbContext.cs
│       ├── IMongoRepository.cs
│       ├── MongoRepository.cs
│       └── MongoSettings.cs
│
├── Extensions/
│   └── ServiceCollectionExtensions.cs  # DI 擴充方法（AddMongo）
│
├── Utilities/
│   └── AppSettings.cs              # PLM 連線設定模型
│
├── appsettings.json                # 設定檔（連線字串留空）
├── appsettings.Development.json    # ⚠️ 已列入 .gitignore，請勿提交
├── Program.cs                      # 應用程式進入點 / DI 註冊
└── PLM_API.csproj

---

## 資料庫說明

| 連線字串名稱 | 對應資料庫 | 用途 |
|---|---|---|
| `DefaultConnection` | GizmoPLM (MSSQL) | PLM 主資料庫 |
| `ERPConnection` | GIZMO (MSSQL) | ERP 品號、庫別、變更單 |
| `ERPSysConnection` | DSCSYS (MSSQL) | ERP 系統資料 |
| `SPCConnection` | SPCAn_Gizmo (MSSQL) | SPC 分析圖片路徑 |
| `ModelConnection` | GMODEL (MSSQL) | 模型資料庫 |
| `GizmoLogConnection` | GizmoLogDB (MSSQL) | API 執行日誌（PLMApiTrace） |
| `Mongo.ConnectionString` | GizmoQCP (MongoDB) | 檢驗基準書 JSON 資料 |

### 主要 ERP 資料表

| 資料表 | 說明 |
|---|---|
| `INVMB` | 品號基本資料 |
| `INVMA` | 品號類別資料 |
| `INVTL` | 品號變更單單頭 |
| `INVTM` | 品號變更單單身 |
| `CMSMC` | 庫別資料 |

### Log 資料表

`GizmoLogDB.dbo.PLMApiTrace`

| 欄位 | 說明 |
|---|---|
| `LogID` | 流水號（自動產生） |
| `TraceID` | 每次 API 呼叫的唯一追蹤 ID（GUID） |
| `MethodName` | 呼叫的 API 方法名稱 |
| `StepName` | 目前執行步驟 |
| `Status` | `Start` / `Info` / `Error` / `Success` |
| `InputData` | 輸入參數 |
| `OutputData` | 輸出結果 |
| `Message` | 訊息或錯誤說明 |
| `ExecutionMs` | 執行毫秒數 |
| `CreatedAt` | 寫入時間 |

---

## API 端點

### Part（品號）

| 方法 | 路由 | 說明 |
|---|---|---|
| `POST` | `/api/Part/GetMappedPartData` | 查詢品號對應的 QC 對應品號 |
| `POST` | `/api/Part/PartObsoleteController` | PLM 觸發品號作廢，建立 ERP 品號變更單 |
| `POST` | `/api/Part/ERPObsoleteController` | ERP 直接觸發品號變更單建立 |

### InspectionBase（檢驗基準書）

| 方法 | 路由 | 說明 |
|---|---|---|
| `POST` | `/api/InspectionBase/AddInspectionBase` | 從 PLM 工作流程讀取檢驗基準書並寫入 MongoDB |

### ERPBase（ERP 基礎資料）

| 方法 | 路由 | 說明 |
|---|---|---|
| `GET` | `/api/ERPBase/GetItemCategory` | 查詢品號類別資料（INVMA） |
| `GET` | `/api/ERPBase/GetWarehouseData` | 查詢庫別資料（CMSMC） |

---

## 資料流說明

### 品號作廢流程（PartObsoleteController）

PLM 系統
  │
  ├─ 1. 呼叫 POST /api/Part/PartObsoleteController
  │      參數：品號、品名、商品、庫別、失效日、維護單號
  │
PartController
  │
  ├─ 2. 建立 PLMApiTrace（TraceID、輸入參數記錄）
  │
PartService
  │
  ├─ 3. 登入 PLM，確認品號存在
  ├─ 4. 查詢 ERP fn_CheckItemStatus，確認品號可作廢
  ├─ 5. 查詢 ERP INVMB，取得品號基本資料
  ├─ 6. 確認變更單是否已存在（防重複）
  └─ 7. 建立 INVTL（單頭）＋ INVTM（單身）寫入 ERP

### 檢驗基準書寫入流程（AddInspectionBase）

PLM 工作流程審查觸發
  │
  ├─ 1. 呼叫 POST /api/InspectionBase/AddInspectionBase
  │      參數：actID（Workflow Activity ID）
  │
InspectionBaseService
  │
  ├─ 2. 登入 PLM，透過 actID 追溯工作流程
  ├─ 3. 取得關聯文件（規格書/檢基書）
  ├─ 4. 取得品號資料
  ├─ 5. 判斷文件類型（05_產品規格書 / 06_檢驗基準書）
  ├─ 6. 解析 PLM XML，轉換為 JSON 格式
  ├─ 7. 查詢 SPC 圖片路徑（SPCConnection）
  └─ 8. 寫入 MongoDB（collection: sips）

---

## 環境設定

### 1. 複製設定檔

cp PLM_API/appsettings.Development.json.example PLM_API/appsettings.Development.json

### 2. 編輯 `appsettings.Development.json`

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=DBA;User Id=YOUR_USER;Password=YOUR_PASSWORD;",
    "ERPConnection": "Server=YOUR_SERVER;Database=DBB;User Id=YOUR_USER;Password=YOUR_PASSWORD;Encrypt=False;",
    "ERPSysConnection": "Server=YOUR_SERVER;Database=DBC;User Id=YOUR_USER;Password=YOUR_PASSWORD;",
    "SPCConnection": "Server=YOUR_SERVER;Database=DBD;User Id=YOUR_USER;Password=YOUR_PASSWORD;",
    "ModelConnection": "Server=YOUR_SERVER;Database=DBE;User Id=YOUR_USER;Password=YOUR_PASSWORD;",
    "GizmoLogConnection": "Server=YOUR_SERVER;Database=DBF;User Id=YOUR_USER;Password=YOUR_PASSWORD;"
  },
  "Mongo": {
    "ConnectionString": "mongodb://YOUR_MONGO_HOST:27017/",
    "Database": "DBG"
  },
  "AppSettings": {
    "PLMServer": "http://YOUR_PLM_HOST/InnovatorServer/Server/InnovatorServer.aspx",
    "PLMDB": "YOUR_PLM_DB",
    "PLMUser": "YOUR_PLM_USER",
    "PLMPassword": "YOUR_PLM_PASSWORD"
  }
}

> ⚠️ `appsettings.Development.json` 已列入 `.gitignore`，**請勿將含有密碼的設定檔 commit 至版控**。

### 3. 建立 Log 資料表

在 `GizmoLogDB` 執行以下 SQL：

CREATE TABLE [PLMApiTrace] (
    [LogID]       BIGINT        IDENTITY(1,1) NOT NULL,
    [TraceID]     NVARCHAR(50)  NOT NULL DEFAULT '',
    [MethodName]  NVARCHAR(100) NOT NULL DEFAULT '',
    [StepName]    NVARCHAR(200) NOT NULL DEFAULT '',
    [Status]      NVARCHAR(20)  NOT NULL DEFAULT '',
    [InputData]   NVARCHAR(MAX) NOT NULL DEFAULT '',
    [OutputData]  NVARCHAR(MAX) NOT NULL DEFAULT '',
    [Message]     NVARCHAR(MAX) NOT NULL DEFAULT '',
    [ExecutionMs] INT           NULL,
    [CreatedAt]   DATETIME2     NULL,
    CONSTRAINT [PK_PLMApiTrace] PRIMARY KEY CLUSTERED ([LogID] ASC)
);

---

## 本機開發啟動

# 還原套件
dotnet restore

# 啟動（開發模式，Swagger UI 開啟於 http://localhost:{port}）
dotnet run --project PLM_API --launch-profile Development

Swagger UI 預設路由：`http://localhost:{port}/`

---

## 日誌機制

本專案使用**雙軌日誌**：

### 1. Serilog（檔案日誌）
- 路徑：`{執行目錄}/logs/log-{日期}.txt`
- 每日自動輪替
- 記錄所有 ASP.NET Core 系統級日誌

### 2. DB Log（PLMApiTrace）
- 寫入 `PLMApiTrace`
- 記錄每次 API 呼叫的完整追蹤資訊
- 每筆 Log 帶有唯一 `TraceID`，可追蹤單次請求的所有執行步驟
- DB 寫入失敗時，自動 fallback 至 Serilog 避免日誌遺失

---

## 主要功能
- 透過 Aras Innovator（PLM）物件實作讀寫PLM等資料。
- 將 PLM XML 與屬性解析成檢查項目（checkItems），並組成 BSON Document 寫入 MongoDB（包含 createdAt/updatedAt 處理）、MSSQL。
- 提供 API 端點（Controllers）以觸發同步或查詢（視專案實作）。

---

## 環境需求
- .NET 9 SDK
- Visual Studio 2022 或等效 IDE
- MongoDB server（本機或遠端）
- 可存取的 Aras Innovator 帳號與權限

---

## 建置與執行
- Visual Studio
  1. 開啟 solution。
  2. 設定啟動專案，執行 __Build > Rebuild Solution__。
  3. 啟動除錯或執行（F5）。
- dotnet CLI
  - 還原：dotnet restore
  - 建置：dotnet build
  - 執行：dotnet run --project <PathToProject>.csproj

---

## 安全與密碼管理
- 開發建議使用 __dotnet user-secrets__ 管理開發時的敏感設定，生產環境請使用環境變數或金鑰庫（例如 Azure Key Vault）。
- PLM 密碼範例程式會做 MD5 雜湊（Innovator.ScalcMD5），實際部署仍應避免在 repo 中放置明文密碼。

---

## 故障排查（常見問題）
- PLM 連線失敗：確認 PLMServer、PLMDB、PLMUser 與密碼正確，且主機能存取 PLM 伺服器。
- Mongo 寫入失敗：檢查 ConnectionString、Database 權限、網路連線與防火牆。
- 欄位或 XML 解析錯誤：檢查 PLM 回傳 XML 結構與服務中解析邏輯（Services/InspectionBaseService.cs）。

---

## 開發建議
- 使用 Repository + Service pattern 保持關心分離。
- 在 Service 中加強例外與日誌紀錄，避免吞掉錯誤（方便除錯）。
- 測試環境建議建立 mock 的 Aras / Mongo 測試資料，或使用相容測試替代。
- 使用非同步 API 與 CancellationToken。
- 統一錯誤格式：加入 ExceptionHandlingMiddleware 回傳結構化 JSON。
- 明確 DI 生命週期（Singleton / Scoped / Transient）。
- 使用 DTO / record 回傳，避免直接回傳資料庫實體。
- 開啟 nullable reference types 與 __Analyze > Run Code Analysis__，提升穩定度。

---

## 版本
- v1.0.0 - 初始版本（生成於 README）
