namespace MaterialsAPI.Services.Interfaces
{
    public interface IReviewsService
    {
        Task<int> AddMaterialReviewAsync(MaterialReviewCreateUpdateDTO materialReviewToAdd);
        Task<int> DeleteMaterialReviewAsync(int materialReviewId);
        Task<List<MaterialReviewReadDTO>> GetAllMaterialReviewsAsync();
        Task<MaterialReviewReadDTO> GetMaterialReviewAsync(int materialId);
        Task<int> UpdateMaterialReviewAsync(int materialReviewToUpdateId, MaterialReviewCreateUpdateDTO updatedMaterialReview);
    }
}
