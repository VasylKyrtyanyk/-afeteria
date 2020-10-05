using Cafeteria.DAL;
using Сafeteria.DataModels.Entities;
using Сafeteria.Services.Abstraction;

namespace Сafeteria.Services.Implementation
{
    public class UserRepository: GenericRepository<User, int>, IUserRepository
    {
        public UserRepository(CafeteriaDbContext dbContext) : base(dbContext)
        {

        }
    }
}
