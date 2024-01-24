using buchhaltungs_service.Model.Entities.Dto;
using buchhaltungs_service.Service.Employee;
using Microsoft.AspNetCore.Mvc;

namespace buchhaltungs_service.Controller
{

    [ApiController()]
    [Route("api/employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetAllEmployees()
        {
            var employees = await _employeeService.GetAllEmployees();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployeeById([FromRoute()] Guid id)
        {
            var employee = await this._employeeService.GetEmployeeById(id);
            return Ok(employee);
        }

        [HttpPost()]
        public async Task<ActionResult<EmployeeDto>> CreateEmployee([FromBody] EmployeeDto employeeDto)
        {
            var employee = await this._employeeService.CreateEmployee(employeeDto);
            return Ok(employee);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<EmployeeDto>> UpdateEmployee([FromRoute()] Guid id, [FromBody] EmployeeDto employeeDto)
        {
            var employee = await this._employeeService.UpdateEmployee(id, employeeDto);
            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee([FromRoute()] Guid id)
        {
            await this._employeeService.DeleteEmployee(id);
            return Ok();
        }
    }
}
