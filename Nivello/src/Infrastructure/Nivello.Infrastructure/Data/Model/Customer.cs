using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nivello.Infrastructure.Data.Model
{
    public class Customer : User
    {
        public DateTime DateOfBirth { get; set; }
    }
}
