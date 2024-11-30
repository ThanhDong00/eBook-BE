using eBook_BE.Dtos.Cart;

namespace eBook_BE.Services.Interface
{
    public interface ICartService
    {
        Task<CartDto> GetCartByIdAsync(Guid id);
        Task<CartDto> GetCartByUserIdAsync(Guid userId);
        Task<CartDto> CreateCartAsync(CreateCartDto createCartDto);

        // Update cart is not neccessary, so not implemented
        Task<CartDto> UpdateCartAsync(Guid id, UpdateCartDto updateCartDto);
        Task<CartDto> DeleteCartAsync(Guid id);
    }
}
