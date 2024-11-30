namespace eBook_BE.Dtos.Book
{
    public class BookFilterDto
    {
        public Guid? CategoryId { get; set; }
        public Guid? PublisherId { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string? Title { get; set; }
    }
}
