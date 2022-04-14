using FluentValidation;
using Nivello.Domain.Commands.Auctions.Commands;
using Nivello.Domain.Commands.Auctions.Validators;
using Nivello.Domain.Commands.Product.Commands;
using Nivello.Infrastructure.Data.Model;
using Nivello.Infrastructure.Data.Repository.Auctions;
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

        public CreateAuctionsBidCommandHandler(IAuctionsBidRepository auctionsBidRepository)
        {
            _auctionsBidRepository = auctionsBidRepository;
        }
        public async Task<CommandResult> Handle(CreateAuctionsBidCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateAuctionsBidCommandValidator();
            validator.ValidateAndThrow(request);
            var auctionsBid = new AuctionsBid(request.ProductId, request.CustomerId, request.Amount);
            await _auctionsBidRepository.CreatedAsync(auctionsBid);
            return new CommandResult(true, auctionsBid);
        }
    }
}
