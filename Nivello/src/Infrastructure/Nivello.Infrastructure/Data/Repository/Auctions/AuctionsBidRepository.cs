using Microsoft.EntityFrameworkCore;
using Nivello.Infrastructure.Data.Context;
using Nivello.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task CreatedAsync(AuctionsBid customer)
        {
            await _dataset.AddAsync(customer);
            _dataContext.SaveChangesAsync().Wait();
        }
    }
}
