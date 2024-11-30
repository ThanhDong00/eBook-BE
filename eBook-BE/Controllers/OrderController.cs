using eBook_BE.Dtos;
using eBook_BE.Dtos.Order;
using eBook_BE.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace eBook_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderAsync([FromBody] CreateOrderDto createOrderDto)
        {
            ApiResponse<OrderDto> response = new();
            try
            {
                response.Data = await _orderService.CreateOrderAsync(createOrderDto);
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
        public async Task<IActionResult> GetAllOrdersAsync()
        {
            ApiResponse<List<OrderDto>> response = new();
            try
            {
                response.Data = await _orderService.GetAllOrdersAsync();
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
        public async Task<IActionResult> GetOrderByIdAsync(Guid id)
        {
            ApiResponse<OrderDto> response = new();
            try
            {
                response.Data = await _orderService.GetOrderByIdAsync(id);
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
        [Route("user/{userId}")]
        public async Task<IActionResult> GetAllOrdersByUserId(Guid userId)
        {
            ApiResponse<List<OrderDto>> response = new();
            try
            {
                response.Data = await _orderService.GetAllOrdersByUserId(userId);
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
        public async Task<IActionResult> UpdateOrderAsync(Guid id, [FromBody] UpdateOrderDto updateOrderDto)
        {
            ApiResponse<OrderDto> response = new();
            try
            {
                response.Data = await _orderService.UpdateOrderAsync(id, updateOrderDto);
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
        public async Task<IActionResult> DeleteOrderAsync(Guid id)
        {
            ApiResponse<OrderDto> response = new();
            try
            {
                response.Data = await _orderService.DeleteOrderAsync(id);
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
