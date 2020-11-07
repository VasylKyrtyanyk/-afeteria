using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Сafeteria.Infrastructure.Abstraction;
using Сafeteria.Infrastructure.Commands;

namespace Сafeteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("{productId}")]
        public async Task<IActionResult> Get([FromRoute] int productId)
        {
            var result = await _productService.GetById(productId);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductCommand product)
        {
            var result = await _productService.Add(product);

            return CreatedAtAction(nameof(Add), result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productService.GetAll();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete]
        [Route("{productId}")]
        public async Task<IActionResult> Delete([FromRoute] int productId)
        {
            var productResult = await _productService.DeleteById(productId);

            if (productResult != true)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
