using PLM_API.PLM.Models.ERP;

namespace PLM_API.PLM.Repositories
{
    public interface IERPBaseRepository
    {
        /// <summary>
        /// 取得庫別資料
        /// </summary>
        /// <param name="whNo">庫別代碼</param>
        /// <returns>庫別資料</returns>
        Task<CMSMC> GetWarehouseData(string whNo);
    }
}
