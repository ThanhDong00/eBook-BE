namespace eBook_BE.Dtos.CartItem
{
    public class CreateCartItemDto
    {
        public int Quantity { get; set; }
        public decimal PriceAtTime { get; set; }
        public Guid CartId { get; set; }
        public Guid BookId { get; set; }
    }
}
