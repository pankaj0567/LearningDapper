using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Core.Domain.Employee;

namespace Dapper.Data.Repositories.Interface
{
    public interface IEmployeeRepository: IRepository<Employee>
    {

    }
}
