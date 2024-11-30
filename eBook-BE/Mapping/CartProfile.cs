using AutoMapper;
using eBook_BE.Dtos.Cart;
using eBook_BE.Models;

namespace eBook_BE.Mapping
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<Cart, CartDto>();
            CreateMap<CreateCartDto, Cart>();
            CreateMap<UpdateCartDto, Cart>();
        }
    }
}
