using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Store
{
    public interface IStoreDataAccess<T> : IDataAccess<T>
    {
        Task<List<T>> GetByFilterStore(string storeName, string zipCode);
    }
}
