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
    public class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<QueryResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            if(request == null || request?.Id == Guid.Empty)
            {
                throw new ArgumentNullException(typeof(GetProductByIdQuery).Name);
            }

            var products = await _productRepository.FirstOrDefaultAsync(ProductsQueries.GetById(request.Id));
            return new QueryResult(true, products);
        }
    }
}
