using FluentValidation;
using Nivello.Domain.Commands.Auctions.Commands;
using Nivello.Lib.Nivello.Lib.Domain.Commands;

namespace Nivello.Domain.Commands.Auctions.Validators
{
    class CreateAuctionsBidCommandValidator : CommandValidator<CreateAuctionsBidCommand>
    {
        public CreateAuctionsBidCommandValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty().NotNull();
            RuleFor(x => x.CustomerId).NotEmpty().NotNull();
            RuleFor(x => x.Amount).NotEmpty().NotNull();
        }
    }
}
