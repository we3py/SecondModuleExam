
namespace MaterialsAPI.Services
{
    public interface IEducationMaterialService
    {
        Task<int> AddMaterialAsync(MaterialCreateUpdateDTO materialToAdd);
        Task<int> DeleteMaterialAsync(int materialId);
        Task<List<MaterialReadDTO>> GetAllMaterialsAsync();
        Task<MaterialReadDTO> GetMaterialAsync(int materialId);
        Task<int> UpdateMaterialAsync(int materialToUpdateId, MaterialCreateUpdateDTO updatedMaterial);
    }
}