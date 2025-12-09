using Entities;

namespace Repositories
{
    public interface IOrdersRepositoriy
    {
        Task<Order> AddOrdersRepositories(Order order);
        Task<Order?> ReturnOrderByIdRepositories(int id);
    }
}