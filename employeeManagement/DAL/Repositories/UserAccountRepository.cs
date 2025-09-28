using employeeManagement.DAL.Interfaces;
using employeeManagement.DBContext;
using employeeManagement.Models;

namespace employeeManagement.DAL.Repositories
{

    public class UserAccountRepository : IUserAccountRepository
    {
        private readonly AppDbContext _context;
        public UserAccountRepository(AppDbContext context) => _context = context;
        public void Delete(int id)
        {
            var userAccount = _context.UserAccounts.Find(id);

            if (userAccount != null)
            {
                _context.UserAccounts.Remove(userAccount);
                _context.SaveChanges();
            }
        }

        public UserAccount GetUserAccount(UserAccount user)
        {
            return _context.UserAccounts
        .FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
        }
        public void Create(UserAccount user)
        {
            _context.UserAccounts.Add(user);
            _context.SaveChanges();
        }
    }
}
