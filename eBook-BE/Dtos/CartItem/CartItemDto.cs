using eBook_BE.Dtos.Book;
using eBook_BE.Dtos.Cart;

namespace eBook_BE.Dtos.CartItem
{
    public class CartItemDto : BaseResponseDto
    {
        public int Quantity { get; set; }
        public decimal PriceAtTime { get; set; }

        public Guid CartId { get; set; }
        public CartDto Cart { get; set; }

        public Guid BookId { get; set; }
        public BookDto Book { get; set; }
    }
}
