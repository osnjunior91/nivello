using Nivello.Infrastructure.Data.Model;
using Nivello.Lib.Nivello.Lib.Infrastructure.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nivello.Infrastructure.Data.Repository.Admins
{
    public interface IAdminRepository : IRepository<SystemAdmin>
    {
        Task<SystemAdmin> FirstOrDefaultAsync(Expression<Func<SystemAdmin, bool>> filter);
    }
}
