using ApiEmployee2.Models;

namespace ApiEmployee2.Repositories
{
    public interface IEmpRepository
    {
        Task<IEnumerable<Employee>> Search(string name);
        Task<IEnumerable<Employee>> Get();
        Task<Employee> Get(int employeeId);
        Task<Employee> GetEmployeeByEmail(string email);
        Task<Employee> Create(Employee employee);
        Task<Employee> Update(Employee employee);
        Task Delete(int employeeId);
    }
}
