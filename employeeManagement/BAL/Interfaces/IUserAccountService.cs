using employeeManagement.Models;

namespace employeeManagement.BAL.Interfaces
{
    public interface IUserAccountService
    {
        UserAccount GetUserAccount(UserAccount user);
        void CreateUserAccount(UserAccount user);
        void DeleteUserAccount(int id);
    }
}
