
using Nivello.Lib.Nivello.Lib.Infrastructure.Data.Models;

namespace Nivello.Infrastructure.Data.Model
{
    public class SystemAdmin : User
    {
        public SystemAdmin(string name, string email, string password) 
            : base(name, email, password)
        {  
        }
    }
}
