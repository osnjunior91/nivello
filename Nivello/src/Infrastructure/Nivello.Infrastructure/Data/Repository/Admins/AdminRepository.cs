using Microsoft.EntityFrameworkCore;
using Nivello.Infrastructure.Data.Context;
using Nivello.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nivello.Infrastructure.Data.Repository.Admins
{
    public class AdminRepository : IAdminRepository
    {
        private readonly DbSet<SystemAdmin> _dataset;
        public AdminRepository(DataContext dataContext)
        {
            _dataset = dataContext.Set<SystemAdmin>();
        }
        public async Task<SystemAdmin> FirstOrDefaultAsync(Expression<Func<SystemAdmin, bool>> filter)
        {
            return await _dataset.SingleOrDefaultAsync(filter);
        }
    }
}
