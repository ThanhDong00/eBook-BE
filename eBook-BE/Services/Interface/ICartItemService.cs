using eBook_BE.Dtos.CartItem;

namespace eBook_BE.Services.Interface
{
    public interface ICartItemService
    {
        Task<CartItemDto> CreateCartItemAsync(CreateCartItemDto createCartItemDto);
        Task<List<CartItemDto>> GettAllCartItemsAsync();
        Task<List<CartItemDto>> GetCartItemsByCartIdAsync(Guid cartId);
        Task<CartItemDto> GetCartItemByIdAsync(Guid id);
        Task<CartItemDto> UpdateCartItemAsync(Guid id, UpdateCartItemDto updateCartItemDto);
        Task<CartItemDto> DeleteCartItemAsync(Guid id);
        Task<CartItemDto> GetCartItemByCartIdAndBookIdAsync(Guid cartId, Guid bookId);

    }
}
