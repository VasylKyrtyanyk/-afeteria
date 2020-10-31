using System;

namespace Сafeteria.Infrastructure.ModelsDTO
{
    public class UserProfileDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Balance { get; set; }
        public int UserId { get; set; }
        public UserDTO User { get; set; }
    }
}
