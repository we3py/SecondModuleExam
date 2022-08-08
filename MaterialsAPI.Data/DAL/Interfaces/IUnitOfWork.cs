
namespace MaterialsAPI.Data.DAL
{
    public interface IUnitOfWork
    {
        IAuthorRepository AuthorRepository { get; set; }
        IMaterialReviewRepository MaterialReviewRepository { get; set; }
        IMaterialsRepository MaterialsRepository { get; set; }
    }
}