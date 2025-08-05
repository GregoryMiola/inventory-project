
using InventoryApi.Models;
using InventoryApi.Dtos;

namespace InventoryApi.Services {
    public class ProductService : IProductService {
        private readonly List<Product> _products = new();
        private int _nextId = 1;

        public IEnumerable<Product> GetAll() => _products;

        public Product? GetById(int id) =>
            _products.FirstOrDefault(p => p.Id == id);

        public Product Create(ProductDto dto) {
            var product = new Product {
                Id = _nextId++,
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                Quantity = dto.Quantity
            };
            _products.Add(product);
            return product;
        }

        public void Update(int id, ProductDto dto) {
            var product = GetById(id);
            if (product == null) return;
            product.Name = dto.Name;
            product.Description = dto.Description;
            product.Price = dto.Price;
            product.Quantity = dto.Quantity;
        }

        public void Delete(int id) =>
            _products.RemoveAll(p => p.Id == id);
    }
}
