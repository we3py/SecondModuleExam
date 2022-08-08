
namespace MaterialsAPI.Data.DAL.Repositories
{
    public interface IAuthorRepository
    {
        Task<ICollection<Author>> GetAll();
    }
}