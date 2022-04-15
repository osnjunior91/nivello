using System;
using System.Linq.Expressions;

namespace Nivello.Domain.Queries.Products.Queries
{
    public static class CustomerQueries
    {
        public static Expression<Func<Infrastructure.Data.Model.Product, bool>> GetAll()
        {
            return x => x.IsDelete == false;
        }
        public static Expression<Func<Infrastructure.Data.Model.Product, bool>> GetById(Guid id)
        {
            return x => x.Id == id;
        }
    }
}
