using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Category
    {
        public Category()
        {
        }

        [Key]
        public int Id { get; set; }

        [Display(Name="Category Name")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
