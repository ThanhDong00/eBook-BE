using eBook_BE.Dtos;
using eBook_BE.Dtos.Author;
using eBook_BE.Enum;
using eBook_BE.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eBook_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthorAsync([FromBody] CreateAuthorDto createAuthorDto)
        {
            try
            {
                var authorDto = await _authorService.CreateAuthorAsync(createAuthorDto);
                return Ok(new ApiResponse<AuthorDto> { Data = authorDto });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<AuthorDto> { ErrorMessage = ex.Message, IsSuccess = false });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAuthorAsync()
        {
            try
            {
                var authors = await _authorService.GetAllAuthorAsync();
                return Ok(new ApiResponse<List<AuthorDto>> { Data = authors });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<List<AuthorDto>> { ErrorMessage = ex.Message, IsSuccess = false });
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAuthorByIdAsync(Guid id)
        {
            try
            {
                var author = await _authorService.GetAuthorByIdAsync(id);
                return Ok(new ApiResponse<AuthorDto> { Data = author });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<AuthorDto> { ErrorMessage = ex.Message, IsSuccess = false });
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAuthorByIdAsync(Guid id, [FromBody] UpdateAuthorDto updateAuthorDto)
        {
            try
            {
                var author = await _authorService.UpdateAuthorByIdAsync(id, updateAuthorDto);
                return Ok(new ApiResponse<AuthorDto> { Data = author });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<AuthorDto> { ErrorMessage = ex.Message, IsSuccess = false });
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAuthorAsync(Guid id)
        {
            try
            {
                var author = await _authorService.DeleteAuthorAsync(id);
                return Ok(new ApiResponse<AuthorDto> { Data = author });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<AuthorDto> { ErrorMessage = ex.Message, IsSuccess = false });
            }
        }
    }
}
