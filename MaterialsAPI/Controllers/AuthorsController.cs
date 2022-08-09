namespace MaterialsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        /// <summary>
        /// Get authors list
        /// </summary>
        /// <returns>Authors list</returns>
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ICollection<AuthorReadDTO>))]
        [Authorize(Roles = "admin, user")]
        public async Task<IActionResult> GetAuthorsAsync()
        {
            return Ok(await _authorService.GetAllAuthorsAsync());
        }

        /// <summary>
        /// Get author by id
        /// </summary>
        /// <param name="id">ID of author you want to get</param>
        /// <returns>Single Author</returns>
        [HttpGet]
        [Route("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(AuthorReadDTO))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "admin, user")]
        public async Task<IActionResult> GetAuthorAsync(int id)
        {
            return Ok(await _authorService.GetAuthorAsync(id));
        }

        /// <summary>
        /// Get materials from specify author with average rating more then 5
        /// </summary>
        /// <param name="id">id of the author from whom you want to extract educational materials</param>
        /// <returns>List of Educational materials</returns>
        [HttpGet]
        [Route("{id}/Materials")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ICollection<MaterialReadDTO>))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status403Forbidden)]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetMaterialsWithAverageMoreThanFiveFromAuthorAsync(int id)
        {
            return Ok(await _authorService.GetMaterialWithAverageMoreThanFiveByAuthorAsync(id));
        }
    }
}
