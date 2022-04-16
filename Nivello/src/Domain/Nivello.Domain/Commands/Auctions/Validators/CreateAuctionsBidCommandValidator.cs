using FluentValidation;
using Nivello.Domain.Commands.Auctions.Commands;
using Nivello.Lib.Nivello.Lib.Domain.Commands;

namespace Nivello.Domain.Commands.Auctions.Validators
{
    class CreateAuctionsBidCommandValidator : CommandValidator<CreateAuctionsBidCommand>
    {
        public CreateAuctionsBidCommandValidator()
        {
            RuleFor(x => x.ProductId).Must(ValidGuidEmpty).NotEmpty().NotNull();
            RuleFor(x => x.CustomerId).Must(ValidGuidEmpty).NotEmpty().NotNull();
            RuleFor(x => x.Amount).GreaterThan(0).NotEmpty().NotNull();
        }
    }
}
