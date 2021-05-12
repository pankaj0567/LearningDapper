using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Core.Domain.Employee
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Email { get; set; }
        public int Gender { get; set; }
    }
}
