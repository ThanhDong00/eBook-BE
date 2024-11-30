namespace eBook_BE.Models
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int PublicationYear { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string CoverImage { get; set; }
        public decimal DiscountPercentage { get; set; } = 0;

        public Guid PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }
        public ICollection<BookCategory> BookCategories { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
