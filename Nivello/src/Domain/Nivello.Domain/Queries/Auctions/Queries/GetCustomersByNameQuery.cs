using Nivello.Lib.Nivello.Lib.Domain.Queries;
using System;

namespace Nivello.Domain.Queries.Auctions.Queries
{
    public class GetAuctionsByUserIdQuery : Query
    {
        public Guid CustomerID { get; private set; }

        public GetAuctionsByUserIdQuery(Guid customerID)
        {
            CustomerID = customerID;
        }
    }
}
