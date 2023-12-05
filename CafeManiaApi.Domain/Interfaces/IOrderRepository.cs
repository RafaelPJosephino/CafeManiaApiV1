using CafeManiaApi.Domain.Entities;

namespace CafeManiaApi.Domain.Interfaces
{
    public interface IOrderRepository
    {
        void RegisterOrder(Order order);

        Order GetOrderById(int IdUser);

        IEnumerable<Order> GetAllPerUser(int IdUser);

        List<ProductOrder> AdicionarItens(List<ProductOrder> produtos);
    }
}
