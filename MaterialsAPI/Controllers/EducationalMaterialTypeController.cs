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
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ICollection<MaterialTypeReadDTO>))]
        [Authorize(Roles = "admin, user")]
        public async Task<IActionResult> GetMaterialTypesAsync()
        {
            return Ok(await _materialTypeService.GetAllMaterialTypes());
        }

        /// <summary>
        /// Get specify educational material
        /// </summary>
        /// <param name="id">ID of educational material type you want to get</param>
        /// <returns>Single educational material type</returns>
        [HttpGet]
        [Route("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(MaterialTypeReadDTO))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "admin, user")]
        public async Task<IActionResult> GetMaterialTypeAsync(int id)
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
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(MaterialReadDTO))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status403Forbidden)]
        [Route("{id}/materials")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetMaterialByTypeAsync(int id)
        {
            return Ok(await _materialTypeService.GetMaterialsByTypeAsync(id));
        }

    }
}
