using AutoMapper;
using CafeManiaApi.Application.DTOs;
using CafeManiaApi.Application.Interfaces;
using CafeManiaApi.Domain.Entities;
using CafeManiaApi.Domain.Interfaces;

namespace CafeManiaApi.Application.Services
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public void RegisterProduct(ProductDTO product)
        {
            var Produto = _mapper.Map<Product>(product);
            _productRepository.AddProduct(Produto);
        }

        public void RemoverProduct(int idproduct)
        {
            _productRepository.removeProduct(idproduct);
        }

        public IEnumerable<ProductDTO> GetProductsAll()
        {
            var ListaProdutos = _productRepository.GetProductsAll();
            return _mapper.Map<IEnumerable<ProductDTO>>(ListaProdutos);
        }

        


    }
}
