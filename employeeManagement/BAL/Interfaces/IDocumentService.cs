using employeeManagement.Models;

namespace employeeManagement.BAL.Interfaces
{
    public interface IDocumentService
    {
        IEnumerable<Document> GetDocumentsByEmployee(int employeeId);
        Document GetById(int id);
        Task<bool> UploadAsync(IFormFile file, int employeeId);
        void Delete(int id);
    }
}
