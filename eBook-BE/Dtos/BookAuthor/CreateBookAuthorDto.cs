namespace eBook_BE.Dtos.BookAuthor
{
    public class CreateBookAuthorDto
    {
        public Guid BookId { get; set; }
        public Guid AuthorId { get; set; }
    }
}
