using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace employeeManagement.Models
{
    public class UserAccount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; } // Hash in production
        [Required]
        public string Role { get; set; } // Admin or User
        public int? EmployeeId { get; set; } // If role is User
        public Employee Employee { get; set; }
    }
}
