using employeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace employeeManagement.DBContext
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
    }
}
