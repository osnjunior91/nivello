using FluentValidation;
using Nivello.Domain.Commands.Auctions.Commands;
using Nivello.Domain.Commands.Auctions.Validators;
using Nivello.Domain.Commands.Product.Commands;
using Nivello.Domain.Queries.Auctions.Queries;
using Nivello.Domain.Queries.Products.Queries;
using Nivello.Infrastructure.Data.Model;
using Nivello.Infrastructure.Data.Repository.Auctions;
using Nivello.Infrastructure.Data.Repository.Products;
using Nivello.Lib.Nivello.Lib.Domain.Commands;
using Nivello.Lib.Nivello.Lib.Domain.Commands.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Nivello.Domain.Commands.Auctions.CommandHandlers
{
    public class CreateAuctionsBidCommandHandler : ICommandHandler<CreateAuctionsBidCommand>
    {
        private readonly IAuctionsBidRepository _auctionsBidRepository;
        private readonly IProductRepository _productRepository;
        public CreateAuctionsBidCommandHandler(IAuctionsBidRepository auctionsBidRepository, IProductRepository productRepository)
        {
            _auctionsBidRepository = auctionsBidRepository;
            _productRepository = productRepository;
        }
        public async Task<CommandResult> Handle(CreateAuctionsBidCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateAuctionsBidCommandValidator();
            validator.ValidateAndThrow(request);
            var product = await _productRepository.FirstOrDefaultAsync(ProductsQueries.GetById(request.ProductId));
            if (product == null)
                throw new ArgumentException("Id de produto invalido");
            if (product.IsDelete)
                throw new ArgumentException("Esse item ja foi encerrado.");
            var lastAction = await _auctionsBidRepository.FirstOrDefaultAsync(AuctionsQueries.GetActiveByProductId(request.ProductId));
            if(lastAction != null)
            {
                if (lastAction.Amount >= request.Amount)
                    throw new ArgumentException("Valor do lance atual deve ser maior que o ultimo lance ativo");
                lastAction.Inactivate();
            }
            else
            {
                if (product.Price >= request.Amount)
                    throw new ArgumentException("Valor do lance atual deve ser maior que o valor do produto.");
            }
            var auctionsBid = new AuctionsBid(request.ProductId, request.CustomerId, request.Amount);
            await _auctionsBidRepository.CreatedAndUpdateAsync(auctionsBid, lastAction);
            return new CommandResult(true, auctionsBid);
        }
    }
}
