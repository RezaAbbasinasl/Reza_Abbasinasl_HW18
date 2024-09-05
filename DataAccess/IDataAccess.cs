using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IDataAccess<T>
    {
        Task<List<T>> GetAll(string tableName);
        Task AddOrModify(string query, T parameter);
        Task<T?> Search(string tableName, string whereClause);
        Task Delete(string tableName, string condition);
    }
}
