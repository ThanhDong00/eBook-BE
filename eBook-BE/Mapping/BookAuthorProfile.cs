using AutoMapper;
using eBook_BE.Dtos.BookAuthor;
using eBook_BE.Models;

namespace eBook_BE.Mapping
{
    public class BookAuthorProfile : Profile
    {
        public BookAuthorProfile()
        {
            CreateMap<BookAuthor, BookAuthorDto>();

            CreateMap<CreateBookAuthorDto, BookAuthor>();

            CreateMap<UpdateBookAuthorDto, BookAuthor>();
        }
    }
}
