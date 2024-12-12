using AutoMapper;
using eBook_BE.Data;
using eBook_BE.Dtos.Book;
using eBook_BE.Dtos.Order;
using eBook_BE.Dtos.OrderItem;
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
            //var orders = await _context.Orders.Where(x => x.IsDeleted == false).ToListAsync();

            //return _mapper.Map<List<OrderDto>>(orders);

            var orders = await _context.Orders
                .Where(x => x.IsDeleted == false)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Book)
                .ToListAsync();

            var orderDtos = _mapper.Map<List<OrderDto>>(orders);
            foreach (var orderDto in orderDtos)
            {
                var order = orders.FirstOrDefault(o => o.Id == orderDto.Id);
                if (order != null)
                {
                    //orderDto.OrderItems = order.OrderItems.Select(oi => _mapper.Map<OrderItemDto>(oi)).ToList();
                    orderDto.OrderItems = order.OrderItems.Select(oi =>
                    {
                        var orderItemDto = _mapper.Map<OrderItemDto>(oi);
                        orderItemDto.Book = _mapper.Map<BookDto>(oi.Book);
                        return orderItemDto;
                    }).ToList();
                }
            }

            return orderDtos;
        }

        public async Task<List<OrderDto>> GetAllOrdersByUserId(Guid userId)
        {
            //var orders = await _context.Orders
            //    .Where(x => x.UserId == userId && x.IsDeleted == false)
            //    .ToListAsync();

            //return _mapper.Map<List<OrderDto>>(orders);

            var orders = await _context.Orders
                .Where(x => x.UserId == userId && x.IsDeleted == false)
                .Include(o => o.OrderItems)
                .ToListAsync();

            var orderDtos = _mapper.Map<List<OrderDto>>(orders);
            foreach (var orderDto in orderDtos)
            {
                var order = orders.FirstOrDefault(o => o.Id == orderDto.Id);
                if (order != null)
                {
                    orderDto.OrderItems = order.OrderItems.Select(oi => _mapper.Map<OrderItemDto>(oi)).ToList();
                }
            }

            return orderDtos;
        }

        public async Task<OrderDto> GetOrderByIdAsync(Guid id)
        {
            //var order = await _context.Orders
            //    .FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);

            //return _mapper.Map<OrderDto>(order);

            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);

            if (order == null)
            {
                throw new KeyNotFoundException("Order not found");
            }

            var orderDto = _mapper.Map<OrderDto>(order);
            orderDto.OrderItems = order.OrderItems.Select(oi => _mapper.Map<OrderItemDto>(oi)).ToList();

            return orderDto;
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
