using System.Collections.Generic;
using System.Threading.Tasks;
using Сafeteria.Infrastructure.ModelsDTO;

namespace Сafeteria.Infrastructure.Abstraction
{
    public interface IUserService
    {
        Task<UserDTO> GetById(int userId);
        Task<IEnumerable<UserDTO>> GetAll();
        Task<UserDTO> Authenticate(string userName, string password);
        Task<bool> Register(UserDTO user);
    }
}
