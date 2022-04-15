using Nivello.Domain.Queries.Customer.Queries;
using Nivello.Infrastructure.Data.Repository.Products;
using Nivello.Lib.Nivello.Lib.Domain.Queries;
using Nivello.Lib.Nivello.Lib.Domain.Queries.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Nivello.Domain.Queries.Customer.QueryHandlers
{
    public class GetCustomersByNameQueryHandler : IQueryHandler<GetCustomersByNameQuery>
    {
        private readonly IProductRepository _productRepository;

        public GetCustomersByNameQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<QueryResult> Handle(GetCustomersByNameQuery request, CancellationToken cancellationToken)
        {
            return new QueryResult(true, null, "Ok");
        }
    }
}
