using Nivello.Infrastructure.Data.Model;
using Nivello.Lib.Nivello.Lib.Infrastructure.Data.Repository;
using System.Threading.Tasks;

namespace Nivello.Infrastructure.Data.Repository.Products
{
    public interface IProductRepository : IRepository<Product>
    {
        Task CreatedAsync(Product product);
    }
}
