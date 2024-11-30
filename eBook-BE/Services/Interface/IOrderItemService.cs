using eBook_BE.Dtos.OrderItem;

namespace eBook_BE.Services.Interface
{
    public interface IOrderItemService
    {
        Task<List<OrderItemDto>> GetAllOrderItemsAsync();
        Task<OrderItemDto> GetOrderItemByIdAsync(Guid id);
        Task<List<OrderItemDto>> GetOrderItemsByOrderId(Guid orderId);
        Task<OrderItemDto> CreateOrderItemAsync(CreateOrderItemDto createOrderItemDto);

        // not update order item
        //Task<OrderItemDto> UpdateOrderItemAsync(Guid id, UpdateOrderItemDto updatedOrderItem);
        Task<OrderItemDto> DeleteOrderItemAsync(Guid id);
    }
}
