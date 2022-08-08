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
    }
}
