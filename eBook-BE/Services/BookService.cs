using AutoMapper;
using eBook_BE.Data;
using eBook_BE.Dtos.Book;
using eBook_BE.Models;
using eBook_BE.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace eBook_BE.Services
{
    public class BookService : IBookService
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BookService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BookDto> CreateBookAsync(CreateBookDto createBookDto)
        {
            var book = _mapper.Map<Book>(createBookDto);

            var publisher = await _context.Publishers.FindAsync(createBookDto.PublisherId);
            if (publisher == null)
            {
                throw new KeyNotFoundException("Publisher not found");
            }

            book.Publisher = publisher;

            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return _mapper.Map<BookDto>(book);
        }

        public async Task<List<BookDto>> GetAllBooksAsync(BookFilterDto filterDto, int pageNumber, int pageSize)
        {
            //var books = await _context.Books
            //    .Where(b => !b.IsDeleted)
            //    .Include(b => b.Publisher)
            //    .Skip((pageNumber - 1) * pageSize)
            //    .Take(pageSize)
            //    .ToListAsync();

            //return _mapper.Map<List<BookDto>>(books);

            var query = _context.Books
                .Where(b => !b.IsDeleted)
                .Include(b => b.Publisher)
                .AsQueryable();

            if (filterDto.CategoryId.HasValue)
            {
                query = query.Where(b => b.BookCategories.Any(bc => bc.CategoryId == filterDto.CategoryId.Value));
            }

            if (filterDto.PublisherId.HasValue)
            {
                query = query.Where(b => b.PublisherId == filterDto.PublisherId.Value);
            }

            if (filterDto.MinPrice.HasValue)
            {
                query = query.Where(b => b.Price >= filterDto.MinPrice.Value);
            }

            if (filterDto.MaxPrice.HasValue)
            {
                query = query.Where(b => b.Price <= filterDto.MaxPrice.Value);
            }

            if (!string.IsNullOrEmpty(filterDto.Title))
            {
                query = query.Where(b => b.Title.Contains(filterDto.Title));
            }

            var books = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return _mapper.Map<List<BookDto>>(books);
        }

        public async Task<BookDto> GetBookByIdAsync(Guid id)
        {
            var book = await _context.Books
                .Include(b => b.Publisher)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                throw new KeyNotFoundException("Book not found");
            }

            return _mapper.Map<BookDto>(book);
        }

        public async Task<BookDto> UpdateBookAsync(Guid id, UpdateBookDto updateBookDto)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                throw new KeyNotFoundException("Book not found");
            }

            _mapper.Map(updateBookDto, book);

            var publisher = await _context.Publishers.FindAsync(updateBookDto.PublisherId);
            if (publisher == null)
            {
                throw new KeyNotFoundException("Publisher not found");
            }

            book.Publisher = publisher;

            await _context.SaveChangesAsync();

            return _mapper.Map<BookDto>(book);
        }

        public async Task<BookDto> DeleteBookAsync(Guid id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                throw new KeyNotFoundException("Book not found");
            }

            book.IsDeleted = true;
            await _context.SaveChangesAsync();

            return _mapper.Map<BookDto>(book);
        }
    }
}
