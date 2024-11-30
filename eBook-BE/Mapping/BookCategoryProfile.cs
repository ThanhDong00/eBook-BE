using AutoMapper;
using eBook_BE.Dtos.BookCategory;
using eBook_BE.Models;

namespace eBook_BE.Mapping
{
    public class BookCategoryProfile : Profile
    {
        public BookCategoryProfile()
        {
            CreateMap<BookCategory, BookCategoryDto>();
            CreateMap<CreateBookCategoryDto, BookCategory>();
            CreateMap<UpdateBookCategoryDto, BookCategory>();
        }
    }
}
