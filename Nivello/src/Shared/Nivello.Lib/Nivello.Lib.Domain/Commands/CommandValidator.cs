using FluentValidation;
using Nivello.Lib.Nivello.Lib.Domain.Commands.Interfaces;

namespace Nivello.Lib.Nivello.Lib.Domain.Commands
{
    public class CommandValidator<T> : AbstractValidator<T>, ICommandValidator<T> where T : Command
    {
    }
}
