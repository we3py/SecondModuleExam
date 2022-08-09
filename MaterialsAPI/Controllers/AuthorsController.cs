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

        [SwaggerOperation(Summary = "Get all authors")]
        [HttpGet]
        [Authorize(Roles = "admin, user")]
        public async Task<IActionResult> GetAuthors()
        {
            return Ok(await _authorService.GetAllAuthorsAsync());
        }

        [SwaggerOperation(Summary = "Get author by ID")]
        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "admin, user")]
        public async Task<IActionResult> GetAuthor(int id)
        {
            return Ok(await _authorService.GetAuthorAsync(id));
        }

        [SwaggerOperation(Summary = "Get material from author with average rating more than 5")]
        [HttpGet]
        [Route("{id}/Materials")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetMaterialsWithAverageMoreThanFiveFromAuthor(int id)
        {
            return Ok(await _authorService.GetMaterialWithAverageMoreThanFiveByAuthorAsync(id));
        }
    }
}
