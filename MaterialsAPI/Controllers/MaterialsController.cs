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
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ICollection<MaterialReadDTO>))]
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
        [HttpGet]
        [Route("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(MaterialReadDTO))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
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
        [HttpPost]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(MaterialCreateUpdateDTO))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status403Forbidden)]
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
        [HttpPut]
        [Route("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(MaterialCreateUpdateDTO))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status403Forbidden)]
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
        /// <returnsID></returns>
        [HttpDelete]
        [Route("{id}")]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status403Forbidden)]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteMaterial(int id)
        {
            var materialId = await _materialService.DeleteMaterialAsync(id);
            return NoContent();
        }
    }
}
