using CafeManiaApi.Application.DTOs;
using CafeManiaApi.Domain.Entities;

namespace CafeManiaApi.Application.Interfaces
{
    public interface IOrderService
    {
        int RegisterOrder(AddOrderDTO order);
        Order GetOrderById(int idorder);
        List<Order> GetAllPerUser(int IdUser);
    }
}
