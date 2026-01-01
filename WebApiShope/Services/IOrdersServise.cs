using DTO;

namespace Services
{
    public interface IOrdersServise
    {
        Task<Resulte<FullOrderDTO>> AddOrderServise(OrdersDTO dto);
        Task<FullOrderDTO> GetByIdOrderServise(int id);
        Task<Resulte<IEnumerable<OrderItemDTO>>> GetOrderItemsServise(int orderId);
        Task<Resulte<FullOrderDTO>> UpdateStatusServise(int id, FullOrderDTO order);
    }
}