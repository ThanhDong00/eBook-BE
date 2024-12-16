using eBook_BE.Data;
using eBook_BE.Dtos;
using eBook_BE.Dtos.Book;
using eBook_BE.Models;
using eBook_BE.Services;
using eBook_BE.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace eBook_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly IBookService _bookService;
        private readonly IRecommendationService _recommendationService;

        public BookController(IBookService bookService, IRecommendationService recommendationService)
        {
            _bookService = bookService;
            _recommendationService = recommendationService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBookAsync([FromBody] CreateBookDto createBookDto)
        {
            ApiResponse<BookDto> apiResponse = new();

            try
            {
                apiResponse.Data = await _bookService.CreateBookAsync(createBookDto);
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
        public async Task<IActionResult> GetAllBooksAsync([FromQuery] BookFilterDto filterDto, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            ApiResponse<List<BookDto>> apiResponse = new();

            try
            {
                apiResponse.Data = await _bookService.GetAllBooksAsync(filterDto, pageNumber, pageSize);
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
        public async Task<IActionResult> GetBookByIdAsync(Guid id)
        {
            ApiResponse<BookDto> apiResponse = new();

            try
            {
                apiResponse.Data = await _bookService.GetBookByIdAsync(id);
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
        public async Task<IActionResult> UpdateBookAsync(Guid id, [FromBody] UpdateBookDto updateBookDto)
        {
            ApiResponse<BookDto> apiResponse = new();

            try
            {
                apiResponse.Data = await _bookService.UpdateBookAsync(id, updateBookDto);
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
        public async Task<IActionResult> DeleteBookAsync(Guid id)
        {
            ApiResponse<BookDto> apiResponse = new();

            try
            {
                apiResponse.Data = await _bookService.DeleteBookAsync(id);
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
        [Route("{id}/recommendations")]
        public async Task<IActionResult> GetRecommendedBooksAsync(Guid id)
        {
            ApiResponse<List<BookDto>> apiResponse = new();

            try
            {
                apiResponse.Data = await _recommendationService.GetRecommendedBooksAsync(id);
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                apiResponse.ErrorMessage = ex.Message;
                apiResponse.IsSuccess = false;
                return BadRequest(apiResponse);
            }
        }

        //[HttpGet]
        //[Route("{id}/details")]
        //public async Task<IActionResult> GetBookWithDetailsAsync(Guid id)
        //{
        //    ApiResponse<BookWithDetailsDto> apiResponse = new();

        //    try
        //    {
        //        apiResponse.Data = await _bookService.GetBookWithDetailsAsync(id);
        //        return Ok(apiResponse);
        //    }
        //    catch (Exception ex)
        //    {
        //        apiResponse.ErrorMessage = ex.Message;
        //        apiResponse.IsSuccess = false;
        //        return BadRequest(apiResponse);
        //    }
        //}

        [HttpPatch]
        [Route("{id}/stock/subtract")]
        public async Task<IActionResult> UpdateBookStockQuantityAsync(Guid id, [FromBody] UpdateBookQuantity updateBookQuantity)
        {
            ApiResponse<BookDto> apiResponse = new();

            try
            {
                apiResponse.Data = await _bookService.UpdateBookStockQuantityAsync(id, updateBookQuantity);
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
