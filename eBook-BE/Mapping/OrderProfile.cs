using AutoMapper;
using eBook_BE.Dtos.Order;
using eBook_BE.Models;

namespace eBook_BE.Mapping
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User));
            CreateMap<CreateOrderDto, Order>();
            CreateMap<UpdateOrderDto, Order>();
        }
    }
}
