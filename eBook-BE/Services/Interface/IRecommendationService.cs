using eBook_BE.Dtos.Book;

namespace eBook_BE.Services.Interface
{
    public interface IRecommendationService
    {
        Task<List<BookDto>> GetRecommendedBooksAsync(Guid bookId);
    }
}
