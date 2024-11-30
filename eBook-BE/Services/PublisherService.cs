using AutoMapper;
using eBook_BE.Data;
using eBook_BE.Dtos.Category;
using eBook_BE.Dtos.Publisher;
using eBook_BE.Models;
using eBook_BE.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace eBook_BE.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PublisherService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PublisherDto> CreatePublisherAsync(CreatePublisherDto createPublisherDto)
        {
            var publisher = _mapper.Map<Publisher>(createPublisherDto);
            _context.Publishers.Add(publisher);
            await _context.SaveChangesAsync();
            return _mapper.Map<PublisherDto>(publisher);
        }

        public async Task<List<PublisherDto>> GetAllPublisherAsync()
        {
            var publishers = await _context.Publishers
                .Where(p => !p.IsDeleted)
                .ToListAsync();
            return _mapper.Map<List<PublisherDto>>(publishers);
        }

        public async Task<PublisherDto> GetPublisherByIdAsync(Guid id)
        {
            var publisher = await _context.Publishers.FindAsync(id);

            if (publisher == null)
            {
                throw new KeyNotFoundException("Publisher not found");
            }

            return _mapper.Map<PublisherDto>(publisher);
        }

        public async Task<PublisherDto> UpdatePublisherAsync(Guid id, UpdatePublisherDto updatePublisherDto)
        {
            var publisher = await _context.Publishers.FindAsync(id);

            if (publisher == null)
            {
                throw new KeyNotFoundException("Publisher not found");
            }

            _mapper.Map(updatePublisherDto, publisher);
            await _context.SaveChangesAsync();

            return _mapper.Map<PublisherDto>(publisher);
        }

        public async Task<PublisherDto> DeletePublisherAsync(Guid id)
        {
            var publisher = await _context.Publishers.FindAsync(id);

            if (publisher == null)
            {
                throw new KeyNotFoundException("Publisher not found");
            }

            publisher.IsDeleted = true;
            await _context.SaveChangesAsync();

            return _mapper.Map<PublisherDto>(publisher);
        }
    }
}
