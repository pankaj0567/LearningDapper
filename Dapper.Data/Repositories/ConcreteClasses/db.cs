using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Data.Repositories.Interface;

namespace Dapper.Data.Repositories.ConcreteClasses
{
    public class Db: DapperRepository<object>,IDb
    {
    }
}
