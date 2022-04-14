﻿using Nivello.Lib.Nivello.Lib.Domain.Data.Models;

namespace Nivello.Lib.Nivello.Lib.Infrastructure.Data.Models
{
    public abstract class User : Entity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }
    }
}