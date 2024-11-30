using AutoMapper;
using eBook_BE.Dtos.Publisher;
using eBook_BE.Models;

namespace eBook_BE.Mapping
{
    public class PublisherProfile : Profile
    {
        public PublisherProfile()
        {
            CreateMap<CreatePublisherDto, Publisher>();
            CreateMap<UpdatePublisherDto, Publisher>();
            CreateMap<Publisher, PublisherDto>();
        }
    }
}
