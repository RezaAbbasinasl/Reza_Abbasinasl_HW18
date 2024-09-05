using Business.Model.Product;
using Business.Services.ProductService;
using DataAccess.Product;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productDataAccess)
        {
            _productService = productDataAccess;
        }
        public IActionResult GetProductsByStoreId(int id)
        {
            var result =  _productService.FilterByStoreId(id);
            return View(result);
        }
        [HttpGet]
        public IActionResult Edit(int id) 
        { 
            return View(_productService.GetById(id)); 
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            _productService.Edit(product);
            return RedirectToAction("GetAll","Store");
        }
    }
}
