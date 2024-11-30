using AutoMapper;
using eBook_BE.Dtos.OrderItem;
using eBook_BE.Models;

namespace eBook_BE.Mapping
{
    public class OrderItemProfile : Profile
    {
        public OrderItemProfile()
        {
            CreateMap<OrderItem, OrderItemDto>();
            CreateMap<CreateOrderItemDto, OrderItem>();
            CreateMap<UpdateOrderItemDto, OrderItem>();
        }
    }
}
