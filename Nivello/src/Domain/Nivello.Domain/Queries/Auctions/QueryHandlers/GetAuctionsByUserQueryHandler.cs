using Nivello.Domain.Queries.Auctions.Queries;
using Nivello.Infrastructure.Data.Repository.Auctions;
using Nivello.Lib.Nivello.Lib.Domain.Queries;
using Nivello.Lib.Nivello.Lib.Domain.Queries.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Nivello.Domain.Queries.Auctions.QueryHandlers
{
    public class GetAuctionsByUserQueryHandler : IQueryHandler<GetAuctionsByUserIdQuery>
    {
        private readonly IAuctionsBidRepository _auctionsBidRepository;

        public GetAuctionsByUserQueryHandler(IAuctionsBidRepository auctionsBidRepository)
        {
            _auctionsBidRepository = auctionsBidRepository;
        }
        public async Task<QueryResult> Handle(GetAuctionsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _auctionsBidRepository.WhereAsync(AuctionsQueries.GetAuctionsByCustomerId(request.CustomerID));
            return new QueryResult(true, response);
        }
    }
}
