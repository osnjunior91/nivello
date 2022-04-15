using Nivello.Infrastructure.Data.Model;
using Nivello.Lib.Nivello.Lib.Infrastructure.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Nivello.Infrastructure.Data.Repository.Auctions
{
    public interface IAuctionsBidRepository : IRepository<AuctionsBid>
    {
        Task CreatedAsync(AuctionsBid auctionsBid);
        Task CreatedAndUpdateAsync(AuctionsBid newAuctionsBid, AuctionsBid lastAuctionsBid);
        Task<AuctionsBid> FirstOrDefaultAsync(Expression<Func<AuctionsBid, bool>> filter);
        Task<IEnumerable<AuctionsBid>> WhereAsync(Expression<Func<AuctionsBid, bool>> filter);
        Task UpdateAsync(AuctionsBid auctionsBid);
    }
}
