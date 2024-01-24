using auftragsverwaltung_service.Model.Entities.Dto;
using auftragsverwaltung_service.Service.Customer;
using Microsoft.AspNetCore.Mvc;

namespace auftragsverwaltungs_service.Controller;

[ApiController]
[Route("api/customers")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet()]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAllCustomers()
    {
        var customers = await _customerService.GetAllCustomers();
        return Ok(customers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerDto>> GetCustomerById([FromRoute()] Guid id)
    {
        var customer = await _customerService.GetCustomerById(id);
        return Ok(customer);
    }

    [HttpPost()]
    public async Task<ActionResult<CustomerDto>> CreateCustomer([FromBody] CustomerDto customerDto)
    {
        var customer = await _customerService.CreateCustomer(customerDto);
        return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id }, customer);
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<CustomerDto>> UpdateCustomer([FromRoute] Guid id, [FromBody] CustomerDto customerDto)
    {
        var customer = await _customerService.UpdateCustomer(id, customerDto);
        return Ok(customer);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCustomer([FromRoute] Guid id)
    {
        await _customerService.DeleteCustomer(id);
        return NoContent();
    }
}