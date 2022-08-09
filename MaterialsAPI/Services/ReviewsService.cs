using MaterialsAPI.Data.DAL.Interfaces;
using MaterialsAPI.Services.Interfaces;

namespace MaterialsAPI.Services
{
    public class ReviewsService : IReviewsService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public ReviewsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<MaterialReviewReadDTO>> GetAllMaterialReviewsAsync()
        {
            List<Task<MaterialReviewReadDTO>> tasks = new List<Task<MaterialReviewReadDTO>>();
            var materialReviews = await _unitOfWork.MaterialReviewRepository.GetAll();

            if (materialReviews == null)
                throw new ArgumentNullException("Material reviews not exist");

            foreach (var materialReview in materialReviews)
            {
                tasks.Add(Task.Run(() => _mapper.Map<MaterialReviewReadDTO>(materialReview)));
            }

            var results = await Task.WhenAll(tasks);
            return results.ToList();
        }

        public async Task<MaterialReviewReadDTO> GetMaterialReviewAsync(int materialId)
        {
            var materialReview = await _unitOfWork.MaterialReviewRepository.GetById(materialId);

            if (materialReview == default)
                throw new KeyNotFoundException("Material review not exist");

            return _mapper.Map<MaterialReviewReadDTO>(materialReview);
        }

        public async Task<int> AddMaterialReviewAsync(MaterialReviewCreateUpdateDTO materialReviewToAdd)
        {
            var materialReview = _mapper.Map<MaterialReview>(materialReviewToAdd);
            await _unitOfWork.MaterialReviewRepository.AddAsync(materialReview);
            await _unitOfWork.MaterialReviewRepository.SaveAsync();

            return materialReview.Id;
        }

        public async Task<int> UpdateMaterialReviewAsync(int materialReviewToUpdateId, MaterialReviewCreateUpdateDTO updatedMaterialReview)
        {
            var materialReview = await _unitOfWork.MaterialReviewRepository.GetById(materialReviewToUpdateId);
            if (materialReview == null)
                throw new KeyNotFoundException("Material review not exist");

            var editedMaterialReview = _mapper.Map(updatedMaterialReview, materialReview);

            _unitOfWork.MaterialReviewRepository.Update(editedMaterialReview);
            await _unitOfWork.MaterialReviewRepository.SaveAsync();

            return editedMaterialReview.Id;
        }

        public async Task<int> DeleteMaterialReviewAsync(int materialReviewId)
        {
            var materialReview = await _unitOfWork.MaterialReviewRepository.GetEntityAsync(materialReviewId);
            if (materialReview == null)
                throw new KeyNotFoundException("Material dont exist");

            _unitOfWork.MaterialReviewRepository.Delete(materialReview);
            await _unitOfWork.MaterialReviewRepository.SaveAsync();

            return materialReviewId;
        }
    }
}
