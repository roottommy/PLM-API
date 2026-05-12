using PLM_API.PLM.Models.SPCAn;

namespace PLM_API.PLM.Repositories
{
    public interface IInspectionBaseRepository
    {
        public Task<List<Cs1dataPicture>> QuerySPCPicture(string pdid);
    }
}
