using InveonFinal.Service.Dtos.OrderDtos;
using InveonFinal.Service.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InveonFinal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;

        public OrderDetailController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetByOrderId(int orderId)
        {
            var orderDetails = await _orderDetailService.GetOrderDetailsByOrderIdAsync(orderId);
            return Ok(orderDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Add(OrderDetailDto orderDetailDto)
        {
            var result = await _orderDetailService.AddOrderDetailAsync(orderDetailDto);
            if (result != null) return BadRequest(result);

            return Ok("Order detail added successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _orderDetailService.RemoveOrderDetailAsync(id);
            if (result != null) return NotFound(result);

            return Ok("Order detail removed successfully.");
        }
    }


}
