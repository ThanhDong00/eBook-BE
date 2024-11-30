namespace eBook_BE.Models
{
    public class OrderItem : BaseEntity
    {
        public int Quantity { get; set; }
        public decimal PriceAtTime { get; set; }

        public Guid OrderId { get; set; }
        public Order Order { get; set; }

        public Guid BookId { get; set; }
        public Book Book { get; set; }
    }
}
