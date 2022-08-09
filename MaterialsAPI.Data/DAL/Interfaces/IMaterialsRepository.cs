namespace MaterialsAPI.Data.DAL.Interfaces
{
    public interface IMaterialsRepository : IRepository<Material>
    {
        Task<ICollection<Material>> GetMaterials();
        Task<ICollection<Material>> GetMaterialsByAuthor(int authorId);
        Task<ICollection<Material>> GetMaterialsByType(int typeId);
        Task<Material> GetMaterialById(int id);
    }
}