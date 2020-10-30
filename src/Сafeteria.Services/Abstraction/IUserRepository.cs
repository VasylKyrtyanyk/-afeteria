using System.Collections.Generic;
using System.Threading.Tasks;
using Сafeteria.DataModels.Entities;

namespace Сafeteria.Services.Abstraction
{
    public interface IUserRepository : IGenericRepository<User, int>
    {
        Task<bool> Register(User user);
    }
}
