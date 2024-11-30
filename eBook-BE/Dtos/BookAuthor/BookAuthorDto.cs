using eBook_BE.Dtos.Author;
using eBook_BE.Dtos.Book;

namespace eBook_BE.Dtos.BookAuthor
{
    public class BookAuthorDto : BaseResponseDto
    {
        public Guid BookId { get; set; }
        public BookDto Book { get; set; }

        public Guid AuthorId { get; set; }
        public AuthorDto Author { get; set; }
    }
}
