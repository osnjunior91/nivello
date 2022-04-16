using Nivello.Lib.Nivello.Lib.Domain.Commands;

namespace Nivello.Domain.Commands.Auth.Commands
{
    public class LoginCommand : Command
    {
        public LoginCommand() { }

        public LoginCommand(string email, string password, bool isAdmin)
        {
            Email = email;
            Password = password;
            IsAdmin = isAdmin;
        }

        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
