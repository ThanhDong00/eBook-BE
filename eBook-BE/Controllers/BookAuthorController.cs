using eBook_BE.Dtos;
using eBook_BE.Dtos.BookAuthor;
using eBook_BE.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace eBook_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookAuthorController : ControllerBase
    {
        private readonly IBookAuthorService _bookAuthorService;

        public BookAuthorController(IBookAuthorService bookAuthorService)
        {
            _bookAuthorService = bookAuthorService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBookAuthorAsync([FromBody] CreateBookAuthorDto createBookAuthorDto)
        {
            ApiResponse<BookAuthorDto> apiResponse = new();

            try
            {
                apiResponse.Data = await _bookAuthorService.CreateBookAuthorAsync(createBookAuthorDto);
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
        public async Task<IActionResult> GetAllBookAuthorAsync()
        {
            ApiResponse<List<BookAuthorDto>> apiResponse = new();

            try
            {
                apiResponse.Data = await _bookAuthorService.GetAllBookAuthorAsync();
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
        public async Task<IActionResult> GetBookAuthorByIdAsync(Guid id)
        {
            ApiResponse<BookAuthorDto> apiResponse = new();

            try
            {
                apiResponse.Data = await _bookAuthorService.GetBookAuthorByIdAsync(id);
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
        public async Task<IActionResult> UpdateBookAuthorByIdAsync(Guid id, [FromBody] UpdateBookAuthorDto updateBookAuthorDto)
        {
            ApiResponse<BookAuthorDto> apiResponse = new();

            try
            {
                apiResponse.Data = await _bookAuthorService.UpdateBookAuthorByIdAsync(id, updateBookAuthorDto);
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
        public async Task<IActionResult> DeleteBookAuthorAsync(Guid id)
        {
            ApiResponse<BookAuthorDto> apiResponse = new();

            try
            {
                apiResponse.Data = await _bookAuthorService.DeleteBookAuthorAsync(id);
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
