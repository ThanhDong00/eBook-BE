using eBook_BE.Dtos.OrderItem;
using eBook_BE.Models;

namespace eBook_BE.Dtos.Order
{
    public class OrderDto : BaseResponseDto
    {
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } 

        public Guid UserId { get; set; }
        public UserApplication User { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }
}
