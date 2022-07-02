using ApiEmployee2.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiEmployee2.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly EmployeeContext _context;

        public DepartmentRepository(EmployeeContext context)
        {
            _context = context;
        }
        public async Task<Department> GetDepartment(int departmentId)
        {
            return await _context.departments.FirstOrDefaultAsync(d => d.DepartmentId == departmentId);
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _context.departments.ToListAsync();
        }
    }
}
