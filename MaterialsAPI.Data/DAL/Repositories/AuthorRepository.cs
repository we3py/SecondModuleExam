namespace MaterialsAPI.Data.DAL.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(MaterialsContext materialsContext) : base(materialsContext)
        {
        }

        public async Task<ICollection<Author>> GetAll()
            => await MaterialContext.Authors
            .Include(a => a.Materials)
            .ToListAsync();

        public async Task<Author> GetByIdWithMaterialsAndReviews(int id)
            => await MaterialContext.Authors
            .Include(a => a.Materials)
                .ThenInclude(m => m.Reviews)
            .Where(a => a.Id == id)
            .FirstOrDefaultAsync();
    }
}
