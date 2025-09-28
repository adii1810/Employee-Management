using employeeManagement.DAL.Interfaces;
using employeeManagement.DBContext;
using employeeManagement.Models;

namespace employeeManagement.DAL.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly AppDbContext _context;

        public DocumentRepository(AppDbContext context) => _context = context;

        public IEnumerable<Document> GetDocumentsByEmployee(int employeeId)
            => _context.Documents.Where(d => d.EmployeeId == employeeId).ToList();

        public Document GetById(int id)
            => _context.Documents.Find(id);

        public void Add(Document document)
        {
            _context.Documents.Add(document);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var doc = _context.Documents.Find(id);
            if (doc != null)
            {
                _context.Documents.Remove(doc);
                _context.SaveChanges();
            }
        }
    }
}
