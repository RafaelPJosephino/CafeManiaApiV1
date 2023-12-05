using CafeManiaApi.Domain.Entities;
using CafeManiaApi.Domain.Interfaces;
using CafeManiaApi.Infra.Data.Context;

namespace CafeManiaApi.Infra.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICollection<Order> Recuperar()
        {
            return _context.Order.ToList();
        }

        public void RegisterOrder(Order order)
        {
            _context.Order.Add(order);
            _context.SaveChanges();
        }

        public IEnumerable<Order> GetAllPerUser(int idUser)
        {
            var orders = _context.Order
                .Where((p) => p.User.Id == idUser)
                .Select(o => new Order(
                    o.Id,
                    o.UserId,
                    o.DateOrder,
                    o.Finished,
                    o.User,
                    o.Products
                    ));

            return orders;
        }

        public List<ProductOrder> AdicionarItens(List<ProductOrder> produtos)
        {
            _context.ProductOrder.AddRange(produtos);
            _context.SaveChanges();
            return produtos;
        }
        public Order GetOrderById(int IdOrder)
        {
            var order = _context.Order.FirstOrDefault((o)=> o.Id == IdOrder);
            return order;
        }

        
    }
}
