
using InventoryApi.Models;
using InventoryApi.Dtos;

namespace InventoryApi.Services {
    public interface IProductService {
        IEnumerable<Product> GetAll();
        Product? GetById(int id);
        Product Create(ProductDto dto);
        void Update(int id, ProductDto dto);
        void Delete(int id);
    }
}
