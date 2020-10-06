using Microsoft.AspNetCore.Mvc;
using Сafeteria.Services;

namespace Сafeteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController: ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public MenusController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
