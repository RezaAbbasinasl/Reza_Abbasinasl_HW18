using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Store
{
    public class StoreDataAccess<T> : IStoreDataAccess<T>
    {
        private readonly IDbConnection _dbConnection;
        public StoreDataAccess(IConfiguration configuration)
        {
            _dbConnection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public async Task AddOrModify(string query, T parameter)
        {
            using (var con = _dbConnection)
            {
                con.Open();
                var result = await con.ExecuteAsync(query, parameter);
            }
        }

        public async Task<List<T>> GetAll(string tableName)
        {
            using (var con = _dbConnection)
            {
                con.Open();
                var getTable = await con.QueryAsync<T>($"SELECT * FROM {tableName}");
                return getTable.ToList();
            }
        }

        public async Task<List<T>> GetByFilterStore(string storeName, string zipCode)
        {
            using (var con = _dbConnection)
            {
                con.Open();
                var query = "SELECT * FROM sales.stores WHERE store_name LIKE @StoreName AND zip_code LIKE @ZipCode";
                var getTable = await con.QueryAsync<T>(query, new { StoreName = $"%{storeName}%", ZipCode = $"%{zipCode}%" });
                return getTable.ToList();
            }
        }

        public async Task<T?> Search(string tableName, string whereClause)
        {
            using (var con = _dbConnection)
            {
                con.Open();
                var result = con.QueryFirstAsync<T>($"SELECT * FROM {tableName} WHERE {whereClause}");
                return await result;
            }
        }
    }
}
