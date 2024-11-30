using eBook_BE.Dtos;
using eBook_BE.Dtos.CartItem;
using eBook_BE.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace eBook_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartItemController : ControllerBase
    {
        private readonly ICartItemService _cartItemService;

        public CartItemController(ICartItemService cartItemService)
        {
            _cartItemService = cartItemService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCartItemAsync([FromBody] CreateCartItemDto createCartItemDto)
        {
            ApiResponse<CartItemDto> response = new();
            try
            {
                response.Data = await _cartItemService.CreateCartItemAsync(createCartItemDto);
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
        public async Task<IActionResult> GetAllCartItemsAsync()
        {
            ApiResponse<List<CartItemDto>> response = new();
            try
            {
                response.Data = await _cartItemService.GettAllCartItemsAsync();
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
        [Route("id/{id}")]
        public async Task<IActionResult> GetCartItemByIdAsync(Guid id)
        {
            ApiResponse<CartItemDto> response = new();
            try
            {
                response.Data = await _cartItemService.GetCartItemByIdAsync(id);
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
        [Route("cartId/{cartId}")]
        public async Task<IActionResult> GetCartItemsByCartIdAsync(Guid cartId)
        {
            ApiResponse<List<CartItemDto>> response = new();
            try
            {
                response.Data = await _cartItemService.GetCartItemsByCartIdAsync(cartId);
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
        public async Task<IActionResult> UpdateCartItemAsync(Guid id,[FromBody] UpdateCartItemDto updateCartItemDto)
        {
            ApiResponse<CartItemDto> response = new();
            try
            {
                response.Data = await _cartItemService.UpdateCartItemAsync(id, updateCartItemDto);
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
        public async Task<IActionResult> DeleteCartItemAsync(Guid id)
        {
            ApiResponse<CartItemDto> response = new();
            try
            {
                response.Data = await _cartItemService.DeleteCartItemAsync(id);
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
