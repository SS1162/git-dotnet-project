using Entities;

namespace Repositories
{
    public interface IOrdersReposetory
    {
        Task<Order> AddOrderReposetory(Order order);
        Task<Order> GetOrderByIdReposetory(int id);
        Task<IEnumerable<OrdersItem>> GetOrderItemsReposetory(int orderId);
        Task UpdateStatusReposetory(int id ,Order order);
        Task<OrdersItem> CheckIfHasPlatformByPlatformID(int platformID);
        Task<OrdersItem?> CheckIfHasProductByProductID(int ProductsId);
    }
}