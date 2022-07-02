using System.ComponentModel.DataAnnotations;

namespace ApiEmployee2.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "FirstName must contain at least 2 characters./ Името мора да содржи барем две букви.")]
        [MaxLength(50, ErrorMessage = "FirstName can't contain more than 50 characters./ Името не смее да содржи повеќе од 50 букви.")]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "LastName must contain at least 2 characters./ Презимето мора да содржи барем две букви.")]
        [MaxLength(50, ErrorMessage = "LastName can't contain more than 50 characters./ Презимето не смее да содржи повеќе од 50 букви.")]
        public string LastName { get; set; }
        [Required]
        [Range(18000, 617500, ErrorMessage = "Salary must be in range between 18000 and 617500 denars./ Платата мора да биде во опсег помеѓу 18000 и 617500 денари.")]
        public decimal Salary { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime DateOfBrith { get; set; }
        public Gender? Gender { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        public string? PhotoPath { get; set; }
        [Required]
        public Department Department { get; set; }
    }
}
