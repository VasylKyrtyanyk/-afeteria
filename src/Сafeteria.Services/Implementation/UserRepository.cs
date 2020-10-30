using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Cafeteria.DAL;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Сafeteria.DataModels.Entities;
using Сafeteria.Services.Abstraction;
using Сafeteria.Services.Helpers;
using BC = BCrypt.Net.BCrypt;

namespace Сafeteria.Services.Implementation
{
    public class UserRepository: GenericRepository<User, int>, IUserRepository
    {
        public UserRepository(CafeteriaDbContext dbContext ) : base(dbContext)
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
