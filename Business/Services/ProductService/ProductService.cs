using Business.Model.Product;
using DataAccess.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductDataAccess<Product> _productDataAccess;
        public ProductService(IProductDataAccess<Product> productDataAccess)
        {
            _productDataAccess = productDataAccess;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(Product product)
        {
            var newProduct = new Product
            {
                List_Price = product.List_Price,
                Model_Year = product.Model_Year,
                Product_Id = product.Product_Id,
                Product_Name = product.Product_Name
            };
            var query = $"UPDATE production.products SET product_name = @Product_Name, list_price = @List_Price, model_year = @Model_Year  WHERE product_id = @Product_Id";

            _productDataAccess.AddOrModify(query, newProduct);
        }

        public List<Product> FilterByStoreId(int id)
        {
            return _productDataAccess.GetProductsByStoreId(id);
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            var result = _productDataAccess.Search("production.products", $"product_id ={id}");
            return result.Result;
        }
    }
}
