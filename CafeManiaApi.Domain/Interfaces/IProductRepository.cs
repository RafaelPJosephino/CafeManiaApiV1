
using CafeManiaApi.Domain.Entities;

namespace CafeManiaApi.Domain.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProductsAll();
        void removeProduct(int id);
        void AddProduct(Product product);
    }
}
