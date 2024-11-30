using eBook_BE.Dtos;
using eBook_BE.Dtos.BookCategory;
using eBook_BE.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace eBook_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookCategoryController : ControllerBase
    {
        private readonly IBookCategoryService _bookCategoryService;

        public BookCategoryController(IBookCategoryService bookCategoryService)
        {
            _bookCategoryService = bookCategoryService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBookCategoryAsync([FromBody] CreateBookCategoryDto createBookCategoryDto)
        {
            ApiResponse<BookCategoryDto> apiResponse = new();

            try
            {
                apiResponse.Data = await _bookCategoryService.CreateBookCategoryAsync(createBookCategoryDto);
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
        public async Task<IActionResult> GetAllBookCategoryAsync()
        {
            ApiResponse<List<BookCategoryDto>> apiResponse = new();

            try
            {
                apiResponse.Data = await _bookCategoryService.GetAllBookCategoryAsync();
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
        public async Task<IActionResult> GetBookCategoryByIdAsync(Guid id)
        {
            ApiResponse<BookCategoryDto> apiResponse = new();

            try
            {
                apiResponse.Data = await _bookCategoryService.GetBookCategoryByIdAsync(id);
                return Ok(apiResponse);
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
        public async Task<IActionResult> UpdateBookCategoryAsync(Guid id, [FromBody] UpdateBookCategoryDto updateBookCategoryDto)
        {
            ApiResponse<BookCategoryDto> apiResponse = new();

            try
            {
                apiResponse.Data = await _bookCategoryService.UpdateBookCategoryAsync(id, updateBookCategoryDto);
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                apiResponse.ErrorMessage = ex.Message;
                apiResponse.IsSuccess = false;
                return BadRequest(apiResponse);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteBookCategoryAsync(Guid id)
        {
            ApiResponse<BookCategoryDto> apiResponse = new();

            try
            {
                apiResponse.Data = await _bookCategoryService.DeleteBookCategoryAsync(id);
                return Ok(apiResponse);
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
