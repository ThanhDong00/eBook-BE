using AutoMapper;
using eBook_BE.Data;
using eBook_BE.Dtos.Author;
using eBook_BE.Dtos.Category;
using eBook_BE.Models;
using eBook_BE.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace eBook_BE.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AuthorService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AuthorDto> CreateAuthorAsync(CreateAuthorDto createAuthorDto)
        {
            Author author = _mapper.Map<Author>(createAuthorDto);

            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            return _mapper.Map<AuthorDto>(author);
        }

        public async Task<List<AuthorDto>> GetAllAuthorAsync()
        {
            var authors = await _context.Authors.Where(x => !x.IsDeleted).ToListAsync();

            return _mapper.Map<List<AuthorDto>>(authors);
        }

        public async Task<AuthorDto> GetAuthorByIdAsync(Guid id)
        {
            var author = await _context.Authors.FindAsync(id);

            if (author == null)
            {
                throw new KeyNotFoundException("Category not found");
            }

            return _mapper.Map<AuthorDto>(author);
        }

        public async Task<AuthorDto> UpdateAuthorByIdAsync(Guid id, UpdateAuthorDto updateAuthorDto)
        {
            var author = await _context.Authors.FindAsync(id);

            if (author == null)
            {
                throw new KeyNotFoundException("Author not found");
            }

            _mapper.Map(updateAuthorDto, author);
            await _context.SaveChangesAsync();

            return _mapper.Map<AuthorDto>(author);
        }

        public async Task<AuthorDto> DeleteAuthorAsync(Guid id)
        {
            var author = _context.Authors.Find(id);

            if (author == null)
            {
                throw new KeyNotFoundException("Author not found");
            }

            author.IsDeleted = true;
            await _context.SaveChangesAsync();

            return _mapper.Map<AuthorDto>(author);
        }
    }
}
