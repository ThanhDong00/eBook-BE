using eBook_BE.Dtos;
using eBook_BE.Dtos.OrderItem;
using eBook_BE.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace eBook_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderItemAsync([FromBody] CreateOrderItemDto createOrderItemDto)
        {
            ApiResponse<OrderItemDto> response = new();
            try
            {
                response.Data = await _orderItemService.CreateOrderItemAsync(createOrderItemDto);
                return Ok(response);
            }
            catch (Exception e)
            {
                response.ErrorMessage = e.Message;
                response.IsSuccess = false;
                return BadRequest(response);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrderItemsAsync()
        {
            ApiResponse<List<OrderItemDto>> response = new();
            try
            {
                response.Data = await _orderItemService.GetAllOrderItemsAsync();
                return Ok(response);
            }
            catch (Exception e)
            {
                response.ErrorMessage = e.Message;
                response.IsSuccess = false;
                return BadRequest(response);
            }
        }

        [HttpGet]
        [Route("id/{id}")]
        public async Task<IActionResult> GetOrderItemByIdAsync(Guid id)
        {
            ApiResponse<OrderItemDto> response = new();
            try
            {
                response.Data = await _orderItemService.GetOrderItemByIdAsync(id);
                return Ok(response);
            }
            catch (Exception e)
            {
                response.ErrorMessage = e.Message;
                response.IsSuccess = false;
                return BadRequest(response);
            }
        }

        [HttpGet]
        [Route("orderId/{orderId}")]
        public async Task<IActionResult> GetOrderItemsByOrderId(Guid orderId)
        {
            ApiResponse<List<OrderItemDto>> response = new();
            try
            {
                response.Data = await _orderItemService.GetOrderItemsByOrderId(orderId);
                return Ok(response);
            }
            catch (Exception e)
            {
                response.ErrorMessage = e.Message;
                response.IsSuccess = false;
                return BadRequest(response);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteOrderItemAsync(Guid id)
        {
            ApiResponse<OrderItemDto> response = new();
            try
            {
                response.Data = await _orderItemService.DeleteOrderItemAsync(id);
                return Ok(response);
            }
            catch (Exception e)
            {
                response.ErrorMessage = e.Message;
                response.IsSuccess = false;
                return BadRequest(response);
            }
        }
    }
}
