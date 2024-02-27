using System.ComponentModel.DataAnnotations;

namespace TestCoreAPP.Models
{
    public class Categories
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public ICollection<Item>? Items { get; set; }    
    }
}
