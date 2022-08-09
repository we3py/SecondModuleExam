namespace MaterialsAPI.Data.DAL.Interfaces
{
    public interface IMaterialReviewRepository
    {
        Task<ICollection<MaterialReview>> GetAll();
    }
}