namespace MaterialsAPI.Services
{
    public class EducationMaterialService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public EducationMaterialService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<MaterialReadDTO>> GetAllMaterials()
        {
            List<Task<MaterialReadDTO>> tasks = new List<Task<MaterialReadDTO>>();
            var materials = await _unitOfWork.MaterialsRepository.GetMaterials();

            if (materials == null)
                throw new ArgumentNullException("Materials not exist");

            foreach (var material in materials)
            {
                tasks.Add(Task.Run(() => _mapper.Map<MaterialReadDTO>(material)));
            }

            var results = await Task.WhenAll(tasks);
            return results.ToList();
        }

        public async Task<MaterialReadDTO> GetMaterial(int materialId)
        {
            var material = await _unitOfWork.MaterialsRepository.GetMaterialById(materialId);

            if (material == default)
                throw new KeyNotFoundException("Material not exist");

            return _mapper.Map<MaterialReadDTO>(material);
        }

        public async Task<int> AddMaterial(MaterialCreateUpdateDTO materialToAdd)
        {
            var material = _mapper.Map<Material>(materialToAdd);
            await _unitOfWork.MaterialsRepository.AddAsync(material);
            await _unitOfWork.MaterialsRepository.SaveAsync();

            return material.Id;
        }

        public async Task<int> UpdateMaterial(int materialToUpdateId, MaterialCreateUpdateDTO updatedMaterial)
        {
            var material = await _unitOfWork.MaterialsRepository.GetMaterialById(materialToUpdateId);
            if (material == null)
                throw new KeyNotFoundException("Material not exist");

            var editedMaterial = _mapper.Map(updatedMaterial, material);
             
             _unitOfWork.MaterialsRepository.Update(editedMaterial);
            await _unitOfWork.MaterialsRepository.SaveAsync();

            return editedMaterial.Id;
        }

        public async Task<int> DeleteMaterial(int materialId)
        {
            var material = await _unitOfWork.MaterialsRepository.GetEntityAsync(materialId);
            if (material == null)
                throw new KeyNotFoundException("Material dont exist");

            _unitOfWork.MaterialsRepository.Delete(material);
            await _unitOfWork.MaterialsRepository.SaveAsync();

            return materialId;
        }

    }
}
