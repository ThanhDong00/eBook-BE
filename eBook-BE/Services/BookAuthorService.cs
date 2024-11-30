using AutoMapper;
using eBook_BE.Data;
using eBook_BE.Dtos.BookAuthor;
using eBook_BE.Models;
using eBook_BE.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace eBook_BE.Services
{
    public class BookAuthorService : IBookAuthorService
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BookAuthorService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<BookAuthorDto> CreateBookAuthorAsync(CreateBookAuthorDto createBookAuthorDto)
        {
            var bookAuthor = _mapper.Map<BookAuthor>(createBookAuthorDto);

            var book = await _context.Books.FindAsync(createBookAuthorDto.BookId);
            if (book == null)
            {
                throw new KeyNotFoundException("Book not found");
            }

            var author = await _context.Authors.FindAsync(createBookAuthorDto.AuthorId);
            if (author == null)
            {
                throw new KeyNotFoundException("Author not found");
            }

            bookAuthor.Book = book;
            bookAuthor.Author = author;

            _context.BookAuthors.Add(bookAuthor);
            await _context.SaveChangesAsync();

            return _mapper.Map<BookAuthorDto>(bookAuthor);
        }

        public async Task<List<BookAuthorDto>> GetAllBookAuthorAsync()
        {
            var bookAuthors = await _context.BookAuthors
                .Where(ba => !ba.IsDeleted)
                .Include(ba => ba.Book)
                .Include(ba => ba.Author)
                .ToListAsync();

            return _mapper.Map<List<BookAuthorDto>>(bookAuthors);
        }

        public async Task<BookAuthorDto> GetBookAuthorByIdAsync(Guid id)
        {
            var bookAuthor = await _context.BookAuthors
                .Include(ba => ba.Book)
                .Include(ba => ba.Author)
                .FirstOrDefaultAsync(ba => ba.Id == id);

            if (bookAuthor == null)
            {
                throw new KeyNotFoundException("BookAuthor not found");
            }

            return _mapper.Map<BookAuthorDto>(bookAuthor);
        }

        public async Task<BookAuthorDto> UpdateBookAuthorByIdAsync(Guid id, UpdateBookAuthorDto updateBookAuthorDto)
        {
            var bookAuthor = await _context.BookAuthors.FindAsync(id);
            if (bookAuthor == null)
            {
                throw new KeyNotFoundException("BookAuthor not found");
            }

            var book = await _context.Books.FindAsync(updateBookAuthorDto.BookId);
            if (book == null)
            {
                throw new KeyNotFoundException("Book not found");
            }

            var author = await _context.Authors.FindAsync(updateBookAuthorDto.AuthorId);
            if (author == null)
            {
                throw new KeyNotFoundException("Author not found");
            }

            bookAuthor.Book = book;
            bookAuthor.Author = author;
            _mapper.Map(updateBookAuthorDto, bookAuthor);

            await _context.SaveChangesAsync();

            return _mapper.Map<BookAuthorDto>(bookAuthor);
        }

        public async Task<BookAuthorDto> DeleteBookAuthorAsync(Guid id)
        {
            var bookAuthor = await _context.BookAuthors.FindAsync(id);
            if (bookAuthor == null)
            {
                throw new KeyNotFoundException("BookAuthor not found");
            }

            bookAuthor.IsDeleted = true;
            await _context.SaveChangesAsync();

            return _mapper.Map<BookAuthorDto>(bookAuthor);
        }
    }
}
