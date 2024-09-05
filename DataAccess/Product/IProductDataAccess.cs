using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Product
{
    public interface IProductDataAccess<T>:IDataAccess<T>
    {
        List<T> GetProductsByStoreId(int id);
    }
}
