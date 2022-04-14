using FluentValidation;
using Nivello.Domain.Commands.Customer.Commands;
using Nivello.Domain.Commands.Customer.Validators;
using Nivello.Infrastructure.Data.Repository.Customers;
using Nivello.Lib.Nivello.Lib.Domain.Commands;
using Nivello.Lib.Nivello.Lib.Domain.Commands.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nivello.Domain.Commands.Customer.CommandHandlers
{
    public class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CommandResult> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateCustomerCommandValidator();
            validator.ValidateAndThrow(request);
            var customer = new Infrastructure.Data.Model.Customer(request.Name, request.Email, request.Password, request.DateOfBirth);
            await _customerRepository.CreatedAsync(customer);
            return new CommandResult(true, customer);
        }
    }
}
