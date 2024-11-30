using eBook_BE.Dtos;
using eBook_BE.Dtos.Category;
using eBook_BE.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eBook_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategoryAsync([FromBody] CreateCategoryDto createCategoryDto)
        {
            ApiResponse<CategoryDto> apiResponse = new();
            try
            {
                apiResponse.Data = await _categoryService.CreateCategoryAsync(createCategoryDto);
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                apiResponse.ErrorMessage = ex.Message;
                apiResponse.IsSuccess = false;
                return BadRequest(apiResponse);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            ApiResponse<List<CategoryDto>> apiResponse = new();
            try
            {
                apiResponse.Data = await _categoryService.GetAllCategoryAsync();
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                apiResponse.ErrorMessage = ex.Message;
                apiResponse.IsSuccess = false;
                return BadRequest(apiResponse);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCategoryByIdAsync(Guid id)
        {
            ApiResponse<CategoryDto> apiResponse = new();

            try
            {
                apiResponse.Data = await _categoryService.GetCategoryByIdAsync(id);
                return Ok(apiResponse);
            }
            catch (KeyNotFoundException ex)
            {
                apiResponse.ErrorMessage = ex.Message;
                apiResponse.IsSuccess = false;
                return NotFound(apiResponse);
            }
            catch (Exception ex)
            {
                apiResponse.ErrorMessage = ex.Message;
                apiResponse.IsSuccess = false;
                return BadRequest(apiResponse);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateCategoryAsync(Guid id, [FromBody] UpdateCategoryDto updateCategoryDto)
        {
            try
            {
                var updatedCategory = await _categoryService.UpdateCategoryAsync(id, updateCategoryDto);
                return Ok(new ApiResponse<CategoryDto> { Data = updatedCategory });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new ApiResponse<CategoryDto> { ErrorMessage = ex.Message, IsSuccess = false });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<CategoryDto> { ErrorMessage = ex.Message, IsSuccess = false });
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCategoryAsync(Guid id)
        {
            ApiResponse<CategoryDto> apiResponse = new();
            try
            {
                apiResponse.Data = await _categoryService.DeleteCategoryAsync(id);
                return Ok(apiResponse);
            }
            catch (KeyNotFoundException ex)
            {
                apiResponse.ErrorMessage = ex.Message;
                apiResponse.IsSuccess = false;
                return NotFound(apiResponse);
            }
            catch (Exception ex)
            {
                apiResponse.ErrorMessage = ex.Message;
                apiResponse.IsSuccess = false;
                return BadRequest(apiResponse);
            }
        }
    }
}
