using ApiEmployee2.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiEmployee2.Repositories
{
    public class EmployeeRepository : IEmpRepository
    {
        private readonly EmployeeContext _context;
        public EmployeeRepository(EmployeeContext context)
        {
            _context = context;
        }
        public async Task<Employee> Create(Employee employee)
        {
            _context.employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task Delete(int employeeId)
        {
            var employeeToDelete = await _context.employees.FindAsync(employeeId);
            _context.employees.Remove(employeeToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> Get()
        {
            return await _context.employees.ToListAsync();
        }

        public async Task<Employee> Get(int employeeId)
        {
            return await _context.employees.FindAsync(employeeId);
        }

        public async Task<Employee> GetEmployeeByEmail(string email)
        {
            return await _context.employees.FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task<IEnumerable<Employee>> Search(string name)
        {
            IQueryable<Employee> query = _context.employees;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.FirstName.Contains(name)
                            || e.LastName.Contains(name));
            }
            return await query.ToListAsync();
        }

        public async Task<Employee> Update(Employee employee)
        {
            var result = await _context.employees
                .FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);

            if (result != null)
            {
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.Email = employee.Email;
                result.DateOfBrith = employee.DateOfBrith;
                result.Gender = employee.Gender;
                if (employee.DepartmentId != 0)
                {
                    result.DepartmentId = employee.DepartmentId;
                }
                else if (employee.Department != null)
                {
                    result.DepartmentId = employee.Department.DepartmentId;
                }
                result.PhotoPath = employee.PhotoPath;

                await _context.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}
