using Business.Model.Store;
using DataAccess;
using DataAccess.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.StoreService
{
    public class StoreService : IStoreService
    {
        private readonly IStoreDataAccess<Store> _storeDataAccess;

        public StoreService(IStoreDataAccess<Store> storeDataAccess)
        {
            _storeDataAccess = storeDataAccess;
        }

        public void AddStore(Store store)
        {
            var newStore = new Store
            {
                City = store.City,
                Email = store.Email,
                Phone = store.Phone,
                State = store.State,
                Store_Name = store.Store_Name,
                Street = store.Street,
                Zip_Code = store.Zip_Code
            };
            var query = "INSERT INTO sales.stores (store_name, email, phone, [state], street, city, zip_code) VALUES(@Store_Name, @Email, @Phone, @State, @Street, @City, @Zip_Code)";
            _storeDataAccess.AddOrModify(query,newStore);
        }

        public void EditStore(Store store)
        {
            var newStore = new Store
            {
                City = store.City,
                Email = store.Email,
                Phone = store.Phone,
                State = store.State,
                Store_Name = store.Store_Name,
                Street = store.Street,
                Zip_Code = store.Zip_Code,
                Store_Id = store.Store_Id
            };
            var query = "UPDATE sales.stores SET store_name = @Store_Name, city = @city, email = @Email, phone = @Phone, [state] = @State, street = @Street,zip_code = @Zip_Code WHERE store_id = @Store_Id";
            _storeDataAccess.AddOrModify(query, newStore);
        }

        public List<Store> FilterStores(string storeName, string zipCode)
        {
            var filter = _storeDataAccess.GetByFilterStore(storeName: storeName, zipCode: zipCode);
            return filter.Result;
        }

        public List<Store> GetAll()
        {
            var stores = _storeDataAccess.GetAll("sales.stores");
            return stores.Result;
        }

        public Store GetById(int id)
        {
            return _storeDataAccess.Search("sales.stores", $"store_id ={id}").Result;
        }
    }
}
