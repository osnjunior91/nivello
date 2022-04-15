using Nivello.Domain.Queries.Products.Queries;
using Nivello.Infrastructure.Data.Repository.Products;
using Nivello.Lib.Nivello.Lib.Domain.Queries;
using Nivello.Lib.Nivello.Lib.Domain.Queries.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nivello.Domain.Queries.Products.QueryHandlers
{
    public class GetCustomersByNameQueryHandler : IQueryHandler<GetAllProductsQuery>
    {
        private readonly IProductRepository _productRepository;

        public GetCustomersByNameQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<QueryResult> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.WhereAsync(ProductsQueries.GetAll());
            return new QueryResult(true, products);
        }
    }
}
