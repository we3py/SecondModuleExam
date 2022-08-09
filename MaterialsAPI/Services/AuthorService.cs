using MaterialsAPI.Data.DAL.Interfaces;

namespace MaterialsAPI.Services
{
    public class AuthorService : IAuthorService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public AuthorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<AuthorReadDTO>> GetAllAuthorsAsync()
        {
            List<Task<AuthorReadDTO>> tasks = new List<Task<AuthorReadDTO>>();
            var authors = await _unitOfWork.AuthorRepository.GetAll();

            if (authors == null)
                throw new ArgumentNullException("Authors not exist");

            foreach (var author in authors)
            {
                tasks.Add(Task.Run(() => _mapper.Map<AuthorReadDTO>(author)));
            }

            var results = await Task.WhenAll(tasks);
            return results.ToList();
        }

        public async Task<AuthorReadDTO> GetAuthorAsync(int id)
        {
            var author = await _unitOfWork.AuthorRepository.GetByIdWithMaterialsAndReviews(id);

            if (author == default)
                throw new KeyNotFoundException("Author not exist");

            return _mapper.Map<AuthorReadDTO>(author);
        }

        public async Task<List<MaterialReadDTO>> GetMaterialWithAverageMoreThanFiveByAuthorAsync(int id)
        {
            var author = await _unitOfWork.AuthorRepository.GetByIdWithMaterialsAndReviews(id);

            if (author == default)
                throw new KeyNotFoundException("Author not exist");
            else if (author.Materials == null)
                throw new NullReferenceException("Author has not materials");

            var materials = new List<MaterialReadDTO>();

            foreach (var material in author.Materials)
            {
                if (material.Reviews == null)
                    continue;

                if (material.Reviews.Average(m => m.Rating) > 5)
                    materials.Add(_mapper.Map<MaterialReadDTO>(material));
            }

            if (author.Materials == null)
                throw new NullReferenceException("Author has not materials with average rating more than 5");

            return materials;
        }
    }
}
