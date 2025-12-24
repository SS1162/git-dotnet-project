using DTO;

namespace Services
{
    public interface IOrdersServise
    {
        Task<FullOrderDTO> AddOrderServise(OrdersDTO dto);
        Task<FullOrderDTO> GetByIdOrderServise(int id);
        Task<IEnumerable<OrderItemDTO>> GetOrderItemsServise(int orderId);
        Task UpdateStatusServise(int id , FullOrderDTO order);
    }
}