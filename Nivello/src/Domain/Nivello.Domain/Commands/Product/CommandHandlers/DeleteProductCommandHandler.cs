using FluentValidation;
using Nivello.Domain.Commands.Product.Commands;
using Nivello.Domain.Commands.Product.Validators;
using Nivello.Domain.Queries.Products.Queries;
using Nivello.Infrastructure.Data.Repository.Products;
using Nivello.Lib.Nivello.Lib.Domain.Commands;
using Nivello.Lib.Nivello.Lib.Domain.Commands.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Nivello.Domain.Commands.Product.CommandHandlers
{
    public class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<CommandResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteProductCommandValidator();
            validator.ValidateAndThrow(request);
            var product = await _productRepository.FirstOrDefaultAsync(CustomerQueries.GetById(request.Id));
            if (product == null)
                throw new ArgumentException("Produto nao encontrado");
            product.DeleteEntity();
            await _productRepository.UpdateAsync(product);
            return new CommandResult(true, null, "Registro excluido com sucesso");
        }
    }
}
