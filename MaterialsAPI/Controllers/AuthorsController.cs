using MaterialsAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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
        [Authorize(Roles = "admin, user")]
        public async Task<IActionResult> GetAuthors()
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
        [Authorize(Roles = "admin, user")]
        public async Task<IActionResult> GetAuthor(int id)
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
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetMaterialsWithAverageMoreThanFiveFromAuthor(int id)
        {
            return Ok(await _authorService.GetMaterialWithAverageMoreThanFiveByAuthorAsync(id));
        }
    }
}
