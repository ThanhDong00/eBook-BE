namespace eBook_BE.Dtos.Book
{
    public class UpdateBookDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int PublicationYear { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string CoverImage { get; set; }
        public decimal DiscountPercentage { get; set; }
        public Guid PublisherId { get; set; }
    }
}
