using AutoMapper;
using buchhaltungs_service.Model.Entities.Dto;
using buchhaltungs_service.Model.Repository.Employee;

namespace buchhaltungs_service.Service.Employee
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            this._employeeRepository = employeeRepository;
            this._mapper = mapper;
        }

        public async Task<EmployeeDto> CreateEmployee(EmployeeDto employeeDto)
        {
            Model.Entities.Employee employee = _mapper.Map<Model.Entities.Employee>(employeeDto);
            return _mapper.Map<EmployeeDto>(await _employeeRepository.CreateEmployee(employee));
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployees()
        {
            return _mapper.Map<IEnumerable<EmployeeDto>>(await _employeeRepository.GetAllEmployees());
        }
        public async Task<EmployeeDto> GetEmployeeById(Guid id)
        {
            return _mapper.Map<EmployeeDto>(await _employeeRepository.GetEmployeeById(id));
        }

        public async Task<EmployeeDto> UpdateEmployee(Guid id, EmployeeDto employeeDto)
        {
            Model.Entities.Employee employee = _mapper.Map<Model.Entities.Employee>(employeeDto);
            return _mapper.Map<EmployeeDto>(await _employeeRepository.UpdateEmployee(id, employee));
        }

        public async Task DeleteEmployee(Guid id)
        {
            await _employeeRepository.DeleteEmployee(id);
        }
    }
}
