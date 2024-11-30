namespace eBook_BE.Dtos.OrderItem
{
    public class CreateOrderItemDto
    {
        public int Quantity { get; set; }
        public decimal PriceAtTime { get; set; }
        public Guid OrderId { get; set; }
        public Guid BookId { get; set; }
    }
}
