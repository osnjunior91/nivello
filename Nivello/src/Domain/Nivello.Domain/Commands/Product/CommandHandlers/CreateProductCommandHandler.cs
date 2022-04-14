using FluentValidation;
using Nivello.Domain.Commands.Product.Commands;
using Nivello.Domain.Commands.Product.Validators;
using Nivello.Infrastructure.Data.Model;
using Nivello.Infrastructure.Data.Repository.Products;
using Nivello.Lib.Nivello.Extension.Methods;
using Nivello.Lib.Nivello.Lib.Domain.Commands;
using Nivello.Lib.Nivello.Lib.Domain.Commands.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Nivello.Domain.Commands.Product.CommandHandlers
{
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<CommandResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateProductCommandValidator();
            validator.ValidateAndThrow(request);
            var image = await request.Imagem.GetBytes();
            var product = new Infrastructure.Data.Model.Product(request.Name, request.Price,
                image, request.SystemAdminId, null);
            await _productRepository.CreatedAsync(product);
            return new CommandResult(true, product);
        }
    }
}
