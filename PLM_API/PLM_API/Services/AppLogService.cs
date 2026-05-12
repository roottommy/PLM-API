using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PLM_API.Infrastructure.MSSql;
using PLM_API.PLM.Models;
using PLM_API.PLM.Models.LogDB;
using Serilog;
using System.ComponentModel.DataAnnotations.Schema;

namespace PLM_API.Services
{
    public class AppLogService : IAppLogService
    {
        private readonly AppLogDbContext _logDb;
        private readonly ILogger<AppLogService> _logger;
        public AppLogService(AppLogDbContext logDb, ILogger<AppLogService> logger)
        {
            _logDb = logDb;
            _logger = logger;
        }

        public async Task LogInfoAsync(PLMApiTrace log)
        {
            log.Status = "Info";
            await WriteLogAsync(log);
        }

        public async Task LogErrorAsync(PLMApiTrace log)
        {
            log.Status = "Error";
            await WriteLogAsync(log);
        }

        private async Task WriteLogAsync(PLMApiTrace log)
        {
            try
            {
                //var log = new PLMApiTrace
                //{
                //    TraceID = traceID,
                //    MethodName = methodName,
                //    StepName = stepName,
                //    Status = status,
                //    InputData = inputData,
                //    OutputData = outputData,
                //    ErrorLog = errLog,
                //    ExecutionMs = execMs,
                //    CreatedAt = DateTime.Now
                //};
                log.CreatedAt = DateTime.Now;

                _logDb.AppLogs.Add(log);
                await _logDb.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // DB 寫入失敗時，退回使用內建 Logger 避免日誌遺失
                _logger.LogError(string.Format("[TraceID : {0}]寫入LOG失敗，寫入失敗錯誤訊息 : {8}，預計寫入資料，MethodName : {1}、StepName : {2}、Status : {3}、InputData : {4}、OutputData : {5}、ErrLog : {6}、ExecMs : {7}", log.TraceID, log.MethodName, log.StepName, log.Status, log.InputData, log.OutputData, log.Message, log.ExecutionMs, ex.Message));
            }
        }
    }
}
