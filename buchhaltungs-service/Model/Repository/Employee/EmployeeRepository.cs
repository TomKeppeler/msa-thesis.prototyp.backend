using buchhaltungs_service.Model.Entities.Dto;
using buchhaltungs_service.Model.Repository.Common;
using Microsoft.EntityFrameworkCore;

namespace buchhaltungs_service.Model.Repository.Employee
{
    public class EmployeeRepository : RepositoryBase, IEmployeeRepository
    {
        public EmployeeRepository(BuchhaltungsContext context) : base(context)
        {
        }

        public async Task<Entities.Employee> CreateEmployee(Entities.Employee employee)
        {
            Context.Employee.Add(employee);
            await Context.SaveChangesAsync();
            return employee;
            
        }

        public async Task<IEnumerable<Entities.Employee>> GetAllEmployees()
        {
            return await Context.Employee.ToListAsync();
        }

        public async Task<Entities.Employee> GetEmployeeById(Guid id)
        {
            return await Context.Employee.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Entities.Employee> UpdateEmployee(Guid id, Entities.Employee employee)
        {
            Context.Employee.Update(employee);
            await Context.SaveChangesAsync();
            return employee;
        }

        public async Task DeleteEmployee(Guid id)
        {
            Entities.Employee employee = await Context.Employee.FirstOrDefaultAsync(e => e.Id == id);
            Context.Employee.Remove(employee);
            await Context.SaveChangesAsync();
        }
    }
}
