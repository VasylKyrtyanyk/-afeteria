﻿using System;
using Сafeteria.DataModels.Entities.ValueObjects;

namespace Сafeteria.DataModels.Entities
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Balance { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
