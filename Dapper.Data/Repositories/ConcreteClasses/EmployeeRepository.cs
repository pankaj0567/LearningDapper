using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Core;
using Dapper.Core.Domain.Employee;
using Dapper.Data.Repositories.Interface;

namespace Dapper.Data.Repositories.ConcreteClasses
{
    public class EmployeeRepository : DapperRepository<Employee>, IEmployeeRepository
    {
    }
}
