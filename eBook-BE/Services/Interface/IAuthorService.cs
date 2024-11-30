using eBook_BE.Dtos.Author;

namespace eBook_BE.Services.Interface
{
    public interface IAuthorService
    {
        Task<AuthorDto> CreateAuthorAsync(CreateAuthorDto createAuthorDto);
        Task<List<AuthorDto>> GetAllAuthorAsync();
        Task<AuthorDto> GetAuthorByIdAsync(Guid id);
        Task<AuthorDto> UpdateAuthorByIdAsync (Guid id, UpdateAuthorDto updateAuthorDto);
        Task<AuthorDto> DeleteAuthorAsync(Guid id);

    }
}
