using eBook_BE.Dtos.Book;
using eBook_BE.Dtos.Category;

namespace eBook_BE.Dtos.BookCategory
{
    public class BookCategoryDto : BaseResponseDto
    {
        public Guid BookId { get; set; }
        public BookDto Book { get; set; }

        public Guid CategoryId { get; set; }
        public CategoryDto Category { get; set; }
    }
}
