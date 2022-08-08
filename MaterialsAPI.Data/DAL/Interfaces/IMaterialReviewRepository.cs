
namespace MaterialsAPI.Data.DAL.Repositories
{
    public interface IMaterialReviewRepository
    {
        Task<ICollection<MaterialReview>> GetAll();
    }
}