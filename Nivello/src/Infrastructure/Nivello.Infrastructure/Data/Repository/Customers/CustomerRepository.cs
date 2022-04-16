using Microsoft.EntityFrameworkCore;
using Nivello.Infrastructure.Data.Context;
using Nivello.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nivello.Infrastructure.Data.Repository.Customers
{
    [ExcludeFromCodeCoverage]
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _dataContext;
        private readonly DbSet<Customer> _dataset;
        public CustomerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
            _dataset = dataContext.Set<Customer>();
        }
        public async Task CreatedAsync(Customer customer)
        {
            await _dataset.AddAsync(customer);
            _dataContext.SaveChangesAsync().Wait();
        }

        public async Task<Customer> FirstOrDefaultAsync(Expression<Func<Customer, bool>> filter)
        {
            return await _dataset.Include(x => x.Bids).SingleOrDefaultAsync(filter);
        }

        public async Task<IEnumerable<Customer>> WhereAsync(Expression<Func<Customer, bool>> filter)
        {
            return await _dataset.Include(x => x.Bids).AsQueryable().Where(filter).ToListAsync();
        }
    }
}
