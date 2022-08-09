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

        /// <summary>
        /// Get educational material types
        /// </summary>
        /// <returns>Educational material types</returns>
        [SwaggerOperation(Summary = "Get all materials")]
        [HttpGet]
        [Authorize(Roles = "admin, user")]
        public async Task<IActionResult> GetMaterialTypes()
        {
            return Ok(await _materialTypeService.GetAllMaterialTypes());
        }

        /// <summary>
        /// Get specify educational material
        /// </summary>
        /// <param name="id">ID of educational material type you want to get</param>
        /// <returns>Single educational material type</returns>
        [SwaggerOperation(Summary = "Get material by ID")]
        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "admin, user")]
        public async Task<IActionResult> GetMaterialType(int id)
        {
            return Ok(await _materialTypeService.GetMaterialTypeAsync(id));
        }

        /// <summary>
        /// Get educational materials from specify educational material types
        /// </summary>
        /// <param name="id">ID of educational material type</param>
        /// <returns>List of educational materials</returns>
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
