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

        [SwaggerOperation(Summary = "Get all materials")]
        [HttpGet]
        [Authorize(Roles = "admin, user")]        
        public async Task<IActionResult> GetMaterials()
        {
            return Ok(await _materialService.GetAllMaterialsAsync());
        }

        [SwaggerOperation(Summary = "Get material by ID")]
        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "admin, user")]
        public async Task<IActionResult> GetMaterial(int id)
        {
            return Ok(await _materialService.GetMaterialAsync(id));
        }

        [SwaggerOperation(Summary = "Add new material")]
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AddMaterial(MaterialCreateUpdateDTO material)
        {
            var id = await _materialService.AddMaterialAsync(material);
            return Created($"{HttpContext.Request.Path}/{id}", $"new Material with id= [{id}] added");
        }

        [SwaggerOperation(Summary = "Update material")]
        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateMaterial(int materialToUpdateId, MaterialCreateUpdateDTO material)
        {
            var id = await _materialService.UpdateMaterialAsync(materialToUpdateId, material);
            return Created($"{HttpContext.Request.Path}/{id}", $"new Material with id= [{id}] updated");
        }

        [SwaggerOperation(Summary = "Delete material")]
        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteMaterial(int materialId)
        {
            var id = await _materialService.DeleteMaterialAsync(materialId);
            return Created($"{HttpContext.Request.Path}/{id}", $"Material with id= [{id}] deleted");
        }
    }
}
