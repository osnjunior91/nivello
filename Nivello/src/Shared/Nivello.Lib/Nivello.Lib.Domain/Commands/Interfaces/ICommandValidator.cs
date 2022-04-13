using MediatR;

namespace Nivello.Lib.Nivello.Lib.Domain.Commands.Interfaces
{
    public interface ICommandValidator<T> : IRequest<T> where T : ICommand
    {
    }
}
