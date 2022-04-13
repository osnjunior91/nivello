using MediatR;

namespace Nivello.Lib.Nivello.Lib.Domain.Commands.Interfaces
{
    public interface ICommandHandler<T> : IRequestHandler<T, CommandResult> where T : Command
    {
    }
}
