using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Core;
using Dapper;
using Dapper.Core.Domain.Employee;

namespace Dapper.Data
{
    public class DapperRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly IDbConnection _connection;
        public DapperRepository()
        {
            string constr = ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString;
            _connection = new SqlConnection(constr);
        }

        public int Add<T>(string storedProcedureName, T entity) where T : BaseEntity
        {
            return _connection.Execute(storedProcedureName, entity, commandType: CommandType.StoredProcedure);
        }
        public async Task<int> AddAsync<T>(string storedProcedureName, T entity) where T : BaseEntity
        {
            return await ExecuteAsync(storedProcedureName, entity);
        }

        private async Task<int> ExecuteAsync<T>(string storedProcedureName, T entity) where T : BaseEntity => await _connection.ExecuteAsync(storedProcedureName, entity, commandType: CommandType.StoredProcedure); 
        public int Delete(string storedProcedureName, int id)
        {
            return _connection.Execute(storedProcedureName, new { @Id = id }, commandType: CommandType.StoredProcedure);
        }
        public async Task<int> DeleteAsync(string storedProcedureName, int id)
        {
            return await _connection.ExecuteAsync(storedProcedureName, new { @Id = id }, commandType: CommandType.StoredProcedure);
        }
        public IEnumerable<T> GetAll<T>(string storedProcedureName, object param = null) where T : BaseEntity
        {
            return _connection.Query<T>(storedProcedureName, param, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<T>> GetAllAsync<T>(string storedProcedureName, object param = null) where T : BaseEntity
        {
            return await _connection.QueryAsync<T>(storedProcedureName, param, commandType: CommandType.StoredProcedure);
        }
        public T GetById<T>(string storedProcedureName, int id) where T : BaseEntity
        {
            var data = _connection.Query<T>(storedProcedureName, new { @Id = id }, commandType: CommandType.StoredProcedure);
            return data.FirstOrDefault();
        }
        public async Task<T> GetByIdAsync<T>(string storedProcedureName, int id) where T : BaseEntity
        {
            var data = await _connection.QueryAsync<T>(storedProcedureName, new { @Id = id },commandType:CommandType.StoredProcedure);
            return data.FirstOrDefault();
        }
        public int Update<T>(string storedProcedureName, T entity) where T : BaseEntity
        {
            return Add(storedProcedureName, entity);
        }
        public async Task<int> UpdateAsync<T>(string storedProcedureName, T entity) where T : BaseEntity
        {
            return await ExecuteAsync(storedProcedureName, entity);
        }
    }
}
