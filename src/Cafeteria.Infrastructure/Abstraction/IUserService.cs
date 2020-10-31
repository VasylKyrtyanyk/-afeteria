﻿using System.Threading.Tasks;
using Сafeteria.Infrastructure.ModelsDTO;

namespace Сafeteria.Infrastructure.Abstraction
{
    public interface IUserService
    {
        Task<UserDTO> Authenticate(string userName, string password);
        Task<bool> Register(UserDTO user);
    }
}