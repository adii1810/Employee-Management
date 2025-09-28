using employeeManagement.DBContext;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using employeeManagement.Models;
using employeeManagement.BAL.Interfaces;

namespace employeeManagement.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserAccountService _userAccount;
        public AccountController(IUserAccountService userAccount)
        {
            _userAccount = userAccount;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(UserAccount model)
        {
            var user = _userAccount.GetUserAccount(model);

            if (user == null)
            {
                TempData["Error"] = "Invalid username or password.";
                return View(model);
            }

            HttpContext.Session.SetInt32("UserId", user.Id);
            HttpContext.Session.SetString("Role", user.Role);

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role),
            new Claim("UserId", user.Id.ToString()),
            new Claim("EmployeeId", user.EmployeeId?.ToString() ?? string.Empty)
        };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.SetString("Role", "");
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        public IActionResult AccessDenied() => View();
    }
}
