using auftragsverwaltung_service.Model.Repository.Common;
using Microsoft.EntityFrameworkCore;

namespace auftragsverwaltung_service.Model.Repository.Order;

public class OrderRepository : RepositoryBase, IOrderRepository
{
    public OrderRepository(AuftragsverwaltungsContext context) : base(context)
    {
    }

    public async Task<Entities.Order> CreateOrder(Entities.Order order)
    {
        await Context.Order.AddAsync(order);
        await SaveAsync();
        return order;
    }

    public async Task DeleteOrder(Entities.Order order)
    {
        Context.Order.Remove(order);
        await SaveAsync();
    }

    public async Task<IEnumerable<Entities.Order>> GetAllOrders()
    {
        return await Context.Order.ToListAsync();
    }

    public async Task<Entities.Order> GetOrderById(Guid id)
    {
        return await Context.Order.FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<Entities.Order> UpdateOrder(Entities.Order order)
    {
        Context.Order.Update(order);
        await SaveAsync();
        return order;
    }
}