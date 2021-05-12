using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Data.Repositories.Interface;

namespace Dapper.Data
{
    public class DbContext : IDbContext
    {
        
        public IEmployeeRepository Employee { get; }
        public IDb Db { get; }

        public DbContext(IEmployeeRepository employeeRepository,IDb db)
        {
            Employee = employeeRepository;
            Db = db;
        }
    }
}
