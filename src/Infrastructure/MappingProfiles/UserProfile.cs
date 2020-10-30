﻿using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.ModelsDTO;
using Сafeteria.DataModels.Entities;

namespace Infrastructure.MappingProfiles
{
    public class UserProfile: AutoMapper.Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}