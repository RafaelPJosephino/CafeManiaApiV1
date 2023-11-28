using CafeManiaApi.Application.DTOs;

namespace CafeManiaApi.Application.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductDTO> GetProductsAll();
        void RegisterProduct(ProductDTO Product);
    }
}
