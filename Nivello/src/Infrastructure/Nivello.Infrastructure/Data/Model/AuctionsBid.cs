using Nivello.Lib.Nivello.Lib.Domain.Data.Models;
using System;

namespace Nivello.Infrastructure.Data.Model
{
    public class AuctionsBid : Entity
    {
        public AuctionsBid() { }
        public AuctionsBid(Guid productId, Product product, Guid customerId, 
            Customer customer, float amount, bool isActive)
        {
            ProductId = productId;
            Product = product;
            CustomerId = customerId;
            Customer = customer;
            Amount = amount;
            IsActive = isActive;
        }

        public Guid ProductId { get; private set; }
        public Product Product { get; private set; }
        public Guid CustomerId { get; private set; }
        public Customer Customer { get; private set; }
        public float Amount { get; private set; }
        public bool IsActive { get; private set; }
    }
}
