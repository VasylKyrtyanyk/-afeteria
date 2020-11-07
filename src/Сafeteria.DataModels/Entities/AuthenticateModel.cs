using System.ComponentModel.DataAnnotations;

namespace Сafeteria.DataModels.Entities
{
    public class AuthenticateModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
