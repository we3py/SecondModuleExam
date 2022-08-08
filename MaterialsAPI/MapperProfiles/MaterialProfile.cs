namespace MaterialsAPI.MapperProfiles
{
    public class MaterialProfile : Profile
    {
        public MaterialProfile()
        {
            CreateMap<Material, MaterialReadDTO>()
                .ForMember(m => m.AuthorName, opt => opt.MapFrom(m => m.Author.AuthorName))
                .ForMember(m => m.MaterialTypeName, opt => opt.MapFrom(m => m.MaterialType.Name));
            CreateMap<MaterialCreateUpdateDTO, Material>();
        }
    }
}
