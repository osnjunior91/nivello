using Nivello.Infrastructure.Data.Model;
using Nivello.Lib.Nivello.Lib.Infrastructure.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Nivello.Infrastructure.Data.Repository.Customers
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task CreatedAsync(Customer customer);
        Task<Customer> FirstOrDefaultAsync(Expression<Func<Customer, bool>> filter);
        Task<IEnumerable<Customer>> WhereAsync(Expression<Func<Customer, bool>> filter);
    }
}
