﻿using eBook_BE.Dtos.Book;

namespace eBook_BE.Services.Interface
{
    public interface IBookService
    {
        //Task<BookWithDetailsDto> GetBookWithDetailsAsync(Guid id);

        Task<List<BookDto>> GetAllBooksAsync(BookFilterDto bookFilterDto, int pageNumber, int pageSize);
        Task<BookDto> GetBookByIdAsync(Guid id);
        Task<BookDto> CreateBookAsync(CreateBookDto createBookDto);
        Task<BookDto> UpdateBookAsync(Guid id, UpdateBookDto updateBookDto);
        Task<BookDto> DeleteBookAsync(Guid id);
        Task<BookDto> UpdateBookStockQuantityAsync(Guid id, UpdateBookQuantity updateBookQuantity);
    }
}
