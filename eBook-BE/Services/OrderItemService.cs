using AutoMapper;
using eBook_BE.Data;
using eBook_BE.Dtos.OrderItem;
using eBook_BE.Models;
using eBook_BE.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace eBook_BE.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public OrderItemService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrderItemDto> CreateOrderItemAsync(CreateOrderItemDto createOrderItemDto)
        {
            var orderItem = _mapper.Map<OrderItem>(createOrderItemDto);

            _context.OrderItems.Add(orderItem);
            await _context.SaveChangesAsync();

            return _mapper.Map<OrderItemDto>(orderItem);
        }

        public async Task<List<OrderItemDto>> GetAllOrderItemsAsync()
        {
            var orderItems = await _context.OrderItems
                .Where(o => !o.IsDeleted)
                .ToListAsync();

            return _mapper.Map<List<OrderItemDto>>(orderItems);
        }

        public async Task<OrderItemDto> GetOrderItemByIdAsync(Guid id)
        {
            var orderItem = await _context.OrderItems.FindAsync(id);

            if (orderItem == null)
            {
                throw new KeyNotFoundException("OrderItem not found");
            }

            return _mapper.Map<OrderItemDto>(orderItem);
        }

        public async Task<List<OrderItemDto>> GetOrderItemsByOrderId(Guid orderId)
        {
            var orderItems = await _context.OrderItems
                .Where(o => o.OrderId == orderId && !o.IsDeleted)
                .ToListAsync();

            return _mapper.Map<List<OrderItemDto>>(orderItems);
        }

        public async Task<OrderItemDto> DeleteOrderItemAsync(Guid id)
        {
            var orderItem = await _context.OrderItems.FindAsync(id);

            if (orderItem == null)
            {
                throw new KeyNotFoundException("OrderItem not found");
            }

            orderItem.IsDeleted = true;
            await _context.SaveChangesAsync();

            return _mapper.Map<OrderItemDto>(orderItem);
        }
    }
}
