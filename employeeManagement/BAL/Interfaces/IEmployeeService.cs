using employeeManagement.Models;

namespace employeeManagement.BAL.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
        int CreateEmployee(Employee emp);
        void UpdateEmployee(Employee emp);
        void DeleteEmployee(int id);
    }
}
