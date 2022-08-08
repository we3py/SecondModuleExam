using MaterialsAPI.Data.Context;
using MaterialsAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialsAPI.Data.DAL.Repositories
{
    public class AuthorRepository : Repository<Author>
    {
        public AuthorRepository(MaterialsContext materialsContext) : base(materialsContext)
        {
        }

        public async Task<ICollection<Author>> GetAll()
            => await MaterialContext.Authors
            .Include(a => a.Materials)
            .ToListAsync();
    }
}
