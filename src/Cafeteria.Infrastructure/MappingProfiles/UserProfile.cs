using Сafeteria.DataModels.Entities;
using Сafeteria.Infrastructure.ModelsDTO;

namespace Сafeteria.Infrastructure.MappingProfiles
{
    public class UserProfile : AutoMapper.Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
