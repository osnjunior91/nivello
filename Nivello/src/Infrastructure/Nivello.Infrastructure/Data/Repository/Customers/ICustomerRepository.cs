using Nivello.Infrastructure.Data.Model;
using Nivello.Lib.Nivello.Lib.Infrastructure.Data.Repository;
using System.Threading.Tasks;

namespace Nivello.Infrastructure.Data.Repository.Customers
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task CreatedAsync(Customer customer);
    }
}
