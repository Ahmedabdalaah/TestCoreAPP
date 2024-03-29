﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace TestCoreAPP.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public string? imagePath { get; set; }
        [NotMapped]
        public IFormFile clientFile {  get; set; }   
        [Required]  
        [ForeignKey("categories")]
        [DisplayName ("Category")]
        public int category {  get; set; }
        public Categories? categories { get; set; } 
    }
}
