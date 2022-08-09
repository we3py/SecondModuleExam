using MaterialsAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MaterialsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialsController : ControllerBase
    {
        private IEducationMaterialService _materialService;

        public MaterialsController(IEducationMaterialService materialService)
        {
            _materialService = materialService;
        }

        /// <summary>
        /// Get educational materials
        /// </summary>
        /// <returns>List of education materials</returns>
        [SwaggerOperation(Summary = "Get all educational materials")]
        [HttpGet]
        [Authorize(Roles = "admin, user")]        
        public async Task<IActionResult> GetMaterials()
        {
            return Ok(await _materialService.GetAllMaterialsAsync());
        }

        /// <summary>
        /// Get specified material
        /// </summary>
        /// <param name="id">ID of material you want to get</param>
        /// <returns>Single educational material</returns>
        [SwaggerOperation(Summary = "Get educational material by ID")]
        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "admin, user")]
        public async Task<IActionResult> GetMaterial(int id)
        {
            return Ok(await _materialService.GetMaterialAsync(id));
        }

        /// <summary>
        /// Add new educational material
        /// </summary>
        /// <param name="material">Pass educational material parameters</param>
        /// <returns>ID of created educational material</returns>
        [SwaggerOperation(Summary = "Add new educational material")]
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AddMaterial(MaterialCreateUpdateDTO material)
        {
            var id = await _materialService.AddMaterialAsync(material);
            return Created($"{HttpContext.Request.Path}/{id}", $"New educational material with id = [{id}] added");
        }

        /// <summary>
        /// Update educational material
        /// </summary>
        /// <param name="id">ID of educational material you want to update</param>
        /// <param name="material">Pass edcuational material parameters</param>
        /// <returns>ID of updated educational material</returns>
        [SwaggerOperation(Summary = "Update educational material")]
        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateMaterial(int id, MaterialCreateUpdateDTO material)
        {
            var materialId = await _materialService.UpdateMaterialAsync(id, material);
            return Created($"{HttpContext.Request.Path}/{materialId}", $"Educational material with id = [{materialId}] updated");
        }

        /// <summary>
        /// Delete educational material
        /// </summary>
        /// <param name="id">ID of educational material you want to delete</param>
        /// <returnsID>ID of deleted material</returns>
        [SwaggerOperation(Summary = "Delete educational material")]
        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteMaterial(int id)
        {
            var materialId = await _materialService.DeleteMaterialAsync(id);
            return Created($"{HttpContext.Request.Path}/{materialId}", $"Educational Material with id = [{materialId}] deleted");
        }
    }
}
