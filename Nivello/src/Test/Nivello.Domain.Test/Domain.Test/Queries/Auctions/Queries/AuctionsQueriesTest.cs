using Nivello.Domain.Queries.Auctions.Queries;
using Nivello.Infrastructure.Data.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nivello.Test.Domain.Test.Queries.Auctions.Queries
{
    public class AuctionsQueriesTest
    {
        private List<AuctionsBid> Bids;
        private Guid productId;
        private Guid customerId;

        [SetUp]
        public void Setup()
        {
            productId = Guid.NewGuid();
            customerId = Guid.NewGuid();
            Bids = new List<AuctionsBid>()
            {
                new AuctionsBid(productId, customerId, 200),
                new AuctionsBid(productId, null, Guid.NewGuid(), null, 100, false),
                new AuctionsBid(productId, null, Guid.NewGuid(), null, 80, false),
                new AuctionsBid(Guid.NewGuid(), customerId, 80),
                new AuctionsBid(Guid.NewGuid(), null, customerId, null, 80, false),
            };
        }

        [Test]
        public void AuctionsQueries_GetActiveByProduct_IsOk()
        {
            var response = Bids.AsQueryable().Count(AuctionsQueries.GetActiveByProductId(productId));
            Assert.IsTrue(response == 1);
        }

        [Test]
        public void AuctionsQueries_GetAuctionsByCustomerId_IsOk()
        {
            var response = Bids.AsQueryable().Count(AuctionsQueries.GetAuctionsByCustomerId(customerId));
            Assert.IsTrue(response == 3);
        }

        [Test]
        public void AuctionsQueries_Invalid_IsOk()
        {
            var bid = new List<AuctionsBid>()
            {
                new AuctionsBid(productId, customerId, 200),
            };

            Assert.IsTrue(bid.AsQueryable().Count(AuctionsQueries.GetActiveByProductId(productId)) == 1);
            bid[0].Inactivate();
            Assert.IsTrue(bid.AsQueryable().Count(AuctionsQueries.GetActiveByProductId(productId)) == 0);
        }
    }
}
