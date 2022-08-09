
namespace MaterialsAPI.Services
{
    public interface IMaterialTypeService
    {
        Task<List<MaterialTypeReadDTO>> GetAllMaterialTypes();
        Task<List<MaterialReadDTO>> GetMaterialsByTypeAsync(int materialTypeId);
        Task<MaterialTypeReadDTO> GetMaterialTypeAsync(int materialTypeId);
    }
}