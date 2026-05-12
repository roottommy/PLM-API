using PLM_API.PLM.Models;
using PLM_API.PLM.Models.ERP;

namespace PLM_API.PLM.Repositories
{
    public interface IPartRepository
    {
        Task<CheckItemStatusResult> CheckItemStatus(string partNo);

        Task<INVMB> GetPart(string partNo);

        /// <summary>
        /// 取得品號類別資料
        /// </summary>
        /// <returns>品號類別資料</returns>
        Task<List<INVMA>> GetPartType();

        /// <summary>
        /// 取得品號類別資料
        /// </summary>
        /// <returns>品號類別資料</returns>
        Task<INVMA> GetPartType(string category, string itemCateNo);

        /// <summary>
        /// 取得庫別資訊
        /// </summary>
        /// <param name="wareHouseCode">庫別</param>
        /// <param name="db">資料庫名稱</param>
        /// <returns></returns>
        Task<CMSMC> GetWarehouse(string wareHouseCode);

        /// <summary>
        /// 取得庫別資訊
        /// </summary>
        /// <param name="wareHouseCode">庫別</param>
        /// <param name="db">資料庫名稱</param>
        /// <returns></returns>
        Task<CMSMC> GetWarehouse(string wareHouseCode, string db);

        Task<ServiceResult> CreateItemChangeOrder(INVTL invtl, List<INVTM> invtms, INVMB invmb);

        Task<bool> CheckingItemChangeOrderExist(string docNo);

        Task<ServiceResult> CreateModelItemChangeOrder(INVTL invtl, List<INVTM> invtms, INVMB invmb);
    }
}
