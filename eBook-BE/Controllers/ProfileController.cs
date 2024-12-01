using eBook_BE.Dtos;
using eBook_BE.Dtos.Profile;
using eBook_BE.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace eBook_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProfileAsync()
        {
            ApiResponse<List<ProfileDto>> response = new();
            try
            {
                response.Data = await _profileService.GetAllProfileAsync();
                return Ok(response);
            }
            catch (Exception e)
            {
                response.IsSuccess = false;
                response.ErrorMessage = e.Message;
                return BadRequest(response);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetProfileByIdAsync(Guid id)
        {
            ApiResponse<ProfileDto> response = new();
            try
            {
                response.Data = await _profileService.GetProfileByIdAsync(id);
                return Ok(response);
            }
            catch (Exception e)
            {
                response.IsSuccess = false;
                response.ErrorMessage = e.Message;
                return BadRequest(response);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateProfileAsync(Guid id, UpdateProfileDto updateProfileDto)
        {
            ApiResponse<ProfileDto> response = new();
            try
            {
                response.Data = await _profileService.UpdateProfileAsync(id, updateProfileDto);
                return Ok(response);
            }
            catch (Exception e)
            {
                response.IsSuccess = false;
                response.ErrorMessage = e.Message;
                return BadRequest(response);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteProfileAsync(Guid id)
        {
            ApiResponse<ProfileDto> response = new();
            try
            {
                response.Data = await _profileService.DeleteProfileAsync(id);
                return Ok(response);
            }
            catch (Exception e)
            {
                response.IsSuccess = false;
                response.ErrorMessage = e.Message;
                return BadRequest(response);
            }
        }
    }
}
