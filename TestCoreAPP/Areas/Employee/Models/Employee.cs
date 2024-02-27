using System.ComponentModel.DataAnnotations;

namespace TestCoreAPP.Areas.Employee.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }    
        public string? Phone { get; set; }   
        public string? Email { get; set; }   
        public int? Age { get; set; }   
        public int? Salary { get; set; }    

    }
}
