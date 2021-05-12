using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Core;

namespace Dapper.Data
{
    public interface IRepository<TEntity> where TEntity: class
    {
        T GetById<T>(string storedProcedureName, int id) where T : BaseEntity;
        IEnumerable<T> GetAll<T>(string storedProcedureName,object param = null) where T : BaseEntity;
        int Add<T>(string storedProcedureName, T entity) where T : BaseEntity;
        int Update<T>(string storedProcedureName, T entity) where T : BaseEntity;
        int Delete(string storedProcedureName, int id);

        Task<T> GetByIdAsync<T>(string storedProcedureName, int id) where T : BaseEntity;
        Task<IEnumerable<T>> GetAllAsync<T>(string storedProcedureName, object param = null) where T : BaseEntity;
        Task<int> AddAsync<T>(string storedProcedureName, T entity) where T : BaseEntity;
        Task<int> UpdateAsync<T>(string storedProcedureName, T entity) where T : BaseEntity;
        Task<int> DeleteAsync(string storedProcedureName, int id);
    }
}
