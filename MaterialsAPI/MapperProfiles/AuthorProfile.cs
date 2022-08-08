namespace MaterialsAPI.MapperProfiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorReadDTO>();
            CreateMap<AuthorCreateUpdateDTO, Author>();
        }
    }
}
