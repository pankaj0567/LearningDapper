using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Data.Repositories.Interface;

namespace Dapper.Data
{
    public interface IDbContext
    {
        IEmployeeRepository Employee { get; }
        IDb Db { get; }
    }
}
