using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Сafeteria.Infrastructure.Abstraction;

namespace Сafeteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderServise;
        public OrdersController(IOrderService orderServise)
        {
            _orderServise = orderServise;
        }

        [HttpGet]
        [Route("{orderId}")]
        public async Task<IActionResult> Get([FromRoute] int orderId)
        {
            var result = await _orderServise.GetById(orderId);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _orderServise.GetAll();
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
            var result = await _orderServise.GetUserOrders(userId);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete]
        [Route("{orderId}")]
        public async Task<IActionResult> Delete([FromRoute] int orderId)
        {
            var orderResult = await _orderServise.DeleteById(orderId);

            if (orderResult != true)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
