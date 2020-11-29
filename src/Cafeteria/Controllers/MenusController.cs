using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Сafeteria.Infrastructure.Abstraction;
using Сafeteria.Infrastructure.Commands;

namespace Сafeteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenusController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet]
        [Route("{menuId}")]
        public async Task<IActionResult> Get(int menuId)
        {
            var result = await _menuService.GetByID(menuId);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _menuService.GetAll();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddMenuCommand menu)
        {
            var result = await _menuService.Add(menu);

            return CreatedAtAction(nameof(Add), result);
        }

        [HttpPut]
        [Route("/Menus/update/{menuId}")]
        public async Task<IActionResult> Update([FromRoute] int menuId, [FromBody] UpdateMenuCommand updateMenuCommand)
        {
            var menuResult = await _menuService.Update(menuId, updateMenuCommand);
            if (menuResult == null)
            {
                return NotFound();
            }

            return CreatedAtAction(nameof(Update), menuResult);
        }

        [HttpDelete]
        [Route("{menuId}")]
        public async Task<IActionResult> Delete([FromRoute] int menuId)
        {
            var menuResult = await _menuService.DeleteById(menuId);

            if (menuResult != true)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
