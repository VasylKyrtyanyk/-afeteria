﻿using System;
using System.Collections.Generic;
using System.Text;
using Сafeteria.DataModels.Entities.ValueObjects;

namespace Infrastructure.ModelsDTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserType UserType { get; set; }
        public UserProfileDTO Profile { get; set; }
        public List<OrderDTO> Orders { get; set; }
        public string Token { get; set; }
    }
}
