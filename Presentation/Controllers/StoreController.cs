using Business.Model.Store;
using Business.Services.StoreService;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class StoreController : Controller
    {
        private readonly IStoreService _storeService;
        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var stores = _storeService.GetAll();
            return View(stores);
        }
        [HttpPost]
        public IActionResult GetAll(string storeName, string zipCode) 
        {
            var filter = _storeService.FilterStores(storeName: storeName, zipCode: zipCode);

            return View(filter);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var store = _storeService.GetById(id);
            return View(store);
        }
        [HttpPost]
        public IActionResult Edit(Store store)
        {
            _storeService.EditStore(store);
            return RedirectToAction("GetAll");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Store store)
        {
            _storeService.AddStore(store);
            return RedirectToAction("GetAll");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _storeService.Delete(id);
            return RedirectToAction("GetAll");
        }
    }
}
