using auftragsverwaltungs_service.Model.Entities.Dto;
using auftragsverwaltungs_service.Service.Order;
using Microsoft.AspNetCore.Mvc;

namespace auftragsverwaltungs_service.Controller;

[ApiController]
[Route("api/orders")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        this._orderService = orderService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderDto>>> GetAllOrders()
    {
        var activities = await _orderService.GetAllOrders();
        return Ok(activities);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OrderDto>> GetOrderById([FromRoute()] Guid id)
    {
        var activity = await _orderService.GetOrderById(id);
        return Ok(activity);
    }

    [HttpPost]
    public async Task<ActionResult<OrderDto>> CreateOrder([FromBody] OrderDto orderDto)
    {
        var activity = await _orderService.CreateOrder(orderDto);
        return Ok(activity);
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<OrderDto>> UpdateOrder([FromRoute()] Guid id, [FromBody] OrderDto orderDto)
    {
        var activity = await _orderService.UpdateOrder(id, orderDto);
        return Ok(activity);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteOrder([FromRoute()] Guid id)
    {
        await _orderService.DeleteOrder(id);
        return Ok();
    }
}