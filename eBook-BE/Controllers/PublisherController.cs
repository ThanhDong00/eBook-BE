using eBook_BE.Dtos;
using eBook_BE.Dtos.Publisher;
using eBook_BE.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace eBook_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePublisherAsync([FromBody] CreatePublisherDto createPublisherDto)
        {
            ApiResponse<PublisherDto> apiResponse = new();
            try
            {
                apiResponse.Data = await _publisherService.CreatePublisherAsync(createPublisherDto);
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
        public async Task<IActionResult> GetAllPublisherAsync()
        {
            ApiResponse<List<PublisherDto>> apiResponse = new();
            try
            {
                apiResponse.Data = await _publisherService.GetAllPublisherAsync();
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
        public async Task<IActionResult> GetPublisherByIdAsync(Guid id)
        {
            ApiResponse<PublisherDto> apiResponse = new();

            try
            {
                apiResponse.Data = await _publisherService.GetPublisherByIdAsync(id);
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
        public async Task<IActionResult> UpdatePublisherAsync(Guid id, [FromBody] UpdatePublisherDto updatePublisherDto)
        {
            ApiResponse<PublisherDto> apiResponse = new();

            try
            {
                apiResponse.Data = await _publisherService.UpdatePublisherAsync(id, updatePublisherDto);
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
        public async Task<IActionResult> DeletePublisherAsync(Guid id)
        {
            ApiResponse<PublisherDto> apiResponse = new();

            try
            {
                apiResponse.Data = await _publisherService.DeletePublisherAsync(id);
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
