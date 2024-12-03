using eBook_BE.Dtos.Author;
using eBook_BE.Dtos.Category;
using eBook_BE.Dtos.Publisher;

namespace eBook_BE.Dtos.Book
{
    public class BookWithDetailsDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int PublicationYear { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string CoverImage { get; set; }
        public decimal DiscountPercentage { get; set; }
        public Guid PublisherId { get; set; }
        public PublisherDto Publisher { get; set; }
        public List<AuthorDto> Authors { get; set; }
        public List<CategoryDto> Categories { get; set; }
    }
}
