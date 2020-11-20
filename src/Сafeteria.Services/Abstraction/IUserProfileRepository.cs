using System.Collections.Generic;
using System.Threading.Tasks;
using Сafeteria.DataModels.Entities;

namespace Сafeteria.Services.Abstraction
{
    public interface IUserProfileRepository : IGenericRepository<UserProfile, int>
    {
        Task<UserProfile> GetUserProfile(int userId);
    }
}
