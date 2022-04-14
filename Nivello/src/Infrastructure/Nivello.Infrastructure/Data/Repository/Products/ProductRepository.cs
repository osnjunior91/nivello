using Microsoft.EntityFrameworkCore;
using Nivello.Infrastructure.Data.Context;
using Nivello.Infrastructure.Data.Model;
using System;
using System.Threading.Tasks;

namespace Nivello.Infrastructure.Data.Repository.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _dataContext;
        private readonly DbSet<Product> _dataset;
        public ProductRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
            _dataset = dataContext.Set<Product>();
        }
        public async Task CreatedAsync(Product product)
        {
            await _dataset.AddAsync(product);
            _dataContext.SaveChangesAsync().Wait();
        }
    }
}
