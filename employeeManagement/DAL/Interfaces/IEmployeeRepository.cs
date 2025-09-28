using employeeManagement.Models;

namespace employeeManagement.DAL.Interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
        int Add(Employee employee);
        void Update(Employee employee);
        void Delete(int id);
    }
}
