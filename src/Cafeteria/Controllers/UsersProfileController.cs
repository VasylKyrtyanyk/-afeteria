using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Сafeteria.Infrastructure.Abstraction;
using Сafeteria.Infrastructure.Commands;

namespace Сafeteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersProfileController : ControllerBase
    {
        private readonly IUserProfileService _userProfileService;

        public UsersProfileController(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        [HttpGet]
        [Route("{profileId}")]
        public async Task<IActionResult> Get(int profileId)
        {
            var result = await _userProfileService.GetById(profileId);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _userProfileService.GetAll();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete]
        [Route("{profileId}")]
        public async Task<IActionResult> Delete([FromRoute] int profileId)
        {
            var profileResult = await _userProfileService.DeleteById(profileId);

            if (profileResult != true)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPut]
        [Route("/UsersProfile/update/{profileId}")]
        public async Task<IActionResult> Update([FromRoute] int profileId, [FromBody] UpdateUserCommand updateUserCommand)
        {
            var profileResult = await _userProfileService.Update(profileId, updateUserCommand);
            if (profileResult == null)
            {
                return NotFound();
            }

            return CreatedAtAction(nameof(Update), profileResult);
        }

        [HttpGet]
        [Route("{userId}/profile")]
        public async Task<IActionResult> GetUserProfile([FromRoute] int userId)
        {
            var profileResult = await _userProfileService.GetUserProfile(userId);

            if (profileResult == null)
            {
                return NotFound();
            }

            return Ok(profileResult);
        }
    }
}