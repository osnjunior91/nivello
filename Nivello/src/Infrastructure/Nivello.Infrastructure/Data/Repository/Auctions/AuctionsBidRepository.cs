using Microsoft.EntityFrameworkCore;
using Nivello.Infrastructure.Data.Context;
using Nivello.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Nivello.Infrastructure.Data.Repository.Auctions
{
    public class AuctionsBidRepository : IAuctionsBidRepository
    {
        private readonly DataContext _dataContext;
        private readonly DbSet<AuctionsBid> _dataset;
        public AuctionsBidRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
            _dataset = dataContext.Set<AuctionsBid>();
        }

        public async Task CreatedAndUpdateAsync(AuctionsBid newAuctionsBid, AuctionsBid lastAuctionsBid)
        {
            using var transaction = _dataContext.Database.BeginTransaction();
            try
            {
                if(lastAuctionsBid != null)
                    await UpdateAsync(lastAuctionsBid);
                if (newAuctionsBid != null)
                    await CreatedAsync(newAuctionsBid);
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task CreatedAsync(AuctionsBid auctionsBid)
        {
            await _dataset.AddAsync(auctionsBid);
            _dataContext.SaveChangesAsync().Wait();
        }

        public async Task<AuctionsBid> FirstOrDefaultAsync(Expression<Func<AuctionsBid, bool>> filter)
        {
            return await _dataset.SingleOrDefaultAsync(filter);
        }

        public async Task UpdateAsync(AuctionsBid auctionsBid)
        {
            _dataset.Update(auctionsBid);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<AuctionsBid>> WhereAsync(Expression<Func<AuctionsBid, bool>> filter)
        {
            return await _dataset.AsQueryable().Where(filter).ToListAsync();
        }
    }
}
