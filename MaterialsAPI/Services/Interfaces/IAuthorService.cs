
namespace MaterialsAPI.Services
{
    public interface IAuthorService
    {
        Task<List<AuthorReadDTO>> GetAllAuthorsAsync();
        Task<AuthorReadDTO> GetAuthorAsync(int id);
        Task<List<MaterialReadDTO>> GetMaterialWithAverageMoreThanFiveByAuthorAsync(int id);
    }
}