namespace MaterialsAPI.Data.DAL.Repositories
{
    public class MaterialReviewRepository : Repository<MaterialReview>, IMaterialReviewRepository
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
