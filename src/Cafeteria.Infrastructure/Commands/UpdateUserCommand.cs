using System;
using Сafeteria.DataModels.Entities.ValueObjects;
using Сafeteria.Infrastructure.ModelsDTO;

namespace Сafeteria.Infrastructure.Commands
{
    public class UpdateUserCommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
