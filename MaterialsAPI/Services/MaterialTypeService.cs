using MaterialsAPI.Data.DAL.Interfaces;

namespace MaterialsAPI.Services
{
    public class MaterialTypeService : IMaterialTypeService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public MaterialTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<MaterialTypeReadDTO>> GetAllMaterialTypes()
        {
            List<Task<MaterialTypeReadDTO>> tasks = new List<Task<MaterialTypeReadDTO>>();
            var materialTypes = await _unitOfWork.MaterialTypesRepository.GetAll();

            if (materialTypes == null)
                throw new ArgumentNullException("Materials not exist");

            foreach (var materialType in materialTypes)
            {
                tasks.Add(Task.Run(() => _mapper.Map<MaterialTypeReadDTO>(materialType)));
            }

            var results = await Task.WhenAll(tasks);
            return results.ToList();
        }

        public async Task<MaterialTypeReadDTO> GetMaterialTypeAsync(int materialTypeId)
        {
            var materialType = await _unitOfWork.MaterialTypesRepository.GetEntityAsync(materialTypeId);

            if (materialType == default)
                throw new KeyNotFoundException("Material type not exist");

            return _mapper.Map<MaterialTypeReadDTO>(materialType);
        }

        public async Task<List<MaterialReadDTO>> GetMaterialsByTypeAsync(int materialTypeId)
        {
            var materials = await _unitOfWork.MaterialsRepository.GetMaterialsByType(materialTypeId);

            if (materials.Count == 0)
                throw new KeyNotFoundException("Material type not exist");

            return _mapper.Map<List<MaterialReadDTO>>(materials);
        }
    }
}
