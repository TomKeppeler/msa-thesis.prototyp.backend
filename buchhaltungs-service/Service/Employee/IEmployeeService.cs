using buchhaltungs_service.Model.Entities.Dto;

namespace buchhaltungs_service.Service.Employee
{
    public interface IEmployeeService
    {
        Task<EmployeeDto> CreateEmployee(EmployeeDto employeeDto);
        Task DeleteEmployee(Guid id);
        Task<IEnumerable<EmployeeDto>> GetAllEmployees();
        Task<EmployeeDto> GetEmployeeById(Guid id);
        Task<EmployeeDto> UpdateEmployee(Guid id, EmployeeDto employeeDto);
    }
}
