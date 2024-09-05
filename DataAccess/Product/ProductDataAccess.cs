using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DataAccess.Product
{
    public class ProductDataAccess<T> : IProductDataAccess<T>
    {
        private readonly IDbConnection _dbConnection;
        public ProductDataAccess(IConfiguration configuration)
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

        public List<T> GetProductsByStoreId(int id)
        {
            using (var con = _dbConnection)
            {
                con.Open();
                var query = $"SELECT pp.product_name as product_name,pp.product_id as product_id, pp.model_year as model_year, pp.list_price as list_price FROM sales.stores AS ss \r\nJOIN production.stocks AS ps ON ps.store_id = ss.store_id \r\nLEFT JOIN production.products AS pp ON pp.product_id = ps.product_id \r\nWHERE ss.store_id = {id}";
                var getTable = con.Query<T>(query);
                return  getTable.ToList();
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
