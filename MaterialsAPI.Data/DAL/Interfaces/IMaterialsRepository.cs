
namespace MaterialsAPI.Data.DAL.Repositories
{
    public interface IMaterialsRepository
    {
        Task<ICollection<Material>> GetMaterials(int typeId);
        Task<ICollection<Material>> GetMaterialsByAuthor(int authorId);
        Task<ICollection<Material>> GetMaterialsByType(int typeId);
    }
}