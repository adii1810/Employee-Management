using employeeManagement.Models;

namespace employeeManagement.DAL.Interfaces
{
    public interface IDocumentRepository
    {
        IEnumerable<Document> GetDocumentsByEmployee(int employeeId);
        Document GetById(int id);
        void Add(Document document);
        void Delete(int id);
    }
}
