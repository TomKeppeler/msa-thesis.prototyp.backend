using System.Collections;
using auftragsverwaltung_service.Model.Entities.Dto;
using auftragsverwaltung_service.Model.Repository.Customer;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace auftragsverwaltung_service.Service.Customer;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mappingProfile;

    public CustomerService(ICustomerRepository customerRepository, IMapper mappingProfile)
    {
        _customerRepository = customerRepository;
        _mappingProfile = mappingProfile;
    }

    public async Task<CustomerDto> CreateCustomer(CustomerDto customerDto)
    {
        var customer = _mappingProfile.Map<Model.Entities.Customer>(customerDto);
        customer = await _customerRepository.CreateCustomer(customer);
        return _mappingProfile.Map<CustomerDto>(customer);
    }


    public async Task DeleteCustomer(Guid id)
    {
        var customer = await _customerRepository.GetCustomerById(id);
        await _customerRepository.DeleteCustomer(customer);
    }

    public async Task<IEnumerable<CustomerDto>> GetAllCustomers()
    {
        return _mappingProfile.Map<IEnumerable<CustomerDto>>(await _customerRepository.GetAllCustomers());
    }

    public Task<CustomerDto> GetCustomerById(Guid id)
    {
        var customer = _customerRepository.GetCustomerById(id);
        return Task.FromResult(_mappingProfile.Map<CustomerDto>(customer));
    }

    public async Task<CustomerDto> UpdateCustomer(Guid id, CustomerDto customerDto)
    {
        var customer = _mappingProfile.Map<Model.Entities.Customer>(customerDto);
        var customerFromDb = _customerRepository.GetCustomerById(id);
        if (customerFromDb == null)
        {
            throw new ArgumentException("Customer: " + id + " not found");
        }
        var updatedCustomer = await _customerRepository.UpdateCustomer(customer);
        return _mappingProfile.Map<CustomerDto>(updatedCustomer);
    }
}