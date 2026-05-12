using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PLM_API.Services;

namespace PLM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ERPBaseController : ControllerBase
    {
        private readonly IERPBaseService _erpBaseService;

        public ERPBaseController(IERPBaseService erpBaseService)
        {
            _erpBaseService = erpBaseService;
        }

        [HttpGet]
        [Route("GetItemCategory")]
        public async Task<IActionResult> GetItemCategory(string category, string itemCateNo)
        {
            try
            {
                var result = await _erpBaseService.GetItemCategory(category, itemCateNo);
                return Ok(result);
            }
            catch (Exception ex)
            { 
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetWarehouseData")]
        public async Task<IActionResult> GetWarehouseData(string whNo)
        {
            try
            {
                var result = await _erpBaseService.GetWarehouseData(whNo);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
