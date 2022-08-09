using MaterialsAPI.Services;
using MaterialsAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MaterialsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private IReviewsService _reviewService;

        public ReviewsController(IReviewsService reviewService)
        {
            _reviewService = reviewService;
        }

        [SwaggerOperation(Summary = "Get all material reviews")]
        [HttpGet]
        [Authorize(Roles = "admin, user")]
        public async Task<IActionResult> GetMaterialReviewsAsync()
        {
            return Ok(await _reviewService.GetAllMaterialReviewsAsync());
        }

        [SwaggerOperation(Summary = "Get material review by ID")]
        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "admin, user")]
        public async Task<IActionResult> GetMaterialReviewAsync(int id)
        {
            return Ok(await _reviewService.GetMaterialReviewAsync(id));
        }

        [SwaggerOperation(Summary = "Add new material review")]
        [HttpPost]
        [Authorize(Roles = "admin, user")]
        public async Task<IActionResult> AddMaterialReviewAsync(MaterialReviewCreateUpdateDTO materialReview)
        {
            var id = await _reviewService.AddMaterialReviewAsync(materialReview);
            return Created($"{HttpContext.Request.Path}/{id}", $"new Material review with id= [{id}] added");
        }

        [SwaggerOperation(Summary = "Update material review")]
        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = "admin, user")]
        public async Task<IActionResult> UpdateMaterialReviewAsync(int id, MaterialReviewCreateUpdateDTO material)
        {
            var materialReviewid = await _reviewService.UpdateMaterialReviewAsync(id, material);
            return Created($"{HttpContext.Request.Path}/{materialReviewid}", $"new Material with id= [{materialReviewid}] updated");
        }

        [SwaggerOperation(Summary = "Delete material")]
        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteMaterialReviewAsync(int id)
        {
            var materialReviewId = await _reviewService.DeleteMaterialReviewAsync(id);
            return Created($"{HttpContext.Request.Path}/{materialReviewId}", $"Material review with id= [{materialReviewId}] deleted");
        }
    }
}
