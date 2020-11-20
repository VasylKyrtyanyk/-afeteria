using System.Collections.Generic;
using System.Threading.Tasks;
using Сafeteria.Infrastructure.ModelsDTO;

namespace Сafeteria.Infrastructure.Abstraction
{
    public interface IUserProfileService
    {
        Task<UserProfileDTO> GetById(int profileId);
        Task<IEnumerable<UserProfileDTO>> GetAll();
        Task<bool> DeleteById(int userProfileId);
        Task<UserProfileDTO> GetUserProfile(int userId);
    }
}
