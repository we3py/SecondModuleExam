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
        private EducationMaterialService _materialService;

        public MaterialsController(EducationMaterialService materialService)
        {
            _materialService = materialService;
        }

        [SwaggerOperation(Summary = "Get all materials")]
        [HttpGet]
        [Authorize(Roles = "admin, user")]        
        public async Task<IActionResult> GetMaterials()
        {
            return Ok(await _materialService.GetAllMaterials());
        }

        [SwaggerOperation(Summary = "Get material by ID")]
        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "admin, user")]
        public async Task<IActionResult> GetMaterial(int id)
        {
            return Ok(await _materialService.GetMaterial(id));
        }

        [SwaggerOperation(Summary = "Add new material")]
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AddMaterial(MaterialCreateUpdateDTO material)
        {
            var id = await _materialService.AddMaterial(material);
            return Created($"{HttpContext.Request.Path}/{id}", $"new Material with id= [{id}] added");
        }

        [SwaggerOperation(Summary = "Update material")]
        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateMaterial(int materialToUpdateId, MaterialCreateUpdateDTO material)
        {
            var id = await _materialService.UpdateMaterial(materialToUpdateId, material);
            return Created($"{HttpContext.Request.Path}/{id}", $"new Material with id= [{id}] updated");
        }

        [SwaggerOperation(Summary = "Delete material")]
        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteMaterial(int materialId)
        {
            var id = await _materialService.DeleteMaterial(materialId);
            return Created($"{HttpContext.Request.Path}/{id}", $"Material with id= [{id}] deleted");
        }
    }
}
