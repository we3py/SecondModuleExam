using MaterialsAPI.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaterialsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialsController : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles = "admin, user")]
        public async Task<List<Material>> GetMaterials()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("[controller]/id")]
        [Authorize(Roles = "admin, user")]
        public async Task<Material> GetMaterial(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task AddMaterial(Material material)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        public async Task UpdateMaterial(Material material)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route("[controller]/id")]
        [Authorize(Roles = "admin")]
        public async Task DeleteMaterial(int id)
        {
            throw new NotImplementedException();
        }
    }
}
