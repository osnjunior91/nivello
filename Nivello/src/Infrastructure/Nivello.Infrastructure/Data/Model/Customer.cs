using Nivello.Lib.Nivello.Lib.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;

namespace Nivello.Infrastructure.Data.Model
{
    public class Customer : User
    {
        public Customer(string name, string email, string password, DateTime dateOfBirth)
            : base(name, email, password)
        {
            DateOfBirth = dateOfBirth;
        }
        public DateTime DateOfBirth { get; private set; }
        public List<AuctionsBid> Bids { get; private set; }
    }
}
