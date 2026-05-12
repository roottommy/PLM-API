namespace PLM_API.Services
{
    public class CodeService
    {
        /// <summary>
        /// 取得確認品號狀態錯誤說明
        /// </summary>
        /// <param name="code">代碼</param>
        /// <returns>狀態錯誤說明</returns>
        public string GetItemStatusMsg(string code)
        {
            string msg = string.Empty;

            switch (code)
            {
                case "00":
                    msg = "可以作廢";
                    break;
                case "01":
                    msg = "尚有庫存數";
                    break;
                case "02":
                    msg = "品號已失效無法再次作廢";
                    break;
                case "03":
                    msg = "尚有異動單/轉撥單未結案";
                    break;
                case "04":
                    msg = "尚有銷貨單未結案";
                    break;
                case "05":
                    msg = "尚有銷退單未結案";
                    break;
                case "06":
                    msg = "尚有進貨單未結案";
                    break;
                case "07":
                    msg = "尚有退貨單未結案";
                    break;
                case "08":
                    msg = "尚有領料單/退料單未結案";
                    break;
                case "09":
                    msg = "尚有托外進貨單未結案";
                    break;
                case "10":
                    msg = "尚有托外退貨單未結案";
                    break;
                case "11":
                    msg = "尚有入庫單未結案";
                    break;
                case "99":
                    msg = "例外錯誤";
                    break;
                default:
                    msg= "錯誤代碼錯誤";
                break;
            }

            return msg;
        }
    }
}
