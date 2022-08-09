using MaterialsAPI.DTOs.User;

namespace MaterialsAPI.MapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRegisterDTO, User>();
        }
    }
}
