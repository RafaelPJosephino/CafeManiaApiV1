using CafeManiaApi.Domain.Entities;
using CafeManiaApi.Domain.Interfaces;
using CafeManiaApi.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManiaApi.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetProductsAll()
        {
            return _context.Product.ToList();
        }

        public void AddProduct(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
        }
        public void removeProduct(int id)
        {
            var produto = _context.Product.First(x => x.Id == id);
            _context.Remove(produto);
            _context.SaveChanges();
        }
    }
}
