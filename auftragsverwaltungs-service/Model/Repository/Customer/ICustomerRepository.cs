namespace auftragsverwaltungs_service.Model.Repository.Customer;

public interface ICustomerRepository
{
    Task<Entities.Customer> CreateCustomer(Entities.Customer customer);
    Task DeleteCustomer(Entities.Customer customer);
    Task<IEnumerable<Entities.Customer>> GetAllCustomers();
    Task<Entities.Customer> GetCustomerById(Guid id);
    Task<Entities.Customer> UpdateCustomer(Entities.Customer customer);
}