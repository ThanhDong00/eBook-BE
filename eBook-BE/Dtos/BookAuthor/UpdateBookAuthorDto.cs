namespace eBook_BE.Dtos.BookAuthor
{
    public class UpdateBookAuthorDto
    {
        public Guid BookId { get; set; }
        public Guid AuthorId { get; set; }
    }
}
