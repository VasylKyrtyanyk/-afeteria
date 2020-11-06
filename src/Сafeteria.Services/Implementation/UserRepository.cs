using System.Threading.Tasks;
using Cafeteria.DAL;
using Сafeteria.DataModels.Entities;
using Сafeteria.Services.Abstraction;

namespace Сafeteria.Services.Implementation
{
    public class UserRepository : GenericRepository<User, int>, IUserRepository
    {
        public UserRepository(CafeteriaDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<bool> Register(User user)
        {
            // save account
            var userDb = await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return userDb != null;
        }
    }
}
