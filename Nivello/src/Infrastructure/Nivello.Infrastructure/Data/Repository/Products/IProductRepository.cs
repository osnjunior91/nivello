using Nivello.Infrastructure.Data.Model;
using Nivello.Lib.Nivello.Lib.Infrastructure.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Nivello.Infrastructure.Data.Repository.Products
{
    public interface IProductRepository : IRepository<Product>
    {
        Task CreatedAsync(Product product);
        Task<IEnumerable<Product>> WhereAsync(Expression<Func<Product, bool>> filter);
    }
}
