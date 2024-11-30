using AutoMapper;
using eBook_BE.Data;
using eBook_BE.Dtos.Order;
using eBook_BE.Models;
using eBook_BE.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace eBook_BE.Services
{
    public class OrderService : IOrderService
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public OrderService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrderDto> CreateOrderAsync(CreateOrderDto createOrderDto)
        {
            var order = _mapper.Map<Order>(createOrderDto);

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return _mapper.Map<OrderDto>(order);
        }

        public async Task<List<OrderDto>> GetAllOrdersAsync()
        {
            var orders = await _context.Orders.Where(x => x.IsDeleted == false).ToListAsync();

            return _mapper.Map<List<OrderDto>>(orders);
        }

        public async Task<List<OrderDto>> GetAllOrdersByUserId(Guid userId)
        {
            var orders = await _context.Orders
                .Where(x => x.UserId == userId && x.IsDeleted == false)
                .ToListAsync();

            return _mapper.Map<List<OrderDto>>(orders);
        }

        public async Task<OrderDto> GetOrderByIdAsync(Guid id)
        {
            var order = await _context.Orders
                .FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);

            return _mapper.Map<OrderDto>(order);
        }

        public async Task<OrderDto> UpdateOrderAsync(Guid id, UpdateOrderDto updateOrderDto)
        {
            var order = await _context.Orders
                .FirstOrDefaultAsync(x => x.Id == id);
            if (order == null)
            {
                throw new KeyNotFoundException("Order not found");
            }

            _mapper.Map(updateOrderDto, order);
            await _context.SaveChangesAsync();

            return _mapper.Map<OrderDto>(order);
        }

        public async Task<OrderDto> DeleteOrderAsync(Guid id)
        {
            var order = await _context.Orders
                .FirstOrDefaultAsync(x => x.Id == id);
            if (order == null)
            {
                throw new KeyNotFoundException("Order not found");
            }

            order.IsDeleted = true;
            await _context.SaveChangesAsync();

            return _mapper.Map<OrderDto>(order);
        }
    }
}
