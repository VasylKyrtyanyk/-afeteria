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

        [HttpPut]
        [Route("/products/update/{productId}")]
        public async Task<IActionResult> Update([FromRoute] int productId, [FromBody] UpdateProductCommand updateProductCommand)
        {
            var productResult = await _productService.Update(productId, updateProductCommand);
            if (productResult == null)
            {
                return NotFound();
            }

            return CreatedAtAction(nameof(Update), productResult);
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
