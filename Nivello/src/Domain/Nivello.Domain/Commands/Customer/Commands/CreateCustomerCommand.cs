using Nivello.Lib.Nivello.Lib.Domain.Commands;
using System;

namespace Nivello.Domain.Commands.Customer.Commands
{
    public class CreateCustomerCommand : Command
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
