using AutoMapper;
using eBook_BE.Data;
using eBook_BE.Dtos.BookAuthor;
using eBook_BE.Dtos.BookCategory;
using eBook_BE.Models;
using eBook_BE.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace eBook_BE.Services
{
    public class BookCategoryService : IBookCategoryService
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BookCategoryService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BookCategoryDto> CreateBookCategoryAsync(CreateBookCategoryDto createBookCategoryDto)
        {
            var bookCategory = _mapper.Map<BookCategory>(createBookCategoryDto);

            var book = await _context.Books.FindAsync(createBookCategoryDto.BookId);
            if (book == null)
            {
                throw new KeyNotFoundException("Book not found");
            }

            var category = await _context.Categories.FindAsync(createBookCategoryDto.CategoryId);
            if (category == null)
            {
                throw new KeyNotFoundException("Category not found");
            }

            bookCategory.Book = book;
            bookCategory.Category = category;

            _context.BookCategories.Add(bookCategory);
            await _context.SaveChangesAsync();

            return _mapper.Map<BookCategoryDto>(bookCategory);
        }

        public async Task<List<BookCategoryDto>> GetAllBookCategoryAsync()
        {
            var bookCategories = await _context.BookCategories
                .Where(bc => !bc.IsDeleted)
                .Include(bc => bc.Book)
                .Include(bc => bc.Category)
                .ToListAsync();

            return _mapper.Map<List<BookCategoryDto>>(bookCategories);
        }

        public async Task<BookCategoryDto> GetBookCategoryByIdAsync(Guid id)
        {
            var bookCategory = await _context.BookCategories
                .Include(bc => bc.Book)
                .Include(bc => bc.Category)
                .FirstOrDefaultAsync(bc => bc.Id == id);

            if (bookCategory == null)
            {
                throw new KeyNotFoundException("BookCategory not found");
            }

            return _mapper.Map<BookCategoryDto>(bookCategory);
        }

        public async Task<BookCategoryDto> UpdateBookCategoryAsync(Guid id, UpdateBookCategoryDto updateBookCategoryDto)
        {
            var bookCategory = await _context.BookCategories.FindAsync(id);
            if (bookCategory == null)
            {
                throw new KeyNotFoundException("BookCategory not found");
            }

            var book = await _context.Books.FindAsync(updateBookCategoryDto.BookId);
            if (book == null)
            {
                throw new KeyNotFoundException("Book not found");
            }

            var category = await _context.Categories.FindAsync(updateBookCategoryDto.CategoryId);
            if (category == null)
            {
                throw new KeyNotFoundException("Category not found");
            }

            bookCategory.Book = book;
            bookCategory.Category = category;
            _mapper.Map(updateBookCategoryDto, bookCategory);

            await _context.SaveChangesAsync();

            return _mapper.Map<BookCategoryDto>(bookCategory);
        }

        public async Task<BookCategoryDto> DeleteBookCategoryAsync(Guid id)
        {
            var bookCategory = await _context.BookCategories.FindAsync(id);
            if (bookCategory == null)
            {
                throw new KeyNotFoundException("BookCategory not found");
            }

            bookCategory.IsDeleted = true;
            await _context.SaveChangesAsync();

            return _mapper.Map<BookCategoryDto>(bookCategory);
        }
    }
}
