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

        public async Task<MaterialReview> GetById(int id)
            => await MaterialContext.MaterialReviews
            .Include(mr => mr.Material)
            .Where(mr => mr.Id == id)
            .FirstOrDefaultAsync();
    }
}
