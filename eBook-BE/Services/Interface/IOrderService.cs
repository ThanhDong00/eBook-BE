using eBook_BE.Dtos.Order;

namespace eBook_BE.Services.Interface
{
    public interface IOrderService
    {
        Task<OrderDto> CreateOrderAsync(CreateOrderDto createOrderDto);
        Task<List<OrderDto>> GetAllOrdersAsync();
        Task<OrderDto> GetOrderByIdAsync(Guid id);
        Task<List<OrderDto>> GetAllOrdersByUserId(Guid userId);
        Task<OrderDto> UpdateOrderAsync(Guid id, UpdateOrderDto updateOrderDto);
        Task<OrderDto> DeleteOrderAsync(Guid id);

    }
}
