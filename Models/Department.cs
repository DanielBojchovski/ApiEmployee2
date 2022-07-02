using System.ComponentModel.DataAnnotations;

namespace ApiEmployee2.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Department name must contain at least 2 characters. / Името на секторот мора да содржи барем две букви.")]
        public string DepartmentName { get; set; }
    }
}
