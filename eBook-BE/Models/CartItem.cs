namespace eBook_BE.Models
{
    public class CartItem : BaseEntity
    {
        public int Quantity { get; set; }
        public decimal PriceAtTime { get; set; }

        public Guid CartId { get; set; }
        public Cart Cart { get; set; }

        public Guid BookId { get; set; }
        public Book Book { get; set; }
    }
}
