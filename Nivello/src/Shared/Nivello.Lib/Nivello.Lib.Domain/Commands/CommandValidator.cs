using FluentValidation;
using Nivello.Lib.Nivello.Lib.Domain.Commands.Interfaces;
using System;

namespace Nivello.Lib.Nivello.Lib.Domain.Commands
{
    public class CommandValidator<T> : AbstractValidator<T>, ICommandValidator<T> where T : Command
    {
        protected bool ValidGuidEmpty(Guid guid)
        {
            return guid != Guid.Empty;
        }
    }
}
