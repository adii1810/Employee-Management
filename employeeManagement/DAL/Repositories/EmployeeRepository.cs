using employeeManagement.DAL.Interfaces;
using employeeManagement.DBContext;
using employeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace employeeManagement.DAL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;
        public EmployeeRepository(AppDbContext context) => _context = context;

        public IEnumerable<Employee> GetAll()
        {

            var emplopyees = _context.Employees
                             .Where(e => _context.UserAccounts
                                 .Any(u => u.EmployeeId == e.Id && u.Role == "user")).ToList();
            return emplopyees;
        }

        public Employee GetById(int id) => _context.Employees.Include(e => e.Documents).FirstOrDefault(e => e.Id == id);

        public int Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee.Id;
        }

        public void Update(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var emp = _context.Employees.Find(id);
            if (emp != null)
            {
                _context.Employees.Remove(emp);
                _context.SaveChanges();
            }
        }
    }
}
