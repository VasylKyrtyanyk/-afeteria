using System.Collections.Generic;
using Сafeteria.DataModels.Entities.Abstraction;

namespace Сafeteria.DataModels.Entities
{
    public class User : IEntity<int>
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserProfile Profile { get; set; }
        public List<Order> Orders { get; set; }
    }
}
