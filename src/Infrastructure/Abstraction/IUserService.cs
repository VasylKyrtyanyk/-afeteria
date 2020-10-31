using System.Threading.Tasks;
using Infrastructure.ModelsDTO;

namespace Infrastructure.Abstraction
{
    public interface IUserService
    {
        Task<UserDTO> Authenticate(string userName, string password);
        Task<bool> Register(UserDTO user);
    }
}
