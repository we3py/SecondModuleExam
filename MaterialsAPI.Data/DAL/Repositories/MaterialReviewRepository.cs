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
    public class MaterialReviewRepository : Repository<MaterialReview>
    {
        public MaterialReviewRepository(MaterialsContext materialsContext) : base(materialsContext)
        {
        }

        public async Task<ICollection<MaterialReview>> GetAll()
            => await MaterialContext.MaterialReviews
            .Include(mr => mr.Material)
            .ToListAsync();
    }
}
