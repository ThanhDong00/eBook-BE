using eBook_BE.Dtos;
using eBook_BE.Dtos.Cart;
using eBook_BE.Helpers.Interface;
using eBook_BE.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eBook_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        //private readonly IClaimService _claimService;
        public CartController(ICartService cartService, IClaimService claimService)
        {
            //_claimService = claimService;
            _cartService = cartService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCartAsync([FromBody] CreateCartDto createCartDto)
        {
            ApiResponse<CartDto> response = new();
            try
            {
                response.Data = await _cartService.CreateCartAsync(createCartDto);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
                return BadRequest(response);
            }
        }

        [HttpGet]
        [Route("id/{id}")]
        public async Task<IActionResult> GetCartByIdAsync(Guid id)
        {
            ApiResponse<CartDto> response = new();
            try
            {
                response.Data = await _cartService.GetCartByIdAsync(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
                return BadRequest(response);
            }
        }

        [HttpGet]
        [Route("user/{userId}")]
        public async Task<IActionResult> GetCartByUserIdAsync(Guid userId)
        {
            ApiResponse<CartDto> response = new();
            try
            {
                //var userId = Guid.Parse(_claimService.GetUserId());
                response.Data = await _cartService.GetCartByUserIdAsync(userId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
                return BadRequest(response);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCartAsync(Guid id)
        {
            ApiResponse<CartDto> response = new();
            try
            {
                response.Data = await _cartService.DeleteCartAsync(id);
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
