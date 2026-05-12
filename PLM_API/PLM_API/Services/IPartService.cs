using PLM_API.PLM.Models;
using PLM_API.PLM.Models.LogDB;

namespace PLM_API.Services
{
    public interface IPartService
    {
        Task<ServiceResult> GetMappedNumberQC(string partNo);

        /// <summary>
        /// 設定品號作廢
        /// </summary>
        /// <param name="partNo">品號</param>
        /// <param name="partName">品名</param>
        /// <param name="product">商品</param>
        /// <param name="warehouse">庫別</param>
        /// <param name="expiryDate">失效日</param>
        /// <param name="docNo">品號維護單號</param>
        /// <param name="pLMApiTrace">LOG檔</param>
        /// <returns></returns>
        Task<ServiceResult> SetPartObsolete(string partNo, string partName, string product, string warehouse, DateTime expiryDate, string docNo, PLMApiTrace pLMApiTrace);

        /// <summary>
        /// 設定品號作廢
        /// </summary>
        /// <param name="partNo">品號</param>
        /// <param name="partName">品名</param>
        /// <param name="product">商品</param>
        /// <param name="warehouse">庫別</param>
        /// <param name="expiryDate">失效日</param>
        /// <param name="chkCode">檢查碼</param>
        /// <param name="db">資料庫</param>
        /// <param name="pLMApiTrace">LOG檔</param>
        /// <returns></returns>
        Task<ServiceResult> SetPartObsolete(string partNo, string oldPartName, string partName, string spec, string oldProduct, string product, string oldWarehouse, string warehouse, string oldPName, string pName, string expiryDate, string chkCode, string db, PLMApiTrace pLMApiTrace);
    }


}
