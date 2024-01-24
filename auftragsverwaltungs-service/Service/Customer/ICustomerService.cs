using auftragsverwaltung_service.Model.Entities.Dto;
using Microsoft.AspNetCore.Mvc;

namespace auftragsverwaltung_service.Service.Customer;

public interface ICustomerService
{
    Task<CustomerDto> CreateCustomer(CustomerDto customerDto);
    Task DeleteCustomer(Guid id);
    Task<IEnumerable<CustomerDto>> GetAllCustomers();
    Task<CustomerDto> GetCustomerById(Guid id);
    Task<CustomerDto> UpdateCustomer(Guid id, CustomerDto customerDto);
}