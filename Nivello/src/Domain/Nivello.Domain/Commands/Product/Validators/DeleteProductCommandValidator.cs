using FluentValidation;
using Nivello.Domain.Commands.Product.Commands;
using Nivello.Lib.Nivello.Lib.Domain.Commands;

namespace Nivello.Domain.Commands.Product.Validators
{
    public class DeleteProductCommandValidator : CommandValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(x => x.Id).Must(ValidGuidEmpty);
        }
    }
}
