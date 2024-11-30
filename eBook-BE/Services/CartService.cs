﻿using AutoMapper;
using eBook_BE.Data;
using eBook_BE.Dtos.Cart;
using eBook_BE.Models;
using eBook_BE.Services.Interface;

namespace eBook_BE.Services
{
    public class CartService : ICartService
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CartService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CartDto> CreateCartAsync(CreateCartDto createCartDto)
        {
            var cart = _mapper.Map<Cart>(createCartDto);

            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();

            return _mapper.Map<CartDto>(cart);
        }

        public async Task<CartDto> GetCartByIdAsync(Guid id)
        {
            var cart = await _context.Carts.FindAsync(id);

            if (cart == null)
            {
                throw new KeyNotFoundException("Cart not found");
            }

            return _mapper.Map<CartDto>(cart);
        }

        public async Task<CartDto> GetCartByUserIdAsync(Guid userId)
        {
            var cart = await _context.Carts.FindAsync(userId);
            if (cart == null)
            {
                throw new KeyNotFoundException("Cart not found");
            }
            return _mapper.Map<CartDto>(cart);
        }

        public Task<CartDto> UpdateCartAsync(Guid id, UpdateCartDto updateCartDto)
        {
            throw new NotImplementedException();
        }

        public async Task<CartDto> DeleteCartAsync(Guid id)
        {
            var cart = await _context.Carts.FindAsync(id);
            if (cart == null)
            {
                throw new KeyNotFoundException("Cart not found");
            }

            cart.IsDeleted = true;
            await _context.SaveChangesAsync();

            return _mapper.Map<CartDto>(cart);
        }
    }
}