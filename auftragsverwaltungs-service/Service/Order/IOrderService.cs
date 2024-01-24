
using auftragsverwaltung_service.Model.Entities.Dto;

namespace auftragsverwaltung_service.Controllers.Order;

public interface IOrderService
{
    Task<OrderDto> CreateOrder(OrderDto orderDto);
    Task DeleteOrder(Guid id);
    Task<OrderDto> GetOrderById(Guid id);
    Task<OrderDto> UpdateOrder(Guid id, OrderDto orderDto);
    Task<IEnumerable<OrderDto>> GetAllOrders();
}