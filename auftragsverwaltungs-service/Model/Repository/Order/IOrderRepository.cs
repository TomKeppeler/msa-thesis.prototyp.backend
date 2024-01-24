namespace auftragsverwaltungs_service.Model.Repository.Order;

public interface IOrderRepository
{
    Task<Entities.Order> CreateOrder(Entities.Order order);
    Task DeleteOrder(Entities.Order order);
    Task<IEnumerable<Entities.Order>> GetAllOrders();
    Task<Entities.Order> GetOrderById(Guid id);
    Task<Entities.Order> UpdateOrder(Entities.Order order);
}