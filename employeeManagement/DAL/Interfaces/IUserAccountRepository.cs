using employeeManagement.Models;

namespace employeeManagement.DAL.Interfaces
{
    public interface IUserAccountRepository
    {
        UserAccount GetUserAccount(UserAccount user);
        void Delete(int id);
        void Create(UserAccount user);
    }
}
