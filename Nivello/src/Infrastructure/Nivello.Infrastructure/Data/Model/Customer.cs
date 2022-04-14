using Nivello.Lib.Nivello.Lib.Infrastructure.Data.Models;
using System;

namespace Nivello.Infrastructure.Data.Model
{
    public class Customer : User
    {
        public Customer(string name, string email, string password, DateTime dateOfBirth)
            : base(name, email, password)
        {
            DateOfBirth = dateOfBirth;
        }
        public DateTime DateOfBirth { get; private set; }
    }
}
