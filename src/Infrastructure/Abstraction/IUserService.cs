using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.ModelsDTO;
using Сafeteria.DataModels.Entities;

namespace Infrastructure.Abstraction
{
    public interface IUserService
    {
        Task<UserDTO> Authenticate(string username, string password);
        Task<bool> Register(UserDTO user);
    }
}
