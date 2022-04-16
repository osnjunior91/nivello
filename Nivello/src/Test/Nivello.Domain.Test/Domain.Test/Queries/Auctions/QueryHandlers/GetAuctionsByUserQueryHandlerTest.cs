using Moq;
using Nivello.Domain.Queries.Auctions.Queries;
using Nivello.Domain.Queries.Auctions.QueryHandlers;
using Nivello.Infrastructure.Data.Model;
using Nivello.Infrastructure.Data.Repository.Auctions;
using Nivello.Lib.Nivello.Lib.Domain.Queries;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Nivello.Test.Domain.Test.Queries.Auctions.QueryHandlers
{
    public class GetAuctionsByUserQueryHandlerTest
    {
        private Mock<IAuctionsBidRepository> _auctionsBidRepository;
        private List<AuctionsBid> Bids;
        private Guid customerId;

        [SetUp]
        public void Setup()
        {
            customerId = Guid.NewGuid();
            Bids = new List<AuctionsBid>()
            {
                new AuctionsBid(Guid.NewGuid(), customerId, 200),
                new AuctionsBid(Guid.NewGuid(), customerId, 80),
                new AuctionsBid(Guid.NewGuid(), null, customerId, null, 80, false),
            };
            _auctionsBidRepository = new Mock<IAuctionsBidRepository>();
            _auctionsBidRepository.Setup(m => m.WhereAsync(It.IsAny<Expression<Func<AuctionsBid, bool>>>())).ReturnsAsync(Bids);
        }

        [Test]
        public async Task When_Find_All_AuctionsByUser_IsOkAsync()
        {
            var handler = new GetAuctionsByUserQueryHandler(_auctionsBidRepository.Object);
            var response = await handler.Handle(new GetAuctionsByUserIdQuery(customerId), new System.Threading.CancellationToken());
            Assert.That(response, Is.InstanceOf<QueryResult>());
            Assert.IsTrue(((IEnumerable)response.Data).Cast<object>().ToList().Count == Bids.Count);
        }

    }
}
