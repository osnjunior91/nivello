using Nivello.Lib.Nivello.Lib.Domain.Commands;
using System;

namespace Nivello.Domain.Commands.Product.Commands
{
    public class DeleteProductCommand : Command
    {
        public DeleteProductCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; private set; }
    }
}
