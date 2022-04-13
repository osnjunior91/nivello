using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nivello.Lib.Nivello.Lib.Domain.Queries.Interfaces
{
    public interface IQueryHandler<T> : IRequestHandler<T, QueryResult> where T : Query
    {
    }
}
