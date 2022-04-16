using Nivello.Lib.Nivello.Lib.Domain.Commands;
using System;

namespace Nivello.Domain.Commands.Customer.Commands
{
    public class CreateCustomerCommand : Command
    {
        public CreateCustomerCommand() { }

        public CreateCustomerCommand(string name, string email, string password, DateTime dateOfBirth)
        {
            Name = name;
            Email = email;
            Password = password;
            DateOfBirth = dateOfBirth;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
