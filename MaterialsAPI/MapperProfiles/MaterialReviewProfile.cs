using MaterialsAPI.Data.Entities;
using MaterialsAPI.DTOs.MaterialReview;

namespace MaterialsAPI.MapperProfiles
{
    public class MaterialReviewProfile : Profile
    {
        public MaterialReviewProfile()
        {
            CreateMap<MaterialReview, MaterialReviewReadDTO>()
                .ForMember(mr => mr.MaterialName, opt => opt.MapFrom(mr => mr.Material.Title));
            CreateMap<MaterialReviewCreateUpdateDTO, MaterialReviewProfile>();
        }
    }
}
