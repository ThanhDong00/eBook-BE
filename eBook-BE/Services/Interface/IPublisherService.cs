using eBook_BE.Dtos.Category;
using eBook_BE.Dtos.Publisher;

namespace eBook_BE.Services.Interface
{
    public interface IPublisherService
    {
        Task<List<PublisherDto>> GetAllPublisherAsync();
        Task<PublisherDto> GetPublisherByIdAsync(Guid id);
        Task<PublisherDto> CreatePublisherAsync(CreatePublisherDto createPublisherDto);
        Task<PublisherDto> UpdatePublisherAsync(Guid id, UpdatePublisherDto updatePublisherDto);
        Task<PublisherDto> DeletePublisherAsync(Guid id);
    }
}
