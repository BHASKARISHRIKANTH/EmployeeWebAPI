using System.ComponentModel.DataAnnotations;

namespace EmployeeWebAPI.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Employee Name is required.")]
        [StringLength(50, ErrorMessage = "Employee Name should not exceed 50 characters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Employee Email is required.")]
        [StringLength(50, ErrorMessage = "Employee Email not in proper manner")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
