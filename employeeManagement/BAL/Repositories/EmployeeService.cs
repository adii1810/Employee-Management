using employeeManagement.BAL.Interfaces;
using employeeManagement.DAL.Interfaces;
using employeeManagement.Models;

namespace employeeManagement.BAL.Repositories
{
    public class EmployeeService: IEmployeeService
        {
            private readonly IEmployeeRepository _repository;
            public EmployeeService(IEmployeeRepository repository) => _repository = repository;

            public IEnumerable<Employee> GetAllEmployees() => _repository.GetAll();
            public Employee GetEmployeeById(int id) => _repository.GetById(id);
            public int CreateEmployee(Employee emp) => _repository.Add(emp);
            public void UpdateEmployee(Employee emp) => _repository.Update(emp);
            public void DeleteEmployee(int id) => _repository.Delete(id);
        }
}
