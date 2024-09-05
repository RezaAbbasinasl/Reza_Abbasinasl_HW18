using Business.Model.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.StoreService
{
    public interface IStoreService : IGenericService<Store>
    {
        List<Store> FilterStores(string storeName, string zipCode);
        void AddStore(Store store);
        void EditStore(Store store);
        Store GetById(int id);
    }
}
