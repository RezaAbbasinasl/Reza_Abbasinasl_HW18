using Business.Model.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.ProductService
{
    public interface IProductService : IGenericService<Product>
    {
        List<Product> FilterByStoreId(int id);
        void Edit(Product product);
        Product GetById(int id);
    }
}
