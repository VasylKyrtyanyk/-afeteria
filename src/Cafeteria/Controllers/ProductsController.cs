using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Сafeteria.Services;

namespace Сafeteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController: ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("{productId}")]
        public async Task<IActionResult> Get([FromRoute] int productId)
        {
            var result = await _unitOfWork.ProductRepository.Get(productId);
            if (result != null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _unitOfWork.ProductRepository.GetAll();
            if (result != null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete]
        [Route("{productId}")]
        public async Task<IActionResult> Delete([FromRoute] int productId)
        {
            var productResult = await _unitOfWork.ProductRepository.Get(productId);
            if (productResult == null)
            {
                return NotFound();
            }

            await _unitOfWork.ProductRepository.Remove(productResult);

            return Ok();
        }
    }
}
