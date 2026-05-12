using PLM_API.PLM.Models.ERP;

namespace PLM_API.Services
{
    public interface IERPBaseService
    {
        Task<INVMA> GetItemCategory(string category, string itemCateNo);

        Task<CMSMC> GetWarehouseData(string whNo);
    }
}
