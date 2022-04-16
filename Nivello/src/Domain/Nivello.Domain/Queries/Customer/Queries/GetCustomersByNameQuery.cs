using Nivello.Lib.Nivello.Lib.Domain.Queries;

namespace Nivello.Domain.Queries.Customer.Queries
{
    public class GetCustomersByNameQuery : Query
    {
        public GetCustomersByNameQuery(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
