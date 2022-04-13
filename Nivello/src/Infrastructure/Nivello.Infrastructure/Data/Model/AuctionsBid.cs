using Nivello.Lib.Nivello.Lib.Domain.Data.Models;
using System;

namespace Nivello.Infrastructure.Data.Model
{
    public class AuctionsBid : Entity
    {
        public Guid ProductId { get; private set; }
        public Product Product { get; private set; }
        public Guid CustomerId { get; private set; }
        public Customer Customer { get; private set; }
        public float Amount { get; private set; }
        public bool IsActive { get; private set; }
    }
}
