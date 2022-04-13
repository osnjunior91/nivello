using Nivello.Lib.Nivello.Lib.Domain.Data.Models;
using System;

namespace Nivello.Infrastructure.Data.Model
{
    public abstract class User : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
