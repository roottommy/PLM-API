namespace PLM_API.PLM.Models
{
    public class ServiceResult
    {
        public CommonEnums.ResultType Status { get; set; }

        public string? Message { get; set; }

        public int Code { get; set; }

        public Meta Meta { get; set; }

        public object? Data { get; set; }
    }

    public class Meta
    {
        public string Key { get; set; }
        public string ObjectType { get; set; }
    }

    public class CommonEnums
    {
        public enum ResultType
        {
            scuuess = 1,
            error = 0
        }

        public enum ResultCode
        {
            /// <summary>
            /// 成功回應
            /// </summary>
            OK = 200,

            /// <summary>
            /// 錯誤請求（參數錯誤、格式不正確）
            /// </summary>
            BadRequest = 400,

            /// <summary>
            /// 未授權（需要登入或 Token 無效）
            /// </summary>
            Unauthorized = 401,

            /// <summary>
            /// 找不到資源
            /// </summary>
            NotFound = 404,

            /// <summary>
            /// 伺服器錯誤
            /// </summary>
            InternalServerError = 500,

            /// <summary>
            /// 缺少必要資訊
            /// </summary>
            MissingInformation = 1000,

            /// <summary>
            /// 缺少必要參數
            /// </summary>
            MissingParameter = 1001,

            /// <summary>
            /// 參數格式錯誤
            /// </summary>
            InvalidParameterFormat = 1002,

            /// <summary>
            /// 無效的 Token
            /// </summary>
            InvalidToken = 1003,

            /// <summary>
            /// 權限不足
            /// </summary>
            PermissionDenied = 1004,

            /// <summary>
            /// 請求過於頻繁
            /// </summary>
            TooFrequentRequests = 1005,

            /// <summary>
            /// 資料處理失敗
            /// </summary>
            DataProcessingFailed = 1100,

            /// <summary>
            /// 帳號不存在
            /// </summary>
            AccountNotFound = 2001,

            /// <summary>
            /// 密碼錯誤
            /// </summary>
            IncorrectPassword = 2002,

            /// <summary>
            /// 使用者已停用
            /// </summary>
            UserDisabled = 2003,

            /// <summary>
            /// 檔案格式不支援
            /// </summary>
            UnsupportedFileFormat = 3001,

            /// <summary>
            /// 檔案過大
            /// </summary>
            FileTooLarge = 3002,

            /// <summary>
            /// 業務邏輯錯誤
            /// </summary>
            BusinessLogicError = 4001,

            /// <summary>
            /// 資料庫連線失敗
            /// </summary>
            DatabaseConnectionFailed = 5001,

            /// <summary>
            /// SQL 語法錯誤
            /// </summary>
            SqlSyntaxError = 5002,

            /// <summary>
            /// 查無資料
            /// </summary>
            NoDataFound = 5003,

            /// <summary>
            /// 資料庫寫入失敗
            /// </summary>
            DatabaseWriteFailed = 5004,

            /// <summary>
            /// 資料庫逾時
            /// </summary>
            DatabaseTimeout = 5005,

            /// <summary>
            /// 違反唯一鍵
            /// </summary>
            DuplicateKey = 5101,

            /// <summary>
            /// 外鍵約束錯誤
            /// </summary>
            ForeignKeyConstraintError = 5102,

            /// <summary>
            /// 資料被鎖定，無法更新
            /// </summary>
            RecordLocked = 5103,

            /// <summary>
            /// 未預期錯誤
            /// </summary>
            GeneralError = 9000

        }
    }
}
