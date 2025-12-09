using Entities;

namespace Services
{
    public interface IOrdersService
    {
        Task<Order> AddOrdersService(Order order);
        Task<Order?> ReturnOrderByIdService(int id);
    }
}