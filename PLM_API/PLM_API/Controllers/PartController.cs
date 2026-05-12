using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PLM_API.PLM.Models;
using PLM_API.PLM.Models.LogDB;
using PLM_API.Services;
using System.Text.Json;

namespace PLM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartController : ControllerBase
    {
        private readonly IPartService _partService;
        private readonly IAppLogService _appLogger;
        private readonly ILogger<PartController> _logger;

        public PartController(IPartService partService, IAppLogService appLogService, ILogger<PartController> logger)
        {
            _partService = partService;
            _appLogger = appLogService;
            _logger = logger;
        }

        [HttpPost]
        [Route("GetMappedPartData")]
        public async Task<IActionResult> GetMappedPartData(string partNo)
        {
            try
            {
                ServiceResult serResult = await _partService.GetMappedNumberQC(partNo);
                // 這裡可以根據 serResult.Status 做進一步處理
                if (serResult.Status == CommonEnums.ResultType.scuuess)
                {
                    return Ok(serResult);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, serResult.Message);
                }
            }
            catch (Exception ex)
            {
                // 可以根據需要記錄錯誤或返回錯誤訊息
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("PartObsoleteController")]
        public async Task<IActionResult> SetPartObsoleteController(string partNo, string partName, string product, string warehouse, string expiryDate, string itemNo)
        {
            PLMApiTrace pLMApiTrace = new PLMApiTrace
            {
                TraceID = Guid.NewGuid().ToString().ToUpper(),
                MethodName = "PartObsoleteController",
                StepName = "Method Start",
                Status = "Start",
                InputData = $"partNo: {partNo}, partName: {partName}, product: {product}, warehouse: {warehouse}, expiryDate: {expiryDate}, itemNo: {itemNo}",
                OutputData = string.Empty,
                Message = string.Empty,
                ExecutionMs = 0,
            };
           
            await _appLogger.LogInfoAsync(pLMApiTrace);

            try
            {
                DateTime expiryDt = DateTime.Parse(expiryDate); // 解析日期字串
                var serResult = await _partService.SetPartObsolete(partNo, partName, product, warehouse, expiryDt, itemNo, pLMApiTrace);
                if (serResult.Status == CommonEnums.ResultType.scuuess)
                {
                    pLMApiTrace.StepName = "Method End";
                    pLMApiTrace.Status = "Success";
                    string jsonStr = JsonSerializer.Serialize(serResult.Data);
                    pLMApiTrace.OutputData = $"Result: {jsonStr}";
                    await _appLogger.LogInfoAsync(pLMApiTrace);
                    return Ok(serResult);
                }
                else
                {
                    pLMApiTrace.StepName = "Method End";
                    pLMApiTrace.Status = "Error";
                    string jsonStr = JsonSerializer.Serialize(serResult.Data);
                    pLMApiTrace.OutputData = $"Result: {jsonStr}";
                    pLMApiTrace.Message = serResult.Message;
                    await _appLogger.LogInfoAsync(pLMApiTrace);
                    return StatusCode(StatusCodes.Status500InternalServerError, serResult.Message);
                }
            }
            catch (Exception ex)
            {
                pLMApiTrace.StepName = "Method End";
                pLMApiTrace.Status = "Error";
                pLMApiTrace.OutputData = string.Empty;
                pLMApiTrace.Message = ex.Message;
                await _appLogger.LogInfoAsync(pLMApiTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, pLMApiTrace.Message);
            }
        }

        [HttpPost]
        [Route("ERPObsoleteController")]
        public async Task<IActionResult> ERPObsoleteController(string partNo, string oldPartName, string partName, string? spec, string? oldProduct, string product, string? oldWarehouse, string warehouse, string? oldPName, string pName, string expiryDate, string chkCode, string db)
        {
            PLMApiTrace pLMApiTrace = new PLMApiTrace
            {
                TraceID = Guid.NewGuid().ToString().ToUpper(),
                MethodName = "ERPObsoleteController",
                StepName = "Method Start",
                Status = "Start",
                InputData = $"partNo: {partNo}, oldPartName: {oldPartName}, partName: {partName}, spec: {spec}, product: {product}, warehouse: {warehouse}, expiryDate: {expiryDate}, chkCode: {chkCode}, db: {db}",
                OutputData = string.Empty,
                Message = string.Empty,
                ExecutionMs = 0,
            };

            await _appLogger.LogInfoAsync(pLMApiTrace);

            try
            {
                //DateTime expiryDt = DateTime.Parse(expiryDate); // 解析日期字串
                var serResult = await _partService.SetPartObsolete(partNo, oldPartName, partName, spec ?? string.Empty, oldProduct ?? string.Empty, product, oldWarehouse ?? string.Empty, warehouse, oldPName ?? string.Empty, pName, expiryDate, chkCode, db, pLMApiTrace);
                if (serResult.Status == CommonEnums.ResultType.scuuess)
                {
                    pLMApiTrace.StepName = "Method End";
                    pLMApiTrace.Status = "Success";
                    string jsonStr = JsonSerializer.Serialize(serResult.Data);
                    pLMApiTrace.OutputData = $"Result: {jsonStr}";
                    await _appLogger.LogInfoAsync(pLMApiTrace);
                    return Ok(serResult);
                }
                else
                {
                    pLMApiTrace.StepName = "Method End";
                    pLMApiTrace.Status = "Error";
                    string jsonStr = JsonSerializer.Serialize(serResult.Data);
                    pLMApiTrace.OutputData = $"Result: {jsonStr}";
                    pLMApiTrace.Message = serResult.Message;
                    await _appLogger.LogInfoAsync(pLMApiTrace);
                    return StatusCode(StatusCodes.Status500InternalServerError, serResult.Message);
                }
            }
            catch (Exception ex)
            {
                pLMApiTrace.StepName = "Method End";
                pLMApiTrace.Status = "Error";
                pLMApiTrace.OutputData = string.Empty;
                pLMApiTrace.Message = ex.Message;
                await _appLogger.LogInfoAsync(pLMApiTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, pLMApiTrace.Message);
            }
        }
    }
}
