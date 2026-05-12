using Microsoft.Extensions.Options;
using PLM_API.PLM.Models.ERP;
using PLM_API.PLM.Repositories;
using PLM_API.Utilities;

namespace PLM_API.Services
{
    public class ERPBaseService : IERPBaseService
    {
        private readonly IPartRepository _partRepository;
        private readonly IERPBaseRepository _erpBaseRepository;

        public ERPBaseService(IPartRepository partRepository, IERPBaseRepository erpBaseRepository)
        {
            _partRepository = partRepository;
            _erpBaseRepository = erpBaseRepository;
        }
        /// <summary>
        /// 取得品號類別資料
        /// </summary>
        /// <param name="category">類別</param>
        /// <param name="itemCateNo">類別代碼</param>
        /// <returns>品號類別資料</returns>
        public async Task<INVMA> GetItemCategory(string category, string itemCateNo)
        { 
            var data = await _partRepository.GetPartType(category, itemCateNo);

            if (data == null)
                return new INVMA();

            return data;
        }

        /// <summary>
        /// 取得庫別資料
        /// </summary>
        /// <param name="whNo">庫別代碼</param>
        /// <returns>庫別資料</returns>
        public async Task<CMSMC> GetWarehouseData(string whNo)
        {
            var data = await _erpBaseRepository.GetWarehouseData(whNo);

            if (data == null)
                return new CMSMC();

            return data;
        }
    }
}
