using Microsoft.EntityFrameworkCore;
using PLM_API.Infrastructure.MSSql;
using PLM_API.PLM.Models.ERP;

namespace PLM_API.PLM.Repositories
{
    public class ERPBaseRepository : IERPBaseRepository
    {
        private readonly AppERPDbContext _erpDB;
        public ERPBaseRepository(AppERPDbContext erpDB)
        {
            _erpDB = erpDB;
        }

        /// <summary>
        /// 取得庫別資料
        /// </summary>
        /// <param name="whNo">庫別代碼</param>
        /// <returns>庫別資料</returns>
        public async Task<CMSMC> GetWarehouseData(string whNo)
        {
            var query = _erpDB.GetWarehouse.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(whNo))
            {                
                query = query.Where(x => x.MC001 == whNo.Trim());
            }

            return await query.FirstOrDefaultAsync();
        }
    }
}
