using buchhaltungs_service.Model.Entities.Dto;

namespace buchhaltungs_service.Model.Repository.Employee
{
    public interface IEmployeeRepository
    {
        Task<Entities.Employee> CreateEmployee(Entities.Employee employee);
        Task DeleteEmployee(Guid id);
        Task<IEnumerable<Entities.Employee>> GetAllEmployees();
        Task<Entities.Employee> GetEmployeeById(Guid id);
        Task<Entities.Employee> UpdateEmployee(Guid id, Entities.Employee employee);
    }
}
