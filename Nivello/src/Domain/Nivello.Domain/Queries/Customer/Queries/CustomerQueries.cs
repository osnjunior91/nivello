using System;
using System.Linq.Expressions;

namespace Nivello.Domain.Queries.Customer.Queries
{
    public static class CustomerQueries
    {
        public static Expression<Func<Infrastructure.Data.Model.Customer, bool>> GetById(Guid id)
        {
            return x => x.Id == id;
        }

        public static Expression<Func<Infrastructure.Data.Model.Customer, bool>> GetByName(string name)
        {
            return x => x.Name.Contains(name);
        }
    }
}
