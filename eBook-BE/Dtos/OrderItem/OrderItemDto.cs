using eBook_BE.Dtos.Book;
using eBook_BE.Dtos.Order;

namespace eBook_BE.Dtos.OrderItem
{
    public class OrderItemDto : BaseResponseDto
    {
        public int Quantity { get; set; }
        public decimal PriceAtTime { get; set; }

        public Guid OrderId { get; set; }
        public OrderDto Order { get; set; }

        public Guid BookId { get; set; }
        public BookDto Book { get; set; }
    }
}
