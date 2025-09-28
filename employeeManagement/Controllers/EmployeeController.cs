using employeeManagement.BAL.Interfaces;
using employeeManagement.DBContext;
using employeeManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace employeeManagement.Controllers
{
    [Authorize(Policy = "AdminOnly")]
    public class EmployeeController : Controller
    {
        private readonly IDocumentService _document;
        private readonly IEmployeeService _employee;
        private readonly IUserAccountService _userAccount;

        public EmployeeController(IDocumentService document, IEmployeeService employee, IUserAccountService userAccount)
        {
            _document = document;
            _employee = employee;
            _userAccount = userAccount;
        }

        public async Task<IActionResult> Index()
        {
            var usersOnly = _employee.GetAllEmployees();
            return View(usersOnly);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee, string username, string password)
        {
            if (ModelState.IsValid)
            {
               var empId =  _employee.CreateEmployee(employee);

                // Create a UserAccount for the employee
                var user = new UserAccount
                {
                    Username = username,
                    Password = password,
                    Role = "user",
                    EmployeeId = empId
                };

               _userAccount.CreateUserAccount(user);

                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        public IActionResult Edit(int id)
        {
            var emp = _employee.GetEmployeeById(id);
            return View(emp);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employee.UpdateEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        public IActionResult Delete(int id)
        {
            var emp = _employee.GetEmployeeById(id);
            return View(emp);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _userAccount.DeleteUserAccount(id);
            _employee.DeleteEmployee(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
