using eBook_BE.Dtos.Book;
using eBook_BE.Dtos.Category;

namespace eBook_BE.Dtos.BookCategory
{
    public class CreateBookCategoryDto
    {
        public Guid BookId { get; set; }

        public Guid CategoryId { get; set; }
    }
}
