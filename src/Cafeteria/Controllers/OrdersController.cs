using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Сafeteria.Infrastructure.Abstraction;
using Сafeteria.Infrastructure.Commands;

namespace Сafeteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [Route("{orderId}")]
        public async Task<IActionResult> Get([FromRoute] int orderId)
        {
            var result = await _orderService.GetById(orderId);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _orderService.GetAll();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("{userId}/userOrders")]
        public async Task<IActionResult> GetUserOrders([FromRoute] int userId)
        {
            var result = await _orderService.GetUserOrders(userId);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Add(CreateOrderCommand order)
        {
            var result = await _orderService.Add(order);

            return CreatedAtAction(nameof(Add), result);
        }

        [HttpPut]
        [Route("/update/{orderId}")]
        public async Task<IActionResult> Update([FromRoute] int orderId, [FromBody] UpdateOrderCommand updateOrderCommand)
        {
            var orderResult = await _orderService.Update(orderId, updateOrderCommand);
            if (orderResult == null)
            {
                return NotFound();
            }

            return CreatedAtAction(nameof(Update), orderResult);
        }

        [HttpDelete]
        [Route("{orderId}")]
        public async Task<IActionResult> Delete([FromRoute] int orderId)
        {
            var orderResult = await _orderService.DeleteById(orderId);

            if (orderResult != true)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
