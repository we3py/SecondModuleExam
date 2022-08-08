namespace MaterialsAPI.Data.DAL.Repositories
{
    public class MaterialsRepository : Repository<Material>
    {
        public MaterialsRepository(MaterialsContext materialsContext) : base(materialsContext)
        {
        }

        public async Task<ICollection<Material>> GetMaterialsByAuthor(int authorId)
            => await MaterialContext.Materials
                .Include(m => m.Reviews)
                .Include(m => m.MaterialType)
                .Include(m => m.Author)
                .Where(m => authorId == m.AuthorId)
                .ToListAsync();

        public async Task<ICollection<Material>> GetMaterialsByType(int typeId)
            => await MaterialContext.Materials
                .Include(m => m.Reviews)
                .Include(m => m.MaterialType)
                .Include(m => m.Author)
                .Where(m => typeId == m.MaterialTypeId)
                .ToListAsync();

        public async Task<ICollection<Material>> GetMaterials(int typeId)
            => await MaterialContext.Materials
                .Include(m => m.Reviews)
                .Include(m => m.MaterialType)
                .Include(m => m.Author)
                .ToListAsync();



    }
}
