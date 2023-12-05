using AutoMapper;
using CafeManiaApi.Application.DTOs;
using CafeManiaApi.Application.Interfaces;
using CafeManiaApi.Domain.Entities;
using CafeManiaApi.Domain.Interfaces;

namespace CafeManiaApi.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderService(
            IUserRepository userRepository,
            IProductRepository productRepository,
            IOrderRepository orderRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            
        }
        public int RegisterOrder(AddOrderDTO order)
        {
            var usuario = _userRepository.GetUserById(order.User);

            var produtos = _productRepository
                .GetProductsAll()
                .Where(p => order.Products.Contains(p.Id))
                .ToList();

            var orderfinalizada = new Order(
                usuario.Id,
                DateTime.UtcNow,
                false,
                usuario);

            var produtosOrdem = produtos.ConvertAll(p => new ProductOrder
            {
                OrderId = orderfinalizada.Id,
                ProductId = p.Id,
                Order = orderfinalizada,
                Product = p,
            });

            orderfinalizada.Products = produtosOrdem;

            _orderRepository.RegisterOrder(orderfinalizada);

            return orderfinalizada.Id;
        }

        public List<Order> GetAllPerUser(int IdUser)
        {
            var orders = _orderRepository.GetAllPerUser(IdUser).ToList();

            return orders;
        }


        public Order GetOrderById(int idorder)
        {
            return _orderRepository.GetOrderById(idorder);
        }

    }
}
