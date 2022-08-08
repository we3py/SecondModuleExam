using AutoMapper;
using MaterialsAPI.Data.Entities;
using MaterialsAPI.DTOs.Author;

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
