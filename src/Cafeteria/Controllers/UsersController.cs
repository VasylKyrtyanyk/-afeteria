using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Infrastructure.Abstraction;
using Infrastructure.ModelsDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Сafeteria.DataModels.Entities;
using Сafeteria.Services;

namespace Сafeteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController: ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService unitOfWork)
        {
            _userService = unitOfWork;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateModel model)
        {
            var user = await _userService.Authenticate(model.Email, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }


        [AllowAnonymous]
        [HttpPost("registration")]
        public async Task<IActionResult> Registration([FromBody] UserDTO model)
        {
            var isRegister = await _userService.Register(model);

            if (isRegister == false)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(true);
        }


    }
}
