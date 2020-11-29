using System.Linq;
using System.Threading.Tasks;
using Cafeteria.DAL;
using Microsoft.EntityFrameworkCore;
using Сafeteria.DataModels.Entities;
using Сafeteria.Services.Abstraction;

namespace Сafeteria.Services.Implementation
{
    public class UserProfileRepository : GenericRepository<UserProfile, int>, IUserProfileRepository
    {
        public UserProfileRepository(CafeteriaDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<UserProfile> GetUserProfile(int userId)
        {
            return await _dbContext.UserProfiles.Where(p => p.UserId == userId).SingleOrDefaultAsync();
        }
    }
}
