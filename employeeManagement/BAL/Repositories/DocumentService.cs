using employeeManagement.BAL.Interfaces;
using employeeManagement.DAL.Interfaces;
using employeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace employeeManagement.BAL.Repositories
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _repository;

        public DocumentService(IDocumentRepository repository) => _repository = repository;

        public IEnumerable<Document> GetDocumentsByEmployee(int employeeId)
            => _repository.GetDocumentsByEmployee(employeeId);

        public Document GetById(int id) => _repository.GetById(id);

        public async Task<bool> UploadAsync(IFormFile file, int employeeId)
        {
            if (file == null || file.Length == 0 || Path.GetExtension(file.FileName).ToLower() != ".pdf")
                return false;

            var filePath = Path.Combine("wwwroot/uploads", file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var document = new Document
            {
                FileName = file.FileName,
                FilePath = "/uploads/" + file.FileName,
                EmployeeId = employeeId
            };
            _repository.Add(document);
            return true;
        }

        public void Delete(int id)
        {
            var doc = _repository.GetById(id);
            if (doc != null)
            {
                var path = Path.Combine("wwwroot", doc.FilePath.TrimStart('/'));
                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);

                _repository.Delete(id);
            }
        }
    }
}
