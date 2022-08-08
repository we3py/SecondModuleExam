
using MaterialsAPI.Data.Entities;
using MaterialsAPI.DTOs.MaterialType;

namespace MaterialsAPI.MapperProfiles
{
    public class MaterialTypeProfile : Profile
    {
        public MaterialTypeProfile()
        {
            CreateMap<MaterialType, MaterialTypeReadDTO>();
            CreateMap<MaterialTypeCreateUpdateDTO, MaterialType>();
        }
    }
}
