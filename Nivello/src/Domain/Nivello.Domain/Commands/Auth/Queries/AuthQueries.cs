using Nivello.Lib.Nivello.Lib.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nivello.Domain.Commands.Auth.Queries
{
    public static class AuthQueries<T> where T : User
    {
        public static Expression<Func<T, bool>> LoginQuery(string email, string password)
        {
            return x => x.Email.Equals(email) && x.Password.Equals(password);
        }

       
    }
}
