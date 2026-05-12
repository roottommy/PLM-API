using PLM_API.PLM.Models;

namespace PLM_API.Services
{
    public interface IInspectionBaseService
    {
        public Task<ServiceResult> InsertInspectionBase(string actID);
    }
}
