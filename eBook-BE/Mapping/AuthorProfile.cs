using AutoMapper;
using eBook_BE.Dtos.Author;
using eBook_BE.Models;

namespace eBook_BE.Mapping
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<CreateAuthorDto, Author>();
            CreateMap<UpdateAuthorDto, Author>();
            CreateMap<Author, AuthorDto>();
        }
    }
}
