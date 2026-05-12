using PLM_API.PLM.Models.LogDB;

namespace PLM_API.Services
{
    public interface IAppLogService
    {
        Task LogInfoAsync(PLMApiTrace log);

        Task LogErrorAsync(PLMApiTrace log);
    }
}
