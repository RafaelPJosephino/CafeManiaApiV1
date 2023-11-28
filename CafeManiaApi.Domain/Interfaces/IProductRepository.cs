
using CafeManiaApi.Domain.Entities;

namespace CafeManiaApi.Domain.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProductsAll();

        void RegisterProduct(Product product);
    }
}
