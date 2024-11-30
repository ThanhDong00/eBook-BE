using eBook_BE.Dtos;
using eBook_BE.Dtos.User;
using eBook_BE.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace eBook_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequest)
        {
            ApiResponse<LoginResponseDto> response = new ApiResponse<LoginResponseDto>();
            try
            {
                response.Data = await _authService.Login(loginRequest);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
                return BadRequest(response);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequest)
        {
            ApiResponse<Guid> response = new();
            try
            {
                response.Data = await _authService.Register(registerRequest);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
                return BadRequest(response);
            }
        }
    }
}
