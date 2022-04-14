using FluentValidation;
using Nivello.Domain.Commands.Auth.Commands;
using Nivello.Domain.Commands.Auth.Validators;
using Nivello.Lib.Nivello.Lib.Domain.Commands;
using Nivello.Lib.Nivello.Lib.Domain.Commands.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Nivello.Domain.Commands.Auth.CommandHandlers
{
    public class LoginCommandHandler : ICommandHandler<LoginCommand>
    {
        public Task<CommandResult> Handle(LoginCommand request, CancellationToken cancellationToken)
        {

            var validator = new LoginCommandValidator();
            validator.ValidateAndThrow(request);

            if (request.IsAdmin)
            {

            }
            else
            {

            }

            throw new System.NotImplementedException();
        }
    }
}
