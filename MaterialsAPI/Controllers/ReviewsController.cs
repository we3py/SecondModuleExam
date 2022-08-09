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
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ICollection<MaterialReviewReadDTO>))]
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
        [HttpGet]
        [Route("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(MaterialReviewReadDTO))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
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
        [HttpPost]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(MaterialReviewCreateUpdateDTO))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
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
        [HttpPut]
        [Route("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(MaterialReviewCreateUpdateDTO))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
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
        [HttpDelete]
        [Route("{id}")]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status403Forbidden)]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteMaterialReviewAsync(int id)
        {
            var materialReviewId = await _reviewService.DeleteMaterialReviewAsync(id);
            return NoContent();
        }
    }
}
