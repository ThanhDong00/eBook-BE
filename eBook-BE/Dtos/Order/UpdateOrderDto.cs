using eBook_BE.Models;

namespace eBook_BE.Dtos.Order
{
    public class UpdateOrderDto
    {
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
    }
}
