using employeeManagement.BAL.Interfaces;
using employeeManagement.BAL.Repositories;
using employeeManagement.DAL.Interfaces;
using employeeManagement.DBContext;
using employeeManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace employeeManagement.Controllers
{
    [Authorize]
    public class DocumentController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly IDocumentService _document;
        private readonly IEmployeeService _employee;

        public DocumentController(IWebHostEnvironment env, IDocumentService document, IEmployeeService employee)
        {
            _env = env;
            _document = document;
            _employee = employee;
        }

        [Authorize(Policy = "AdminOnly")]
        public Task<IActionResult> EmployeeDocs(int employeeId)
        {
            var employee = _employee.GetEmployeeById(employeeId);
           
            if (employee == null)
                return Task.FromResult<IActionResult>(NotFound());

            ViewBag.EmployeeId = employee.Id;
            ViewBag.EmployeeName = employee.Name;

            return Task.FromResult<IActionResult>(View(_document.GetDocumentsByEmployee(employee.Id)));
        }

        [HttpPost, Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> UploadByAdmin(IFormFile file, int employeeId)
        {
            var uploadDocument = await _document.UploadAsync(file, employeeId);

            if (!uploadDocument)
            {
                TempData["Error"] = "Only PDF files allowed.";
                return RedirectToAction("EmployeeDocs", new { employeeId });
            }           
            return RedirectToAction("EmployeeDocs", new { employeeId });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, int employeeId)
        {
            _document.Delete(id);
            return RedirectToAction("EmployeeDocs", new { employeeId });
        }

        [Authorize(Policy = "UserOnly")]
        public IActionResult MyDocuments()
        {
            var documents = _document.GetDocumentsByEmployee(int.Parse(User.FindFirst("EmployeeId").Value));
            return View(documents);
        }

        public IActionResult Download(int id)
        {
            var doc = _document.GetById(id);
            var path = Path.Combine(_env.WebRootPath, doc.FilePath.TrimStart('/'));
            return File(System.IO.File.ReadAllBytes(path), "application/octet-stream", doc.FileName);
        }
    }
}
