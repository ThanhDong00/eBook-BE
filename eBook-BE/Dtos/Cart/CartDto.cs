using eBook_BE.Dtos.CartItem;

namespace eBook_BE.Dtos.Cart
{
    public class CartDto : BaseResponseDto
    {
        public Guid UserId { get; set; }
        //public UserApplicationDto User { get; set; }
        public List<CartItemDto> CartItems { get; set; }
    }
}
