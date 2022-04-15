using FluentValidation;
using Nivello.Domain.Commands.Customer.Commands;
using Nivello.Lib.Nivello.Lib.Domain.Commands;
using System;

namespace Nivello.Domain.Commands.Customer.Validators
{
    public class CreateCustomerCommandValidator : CommandValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
            RuleFor(x => x.Password).NotEmpty().NotNull();
            RuleFor(x => x.Email).NotEmpty().NotNull();
            RuleFor(x => x.DateOfBirth).Must(ValidAge).WithMessage("Usuario deve ter mais de 18 anos").NotEmpty().NotNull();
        }

        private bool ValidAge(DateTime arg)
        {
            return DateTime.Now.AddYears(-18) > arg;
        }
    }
}
