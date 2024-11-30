using eBook_BE.Dtos.BookAuthor;

namespace eBook_BE.Services.Interface
{
    public interface IBookAuthorService
    {
        Task<BookAuthorDto> CreateBookAuthorAsync(CreateBookAuthorDto createBookAuthorDto);
        Task<List<BookAuthorDto>> GetAllBookAuthorAsync();
        Task<BookAuthorDto> GetBookAuthorByIdAsync(Guid id);
        Task<BookAuthorDto> UpdateBookAuthorByIdAsync(Guid id, UpdateBookAuthorDto updateBookAuthorDto);
        Task<BookAuthorDto> DeleteBookAuthorAsync(Guid id);
    }
}
