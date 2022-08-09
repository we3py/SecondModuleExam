namespace MaterialsAPI.Data.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        public IAuthorRepository AuthorRepository { get; set; }
        public IMaterialReviewRepository MaterialReviewRepository { get; set; }
        public IMaterialsRepository MaterialsRepository { get; set; }
        public IRepository<MaterialType> MaterialTypesRepository { get; set; }

        public UnitOfWork(IAuthorRepository authorRepository, IMaterialReviewRepository materialReviewRepository, IMaterialsRepository materialsRepository, IRepository<MaterialType> materialTypesRepository)
        {
            AuthorRepository = authorRepository;
            MaterialReviewRepository = materialReviewRepository;
            MaterialsRepository = materialsRepository;
            MaterialTypesRepository = materialTypesRepository;
        }

    }
}
