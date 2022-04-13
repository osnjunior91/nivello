using MediatR;

namespace Nivello.Lib.Nivello.Lib.Domain.Commands.Interfaces
{
    public interface ICommand : IRequest<CommandResult>
    {
    }
}
