using auftragsverwaltung_service.Model.Entities.Dto;
using auftragsverwaltung_service.Model.Repository.Order;
using AutoMapper;

namespace auftragsverwaltung_service.Controllers.Order;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public OrderService(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }
    public async Task<OrderDto> CreateOrder(OrderDto orderDto)
    {
        var order = _mapper.Map<Model.Entities.Order>(orderDto);
        order = await _orderRepository.CreateOrder(order);
        return _mapper.Map<OrderDto>(order);
    }

    public async Task DeleteOrder(Guid id)
    {
        var order = await _orderRepository.GetOrderById(id);
        await _orderRepository.DeleteOrder(order);
    }

    public async Task<IEnumerable<OrderDto>> GetAllOrders()
    {
        return _mapper.Map<IEnumerable<OrderDto>>(await _orderRepository.GetAllOrders());
    }

    public async Task<OrderDto> GetOrderById(Guid id)
    {
        var order = await _orderRepository.GetOrderById(id);
        return _mapper.Map<OrderDto>(order);
    }

    public async Task<OrderDto> UpdateOrder(Guid id, OrderDto orderDto)
    {
        var order = _mapper.Map<Model.Entities.Order>(orderDto);
        var orderFormDb = await _orderRepository.GetOrderById(id);
        if(orderFormDb == null)
        {
            throw new ArgumentException("Order: " + id + " not found");
        }
        var updatedOrder = await _orderRepository.UpdateOrder(order);
        return _mapper.Map<OrderDto>(updatedOrder);
    }
}