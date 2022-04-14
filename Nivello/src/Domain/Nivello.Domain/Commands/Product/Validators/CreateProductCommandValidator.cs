using FluentValidation;
using Nivello.Domain.Commands.Product.Commands;
using Nivello.Lib.Nivello.Lib.Domain.Commands;

namespace Nivello.Domain.Commands.Product.Validators
{
    public class CreateProductCommandValidator : CommandValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Price).NotEmpty().NotNull();
            RuleFor(x => x.Name).NotEmpty().NotNull();
            RuleFor(x => x.SystemAdminId).NotEmpty().NotNull();
            RuleFor(x => x.Imagem).NotEmpty().NotNull();
        }
    }
}
