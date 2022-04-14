using Nivello.Lib.Nivello.Lib.Domain.Commands;
using System;

namespace Nivello.Domain.Commands.Auctions.Commands
{
    public class CreateAuctionsBidCommand : Command
    {
        public Guid ProductId { get; set; }
        public Guid CustomerId { get; set; }
        public float Amount { get; set; }
    }
}
