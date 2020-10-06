using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Сafeteria.Services;

namespace Сafeteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController: ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrdersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("{orderId}")]
        public async Task<IActionResult> Get([FromRoute] int orderId)
        {
            var result = await _unitOfWork.OrderRepository.Get(orderId);
            if (result != null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _unitOfWork.OrderRepository.GetAll();
            if (result != null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("{userId}/userOrders")]
        public async Task<IActionResult> GetUserOrders([FromRoute] int userId)
        {
            var result = await _unitOfWork.OrderRepository.GetUserOrders(userId);
            if (result != null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpDelete]
        [Route("{orderId")]
        public async Task<IActionResult> Delete([FromRoute] int orderId)
        {
            var orderResult = await _unitOfWork.OrderRepository.Get(orderId);
            if (orderResult == null)
            {
                return NotFound();
            }

            await _unitOfWork.OrderRepository.Remove(orderResult);

            return Ok();
        }
    }
}
