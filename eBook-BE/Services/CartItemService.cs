using AutoMapper;
using eBook_BE.Data;
using eBook_BE.Dtos.CartItem;
using eBook_BE.Models;
using eBook_BE.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace eBook_BE.Services
{
    public class CartItemService : ICartItemService
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CartItemService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<CartItemDto> CreateCartItemAsync(CreateCartItemDto createCartItemDto)
        {
            var cartItem = _mapper.Map<CartItem>(createCartItemDto);

            _context.CartItems.Add(cartItem);
            await _context.SaveChangesAsync();

            return _mapper.Map<CartItemDto>(cartItem);
        }

        public async Task<CartItemDto> GetCartItemByIdAsync(Guid id)
        {
            var cartItem = await _context.CartItems.FindAsync(id);
            if (cartItem == null)
            {
                throw new KeyNotFoundException("CartItem not found");
            }

            return _mapper.Map<CartItemDto>(cartItem);
        }

        public async Task<List<CartItemDto>> GetCartItemsByCartIdAsync(Guid cartId)
        {
            var cartItems = await _context.CartItems
                .Where(c => c.CartId == cartId && !c.IsDeleted)
                .ToListAsync();

            return _mapper.Map<List<CartItemDto>>(cartItems);
        }

        public async Task<List<CartItemDto>> GettAllCartItemsAsync()
        {
            var cartItems = await _context.CartItems.Where(c => !c.IsDeleted).ToListAsync();

            return _mapper.Map<List<CartItemDto>>(cartItems);
        }

        public async Task<CartItemDto> UpdateCartItemAsync(Guid id, UpdateCartItemDto updateCartItemDto)
        {
            var cartItem = await _context.CartItems.FindAsync(id);
            if (cartItem == null)
            {
                throw new KeyNotFoundException("CartItem not found");
            }

            cartItem.Quantity += updateCartItemDto.Quantity;
            cartItem.PriceAtTime = updateCartItemDto.PriceAtTime;
            await _context.SaveChangesAsync();

            return _mapper.Map<CartItemDto>(cartItem);
        }

        public async Task<CartItemDto> DeleteCartItemAsync(Guid id)
        {
            var cartItem = await _context.CartItems.FindAsync(id);
            if (cartItem == null)
            {
                throw new KeyNotFoundException("CartItem not found");
            }

            cartItem.IsDeleted = true;
            await _context.SaveChangesAsync();

            return _mapper.Map<CartItemDto>(cartItem);
        }
    }
}
