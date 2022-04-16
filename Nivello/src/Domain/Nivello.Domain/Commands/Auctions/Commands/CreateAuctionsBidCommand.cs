using Nivello.Lib.Nivello.Lib.Domain.Commands;
using System;

namespace Nivello.Domain.Commands.Auctions.Commands
{
    public class CreateAuctionsBidCommand : Command
    {
        public CreateAuctionsBidCommand() { }

        public CreateAuctionsBidCommand(Guid productId, Guid customerId, float amount)
        {
            ProductId = productId;
            CustomerId = customerId;
            Amount = amount;
        }

        public Guid ProductId { get; set; }
        public Guid CustomerId { get; set; }
        public float Amount { get; set; }
    }
}
