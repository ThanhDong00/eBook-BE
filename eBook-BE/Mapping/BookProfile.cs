using AutoMapper;
using eBook_BE.Dtos.Book;
using eBook_BE.Dtos.Publisher;
using eBook_BE.Models;

namespace eBook_BE.Mapping
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<CreateBookDto, Book>();
            CreateMap<UpdateBookDto, Book>();
            CreateMap<Book, BookDto>();
        }
    }
}
