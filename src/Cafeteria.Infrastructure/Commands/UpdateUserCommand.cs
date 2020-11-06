using Сafeteria.DataModels.Entities.ValueObjects;
using Сafeteria.Infrastructure.ModelsDTO;

namespace Сafeteria.Infrastructure.Commands
{
    public class UpdateUserCommand
    {
        // TODO
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserType UserType { get; set; }
        public UserProfileDTO Profile { get; set; }
    }
}
