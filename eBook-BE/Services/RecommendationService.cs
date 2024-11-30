using AutoMapper;
using eBook_BE.Data;
using eBook_BE.Dtos.Book;
using eBook_BE.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace eBook_BE.Services
{
    public class RecommendationService : IRecommendationService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public RecommendationService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<BookDto>> GetRecommendedBooksAsync(Guid bookId)
        {
            var book = await _context.Books
                .Include(b => b.Publisher)
                .Include(b => b.BookCategories)
                .ThenInclude(bc => bc.Category)
                .FirstOrDefaultAsync(b => b.Id == bookId);

            if (book == null)
            {
                throw new KeyNotFoundException("Book not found");
            }

            var recommendedBooks = await _context.Books
                .Where(b => b.Id != bookId && !b.IsDeleted)
                .Include(b => b.Publisher)
                .Include(b => b.BookCategories)
                .ThenInclude(bc => bc.Category)
                .ToListAsync();

            // Simple content-based filtering: recommend books with the same publisher or category
            var filteredBooks = recommendedBooks
                .Where(b => b.PublisherId == book.PublisherId ||
                            b.BookCategories.Any(bc => book.BookCategories.Select(c => c.CategoryId).Contains(bc.CategoryId)))
                .ToList();

            // If less than 5 books are found, add more books to meet the minimum requirement
            if (filteredBooks.Count < 5)
            {
                var additionalBooks = recommendedBooks
                    .Where(b => !filteredBooks.Contains(b))
                    .Take(5 - filteredBooks.Count)
                    .ToList();

                filteredBooks.AddRange(additionalBooks);
            }

            return _mapper.Map<List<BookDto>>(filteredBooks.Take(5).ToList());
        }
    }
}
