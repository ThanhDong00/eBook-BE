using AutoMapper;
using eBook_BE.Dtos.CartItem;
using eBook_BE.Models;

namespace eBook_BE.Mapping
{
    public class CartItemProfile : Profile
    {
        public CartItemProfile()
        {
            CreateMap<CartItem, CartItemDto>()
                .ForMember(dest => dest.Cart, opt => opt.MapFrom(src => src.Cart))
                .ForMember(dest => dest.Book, opt => opt.MapFrom(src => src.Book));
            CreateMap<CreateCartItemDto, CartItem>();
            CreateMap<UpdateCartItemDto, CartItem>();
        }
    }
}
