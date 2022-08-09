using MaterialsAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MaterialsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationalMaterialTypeController : ControllerBase
    {
        private IMaterialTypeService _materialTypeService;

        public EducationalMaterialTypeController(IMaterialTypeService materialTypeService)
        {
            _materialTypeService = materialTypeService;
        }

        [SwaggerOperation(Summary = "Get all materials")]
        [HttpGet]
        [Authorize(Roles = "admin, user")]
        public async Task<IActionResult> GetMaterialTypes()
        {
            return Ok(await _materialTypeService.GetAllMaterialTypes());
        }

        [SwaggerOperation(Summary = "Get material by ID")]
        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "admin, user")]
        public async Task<IActionResult> GetMaterialType(int id)
        {
            return Ok(await _materialTypeService.GetMaterialTypeAsync(id));
        }

        [SwaggerOperation(Summary = "Get material by ID")]
        [HttpGet]
        [Route("{id}/materials")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetMaterialByType(int id)
        {
            return Ok(await _materialTypeService.GetMaterialsByTypeAsync(id));
        }

    }
}
