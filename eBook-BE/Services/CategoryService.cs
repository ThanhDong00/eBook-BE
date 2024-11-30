using AutoMapper;
using eBook_BE.Data;
using eBook_BE.Dtos.Category;
using eBook_BE.Models;
using eBook_BE.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace eBook_BE.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        // Constructor 
        public CategoryService(ApplicationDbContext dbContext, IMapper mapper) { 
            _dbContext = dbContext;
            _mapper = mapper;
        }

        // APIs
        public async Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            Category category = _mapper.Map<Category>(createCategoryDto);

            _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<List<CategoryDto>> GetAllCategoryAsync()
        {
            var categories = await _dbContext.Categories.Where(p => !p.IsDeleted).ToListAsync();
            return _mapper.Map<List<CategoryDto>>(categories);  
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(Guid id)
        {
            var category = await _dbContext.Categories.Where(c => c.Id == id).FirstOrDefaultAsync();

            if (category == null)
            {
                throw new KeyNotFoundException("Category not found");
            }

            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<CategoryDto> UpdateCategoryAsync(Guid id, UpdateCategoryDto updateCategoryDto)
        {
            var category = await _dbContext.Categories.FindAsync(id);

            if (category == null)
            {
                throw new KeyNotFoundException("Category not found");
            }

            _mapper.Map(updateCategoryDto, category);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<CategoryDto> DeleteCategoryAsync(Guid id)
        {
            var category = await _dbContext.Categories.FindAsync(id);

            if (category == null)
            {
                throw new KeyNotFoundException("Category not found");
            }

            category.IsDeleted = true;
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<CategoryDto>(category);
        }
    }
}
