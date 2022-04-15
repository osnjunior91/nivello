using Nivello.Lib.Nivello.Lib.Domain.Data.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

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

        public AuctionsBid(Guid productId, Guid customerId, float amount)
        {
            ProductId = productId;
            CustomerId = customerId;
            Amount = amount;
            IsActive = true;
        }

        public void Inactivate() => IsActive = false;

        public Guid ProductId { get; private set; }
        [NotMapped]
        public Product Product { get; private set; }
        public Guid CustomerId { get; private set; }
        [NotMapped]
        public Customer Customer { get; private set; }
        public float Amount { get; private set; }
        public bool IsActive { get; private set; }
    }
}
