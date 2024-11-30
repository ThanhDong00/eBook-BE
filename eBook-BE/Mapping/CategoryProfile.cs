using AutoMapper;
using eBook_BE.Dtos.Category;
using eBook_BE.Models;

namespace eBook_BE.Mapping
{
    public class CategoryProfile: Profile
    {
        public CategoryProfile() {
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
        }
    }
}
