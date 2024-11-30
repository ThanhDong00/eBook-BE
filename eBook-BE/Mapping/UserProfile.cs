using AutoMapper;
using eBook_BE.Dtos.User;
using eBook_BE.Models;

namespace eBook_BE.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserApplication, UserDto>();
        }
    }
}
