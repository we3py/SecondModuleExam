using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaterialsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationalMaterialTypeController : ControllerBase
    {
        [HttpGet]
        public async Task gowno()
        {
            throw new NotImplementedException();
        }
    }
}
