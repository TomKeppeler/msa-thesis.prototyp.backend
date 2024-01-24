using auftragsverwaltungs_service.Model.Entities.Dto;

namespace auftragsverwaltungs_service.Service.Order;

public interface IOrderService
{
    Task<OrderDto> CreateOrder(OrderDto orderDto);
    Task DeleteOrder(Guid id);
    Task<OrderDto> GetOrderById(Guid id);
    Task<OrderDto> UpdateOrder(Guid id, OrderDto orderDto);
    Task<IEnumerable<OrderDto>> GetAllOrders();
}