using Nivello.Lib.Nivello.Lib.Infrastructure.Data.Models;
using System;
using System.Linq.Expressions;

namespace Nivello.Domain.Queries.Auth.Queries
{
    public static class AuthQueries<T> where T : User
    {
        public static Expression<Func<T, bool>> LoginQuery(string email, string password)
        {
            return x => x.Email.Equals(email) && x.Password.Equals(password);
        }

       
    }
}
