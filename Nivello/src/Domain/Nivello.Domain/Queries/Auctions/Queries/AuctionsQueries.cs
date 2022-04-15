using Nivello.Infrastructure.Data.Model;
using Nivello.Lib.Nivello.Lib.Infrastructure.Data.Models;
using System;
using System.Linq.Expressions;

namespace Nivello.Domain.Queries.Auctions.Queries
{
    public static class AuctionsQueries
    {
        public static Expression<Func<AuctionsBid, bool>> GetActiveByProductId(Guid productId)
        {
            return x => x.ProductId == productId && x.IsActive == true;
        }

       
    }
}
