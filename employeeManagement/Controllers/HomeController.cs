using System.Diagnostics;
using employeeManagement.BAL.Interfaces;
using employeeManagement.DBContext;
using employeeManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace employeeManagement.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IEmployeeService _employee;
        public HomeController(IEmployeeService employee)
        {
            _employee = employee;
        }

        public IActionResult Index()
        {
            if (User.Identities.ToList()[0].IsAuthenticated)
            {
                var role = User.IsInRole("admin") ? "admin" : "User";
                HttpContext.Session.SetString("Role", role);
                HttpContext.Session.SetInt32("UserId", Convert.ToInt32(User.Claims.ToArray()[2].Value));
            }
            if (User.IsInRole("admin"))
            {
                return RedirectToAction("Index", "Employee");
            }

            if (User.IsInRole("user"))
            {
                int employeeId = int.Parse(User.FindFirst("EmployeeId").Value);
                var employee = _employee.GetEmployeeById(employeeId);
                return View("UserProfile", employee);
            }

            return RedirectToAction("Login", "Account");
        }
    }
}
