using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PLM_API.PLM.Models;
using PLM_API.Services;

namespace PLM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InspectionBaseController : ControllerBase
    {
        private readonly IInspectionBaseService _InspectionBaseService;

        public InspectionBaseController(IInspectionBaseService inspectionBaseService)
        {
            _InspectionBaseService = inspectionBaseService;
        }

        [HttpPost]
        [Route("AddInspectionBase")]
        public async Task<IActionResult> AddInspectionBase(string id)
        {
            try
            {
                ServiceResult result = await _InspectionBaseService.InsertInspectionBase(id);
                if(result.Status == CommonEnums.ResultType.error)
                {
                    return StatusCode(result.Code, result.Message);
                }

                return StatusCode(result.Code);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status405MethodNotAllowed, ex.Message);
            }
        }
    }
}
