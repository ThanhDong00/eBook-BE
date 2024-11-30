using eBook_BE.Dtos.BookCategory;

namespace eBook_BE.Services.Interface
{
    public interface IBookCategoryService
    {
        Task<BookCategoryDto> CreateBookCategoryAsync(CreateBookCategoryDto createBookCategoryDto);
        Task<List<BookCategoryDto>> GetAllBookCategoryAsync();
        Task<BookCategoryDto> GetBookCategoryByIdAsync(Guid id);
        Task<BookCategoryDto> UpdateBookCategoryAsync(Guid id, UpdateBookCategoryDto updateBookCategoryDto);
        Task<BookCategoryDto> DeleteBookCategoryAsync(Guid id);
    }
}
