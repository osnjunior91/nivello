using Nivello.Domain.Queries.Customer.Queries;
using Nivello.Infrastructure.Data.Repository.Customers;
using Nivello.Lib.Nivello.Lib.Domain.Queries;
using Nivello.Lib.Nivello.Lib.Domain.Queries.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Nivello.Domain.Queries.Customer.QueryHandlers
{
    public class GetCustomersByNameQueryHandler : IQueryHandler<GetCustomersByNameQuery>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomersByNameQueryHandler(ICustomerRepository customerRepository)
        {   
            _customerRepository = customerRepository;
        }
        public async Task<QueryResult> Handle(GetCustomersByNameQuery request, CancellationToken cancellationToken)
        {
            var response = await _customerRepository.WhereAsync(CustomerQueries.GetByName(request.Name));
            return new QueryResult(true, response);
        }
    }
}
