using Nivello.Lib.Nivello.Lib.Domain.Queries;
using System;

namespace Nivello.Domain.Queries.Products.Queries
{
    public class GetProductByIdQuery : Query
    {
        public GetProductByIdQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; private set; }
    }
}
