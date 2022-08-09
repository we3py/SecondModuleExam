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

        /// <summary>
        /// Get all educational material reviews
        /// </summary>
        /// <returns>List of educational material reviews</returns>
        [SwaggerOperation(Summary = "Get all educational material reviews")]
        [HttpGet]
        [Authorize(Roles = "admin, user")]
        public async Task<IActionResult> GetMaterialReviewsAsync()
        {
            return Ok(await _reviewService.GetAllMaterialReviewsAsync());
        }

        /// <summary>
        /// Get specified educational material review
        /// </summary>
        /// <param name="id">ID of educational material review you want to get</param>
        /// <returns>Single educational material review</returns>
        [SwaggerOperation(Summary = "Get educational material review by ID")]
        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "admin, user")]
        public async Task<IActionResult> GetMaterialReviewAsync(int id)
        {
            return Ok(await _reviewService.GetMaterialReviewAsync(id));
        }

        /// <summary>
        /// Add educational material review
        /// </summary>
        /// <param name="materialReview">Pass educational material review parameters</param>
        /// <returns>ID of created educational material review</returns>
        [SwaggerOperation(Summary = "Add new educational material review")]
        [HttpPost]
        [Authorize(Roles = "admin, user")]
        public async Task<IActionResult> AddMaterialReviewAsync(MaterialReviewCreateUpdateDTO materialReview)
        {
            var id = await _reviewService.AddMaterialReviewAsync(materialReview);
            return Created($"{HttpContext.Request.Path}/{id}", $"new Material review with id= [{id}] added");
        }

        /// <summary>
        /// Update educational material review
        /// </summary>
        /// <param name="id">ID of educational material review you want to update</param>
        /// <param name="material">Pass educational material review parameters</param>
        /// <returns>ID of updated educational material review</returns>
        [SwaggerOperation(Summary = "Update educational material review")]
        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = "admin, user")]
        public async Task<IActionResult> UpdateMaterialReviewAsync(int id, MaterialReviewCreateUpdateDTO material)
        {
            var materialReviewid = await _reviewService.UpdateMaterialReviewAsync(id, material);
            return Created($"{HttpContext.Request.Path}/{materialReviewid}", $"Educational material with id= [{materialReviewid}] updated");
        }

        /// <summary>
        /// Delete educational material review
        /// </summary>
        /// <param name="id">ID of educational material review you want to delete</param>
        /// <returns>ID of deleted educational material review</returns>
        [SwaggerOperation(Summary = "Delete educational material")]
        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteMaterialReviewAsync(int id)
        {
            var materialReviewId = await _reviewService.DeleteMaterialReviewAsync(id);
            return Created($"{HttpContext.Request.Path}/{materialReviewId}", $"Educational material review with id= [{materialReviewId}] deleted");
        }
    }
}
