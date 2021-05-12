using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Core;

namespace Dapper.Data
{
    public class EntityRepository 
    {
        public Task<T> AddAsync<T>(T entity) where T : BaseEntity => throw new NotImplementedException();
        public Task DeleteAsync<T>(T entity) where T : BaseEntity => throw new NotImplementedException();
        public Task<T> GetByIdAsync<T>(int id) where T : BaseEntity => throw new NotImplementedException();
        public Task<List<T>> ListAsync<T>() where T : BaseEntity
        {
            throw new NotImplementedException();
        }
        public Task UpdateAsync<T>(T entity) where T : BaseEntity => throw new NotImplementedException();


    }
}
