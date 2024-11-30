using eBook_BE.Dtos.Category;

namespace eBook_BE.Services.Interface
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllCategoryAsync();
        Task<CategoryDto> GetCategoryByIdAsync(Guid id);
        Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task<CategoryDto> UpdateCategoryAsync (Guid id, UpdateCategoryDto updateCategoryDto);
        Task<CategoryDto> DeleteCategoryAsync (Guid id);
    }
}
