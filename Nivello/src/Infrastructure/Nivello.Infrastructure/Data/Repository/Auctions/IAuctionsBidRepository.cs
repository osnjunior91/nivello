using Nivello.Infrastructure.Data.Model;
using Nivello.Lib.Nivello.Lib.Infrastructure.Data.Repository;
using System.Threading.Tasks;

namespace Nivello.Infrastructure.Data.Repository.Auctions
{
    public interface IAuctionsBidRepository : IRepository<AuctionsBid>
    {
        Task CreatedAsync(AuctionsBid customer);
    }
}
