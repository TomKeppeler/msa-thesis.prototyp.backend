using auftragsverwaltung_service.Model.Repository.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace auftragsverwaltung_service.Model.Repository.Customer;

public class CustomerRepository : RepositoryBase, ICustomerRepository
{

    public CustomerRepository(AuftragsverwaltungsContext context) : base(context)
    {
    }

    public async Task<Entities.Customer> CreateCustomer(Entities.Customer customer)
    {
        await Context.Customer.AddAsync(customer);
        await SaveAsync();
        return customer;
    }

    public async Task DeleteCustomer(Entities.Customer customer)
    {
        Context.Customer.Remove(customer);
        await SaveAsync();
    }

    public async Task<IEnumerable<Entities.Customer>> GetAllCustomers()
    {
        return await Context.Customer.AsNoTracking().ToListAsync();
    }

    public async Task<Entities.Customer> GetCustomerById(Guid id)
    {
        return await Context.Customer.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Entities.Customer> UpdateCustomer(Entities.Customer customer)
    {
        Context.Customer.Update(customer);
        await SaveAsync();
        return customer;
    }
}