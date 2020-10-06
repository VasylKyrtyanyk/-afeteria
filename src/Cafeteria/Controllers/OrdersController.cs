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
        public async Task<IActionResult> Get(int id)
        {
            var result = await _unitOfWork.OrderRepository.Get(id);
            if (result != null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
