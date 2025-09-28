using employeeManagement.BAL.Interfaces;
using employeeManagement.DAL.Interfaces;
using employeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace employeeManagement.BAL.Repositories
{
    public class UserAccountService:IUserAccountService
    {
        private readonly IUserAccountRepository _repository;
        public UserAccountService(IUserAccountRepository repository) => _repository = repository;

        public UserAccount GetUserAccount(UserAccount user)
        {
            return _repository.GetUserAccount(user);
        }
        public void CreateUserAccount(UserAccount user)
        {
           _repository.Create(user);
        }
        public void DeleteUserAccount(int id) => _repository.Delete(id);
    }
}
